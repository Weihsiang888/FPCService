# FPCService 專案架構說明文件

## 📋 專案概述

**專案名稱**: FPCService  
**專案類型**: Blazor Server Application (.NET 8)  
**執行環境**: Windows Service  
**資料庫**: SQL Server (FPC Database)  
**預設通訊埠**: HTTP 6003  
**開發工具**: Visual Studio Community 2026 (18.7.3)

### 專案簡介
FPCService 是一個基於 Blazor Server 的工廠生產控制系統，負責管理紡紗機、行動機器人 (AGV)、儲存架、包裝等生產設備的狀態與任務佇列。系統採用 Entity Framework Core 作為資料存取層，並整合 DevExpress Blazor UI 元件庫。

---

## 🏗️ 整體架構

```
FPCService/
├── 📁 Components/               # Blazor 元件與頁面
│   ├── Layout/                  # 版面配置元件
│   ├── Pages/                   # 頁面元件
│   └── Shared/                  # 共用元件
├── 📁 Data/                     # 資料層
│   ├── Class/                   # Entity 實體類別
│   │   ├── Main/                # 主檔實體
│   │   ├── Detail/              # 明細/歷史實體
│   │   ├── Queue/               # 佇列實體
│   │   ├── EventLog/            # 事件紀錄實體
│   │   └── Object/              # 物件實體
│   ├── DSDBContext/             # EF Core DbContext
│   └── Schema/                  # 資料庫結構 SQL 檔案
├── 📁 Services/                 # 服務層（按領域拆分）
│   ├── YarnMachine/             # 紡紗機服務
│   ├── YarnSpool/               # 紗管服務
│   ├── MobileRobot/             # 行動機器人服務
│   ├── Place/                   # 場域服務
│   ├── StorageRack/             # 儲存架服務
│   └── Packaging/               # 包裝服務
├── 📁 Metadata/                 # 專案文件
├── 📁 wwwroot/                  # 靜態資源
│   ├── css/                     # 樣式表
│   └── images/                  # 圖片資源
├── 📄 Program.cs                # 應用程式進入點
├── 📄 appsettings.json          # 應用程式設定
└── 📄 FPCService.csproj         # 專案檔

CommonLibrary/                   # 共用類別庫 (外部專案)
└── CommonLibraryP/
	├── LogPKG/                  # 日誌套件
	├── MachinePKG/              # 機台管理套件
	├── MapPKG/                  # 地圖套件
	├── ShopfloorPKG/            # 現場管理套件
	├── UserPKG/                 # 使用者管理套件
	└── NotificationUtility/     # 通知工具
```

---

## 📊 資料層架構 (Data Layer)

### 資料庫連線
- **伺服器**: 127.0.0.1 (本機 SQL Server)
- **資料庫名稱**: FPC
- **認證方式**: SQL Server Authentication
- **連線字串**: 定義於 `appsettings.json`

### Entity 分類

#### 1️⃣ Main（主檔）
主要實體資料，代表系統中的核心物件：
- `MainYarnMachine` - 紡紗機主檔
- `MainYarnMachineSlot` - 紡紗機插槽主檔
- `MainMobileRobot` - 行動機器人主檔
- `MobileRobotPoint` - 行動機器人點位
- `MainPlace` - 場域主檔
- `MainPlaceSlot` - 場域插槽主檔
- `MainStorageRack` - 儲存架主檔
- `MainRackSlot` - 儲存架插槽主檔
- `MainPackaging` - 包裝主檔

#### 2️⃣ Detail（明細/歷史）
記錄實體的歷史變更資訊：
- `DetialYarnMachine` - 紡紗機歷史明細
- `DetialYarnMachineSlot` - 紡紗機插槽歷史明細
- `DetialMobileRobot` - 行動機器人歷史明細
- `DetialPlaceSlot` - 場域插槽歷史明細
- `DetialRackSlot` - 儲存架插槽歷史明細
- `DetialPackaging` - 包裝歷史明細

**特性**:
- 包含 `UID` (自動編號主鍵) 和 `OccurrenceTime` (發生時間)
- 僅支援新增和查詢，不支援修改

