# 資料變更通知機制

## 概述

本專案實作了一個事件驅動的資料變更通知機制，讓 UI 頁面能夠在資料變更時自動更新，無需手動呼叫 `LoadData()` 方法。

## 架構設計

### 1. 通知服務 (`DataChangeNotificationService`)

位置：`FPCService/Services/DataChangeNotificationService.cs`

這是一個單例 (Singleton) 服務，負責管理和發送資料變更事件。

```csharp
public class DataChangeNotificationService
{
	// 定義各種資料表的變更事件
	public event Action? MainMobileRobotChanged;
	public event Action? DetailMobileRobotChanged;
	public event Action? MobileRobotPointChanged;
	public event Action? QueueMobileRobotChanged;
	public event Action? LogMobileRobotChanged;

	// 通知方法
	public void NotifyMainMobileRobotChanged() => MainMobileRobotChanged?.Invoke();
	// ... 其他通知方法
}
```

### 2. DI 註冊

在 `ServiceCollectionExtensions.cs` 中註冊為 Singleton：

```csharp
services.AddSingleton<DataChangeNotificationService>();
```

### 3. Service 層實作

在 `MobileRobotService.cs` 中：

```csharp
public class MobileRobotService
{
	private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
	private readonly DataChangeNotificationService _notificationService;

	public MobileRobotService(
		IDbContextFactory<DSDBContext> dbContextFactory,
		DataChangeNotificationService notificationService)
	{
		_dbContextFactory = dbContextFactory;
		_notificationService = notificationService;
	}

	public async Task<bool> InsertMainMobileRobotAsync(MainMobileRobot entity)
	{
		await using var db = await _dbContextFactory.CreateDbContextAsync();
		db.MainMobileRobot.Add(entity);
		var result = await db.SaveChangesAsync() > 0;

		// 資料變更後發送通知
		if (result) _notificationService.NotifyMainMobileRobotChanged();

		return result;
	}
}
```

### 4. UI 頁面實作

在 Blazor 頁面中（例如 `MainMobileRobotPage.razor`）：

```razor
@page "/mobilerobot/main"
@using FPCService.Services
@inject DataChangeNotificationService NotificationService
@implements IDisposable

@code {
	protected override async Task OnInitializedAsync()
	{
		await LoadData();
		// 訂閱資料變更事件
		NotificationService.MainMobileRobotChanged += OnDataChanged;
	}

	private async void OnDataChanged()
	{
		// 使用 InvokeAsync 確保在正確的同步上下文中執行
		await InvokeAsync(async () =>
		{
			await LoadData();
			StateHasChanged();  // 通知 Blazor 重新渲染
		});
	}

	// 實作 IDisposable 以清理事件訂閱
	public void Dispose()
	{
		NotificationService.MainMobileRobotChanged -= OnDataChanged;
	}

	private async Task SaveRobot()
	{
		// ... 執行儲存

		if (success)
		{
			isPopupVisible = false;
			// 不需要手動呼叫 LoadData，通知機制會自動觸發
		}
	}
}
```

## 優點

1. **降低耦合度**：頁面不需要知道何時需要重新載入資料
2. **自動同步**：多個頁面可以同時顯示相同資料並保持同步
3. **維護性佳**：資料變更邏輯集中在 Service 層
4. **程式碼簡潔**：移除重複的 `LoadData()` 呼叫

## 注意事項

### 1. 執行緒安全

事件處理器使用 `InvokeAsync` 確保在 Blazor 的同步上下文中執行：

```csharp
private async void OnDataChanged()
{
	await InvokeAsync(async () =>
	{
		await LoadData();
		StateHasChanged();
	});
}
```

### 2. 記憶體洩漏防護

**必須**實作 `IDisposable` 並取消事件訂閱：

```csharp
@implements IDisposable

public void Dispose()
{
	NotificationService.MainMobileRobotChanged -= OnDataChanged;
}
```

### 3. 跨頁面通知

因為通知服務是 Singleton，所有頁面共用同一個實例。如果多個頁面同時開啟並訂閱同一個事件，它們都會收到通知並更新。

## 擴展指南

### 新增其他領域的通知

1. 在 `DataChangeNotificationService` 中新增事件：

```csharp
public event Action? NewDomainChanged;
public void NotifyNewDomainChanged() => NewDomainChanged?.Invoke();
```

2. 在對應的 Service 中注入並使用：

```csharp
if (result) _notificationService.NotifyNewDomainChanged();
```

3. 在頁面中訂閱和取消訂閱：

```csharp
NotificationService.NewDomainChanged += OnDataChanged;
// ...
NotificationService.NewDomainChanged -= OnDataChanged;
```

## 已實作的通知事件

| 事件名稱 | 觸發時機 | 訂閱頁面 |
|---------|---------|---------|
| `MainMobileRobotChanged` | Main_MobileRobot 資料表變更 | MainMobileRobotPage.razor |
| `DetailMobileRobotChanged` | Detail_MobileRobot 資料表變更 | DetailMobileRobotPage.razor |
| `MobileRobotPointChanged` | MobileRobotPoint 資料表變更 | MobileRobotPointPage.razor |
| `QueueMobileRobotChanged` | Queue_MobileRobot 資料表變更 | QueueMobileRobotPage.razor |
| `LogMobileRobotChanged` | Log_MobileRobot 資料表變更 | LogMobileRobotPage.razor |

## 測試建議

1. **單一頁面測試**：在頁面中執行新增/修改/刪除操作，確認資料能自動更新
2. **多頁面測試**：開啟多個瀏覽器分頁，在一個分頁中修改資料，確認其他分頁也能更新（需要 SignalR 或類似技術才能跨瀏覽器實例）
3. **記憶體測試**：反覆進入和離開頁面，確認沒有記憶體洩漏

## 升級建議

### 未來可考慮的改進

1. **細粒度通知**：傳遞變更的實體 ID，讓訂閱者可以選擇性更新
2. **SignalR 整合**：支援跨用戶端的即時更新
3. **批次通知**：合併短時間內的多次變更，減少 UI 更新次數
4. **條件訂閱**：讓訂閱者指定篩選條件，只接收特定資料的變更通知
