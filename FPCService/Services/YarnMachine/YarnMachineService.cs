using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.YarnMachine
{
    public class YarnMachineService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;

        public YarnMachineService(IDbContextFactory<DSDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region MainYarnMachine CRUD

        /// <summary>
        /// 取得全部紡紗機主檔
        /// </summary>
        public async Task<List<MainYarnMachine>> GetMainYarnMachineAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainYarnMachine.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機主檔
        /// </summary>
        public async Task<MainYarnMachine?> GetMainYarnMachineByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainYarnMachine.AsNoTracking()
                .FirstOrDefaultAsync(x => x.YarnMachineUid == uid);
        }

        /// <summary>
        /// 新增紡紗機主檔
        /// </summary>
        public async Task<bool> InsertMainYarnMachineAsync(MainYarnMachine entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachine.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新紡紗機主檔
        /// </summary>
        public async Task<bool> UpdateMainYarnMachineAsync(MainYarnMachine entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachine.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除紡紗機主檔
        /// </summary>
        public async Task<bool> DeleteMainYarnMachineAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainYarnMachine.FirstOrDefaultAsync(x => x.YarnMachineUid == uid);
            if (item == null) return false;

            db.MainYarnMachine.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion

        #region DetialYarnMachine CRUD

        /// <summary>
        /// 取得全部紡紗機事件明細
        /// </summary>
        public async Task<List<DetialYarnMachine>> GetDetialYarnMachineAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialYarnMachine.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機事件明細
        /// </summary>
        public async Task<DetialYarnMachine?> GetDetialYarnMachineByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialYarnMachine.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增紡紗機事件明細
        /// </summary>
        public async Task<bool> InsertDetialYarnMachineAsync(DetialYarnMachine entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialYarnMachine.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除紡紗機事件明細
        /// </summary>
        public async Task<bool> DeleteDetialYarnMachineAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialYarnMachine.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialYarnMachine.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
