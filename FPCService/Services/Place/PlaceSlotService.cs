using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.Place
{
    public class PlaceSlotService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;

        public PlaceSlotService(IDbContextFactory<DSDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region MainPlaceSlot CRUD

        /// <summary>
        /// 取得全部場域插槽主檔
        /// </summary>
        public async Task<List<MainPlaceSlot>> GetMainPlaceSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPlaceSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得場域插槽主檔
        /// </summary>
        public async Task<MainPlaceSlot?> GetMainPlaceSlotByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPlaceSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PlaceSlotUid == uid);
        }

        /// <summary>
        /// 新增場域插槽主檔
        /// </summary>
        public async Task<bool> InsertMainPlaceSlotAsync(MainPlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPlaceSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新場域插槽主檔
        /// </summary>
        public async Task<bool> UpdateMainPlaceSlotAsync(MainPlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPlaceSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除場域插槽主檔
        /// </summary>
        public async Task<bool> DeleteMainPlaceSlotAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainPlaceSlot.FirstOrDefaultAsync(x => x.PlaceSlotUid == uid);
            if (item == null) return false;

            db.MainPlaceSlot.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region DetialPlaceSlot CRUD

        /// <summary>
        /// 取得全部場域插槽事件明細
        /// </summary>
        public async Task<List<DetialPlaceSlot>> GetDetialPlaceSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialPlaceSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得場域插槽事件明細
        /// </summary>
        public async Task<DetialPlaceSlot?> GetDetialPlaceSlotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialPlaceSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增場域插槽事件明細
        /// </summary>
        public async Task<bool> InsertDetialPlaceSlotAsync(DetialPlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialPlaceSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除場域插槽事件明細
        /// </summary>
        public async Task<bool> DeleteDetialPlaceSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialPlaceSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialPlaceSlot.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region QueuePlaceSlot CRUD

        /// <summary>
        /// 取得全部場域插槽佇列
        /// </summary>
        public async Task<List<QueuePlaceSlot>> GetQueuePlaceSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.QueuePlaceSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增場域插槽佇列
        /// </summary>
        public async Task<bool> InsertQueuePlaceSlotAsync(QueuePlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueuePlaceSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新場域插槽佇列
        /// </summary>
        public async Task<bool> UpdateQueuePlaceSlotAsync(QueuePlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueuePlaceSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除場域插槽佇列
        /// </summary>
        public async Task<bool> DeleteQueuePlaceSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.QueuePlaceSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.QueuePlaceSlot.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region LogPlaceSlot CRUD

        /// <summary>
        /// 取得全部場域插槽紀錄
        /// </summary>
        public async Task<List<LogPlaceSlot>> GetLogPlaceSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.LogPlaceSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增場域插槽紀錄
        /// </summary>
        public async Task<bool> InsertLogPlaceSlotAsync(LogPlaceSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.LogPlaceSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
