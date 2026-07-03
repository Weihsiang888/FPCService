using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.YarnSpool
{
    public class YarnSpoolService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public YarnSpoolService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
        }

        #region YarnSpool CRUD

        /// <summary>
        /// 取得全部紗管
        /// </summary>
        public async Task<List<Data.YarnSpool>> GetYarnSpoolAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.YarnSpool.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得紗管
        /// </summary>
        public async Task<Data.YarnSpool?> GetYarnSpoolByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.YarnSpool.AsNoTracking()
                .FirstOrDefaultAsync(x => x.YarnSpoolUid == uid);
        }

        /// <summary>
        /// 新增紗管
        /// </summary>
        public async Task<bool> InsertYarnSpoolAsync(Data.YarnSpool entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.YarnSpool.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyYarnSpoolChanged();
            return result;
        }

        /// <summary>
        /// 更新紗管
        /// </summary>
        public async Task<bool> UpdateYarnSpoolAsync(Data.YarnSpool entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.YarnSpool.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyYarnSpoolChanged();
            return result;
        }

        /// <summary>
        /// 刪除紗管
        /// </summary>
        public async Task<bool> DeleteYarnSpoolAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.YarnSpool.FirstOrDefaultAsync(x => x.YarnSpoolUid == uid);
            if (item == null) return false;

            db.YarnSpool.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyYarnSpoolChanged();
            return result;
        }

        #endregion
    }
}
