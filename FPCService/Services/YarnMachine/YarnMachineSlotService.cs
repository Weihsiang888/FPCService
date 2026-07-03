using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.YarnMachine
{
    public class YarnMachineSlotService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;

        public YarnMachineSlotService(IDbContextFactory<DSDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
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
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新紡紗機插槽主檔
        /// </summary>
        public async Task<bool> UpdateMainYarnMachineSlotAsync(MainYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachineSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region DetialYarnMachineSlot CRUD

        /// <summary>
        /// 取得全部紡紗機插槽事件明細
        /// </summary>
        public async Task<List<DetialYarnMachineSlot>> GetDetialYarnMachineSlotAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialYarnMachineSlot.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機插槽事件明細
        /// </summary>
        public async Task<DetialYarnMachineSlot?> GetDetialYarnMachineSlotByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialYarnMachineSlot.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增紡紗機插槽事件明細
        /// </summary>
        public async Task<bool> InsertDetialYarnMachineSlotAsync(DetialYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialYarnMachineSlot.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除紡紗機插槽事件明細
        /// </summary>
        public async Task<bool> DeleteDetialYarnMachineSlotAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialYarnMachineSlot.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialYarnMachineSlot.Remove(item);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新紡紗機插槽佇列
        /// </summary>
        public async Task<bool> UpdateQueueYarnMachineSlotAsync(QueueYarnMachineSlot entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueueYarnMachineSlot.Update(entity);
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
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
            return await db.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
