using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.MobileRobot
{
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

        #region MainMobileRobot CRUD

        /// <summary>
        /// 取得全部行動機器人主檔
        /// </summary>
        public async Task<List<MainMobileRobot>> GetMainMobileRobotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainMobileRobot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得行動機器人主檔
        /// </summary>
        public async Task<MainMobileRobot?> GetMainMobileRobotByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainMobileRobot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.MobileRobotUid == uid);
        }

        /// <summary>
        /// 新增行動機器人主檔
        /// </summary>
        public async Task<bool> InsertMainMobileRobotAsync(MainMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainMobileRobot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainMobileRobotChanged();
            return result;
        }

        /// <summary>
        /// 更新行動機器人主檔
        /// </summary>
        public async Task<bool> UpdateMainMobileRobotAsync(MainMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainMobileRobot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainMobileRobotChanged();
            return result;
        }

        /// <summary>
        /// 刪除行動機器人主檔
        /// </summary>
        public async Task<bool> DeleteMainMobileRobotAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainMobileRobot.FirstOrDefaultAsync(x => x.MobileRobotUid == uid);
            if (item == null) return false;

            db.MainMobileRobot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainMobileRobotChanged();
            return result;
        }

        #endregion

        #region DetialMobileRobot CRUD

        /// <summary>
        /// 取得全部行動機器人事件明細
        /// </summary>
        public async Task<List<DetialMobileRobot>> GetDetialMobileRobotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialMobileRobot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得行動機器人事件明細
        /// </summary>
        public async Task<DetialMobileRobot?> GetDetialMobileRobotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialMobileRobot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增行動機器人事件明細
        /// </summary>
        public async Task<bool> InsertDetialMobileRobotAsync(DetialMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialMobileRobot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialMobileRobotChanged();
            return result;
        }

        /// <summary>
        /// 刪除行動機器人事件明細
        /// </summary>
        public async Task<bool> DeleteDetialMobileRobotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialMobileRobot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialMobileRobot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialMobileRobotChanged();
            return result;
        }

        #endregion

        #region MobileRobotPoint CRUD

        /// <summary>
        /// 取得全部行動機器人點位
        /// </summary>
        public async Task<List<MobileRobotPoint>> GetMobileRobotPointAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MobileRobotPoint.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得行動機器人點位
        /// </summary>
        public async Task<MobileRobotPoint?> GetMobileRobotPointByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MobileRobotPoint.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PointCode == uid);
        }

        /// <summary>
        /// 新增行動機器人點位
        /// </summary>
        public async Task<bool> InsertMobileRobotPointAsync(MobileRobotPoint entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MobileRobotPoint.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMobileRobotPointChanged();
            return result;
        }

        /// <summary>
        /// 更新行動機器人點位
        /// </summary>
        public async Task<bool> UpdateMobileRobotPointAsync(MobileRobotPoint entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MobileRobotPoint.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMobileRobotPointChanged();
            return result;
        }

        /// <summary>
        /// 刪除行動機器人點位
        /// </summary>
        public async Task<bool> DeleteMobileRobotPointAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MobileRobotPoint.FirstOrDefaultAsync(x => x.PointCode == uid);
            if (item == null) return false;

            db.MobileRobotPoint.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMobileRobotPointChanged();
            return result;
        }

        #endregion

        #region QueueMobileRobot CRUD

        /// <summary>
        /// 取得全部行動機器人佇列
        /// </summary>
        public async Task<List<QueueMobileRobot>> GetQueueMobileRobotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.QueueMobileRobot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增行動機器人佇列
        /// </summary>
        public async Task<bool> InsertQueueMobileRobotAsync(QueueMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueMobileRobot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueMobileRobotChanged();
            return result;
        }

        /// <summary>
        /// 更新行動機器人佇列
        /// </summary>
        public async Task<bool> UpdateQueueMobileRobotAsync(QueueMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueMobileRobot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueMobileRobotChanged();
            return result;
        }

        /// <summary>
        /// 刪除行動機器人佇列
        /// </summary>
        public async Task<bool> DeleteQueueMobileRobotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.QueueMobileRobot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.QueueMobileRobot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueMobileRobotChanged();
            return result;
        }

        #endregion

        #region LogMobileRobot CRUD

        /// <summary>
        /// 取得全部行動機器人紀錄
        /// </summary>
        public async Task<List<LogMobileRobot>> GetLogMobileRobotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.LogMobileRobot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增行動機器人紀錄
        /// </summary>
        public async Task<bool> InsertLogMobileRobotAsync(LogMobileRobot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.LogMobileRobot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyLogMobileRobotChanged();
            return result;
        }

        #endregion
    }
}
