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
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialYarnMachineChanged();
            return result;
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
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialYarnMachineChanged();
            return result;
        }

        #endregion
    }
}
