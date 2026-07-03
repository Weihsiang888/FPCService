# YarnMachine 和 YarnMachineSlot 服務 CRUD UI 實作文件

## 概述
本次實作為 YarnMachineService 和 YarnMachineSlotService 建立了完整的 CRUD 網頁 UI，並整合了自動通知機制，當資料發生變更時會主動通知頁面更新。

## 實作架構

### 1. 資料變更通知服務擴充
**檔案：** `FPCService/Services/DataChangeNotificationService.cs`

新增以下事件和通知方法：

#### YarnMachine 事件
- `MainYarnMachineChanged` - 紡紗機主檔變更事件
- `DetialYarnMachineChanged` - 紡紗機事件明細變更事件
- `NotifyMainYarnMachineChanged()` - 觸發紡紗機主檔變更通知
- `NotifyDetialYarnMachineChanged()` - 觸發紡紗機事件明細變更通知

#### YarnMachineSlot 事件
- `MainYarnMachineSlotChanged` - 紡紗機插槽主檔變更事件
- `DetialYarnMachineSlotChanged` - 紡紗機插槽事件明細變更事件
- `QueueYarnMachineSlotChanged` - 紡紗機插槽佇列變更事件
- `LogYarnMachineSlotChanged` - 紡紗機插槽紀錄變更事件
- 對應的 `Notify*Changed()` 方法

### 2. Service 層整合通知機制

#### YarnMachineService
**檔案：** `FPCService/Services/YarnMachine/YarnMachineService.cs`

- 注入 `DataChangeNotificationService`
- 在以下方法中加入通知機制：
  - **MainYarnMachine CRUD：** `Insert`、`Update`、`Delete` 後通知
  - **DetialYarnMachine CRUD：** `Insert`、`Delete` 後通知

#### YarnMachineSlotService
**檔案：** `FPCService/Services/YarnMachine/YarnMachineSlotService.cs`

- 注入 `DataChangeNotificationService`
- 在以下方法中加入通知機制：
  - **MainYarnMachineSlot CRUD：** `Insert`、`Update`、`Delete` 後通知
  - **DetialYarnMachineSlot CRUD：** `Insert`、`Delete` 後通知
  - **QueueYarnMachineSlot CRUD：** `Insert`、`Update`、`Delete` 後通知
  - **LogYarnMachineSlot CRUD：** `Insert` 後通知

### 3. Blazor UI 頁面

#### YarnMachineService 頁面
**目錄：** `FPCService/Components/Pages/YarnMachineService/`

##### MainYarnMachinePage.razor
- **路由：** `/yarnmachine/main`
- **功能：** 紡紗機主檔管理
- **欄位：**
  - YarnMachineUid - 紡紗機編號
  - YarnMachineStatus - 紡紗機狀態
  - WorderOrder - 工單號碼
  - YarnSpoolType - 紗筒類型
  - Floor - 樓層
  - YarnSpoolCompletedCount - 已完成紗筒數
  - TaskUid - 任務編號
  - ProcessTime - 處理時間

##### DetialYarnMachinePage.razor
- **路由：** `/yarnmachine/detail`
- **功能：** 紡紗機事件明細
- **欄位：** MainYarnMachine 欄位 + UID、OccurrenceTime

#### YarnMachineSlotService 頁面
**目錄：** `FPCService/Components/Pages/YarnMachineSlotService/`

##### MainYarnMachineSlotPage.razor
- **路由：** `/yarnmachineslot/main`
- **功能：** 紡紗機插槽主檔管理
- **欄位：**
  - YarnMachineSlotUid - 插槽編號
  - YarnMachineUid - 紡紗機編號
  - YarnMachineSlotPoint - 插槽點位
  - YarnMachineSlotStatus - 插槽狀態
  - YarnSpoolType - 紗筒類型
  - Floor - 樓層
  - PointCode - 點位代碼
  - TaskUid - 任務編號

##### DetialYarnMachineSlotPage.razor
- **路由：** `/yarnmachineslot/detail`
- **功能：** 紡紗機插槽事件明細
- **欄位：** MainYarnMachineSlot 欄位 + UID、OccurrenceTime

##### QueueYarnMachineSlotPage.razor
- **路由：** `/yarnmachineslot/queue`
- **功能：** 紡紗機插槽佇列管理
- **欄位：**
  - UID - 序號
  - QueueStatus - 佇列狀態
  - YarnMachineSlotUid - 插槽編號
  - YarnSpoolType - 紗筒類型
  - Floor - 樓層
  - TaskUid - 任務編號
  - PointCode - 點位代碼
  - ProcessTime - 處理時間
  - CreateTime - 建立時間
  - CompleteTime - 完成時間

##### LogYarnMachineSlotPage.razor
- **路由：** `/yarnmachineslot/log`
- **功能：** 紡紗機插槽紀錄
- **欄位：**
  - UID - 序號
  - YarnMachineSlotUid - 插槽編號
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
	NotificationService.MainYarnMachineChanged += OnDataChanged;
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
	NotificationService.MainYarnMachineChanged -= OnDataChanged;
}
```

## 技術特點

1. **事件驅動更新：** 使用事件訂閱機制取代手動呼叫 `LoadData()`
2. **自動同步：** 任何 CRUD 操作都會自動通知所有訂閱頁面更新
3. **資源管理：** 實作 `IDisposable` 確保事件訂閱正確清理
4. **一致性架構：** 與 MobileRobot、Packaging、Place、PlaceSlot、RackSlot、StorageRack 使用相同模式

## 建置驗證

✅ 建置成功 - 所有頁面和服務整合正常

## 檔案清單

### 修改的檔案
- `FPCService/Services/DataChangeNotificationService.cs`
- `FPCService/Services/YarnMachine/YarnMachineService.cs`
- `FPCService/Services/YarnMachine/YarnMachineSlotService.cs`

### 新增的檔案
- `FPCService/Components/Pages/YarnMachineService/MainYarnMachinePage.razor`
- `FPCService/Components/Pages/YarnMachineService/DetialYarnMachinePage.razor`
- `FPCService/Components/Pages/YarnMachineSlotService/MainYarnMachineSlotPage.razor`
- `FPCService/Components/Pages/YarnMachineSlotService/DetialYarnMachineSlotPage.razor`
- `FPCService/Components/Pages/YarnMachineSlotService/QueueYarnMachineSlotPage.razor`
- `FPCService/Components/Pages/YarnMachineSlotService/LogYarnMachineSlotPage.razor`

## 與其他服務的一致性

本次實作延續了已建立的模式：
- **MobileRobotService** - 5 個頁面（Main, Detial, Point, Queue, Log）
- **PackagingService** - 4 個頁面（Main, Detial, Queue, Log）
- **PlaceService** - 1 個頁面（Main）
- **PlaceSlotService** - 4 個頁面（Main, Detial, Queue, Log）
- **StorageRackService** - 1 個頁面（Main）
- **RackSlotService** - 4 個頁面（Main, Detial, Queue, Log）
- **YarnMachineService** - 2 個頁面（Main, Detial）✅
- **YarnMachineSlotService** - 4 個頁面（Main, Detial, Queue, Log）✅

## 後續工作

如需要可以：
1. 為頁面加入搜尋和篩選功能
2. 加入資料驗證邏輯
3. 自訂欄位顯示格式
4. 加入刪除確認對話框
5. 推送變更至 Git 儲存庫
