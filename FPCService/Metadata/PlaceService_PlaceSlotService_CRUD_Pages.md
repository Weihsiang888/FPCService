# Place 和 PlaceSlot 服務 CRUD 頁面實作說明

## 概述

本文件說明 PlaceService 和 PlaceSlotService 的 CRUD 頁面實作，採用事件驅動的自動更新機制，參考 MobileRobotService 的實作模式。

## 實作的服務與頁面

### PlaceService（場域服務）

#### 1. MainPlacePage.razor
- **路由**: `/place/main`
- **功能**: 場域主檔管理
- **欄位**:
  - PlaceUid (場域編號) - 主鍵
  - PlaceName (場域名稱)
  - PlaceId (場域ID)
  - Floor (樓層)
  - TaskUid (任務編號)
  - PlaceCompletedCount (完成數量)
  - ProcessTime (處理時間)
- **操作**: 新增、編輯、刪除

### PlaceSlotService（場域插槽服務）

#### 1. MainPlaceSlotPage.razor
- **路由**: `/placeslot/main`
- **功能**: 場域插槽主檔管理
- **欄位**:
  - PlaceSlotUid (插槽編號) - 主鍵
  - PlaceUid (場域編號)
  - PlaceSlotPoint (插槽點位)
  - PlaceSlotStatus (插槽狀態)
  - Floor (樓層)
  - TaskUid (任務編號)
- **操作**: 新增、編輯、刪除

#### 2. DetailPlaceSlotPage.razor
- **路由**: `/placeslot/detail`
- **功能**: 場域插槽事件明細
- **欄位**:
  - UID (自動編號) - 主鍵
  - PlaceSlotUid (插槽編號)
  - PlaceUid (場域編號)
  - PlaceSlotPoint (插槽點位)
  - PlaceSlotStatus (插槽狀態)
  - Floor (樓層)
  - TaskUid (任務編號)
  - OccurrenceTime (發生時間)
- **操作**: 新增、刪除

#### 3. QueuePlaceSlotPage.razor
- **路由**: `/placeslot/queue`
- **功能**: 場域插槽佇列管理
- **欄位**:
  - UID (自動編號) - 主鍵
  - QueueStatus (佇列狀態)
  - PlaceSlotUid (插槽編號)
  - Floor (樓層)
  - TaskUid (任務編號)
  - ProcessTime (處理時間)
  - CreateTime (建立時間)
  - CompleteTime (完成時間 - 可空)
- **操作**: 新增、編輯、刪除

#### 4. LogPlaceSlotPage.razor
- **路由**: `/placeslot/log`
- **功能**: 場域插槽紀錄
- **欄位**:
  - UID (自動編號) - 主鍵
  - PlaceSlotUid (插槽編號)
  - Floor (樓層)
  - TaskUid (任務編號)
  - Message (訊息)
  - ProcessTime (處理時間)
- **操作**: 新增（唯讀日誌）

## 事件驅動更新機制

### 架構說明

所有 Place 和 PlaceSlot 頁面都使用 `DataChangeNotificationService` 來實現自動更新。當 `PlaceService` 或 `PlaceSlotService` 進行資料處理（新增、修改、刪除）時，會主動通知頁面更新。

### DataChangeNotificationService 擴充

在 `FPCService/Services/DataChangeNotificationService.cs` 中新增了 Place 和 PlaceSlot 相關的事件：

```csharp
// Place 相關事件
public event Action? MainPlaceChanged;

// PlaceSlot 相關事件
public event Action? MainPlaceSlotChanged;
public event Action? DetailPlaceSlotChanged;
public event Action? QueuePlaceSlotChanged;
public event Action? LogPlaceSlotChanged;

// 通知方法 - Place
public void NotifyMainPlaceChanged() => MainPlaceChanged?.Invoke();

// 通知方法 - PlaceSlot
public void NotifyMainPlaceSlotChanged() => MainPlaceSlotChanged?.Invoke();
public void NotifyDetailPlaceSlotChanged() => DetailPlaceSlotChanged?.Invoke();
public void NotifyQueuePlaceSlotChanged() => QueuePlaceSlotChanged?.Invoke();
public void NotifyLogPlaceSlotChanged() => LogPlaceSlotChanged?.Invoke();
```