#### 3️⃣ Queue（佇列）
任務佇列，用於處理非同步工作：
- `QueueYarnMachineSlot` - 紡紗機插槽任務佇列
- `QueueMobileRobot` - 行動機器人任務佇列
- `QueuePlaceSlot` - 場域插槽任務佇列
- `QueueRackSlot` - 儲存架插槽任務佇列
- `QueuePackaging` - 包裝任務佇列

**特性**:
- 包含 `QueueStatus`、`CreateTime`、`CompleteTime`
- 支援 CRUD 全操作（含 Update）

#### 4️⃣ EventLog（事件紀錄）
系統事件與操作日誌：
- `LogYarnMachineSlot` - 紡紗機插槽事件紀錄
- `LogMobileRobot` - 行動機器人事件紀錄
- `LogPlaceSlot` - 場域插槽事件紀錄
- `LogRackSlot` - 儲存架插槽事件紀錄
- `LogPackaging` - 包裝事件紀錄

**特性**:
- 包含 `UID`、`Message`、`ProcessTime`
- 僅支援新增和查詢，不支援修改或刪除

#### 5️⃣ Object（物件實體）
核心物件資料：
- `YarnSpool` - 紗管（Table_YarnSpool）

**特性**:
- 包含完整生命週期時間戳記
- 支援 CRUD 全操作

### DbContext 設計

**檔案**: `Data/DSDBContext/DSDBContext.cs`

```csharp
public class DSDBContext : DbContext
{
	// DbSet 屬性 (26 張資料表)
	public DbSet<MainYarnMachine> MainYarnMachine { get; set; }
	public DbSet<YarnSpool> YarnSpool { get; set; }
	// ... 其他 DbSet

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Fluent API 設定：
		// - HasColumnName: 對應資料庫欄位名稱 (處理大小寫與底線差異)
		// - HasKey: 設定主鍵
		// - HasMaxLength: 字串長度限制
		// - HasColumnType: 日期時間格式
	}
}
```

**設計原則**:
- Entity 類別為純 POCO，不包含 Data Annotations
- 所有資料庫映射透過 Fluent API 集中管理
- 使用 `IDbContextFactory<DSDBContext>` 建立 DbContext 實例

---

## 🔧 服務層架構 (Service Layer)

### 領域服務分類

服務層採用 **領域驅動設計 (Domain-Driven Design)** 原則，依業務領域拆分：

#### 1️⃣ YarnMachine 領域（紡紗機）
**路徑**: `Services/YarnMachine/`

##### YarnMachineService
- `GetMainYarnMachineAsync()` - 取得所有紡紗機
- `GetMainYarnMachineByUidAsync(uid)` - 依 UID 取得
- `InsertMainYarnMachineAsync(entity)` - 新增
- `UpdateMainYarnMachineAsync(entity)` - 更新
- `DeleteMainYarnMachineAsync(uid)` - 刪除
- `GetDetialYarnMachineAsync()` - 取得歷史明細
- `InsertDetialYarnMachineAsync(entity)` - 新增明細

##### YarnMachineSlotService
- MainYarnMachineSlot CRUD
- DetialYarnMachineSlot CRUD
- QueueYarnMachineSlot CRUD (含 Update)
- LogYarnMachineSlot 新增/查詢

#### 2️⃣ YarnSpool 領域（紗管）
**路徑**: `Services/YarnSpool/`

##### YarnSpoolService
- `GetYarnSpoolAsync()` - 取得所有紗管
- `GetYarnSpoolByUidAsync(uid)` - 依 UID 取得
- `InsertYarnSpoolAsync(entity)` - 新增
- `UpdateYarnSpoolAsync(entity)` - 更新
- `DeleteYarnSpoolAsync(uid)` - 刪除

#### 3️⃣ MobileRobot 領域（行動機器人/AGV）
**路徑**: `Services/MobileRobot/`

##### MobileRobotService
- MainMobileRobot CRUD
- DetialMobileRobot CRUD
- MobileRobotPoint CRUD (點位管理)
- QueueMobileRobot CRUD (含 Update)
- LogMobileRobot 新增/查詢

#### 4️⃣ Place 領域（場域）
**路徑**: `Services/Place/`

##### PlaceService
- MainPlace CRUD

