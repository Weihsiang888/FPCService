using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.StorageRack
{
    public class RackSlotService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;

        public RackSlotService(IDbContextFactory<DSDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
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
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新儲存架插槽主檔
        /// </summary>
        public async Task<bool> UpdateMainRackSlotAsync(MainRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainRackSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region DetialRackSlot CRUD

        /// <summary>
        /// 取得全部儲存架插槽事件明細
        /// </summary>
        public async Task<List<DetialRackSlot>> GetDetialRackSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialRackSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得儲存架插槽事件明細
        /// </summary>
        public async Task<DetialRackSlot?> GetDetialRackSlotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialRackSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增儲存架插槽事件明細
        /// </summary>
        public async Task<bool> InsertDetialRackSlotAsync(DetialRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialRackSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除儲存架插槽事件明細
        /// </summary>
        public async Task<bool> DeleteDetialRackSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialRackSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialRackSlot.Remove(item);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新儲存架插槽佇列
        /// </summary>
        public async Task<bool> UpdateQueueRackSlotAsync(QueueRackSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueRackSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
