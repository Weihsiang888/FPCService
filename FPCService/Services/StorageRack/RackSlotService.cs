using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.StorageRack
{
    public class RackSlotService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public RackSlotService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
        }

        #region MainRackSlot CRUD

        /// <summary>
        /// 取得全部儲存架插槽主檔
        /// </summary>
        public async Task<List<MainRackSlot>> GetMainRackSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainRackSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得儲存架插槽主檔
        /// </summary>
        public async Task<MainRackSlot?> GetMainRackSlotByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainRackSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.RackSlotUid == uid);
        }

        /// <summary>
        /// 新增儲存架插槽主檔
        /// </summary>
        public async Task<bool> InsertMainRackSlotAsync(MainRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainRackSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainRackSlotChanged();
            return result;
        }

        /// <summary>
        /// 更新儲存架插槽主檔
        /// </summary>
        public async Task<bool> UpdateMainRackSlotAsync(MainRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainRackSlot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainRackSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除儲存架插槽主檔
        /// </summary>
        public async Task<bool> DeleteMainRackSlotAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainRackSlot.FirstOrDefaultAsync(x => x.RackSlotUid == uid);
            if (item == null) return false;

            db.MainRackSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainRackSlotChanged();
            return result;
        }

        #endregion

        #region DetailRackSlot CRUD

        /// <summary>
        /// 取得全部儲存架插槽事件明細
        /// </summary>
        public async Task<List<DetailRackSlot>> GetDetailRackSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailRackSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得儲存架插槽事件明細
        /// </summary>
        public async Task<DetailRackSlot?> GetDetailRackSlotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailRackSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增儲存架插槽事件明細
        /// </summary>
        public async Task<bool> InsertDetailRackSlotAsync(DetailRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetailRackSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailRackSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除儲存架插槽事件明細
        /// </summary>
        public async Task<bool> DeleteDetailRackSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetailRackSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetailRackSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailRackSlotChanged();
            return result;
        }

        #endregion

        #region QueueRackSlot CRUD

        /// <summary>
        /// 取得全部儲存架插槽佇列
        /// </summary>
        public async Task<List<QueueRackSlot>> GetQueueRackSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.QueueRackSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增儲存架插槽佇列
        /// </summary>
        public async Task<bool> InsertQueueRackSlotAsync(QueueRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueRackSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueRackSlotChanged();
            return result;
        }

        /// <summary>
        /// 更新儲存架插槽佇列
        /// </summary>
        public async Task<bool> UpdateQueueRackSlotAsync(QueueRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueRackSlot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueRackSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除儲存架插槽佇列
        /// </summary>
        public async Task<bool> DeleteQueueRackSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.QueueRackSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.QueueRackSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueRackSlotChanged();
            return result;
        }

        #endregion

        #region LogRackSlot CRUD

        /// <summary>
        /// 取得全部儲存架插槽紀錄
        /// </summary>
        public async Task<List<LogRackSlot>> GetLogRackSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.LogRackSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增儲存架插槽紀錄
        /// </summary>
        public async Task<bool> InsertLogRackSlotAsync(LogRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.LogRackSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyLogRackSlotChanged();
            return result;
        }

        #endregion
    }
}