##### PlaceSlotService
- MainPlaceSlot CRUD
- DetialPlaceSlot CRUD
- QueuePlaceSlot CRUD (含 Update)
- LogPlaceSlot 新增/查詢

#### 5️⃣ StorageRack 領域（儲存架）
**路徑**: `Services/StorageRack/`

##### StorageRackService
- MainStorageRack CRUD

##### RackSlotService
- MainRackSlot CRUD
- DetialRackSlot CRUD
- QueueRackSlot CRUD (含 Update)
- LogRackSlot 新增/查詢

#### 6️⃣ Packaging 領域（包裝）
**路徑**: `Services/Packaging/`

##### PackagingService
- MainPackaging CRUD
- DetialPackaging CRUD
- QueuePackaging CRUD (含 Update)
- LogPackaging 新增/查詢

### 服務註冊

**檔案**: `Services/ServiceCollectionExtensions.cs`

```csharp
public static class ServiceCollectionExtensions
{
	public static IServiceCollection AddDomainServices(this IServiceCollection services)
	{
		// 註冊所有領域服務為 Scoped 生命週期
		services.AddScoped<YarnMachineService>();
		services.AddScoped<YarnMachineSlotService>();
		services.AddScoped<YarnSpoolService>();
		services.AddScoped<MobileRobotService>();
		services.AddScoped<PlaceService>();
		services.AddScoped<PlaceSlotService>();
		services.AddScoped<StorageRackService>();
		services.AddScoped<RackSlotService>();
		services.AddScoped<PackagingService>();

		return services;
	}
}
```

**生命週期**: `Scoped` - 每個 HTTP 請求建立一次實例

---

## 🎨 展示層架構 (Presentation Layer)

### Blazor 元件結構

#### Layout 元件
**路徑**: `Components/Layout/`

- **MainLayout.razor**
  - 主版面配置
  - 使用 DevExpress Drawer 元件實現側邊選單
  - 導覽管理與狀態控制

- **NavMenu.razor**
  - 導覽選單
  - 路由連結管理

- **Drawer.razor**
  - 側邊抽屜元件
  - 支援展開/收合狀態

#### 頁面元件
**路徑**: `Components/Pages/`

##### 首頁
- `Index/Index.razor` - 主儀表板頁面
- `Index/IndexTile.razor` - 首頁磚片元件

##### 機台管理
- `Machine/MachinePage.razor` - 機台概覽頁面
- `Machine/MachineSettingPage.razor` - 機台設定頁面
- `Machine/ModbusSlaveSettingPage.razor` - Modbus 從站設定
- `Machine/TagCategoriesPage.razor` - 標籤分類管理

##### 範例頁面
- `Counter.razor` - 計數器範例
- `Weather.razor` - 天氣資料範例

#### 共用元件
**路徑**: `Components/Shared/`

- `DrawerStateComponentBase.cs` - 抽屜狀態基底類別

### 元件樣式
每個 Razor 元件可搭配對應的 `.razor.css` 檔案，採用 **CSS Isolation** 機制：
- `MainLayout.razor.css`
- `NavMenu.razor.css`
- `Index.razor.css`
- 等

---

## 🌐 應用程式設定

### Program.cs 設定摘要

```csharp
var builder = WebApplication.CreateBuilder(webApOpts);
builder.Host.UseWindowsService();  // 支援 Windows Service 執行

// Blazor Server
builder.Services.AddRazorComponents()
	.AddInteractiveServerComponents();

// DevExpress Blazor
builder.Services.AddDevExpressBlazor(options => {
	options.SizeMode = DevExpress.Blazor.SizeMode.Large;
});

// API 支援
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// 機台服務 (CommonLibrary)
builder.AddMachineService();

// 註冊領域服務 (需手動加入)
// builder.Services.AddDomainServices();
```

### appsettings.json 設定

```json
{
  "ConnectionStrings": {
	"DefaultConnection": "Data Source=127.0.0.1;Initial Catalog=FPC;..."
  },
  "Logging": {
	"LogLevel": {
	  "Default": "Information",
	  "Microsoft.AspNetCore": "Warning",
	  "Microsoft.EntityFrameworkCore": "Warning"
	}
  },
  "Kestrel": {
	"EndPoints": {
	  "Http": {
		"Url": "http://*:6003"
	  }
	}
  }
}
```

