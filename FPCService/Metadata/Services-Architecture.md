# FPCService 服務層架構說明

## 📁 架構概述

原本的單一 `DataService.cs`（1196 行）已重構為**按功能領域拆分**的架構，將 CRUD 操作依據業務領域分散到不同的服務類別中。

## 🗂️ 服務領域劃分

### 1️⃣ YarnMachine（紡紗機）
**路徑**: `FPCService/Services/YarnMachine/`

#### YarnMachineService
處理紡紗機主檔和事件明細：
- `MainYarnMachine` CRUD
- `DetailYarnMachine` CRUD

#### YarnMachineSlotService
處理紡紗機插槽相關資料：
- `MainYarnMachineSlot` CRUD
- `DetailYarnMachineSlot` CRUD
- `QueueYarnMachineSlot` CRUD（含 Update）
- `LogYarnMachineSlot` 新增/查詢

---

### 2️⃣ YarnSpool（紗管）
**路徑**: `FPCService/Services/YarnSpool/`

#### YarnSpoolService
處理紗管資料：
- `YarnSpool` CRUD（含 Update）

---

### 3️⃣ MobileRobot（行動機器人/AGV）
**路徑**: `FPCService/Services/MobileRobot/`

#### MobileRobotService
處理行動機器人相關資料：
- `MainMobileRobot` CRUD
- `DetailMobileRobot` CRUD
- `MobileRobotPoint` CRUD
- `QueueMobileRobot` CRUD（含 Update）
- `LogMobileRobot` 新增/查詢

---

### 4️⃣ Place（場域）
**路徑**: `FPCService/Services/Place/`

#### PlaceService
處理場域主檔：
- `MainPlace` CRUD

#### PlaceSlotService
處理場域插槽相關資料：
- `MainPlaceSlot` CRUD
- `DetailPlaceSlot` CRUD
- `QueuePlaceSlot` CRUD（含 Update）
- `LogPlaceSlot` 新增/查詢

---

### 5️⃣ StorageRack（儲存架）
**路徑**: `FPCService/Services/StorageRack/`

#### StorageRackService
處理儲存架主檔：
- `MainStorageRack` CRUD

#### RackSlotService
處理儲存架插槽相關資料：
- `MainRackSlot` CRUD
- `DetailRackSlot` CRUD
- `QueueRackSlot` CRUD（含 Update）
- `LogRackSlot` 新增/查詢

---

### 6️⃣ Packaging（包裝）
**路徑**: `FPCService/Services/Packaging/`

#### PackagingService
處理包裝相關資料：
- `MainPackaging` CRUD
- `DetailPackaging` CRUD
- `QueuePackaging` CRUD（含 Update）
- `LogPackaging` 新增/查詢

---

## 🔧 服務註冊

### 方法 1：使用擴充方法（推薦）✅

在 `Program.cs` 中使用擴充方法一次註冊所有服務：

```csharp
using FPCService.Services;

// 註冊所有領域服務
builder.Services.AddDomainServices();
```

### 方法 2：手動註冊個別服務

如果只需要特定領域的服務：

```csharp
using FPCService.Services.YarnMachine;
using FPCService.Services.MobileRobot;

builder.Services.AddScoped<YarnMachineService>();
builder.Services.AddScoped<YarnMachineSlotService>();
builder.Services.AddScoped<MobileRobotService>();
// ...
```

---

## 💡 使用範例

### Blazor 頁面注入

```csharp
@page "/yarnmachine"
@using FPCService.Services.YarnMachine
@inject YarnMachineService YarnMachineService

<h3>紡紗機管理</h3>

@code {
	private List<MainYarnMachine> machines = new();

	protected override async Task OnInitializedAsync()
	{
		machines = await YarnMachineService.GetMainYarnMachineAsync();
	}
}
```

### Controller 注入（若使用 Web API）

