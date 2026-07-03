# YarnSpool 服務 CRUD UI 實作文件

## 概述
本次實作為 YarnSpoolService 建立了完整的 CRUD 網頁 UI，並整合了自動通知機制，當資料發生變更時會主動通知頁面更新。

## 實作架構

### 1. 資料變更通知服務擴充
**檔案：** `FPCService/Services/DataChangeNotificationService.cs`

新增以下事件和通知方法：

#### YarnSpool 事件
- `YarnSpoolChanged` - 紗管資料變更事件
- `NotifyYarnSpoolChanged()` - 觸發紗管資料變更通知

### 2. Service 層整合通知機制

#### YarnSpoolService
**檔案：** `FPCService/Services/YarnSpool/YarnSpoolService.cs`

- 注入 `DataChangeNotificationService`
- 在以下方法中加入通知機制：
  - `InsertYarnSpoolAsync` - 新增後通知
  - `UpdateYarnSpoolAsync` - 更新後通知
  - `DeleteYarnSpoolAsync` - 刪除後通知

### 3. Blazor UI 頁面

#### YarnSpoolService 頁面
**目錄：** `FPCService/Components/Pages/YarnSpoolService/`

##### YarnSpoolPage.razor
- **路由：** `/yarnspool/main`
- **功能：** 紗管管理
- **欄位：**
  - UID - 序號
  - YarnSpoolUid - 紗管編號
  - YarnSpoolStatus - 紗管狀態
  - YarnSpoolType - 紗管類型
  - AgvUid - AGV 編號
  - PlaceUid - 站點編號
  - PlaceSlotUid - 站點插槽編號
  - StorageRackUid - 儲存架編號
  - RackSlotUid - 儲存架插槽編號
  - TaskUid - 任務編號
  - Floor - 樓層
  - ProcessTime - 處理時間
  - CreateTime - 建立時間
  - CompleteTime - 完成時間
  - PlaceTime - 放置時間
  - StorageTime - 儲存時間
  - PackagingTime - 包裝時間
  - EventTime - 事件時間

## 頁面設計模式

頁面遵循以下設計模式（參考 MobileRobotService）：

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
	NotificationService.YarnSpoolChanged += OnDataChanged;
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
	NotificationService.YarnSpoolChanged -= OnDataChanged;
}
```

## 技術特點

1. **事件驅動更新：** 使用事件訂閱機制取代手動呼叫 `LoadData()`
2. **自動同步：** 任何 CRUD 操作都會自動通知所有訂閱頁面更新
3. **資源管理：** 實作 `IDisposable` 確保事件訂閱正確清理
4. **一致性架構：** 與其他所有服務使用相同模式

## 建置驗證

✅ 建置成功 - 所有頁面和服務整合正常

## 檔案清單

### 修改的檔案
- `FPCService/Services/DataChangeNotificationService.cs`
- `FPCService/Services/YarnSpool/YarnSpoolService.cs`

### 新增的檔案
- `FPCService/Components/Pages/YarnSpoolService/YarnSpoolPage.razor`

## YarnSpool 實體說明

YarnSpool 是一個複雜的實體，追蹤紗管在整個系統中的生命週期：

### 狀態追蹤
- **YarnSpoolStatus** - 當前狀態
- **YarnSpoolType** - 紗管類型

### 位置追蹤
- **AgvUid** - 當前所在的 AGV
- **PlaceUid / PlaceSlotUid** - 站點位置
- **StorageRackUid / RackSlotUid** - 儲存架位置

### 時間追蹤
- **CreateTime** - 建立時間
- **ProcessTime** - 處理時間
- **PlaceTime** - 放置時間
- **StorageTime** - 儲存時間
- **PackagingTime** - 包裝時間
- **CompleteTime** - 完成時間
- **EventTime** - 事件時間

這些欄位讓系統能夠完整追蹤每個紗管的位置和狀態變化。

## 與其他服務的一致性

本次實作延續了已建立的模式：
- **MobileRobotService** - 5 個頁面
- **PackagingService** - 4 個頁面
- **PlaceService** - 1 個頁面
- **PlaceSlotService** - 4 個頁面
- **StorageRackService** - 1 個頁面
- **RackSlotService** - 4 個頁面
- **YarnMachineService** - 2 個頁面
- **YarnMachineSlotService** - 4 個頁面
- **YarnSpoolService** - 1 個頁面 ✅

## 後續工作

如需要可以：
1. 為頁面加入搜尋和篩選功能（特別是按狀態、類型、位置篩選）
2. 加入資料驗證邏輯
3. 自訂欄位顯示格式（特別是時間欄位）
4. 加入刪除確認對話框
5. 加入紗管生命週期視覺化顯示
6. 推送變更至 Git 儲存庫
