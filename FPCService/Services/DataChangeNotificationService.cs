using System;

namespace FPCService.Services
{
    /// <summary>
    /// 資料變更通知服務，用於通知 UI 頁面重新載入資料
    /// </summary>
    public class DataChangeNotificationService
    {
        // 定義各種資料表的變更事件
        public event Action? MainMobileRobotChanged;
        public event Action? DetialMobileRobotChanged;
        public event Action? MobileRobotPointChanged;
        public event Action? QueueMobileRobotChanged;
        public event Action? LogMobileRobotChanged;

        // 通知方法
        public void NotifyMainMobileRobotChanged() => MainMobileRobotChanged?.Invoke();
        public void NotifyDetialMobileRobotChanged() => DetialMobileRobotChanged?.Invoke();
        public void NotifyMobileRobotPointChanged() => MobileRobotPointChanged?.Invoke();
        public void NotifyQueueMobileRobotChanged() => QueueMobileRobotChanged?.Invoke();
        public void NotifyLogMobileRobotChanged() => LogMobileRobotChanged?.Invoke();
    }
}