```csharp
using FPCService.Services.YarnMachine;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class YarnMachineController : ControllerBase
{
	private readonly YarnMachineService _yarnMachineService;

	public YarnMachineController(YarnMachineService yarnMachineService)
	{
		_yarnMachineService = yarnMachineService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var result = await _yarnMachineService.GetMainYarnMachineAsync();
		return Ok(result);
	}
}
```

---

## ✅ 重構完成清單

- ✅ `YarnMachineService` & `YarnMachineSlotService`
- ✅ `YarnSpoolService`
- ✅ `MobileRobotService`
- ✅ `PlaceService` & `PlaceSlotService`
- ✅ `StorageRackService` & `RackSlotService`
- ✅ `PackagingService`
- ✅ `ServiceCollectionExtensions` 擴充方法
- ✅ 移除舊的 `DataService.cs`（已備份至版本控制）

---

## 📊 架構優勢

### 舊架構（已淘汰）
```
DataService.cs
└── 1196 行，26 個 #region
	├── 所有 CRUD 混雜
	└── 難以維護和測試
```

### 新架構（目前）
```
Services/
├── YarnMachine/
│   ├── YarnMachineService.cs
│   └── YarnMachineSlotService.cs
├── YarnSpool/
│   └── YarnSpoolService.cs
├── MobileRobot/
│   └── MobileRobotService.cs
├── Place/
│   ├── PlaceService.cs
│   └── PlaceSlotService.cs
├── StorageRack/
│   ├── StorageRackService.cs
│   └── RackSlotService.cs
├── Packaging/
│   └── PackagingService.cs
└── ServiceCollectionExtensions.cs
```

### 帶來的好處
1. **單一職責原則**：每個服務類別只處理特定領域的業務邏輯
2. **易於維護**：每個檔案只有 100-300 行，容易理解和修改
3. **團隊協作友善**：不同開發者可以同時修改不同領域的服務，減少合併衝突
4. **測試更容易**：可以針對個別領域服務撰寫單元測試
5. **效能優化**：使用 `AddScoped` 生命週期，在每個請求內共用實例

---

## 📝 注意事項

1. **所有 Queue 資料表都支援 Update**：包含 `QueueYarnMachineSlot`, `QueueMobileRobot`, `QueuePlaceSlot`, `QueueRackSlot`, `QueuePackaging`
2. **Log 資料表只支援新增**：`LogYarnMachineSlot`, `LogMobileRobot`, `LogPlaceSlot`, `LogRackSlot`, `LogPackaging` 不提供修改/刪除
3. **Detail 資料表不支援 Update**：只提供新增和刪除操作
4. **DbContext 使用 Factory 模式**：確保每次操作使用新的 DbContext 實例，避免追蹤問題

---

## 🔄 遷移指南

### 如果現有程式碼使用了舊的 DataService

舊的 `DataService` 已被移除，請依照以下步驟遷移：

#### 步驟 1：更新注入
```csharp
// 舊的方式 ❌
@inject DataService DataService

// 新的方式 ✅
@inject YarnMachineService YarnMachineService
@inject MobileRobotService MobileRobotService
```

#### 步驟 2：更新方法呼叫
```csharp
// 舊的方式 ❌
var machines = await DataService.GetMainYarnMachineAsync();

// 新的方式 ✅（方法名稱和參數完全相同）
var machines = await YarnMachineService.GetMainYarnMachineAsync();
```

---

## 🚀 未來擴充建議

1. **增加通用基底類別**：避免重複的 DbContext 處理邏輯
2. **引入 Repository Pattern**：進一步抽象資料存取層
3. **加入 Cache 機制**：針對不常變動的主檔資料
4. **使用 AutoMapper**：簡化 Entity 和 DTO 之間的轉換
5. **加入業務邏輯層（Business Logic Layer）**：將複雜業務規則從 Service 中分離

---

**重構完成時間**: 2026/7/3  
**重構版本**: v2.0  
**舊版備份**: 請參考 Git 歷史記錄中的 `DataService.cs`
