using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.YarnMachine
{
    public class YarnMachineService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public YarnMachineService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
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
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineChanged();
            return result;
        }

        /// <summary>
        /// 更新紡紗機主檔
        /// </summary>
        public async Task<bool> UpdateMainYarnMachineAsync(MainYarnMachine entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainYarnMachine.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineChanged();
            return result;
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
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainYarnMachineChanged();
            return result;
        }

        #endregion

        #region DetailYarnMachine CRUD

        /// <summary>
        /// 取得全部紡紗機事件明細
        /// </summary>
        public async Task<List<DetailYarnMachine>> GetDetailYarnMachineAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailYarnMachine.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紡紗機事件明細
        /// </summary>
        public async Task<DetailYarnMachine?> GetDetailYarnMachineByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetailYarnMachine.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增紡紗機事件明細
        /// </summary>
        public async Task<bool> InsertDetailYarnMachineAsync(DetailYarnMachine entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetailYarnMachine.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailYarnMachineChanged();
            return result;
        }

        /// <summary>
        /// 刪除紡紗機事件明細
        /// </summary>
        public async Task<bool> DeleteDetailYarnMachineAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetailYarnMachine.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetailYarnMachine.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetailYarnMachineChanged();
            return result;
        }

        #endregion
    }
}
