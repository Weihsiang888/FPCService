using System;

namespace FPCService.Services
{
    /// <summary>
    /// 資料變更通知服務，用於通知 UI 頁面重新載入資料
    /// </summary>
    public class DataChangeNotificationService
    {
        // 定義各種資料表的變更事件

        // MobileRobot 相關事件
        public event Action? MainMobileRobotChanged;
        public event Action? DetialMobileRobotChanged;
        public event Action? MobileRobotPointChanged;
        public event Action? QueueMobileRobotChanged;
        public event Action? LogMobileRobotChanged;

        // Packaging 相關事件
        public event Action? MainPackagingChanged;
        public event Action? DetialPackagingChanged;
        public event Action? QueuePackagingChanged;
        public event Action? LogPackagingChanged;

        // Place 相關事件
        public event Action? MainPlaceChanged;

        // PlaceSlot 相關事件
        public event Action? MainPlaceSlotChanged;
        public event Action? DetialPlaceSlotChanged;
        public event Action? QueuePlaceSlotChanged;
        public event Action? LogPlaceSlotChanged;

        // StorageRack 相關事件
        public event Action? MainStorageRackChanged;

        // RackSlot 相關事件
        public event Action? MainRackSlotChanged;
        public event Action? DetialRackSlotChanged;
        public event Action? QueueRackSlotChanged;
        public event Action? LogRackSlotChanged;

        // YarnMachine 相關事件
        public event Action? MainYarnMachineChanged;
        public event Action? DetialYarnMachineChanged;

        // YarnMachineSlot 相關事件
        public event Action? MainYarnMachineSlotChanged;
        public event Action? DetialYarnMachineSlotChanged;
        public event Action? QueueYarnMachineSlotChanged;
        public event Action? LogYarnMachineSlotChanged;

        // 通知方法 - MobileRobot
        public void NotifyMainMobileRobotChanged() => MainMobileRobotChanged?.Invoke();
        public void NotifyDetialMobileRobotChanged() => DetialMobileRobotChanged?.Invoke();
        public void NotifyMobileRobotPointChanged() => MobileRobotPointChanged?.Invoke();
        public void NotifyQueueMobileRobotChanged() => QueueMobileRobotChanged?.Invoke();
        public void NotifyLogMobileRobotChanged() => LogMobileRobotChanged?.Invoke();

        // 通知方法 - Packaging
        public void NotifyMainPackagingChanged() => MainPackagingChanged?.Invoke();
        public void NotifyDetialPackagingChanged() => DetialPackagingChanged?.Invoke();
        public void NotifyQueuePackagingChanged() => QueuePackagingChanged?.Invoke();
        public void NotifyLogPackagingChanged() => LogPackagingChanged?.Invoke();

        // 通知方法 - Place
        public void NotifyMainPlaceChanged() => MainPlaceChanged?.Invoke();

        // 通知方法 - PlaceSlot
        public void NotifyMainPlaceSlotChanged() => MainPlaceSlotChanged?.Invoke();
        public void NotifyDetialPlaceSlotChanged() => DetialPlaceSlotChanged?.Invoke();
        public void NotifyQueuePlaceSlotChanged() => QueuePlaceSlotChanged?.Invoke();
        public void NotifyLogPlaceSlotChanged() => LogPlaceSlotChanged?.Invoke();

        // 通知方法 - StorageRack
        public void NotifyMainStorageRackChanged() => MainStorageRackChanged?.Invoke();

        // 通知方法 - RackSlot
        public void NotifyMainRackSlotChanged() => MainRackSlotChanged?.Invoke();
        public void NotifyDetialRackSlotChanged() => DetialRackSlotChanged?.Invoke();
        public void NotifyQueueRackSlotChanged() => QueueRackSlotChanged?.Invoke();
        public void NotifyLogRackSlotChanged() => LogRackSlotChanged?.Invoke();

        // 通知方法 - YarnMachine
        public void NotifyMainYarnMachineChanged() => MainYarnMachineChanged?.Invoke();
        public void NotifyDetialYarnMachineChanged() => DetialYarnMachineChanged?.Invoke();

        // 通知方法 - YarnMachineSlot
        public void NotifyMainYarnMachineSlotChanged() => MainYarnMachineSlotChanged?.Invoke();
        public void NotifyDetialYarnMachineSlotChanged() => DetialYarnMachineSlotChanged?.Invoke();
        public void NotifyQueueYarnMachineSlotChanged() => QueueYarnMachineSlotChanged?.Invoke();
        public void NotifyLogYarnMachineSlotChanged() => LogYarnMachineSlotChanged?.Invoke();
    }
}
