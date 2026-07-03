# RackSlot 和 StorageRack 服務 CRUD UI 實作文件

## 概述
本次實作為 RackSlotService 和 StorageRackService 建立了完整的 CRUD 網頁 UI，並整合了自動通知機制，當資料發生變更時會主動通知頁面更新。

## 實作架構

### 1. 資料變更通知服務擴充
**檔案：** `FPCService/Services/DataChangeNotificationService.cs`

新增以下事件和通知方法：

#### StorageRack 事件
- `MainStorageRackChanged` - 儲存架主檔變更事件
- `NotifyMainStorageRackChanged()` - 觸發儲存架主檔變更通知

#### RackSlot 事件
- `MainRackSlotChanged` - 插槽主檔變更事件
- `DetialRackSlotChanged` - 插槽事件明細變更事件
- `QueueRackSlotChanged` - 插槽佇列變更事件
- `LogRackSlotChanged` - 插槽紀錄變更事件
- 對應的 `Notify*Changed()` 方法

### 2. Service 層整合通知機制

#### StorageRackService
**檔案：** `FPCService/Services/StorageRack/StorageRackService.cs`

- 注入 `DataChangeNotificationService`
- 在以下方法中加入通知機制：
  - `InsertMainStorageRackAsync` - 新增後通知
  - `UpdateMainStorageRackAsync` - 更新後通知
  - `DeleteMainStorageRackAsync` - 刪除後通知

#### RackSlotService
**檔案：** `FPCService/Services/StorageRack/RackSlotService.cs`

- 注入 `DataChangeNotificationService`
- 在以下方法中加入通知機制：
  - **MainRackSlot CRUD：** `Insert`、`Update`、`Delete` 後通知
  - **DetialRackSlot CRUD：** `Insert`、`Delete` 後通知
  - **QueueRackSlot CRUD：** `Insert`、`Update`、`Delete` 後通知
  - **LogRackSlot CRUD：** `Insert` 後通知

### 3. Blazor UI 頁面

#### StorageRackService 頁面
**目錄：** `FPCService/Components/Pages/StorageRackService/`

##### MainStorageRackPage.razor
- **路由：** `/storagerack/main`
- **功能：** 儲存架主檔管理
- **欄位：**
  - StorageRackUid - 儲存架編號
  - StorageRackName - 儲存架名稱
  - StorageRackPoint - 儲存架點位
  - YarnSpoolType - 紗筒類型
  - Floor - 樓層
  - TaskUid - 任務編號
  - StorageCompletedCount - 已完成數量
  - ProcessTime - 處理時間

#### RackSlotService 頁面
**目錄：** `FPCService/Components/Pages/RackSlotService/`

##### MainRackSlotPage.razor
- **路由：** `/rackslot/main`
- **功能：** 儲存架插槽主檔管理
- **欄位：**
  - RackSlotUid - 插槽編號
  - StorageRackUid - 儲存架編號
  - RackSlotPoint - 插槽點位
  - RackSlotStatus - 插槽狀態
  - YarnSpoolType - 紗筒類型
  - Floor - 樓層
  - TaskUid - 任務編號

##### DetialRackSlotPage.razor
- **路由：** `/rackslot/detail`
- **功能：** 儲存架插槽事件明細
- **欄位：** MainRackSlot 欄位 + UID、OccurrenceTime

##### QueueRackSlotPage.razor
- **路由：** `/rackslot/queue`
- **功能：** 儲存架插槽佇列管理
- **欄位：**
  - UID - 序號
  - QueueStatus - 佇列狀態
  - RackSlotUid - 插槽編號
  - Floor - 樓層
  - TaskUid - 任務編號
  - ProcessTime - 處理時間
  - CreateTime - 建立時間
  - CompleteTime - 完成時間

##### LogRackSlotPage.razor
- **路由：** `/rackslot/log`
- **功能：** 儲存架插槽紀錄
- **欄位：**
  - UID - 序號
  - RackSlotUid - 插槽編號
  - Floor - 樓層
  - TaskUid - 任務編號
  - Message - 訊息
  - ProcessTime - 處理時間

## 頁面設計模式

所有頁面都遵循以下設計模式（參考 MobileRobotService）：

### 1. 渲染模式
使用 `@rendermode InteractiveServer` 啟用伺服器端互動模式

### 2. 生命週期
- **OnInitializedAsync：** 訂閱通知事件並載入初始資料
- **OnDataChanged：** 當資料變更時自動重新載入資料並更新 UI
- **Dispose：** 取消訂閱通知事件避免記憶體洩漏

### 3. 資料載入
```csharp
protected override async Task OnInitializedAsync()
{
	NotificationService.MainStorageRackChanged += OnDataChanged;
	await LoadData();
}

private void OnDataChanged()
{
	InvokeAsync(async () =>
	{
		await LoadData();
		StateHasChanged();
	});
}
```

### 4. CRUD 操作
- 使用 DevExpress Grid 的 `EditMode="GridEditMode.EditRow"`
- 在 `OnEditModelSaving` 事件中處理新增和更新
- Service 層自動觸發通知，頁面自動更新

### 5. 清理資源
```csharp
public void Dispose()
{
	NotificationService.MainStorageRackChanged -= OnDataChanged;
}
```

## 技術特點

1. **事件驅動更新：** 使用事件訂閱機制取代手動呼叫 `LoadData()`
2. **自動同步：** 任何 CRUD 操作都會自動通知所有訂閱頁面更新
3. **資源管理：** 實作 `IDisposable` 確保事件訂閱正確清理
4. **一致性架構：** 與 MobileRobot、Packaging、Place、PlaceSlot 使用相同模式

## 建置驗證

✅ 建置成功 - 所有頁面和服務整合正常

## 檔案清單

### 修改的檔案
- `FPCService/Services/DataChangeNotificationService.cs`
- `FPCService/Services/StorageRack/StorageRackService.cs`
- `FPCService/Services/StorageRack/RackSlotService.cs`

### 新增的檔案
- `FPCService/Components/Pages/StorageRackService/MainStorageRackPage.razor`
- `FPCService/Components/Pages/RackSlotService/MainRackSlotPage.razor`
- `FPCService/Components/Pages/RackSlotService/DetialRackSlotPage.razor`
- `FPCService/Components/Pages/RackSlotService/QueueRackSlotPage.razor`
- `FPCService/Components/Pages/RackSlotService/LogRackSlotPage.razor`

## 後續工作

如需要可以：
1. 為頁面加入搜尋和篩選功能
2. 加入資料驗證邏輯
3. 自訂欄位顯示格式
4. 加入刪除確認對話框
5. 推送變更至 Git 儲存庫