### PlaceService 整合

`PlaceService` 注入 `DataChangeNotificationService` 並在 CRUD 操作後觸發通知：

```csharp
public class PlaceService
{
	private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
	private readonly DataChangeNotificationService _notificationService;

	public PlaceService(
		IDbContextFactory<DSDBContext> dbContextFactory,
		DataChangeNotificationService notificationService)
	{
		_dbContextFactory = dbContextFactory;
		_notificationService = notificationService;
	}

	// 範例: MainPlace 新增
	public async Task<bool> InsertMainPlaceAsync(MainPlace entity)
	{
		await using var db = await _dbContextFactory.CreateDbContextAsync();
		db.MainPlace.Add(entity);
		var result = await db.SaveChangesAsync() > 0;
		if (result) _notificationService.NotifyMainPlaceChanged();
		return result;
	}
}
```

### PlaceSlotService 整合

`PlaceSlotService` 同樣注入 `DataChangeNotificationService` 並針對不同資料表觸發對應的通知：

```csharp
public class PlaceSlotService
{
	private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
	private readonly DataChangeNotificationService _notificationService;

	public PlaceSlotService(
		IDbContextFactory<DSDBContext> dbContextFactory,
		DataChangeNotificationService notificationService)
	{
		_dbContextFactory = dbContextFactory;
		_notificationService = notificationService;
	}

	// MainPlaceSlot CRUD 操作後通知 MainPlaceSlotChanged
	// DetailPlaceSlot CRUD 操作後通知 DetailPlaceSlotChanged
	// QueuePlaceSlot CRUD 操作後通知 QueuePlaceSlotChanged
	// LogPlaceSlot CRUD 操作後通知 LogPlaceSlotChanged
}
```

### 頁面訂閱模式

所有頁面遵循相同的訂閱模式：

```csharp
@rendermode InteractiveServer
@inject PlaceService PlaceService  // 或 PlaceSlotService
@inject DataChangeNotificationService NotificationService
@implements IDisposable

@code {
	protected override async Task OnInitializedAsync()
	{
		await LoadData();
		// 訂閱對應的事件
		NotificationService.MainPlaceChanged += OnDataChanged;
	}

	private async Task LoadData()
	{
		// 載入資料
		places = await PlaceService.GetMainPlaceAsync();
	}

	private async void OnDataChanged()
	{
		// 事件觸發時，透過 InvokeAsync 重新載入資料
		await InvokeAsync(async () =>
		{
			await LoadData();
			StateHasChanged();
		});
	}

	public void Dispose()
	{
		// 取消訂閱避免記憶體洩漏
		NotificationService.MainPlaceChanged -= OnDataChanged;
	}

	private async Task SavePlace()
	{
		// CRUD 操作後不需手動呼叫 LoadData()
		// 通知機制會自動觸發更新
		await PlaceService.InsertMainPlaceAsync(editModel);
		isPopupVisible = false;
	}
}
```

## 關鍵特性

### 1. 自動更新
- 任何使用者的 CRUD 操作都會自動更新所有開啟的頁面
- 不需要手動重新整理或重新載入資料

### 2. 執行緒安全
- 使用 `InvokeAsync` 確保 UI 更新在正確的執行緒上進行
- 呼叫 `StateHasChanged()` 強制 Blazor 重新渲染

### 3. 資源管理
- 實作 `IDisposable` 介面
- 在元件銷毀時取消事件訂閱，避免記憶體洩漏

### 4. 互動式渲染
- 使用 `@rendermode InteractiveServer`
- 支援即時互動和事件處理

## UI 元件

