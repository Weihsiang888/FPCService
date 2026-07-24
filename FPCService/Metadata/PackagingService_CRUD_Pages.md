# PackagingService CRUD 頁面實作說明

## 概述

本文件說明 PackagingService 的 CRUD 頁面實作，採用事件驅動的自動更新機制，參考 MobileRobotService 的實作模式。

## 實作的頁面

### 1. MainPackagingPage.razor
- **路由**: `/packaging/main`
- **功能**: 包裝主檔管理
- **欄位**:
  - PackagingUid (包裝編號)
  - PackagingPoint (包裝點位)
  - Floor (樓層)
  - TaskUid (任務編號)
  - ProcessTime (處理時間)
- **操作**: 新增、編輯、刪除

### 2. DetailPackagingPage.razor
- **路由**: `/packaging/detail`
- **功能**: 包裝事件明細
- **欄位**:
  - UID (自動編號)
  - PackagingUid (包裝編號)
  - PackagingPoint (包裝點位)
  - Floor (樓層)
  - TaskUid (任務編號)
  - OccurrenceTime (發生時間)
- **操作**: 新增、刪除

### 3. QueuePackagingPage.razor
- **路由**: `/packaging/queue`
- **功能**: 包裝佇列管理
- **欄位**:
  - UID (自動編號)
  - QueueStatus (佇列狀態)
  - PackagingUid (包裝編號)
  - Floor (樓層)
  - TaskUid (任務編號)
  - ProcessTime (處理時間)
  - CreateTime (建立時間)
  - CompleteTime (完成時間)
- **操作**: 新增、編輯、刪除

### 4. LogPackagingPage.razor
- **路由**: `/packaging/log`
- **功能**: 包裝紀錄
- **欄位**:
  - UID (自動編號)
  - PackagingUid (包裝編號)
  - Floor (樓層)
  - TaskUid (任務編號)
  - Message (訊息)
  - ProcessTime (處理時間)
- **操作**: 新增

## 事件驅動更新機制

### 架構說明

所有 Packaging 頁面都使用 `DataChangeNotificationService` 來實現自動更新，當 `PackagingService` 進行資料處理（新增、修改、刪除）時，會主動通知頁面更新。

### DataChangeNotificationService 擴充

在 `FPCService/Services/DataChangeNotificationService.cs` 中新增了 Packaging 相關的事件:

```csharp
// Packaging 相關事件
public event Action? MainPackagingChanged;
public event Action? DetailPackagingChanged;
public event Action? QueuePackagingChanged;
public event Action? LogPackagingChanged;

// 通知方法 - Packaging
public void NotifyMainPackagingChanged() => MainPackagingChanged?.Invoke();
public void NotifyDetailPackagingChanged() => DetailPackagingChanged?.Invoke();
public void NotifyQueuePackagingChanged() => QueuePackagingChanged?.Invoke();
public void NotifyLogPackagingChanged() => LogPackagingChanged?.Invoke();
```

### PackagingService 整合

`PackagingService` 注入 `DataChangeNotificationService` 並在 CRUD 操作後觸發通知:

```csharp
public class PackagingService
{
	private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
	private readonly DataChangeNotificationService _notificationService;

	public PackagingService(
		IDbContextFactory<DSDBContext> dbContextFactory,
		DataChangeNotificationService notificationService)
	{
		_dbContextFactory = dbContextFactory;
		_notificationService = notificationService;
	}

	// 範例: MainPackaging 新增
	public async Task<bool> InsertMainPackagingAsync(MainPackaging entity)
	{
		await using var db = await _dbContextFactory.CreateDbContextAsync();
		db.MainPackaging.Add(entity);
		var result = await db.SaveChangesAsync() > 0;
		if (result) _notificationService.NotifyMainPackagingChanged();
		return result;
	}
}
```

### 頁面訂閱模式

所有 Packaging 頁面遵循相同的訂閱模式:

```csharp
@rendermode InteractiveServer
@inject PackagingService PackagingService
@inject DataChangeNotificationService NotificationService
@implements IDisposable

@code {
	protected override async Task OnInitializedAsync()
	{
		await LoadData();
		// 訂閱對應的事件
		NotificationService.MainPackagingChanged += OnDataChanged;
	}

	private async Task LoadData()
	{
		// 載入資料
		packagings = await PackagingService.GetMainPackagingAsync();
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
		NotificationService.MainPackagingChanged -= OnDataChanged;
	}

	private async Task SavePackaging()
	{
		// CRUD 操作後不需手動呼叫 LoadData()
		// 通知機制會自動觸發更新
		await PackagingService.InsertMainPackagingAsync(editModel);
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

所有頁面都使用 DevExpress Blazor 元件:

- **DxGrid**: 資料表格顯示
  - 支援分頁 (`PageSize="20"`)
  - 支援篩選 (`ShowFilterRow="true"`)
  - 自訂欄位顯示格式

- **Modal 彈出視窗**: 新增/編輯表單
  - Bootstrap 5 樣式
  - 表單欄位驗證
  - 取消/儲存按鈕

## 資料驗證

所有頁面在儲存時會:
1. 自動設定時間戳記欄位 (`ProcessTime`, `OccurrenceTime`, `CreateTime`)
2. 初始化必填欄位的預設值
3. 使用 `JSRuntime` 顯示刪除確認對話框

## 維護建議

1. **一致性**: 所有新的 Service CRUD 頁面應遵循相同的模式
2. **命名規範**: 事件名稱應與資料表名稱對應
3. **錯誤處理**: 可考慮加入錯誤訊息顯示機制
4. **權限控制**: 未來可在各操作按鈕加入權限檢查

## 參考實作

- 參考 MobileRobotService 的頁面實作
- 位於 `FPCService\Components\Pages\MobileRobotService\` 目錄
- 使用相同的通知機制和訂閱模式

## 測試建議

1. 開啟多個瀏覽器視窗測試同步更新
2. 測試新增、編輯、刪除操作的即時反應
3. 檢查元件銷毀時是否正確取消訂閱
4. 驗證所有欄位的資料類型和格式

## 已知限制

1. Log 頁面目前只支援新增，不支援刪除操作
2. 時間欄位都在儲存時自動設定為當前時間
3. UID 欄位由資料庫自動產生，不可手動編輯