---

## 📦 相依套件

### NuGet 套件

#### UI 框架
- **DevExpress.Blazor** - DevExpress Blazor UI 元件庫

#### 資料存取
- **Microsoft.EntityFrameworkCore**
- **Microsoft.EntityFrameworkCore.SqlServer**
- **Microsoft.EntityFrameworkCore.Tools** (開發工具)

#### API 支援
- **Swashbuckle.AspNetCore** - Swagger/OpenAPI 文件生成

#### 其他
- **Microsoft.AspNetCore.Components.WebAssembly.Server** (若有混合模式)
- **Microsoft.Extensions.Hosting.WindowsServices** - Windows Service 支援

### 專案參考
- **CommonLibraryP** - 共用類別庫
  - 機台管理 (MachinePKG)
  - 日誌系統 (LogPKG)
  - 地圖功能 (MapPKG)
  - 現場管理 (ShopfloorPKG)
  - 使用者管理 (UserPKG)
  - 通知工具 (NotificationUtility)

---

## 🚀 執行模式

### 開發模式
```bash
dotnet run
```
- 啟用 Swagger UI (`/swagger`)
- 詳細錯誤頁面
- 熱重載支援

### Windows Service 模式
```bash
# 發行
dotnet publish -c Release

# 安裝服務
sc create FPCService binPath="C:\path\to\FPCService.exe"
sc start FPCService
```

### 存取位址
- **HTTP**: http://localhost:6003
- **Swagger**: http://localhost:6003/swagger

---

## 📝 開發規範

### Entity 設計原則
1. **純 POCO 類別** - 不使用 Data Annotations
2. **屬性命名** - 使用 PascalCase (C# 慣例)
3. **資料庫映射** - 統一在 `DSDBContext.OnModelCreating` 使用 Fluent API

### Service 設計原則
1. **單一職責** - 每個 Service 處理單一業務領域
2. **非同步操作** - 所有資料存取方法使用 `async/await`
3. **DbContext 管理** - 使用 Factory 模式，確保每次操作使用新實例
4. **錯誤處理** - 回傳 `bool` 或 `null` 表示操作結果

### Blazor 元件規範
1. **元件檔名** - 使用 PascalCase (e.g., `MachinePage.razor`)
2. **路由定義** - 使用 `@page` 指令
3. **DI 注入** - 使用 `@inject` 指令
4. **CSS Isolation** - 使用對應的 `.razor.css` 檔案

---

## 🔐 安全性考量

### 資料庫連線
- **建議**: 不要在 `appsettings.json` 明文儲存密碼
- **最佳實務**: 使用 Azure Key Vault、User Secrets 或 Windows 整合驗證

### API 安全
- 目前無認證機制
- **建議**: 加入 JWT Bearer Token 或 Cookie Authentication

---

## 📊 效能最佳化

### Entity Framework Core
- 所有查詢使用 `AsNoTracking()` (除非需要追蹤)
- 使用 `IDbContextFactory` 避免 DbContext 生命週期問題
- 啟用 Connection Pooling

### Blazor Server
- 使用 `@rendermode InteractiveServer` 控制互動模式
- 適當使用 `StateHasChanged()` 觸發 UI 更新
- 考慮使用 Virtualization 處理大量資料列表

---

## 🧪 測試建議

### 單元測試
- 針對各領域 Service 撰寫單元測試
- 使用 In-Memory Database 或 Mock DbContext

### 整合測試
- 測試 API 端點
- 測試 Blazor 元件互動

---

## 📚 相關文件

- [服務層架構說明](./Services-Architecture.md)
- [資料庫結構 SQL](../Data/Schema/FPCService.sql)

---

## 🔄 版本歷程

### v2.0 (2026/7/3)
- ✅ 重構服務層，從單一 `DataService.cs` (1196 行) 拆分為 10 個領域服務
- ✅ 實作完整的 EF Core Fluent API 映射
- ✅ 建立專案架構文件

### v1.0
- 初始版本
- 基礎 Blazor Server 架構
- 整合 DevExpress UI 元件

---

**文件維護**: 2026/7/3  
**聯絡資訊**: 請參考 Git Repository  
**授權**: 內部專案
