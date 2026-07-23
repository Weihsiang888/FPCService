using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.YarnMachine
{
    public class YarnMachineSlotService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public YarnMachineSlotService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
        }

        #region MainYarnMachineSlot CRUD

        /// <summary>
        /// 取得全部紡紗機插槽主檔
        /// </summary>
        public async Task<List<MainYarnMachineSlot>> GetMainYarnMachineSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainYarnMachineSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機插槽主檔
        /// </summary>
        public async Task<MainYarnMachineSlot?> GetMainYarnMachineSlotByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainYarnMachineSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.YarnMachineSlotUid == uid);
        }

        /// <summary>
        /// 新增紡紗機插槽主檔
        /// </summary>
        public async Task<bool> InsertMainYarnMachineSlotAsync(MainYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachineSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineSlotChanged();
            return result;
        }

        /// <summary>
        /// 更新紡紗機插槽主檔
        /// </summary>
        public async Task<bool> UpdateMainYarnMachineSlotAsync(MainYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachineSlot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除紡紗機插槽主檔
        /// </summary>
        public async Task<bool> DeleteMainYarnMachineSlotAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainYarnMachineSlot.FirstOrDefaultAsync(x => x.YarnMachineSlotUid == uid);
            if (item == null) return false;

            db.MainYarnMachineSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineSlotChanged();
            return result;
        }

        #endregion

        #region DetailYarnMachineSlot CRUD

        /// <summary>
        /// 取得全部紡紗機插槽事件明細
        /// </summary>
        public async Task<List<DetailYarnMachineSlot>> GetDetailYarnMachineSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailYarnMachineSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機插槽事件明細
        /// </summary>
        public async Task<DetailYarnMachineSlot?> GetDetailYarnMachineSlotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailYarnMachineSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增紡紗機插槽事件明細
        /// </summary>
        public async Task<bool> InsertDetailYarnMachineSlotAsync(DetailYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetailYarnMachineSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailYarnMachineSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除紡紗機插槽事件明細
        /// </summary>
        public async Task<bool> DeleteDetailYarnMachineSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetailYarnMachineSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetailYarnMachineSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailYarnMachineSlotChanged();
            return result;
        }

        #endregion

        #region QueueYarnMachineSlot CRUD

        /// <summary>
        /// 取得全部紡紗機插槽佇列
        /// </summary>
        public async Task<List<QueueYarnMachineSlot>> GetQueueYarnMachineSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.QueueYarnMachineSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增紡紗機插槽佇列
        /// </summary>
        public async Task<bool> InsertQueueYarnMachineSlotAsync(QueueYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueYarnMachineSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueYarnMachineSlotChanged();
            return result;
        }

        /// <summary>
        /// 更新紡紗機插槽佇列
        /// </summary>
        public async Task<bool> UpdateQueueYarnMachineSlotAsync(QueueYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueYarnMachineSlot.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueYarnMachineSlotChanged();
            return result;
        }

        /// <summary>
        /// 刪除紡紗機插槽佇列
        /// </summary>
        public async Task<bool> DeleteQueueYarnMachineSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.QueueYarnMachineSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.QueueYarnMachineSlot.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueueYarnMachineSlotChanged();
            return result;
        }

        #endregion

        #region LogYarnMachineSlot CRUD

        /// <summary>
        /// 取得全部紡紗機插槽紀錄
        /// </summary>
        public async Task<List<LogYarnMachineSlot>> GetLogYarnMachineSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.LogYarnMachineSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增紡紗機插槽紀錄
        /// </summary>
        public async Task<bool> InsertLogYarnMachineSlotAsync(LogYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.LogYarnMachineSlot.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyLogYarnMachineSlotChanged();
            return result;
        }

        #endregion
    }
}