所有頁面都使用 DevExpress Blazor 元件：

- **DxGrid**: 資料表格顯示
  - 支援分頁 (`PageSize="20"`)
  - 支援篩選 (`ShowFilterRow="true"`)
  - 自訂欄位顯示格式

- **Modal 彈出視窗**: 新增/編輯表單
  - Bootstrap 5 樣式
  - 表單欄位驗證
  - 取消/儲存按鈕

## 資料驗證

所有頁面在儲存時會：
1. 自動設定時間戳記欄位 (`ProcessTime`, `OccurrenceTime`, `CreateTime`)
2. 初始化必填欄位的預設值
3. 使用 `JSRuntime` 顯示刪除確認對話框

## 服務與頁面對應關係

### PlaceService
- **服務檔案**: `FPCService/Services/Place/PlaceService.cs`
- **頁面目錄**: `FPCService/Components/Pages/PlaceService/`
- **實體類別**: `MainPlace`

### PlaceSlotService
- **服務檔案**: `FPCService/Services/Place/PlaceSlotService.cs`
- **頁面目錄**: `FPCService/Components/Pages/PlaceSlotService/`
- **實體類別**: `MainPlaceSlot`, `DetailPlaceSlot`, `QueuePlaceSlot`, `LogPlaceSlot`

## 與其他服務的關聯

### 相關服務
本實作與以下服務使用相同的架構模式：
- MobileRobotService（參考實作）
- PackagingService

### 通知服務整合
所有領域服務（Domain Services）共用同一個 `DataChangeNotificationService` 單例，確保：
- 統一的事件管理
- 記憶體效率
- 跨服務的一致性

## 維護建議

1. **一致性**: 所有新的 Service CRUD 頁面應遵循相同的模式
2. **命名規範**: 
   - 事件名稱應與資料表名稱對應
   - Service 檔案應放在對應的服務目錄下
   - 頁面應放在 `Components/Pages/xxxService/` 目錄
3. **錯誤處理**: 可考慮加入錯誤訊息顯示機制
4. **權限控制**: 未來可在各操作按鈕加入權限檢查
5. **關聯資料**: Place 和 PlaceSlot 之間有關聯性（PlaceUid），未來可考慮加入下拉選單或聯動查詢

## 參考實作

- 參考 MobileRobotService 和 PackagingService 的頁面實作
- 位於 `FPCService\Components\Pages\MobileRobotService\` 和 `FPCService\Components\Pages\PackagingService\` 目錄
- 使用相同的通知機制和訂閱模式

## 測試建議

1. 開啟多個瀏覽器視窗測試同步更新
2. 測試 Place 和 PlaceSlot 頁面的獨立操作
3. 測試新增、編輯、刪除操作的即時反應
4. 檢查元件銷毀時是否正確取消訂閱
5. 驗證所有欄位的資料類型和格式
6. 測試 PlaceUid 在 Place 和 PlaceSlot 之間的關聯正確性

## 已知限制

1. Log 頁面目前只支援新增，不支援刪除操作
2. 時間欄位都在儲存時自動設定為當前時間
3. UID 欄位由資料庫自動產生，不可手動編輯
4. PlaceSlotStatus 目前使用文字輸入，未來可考慮改為下拉選單
5. PlaceUid 關聯欄位未實作外鍵驗證或下拉選擇功能

## 未來改進建議

1. **關聯資料選擇**: 在 PlaceSlot 頁面中，PlaceUid 可以改為下拉選單，從 MainPlace 載入選項
2. **狀態列舉**: PlaceSlotStatus 和 QueueStatus 可以定義為列舉類型
3. **批次操作**: 可加入批次刪除或批次更新功能
4. **資料匯出**: 可加入 Excel 或 CSV 匯出功能
5. **進階篩選**: 可加入更多篩選條件和搜尋功能
6. **分頁大小調整**: 讓使用者可以動態調整每頁顯示的資料筆數
