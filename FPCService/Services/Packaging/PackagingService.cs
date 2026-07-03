using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.Packaging
{
    public class PackagingService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public PackagingService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
        }

        #region MainPackaging CRUD

        /// <summary>
        /// 取得全部包裝主檔
        /// </summary>
        public async Task<List<MainPackaging>> GetMainPackagingAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPackaging.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得包裝主檔
        /// </summary>
        public async Task<MainPackaging?> GetMainPackagingByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPackaging.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PackagingUid == uid);
        }

        /// <summary>
        /// 新增包裝主檔
        /// </summary>
        public async Task<bool> InsertMainPackagingAsync(MainPackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPackaging.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainPackagingChanged();
            return result;
        }

        /// <summary>
        /// 更新包裝主檔
        /// </summary>
        public async Task<bool> UpdateMainPackagingAsync(MainPackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPackaging.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainPackagingChanged();
            return result;
        }

        /// <summary>
        /// 刪除包裝主檔
        /// </summary>
        public async Task<bool> DeleteMainPackagingAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainPackaging.FirstOrDefaultAsync(x => x.PackagingUid == uid);
            if (item == null) return false;

            db.MainPackaging.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainPackagingChanged();
            return result;
        }

        #endregion

        #region DetialPackaging CRUD

        /// <summary>
        /// 取得全部包裝事件明細
        /// </summary>
        public async Task<List<DetialPackaging>> GetDetialPackagingAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialPackaging.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得包裝事件明細
        /// </summary>
        public async Task<DetialPackaging?> GetDetialPackagingByUidAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.DetialPackaging.AsNoTracking()
                .FirstOrDefaultAsync(x => x.UID == uid);
        }

        /// <summary>
        /// 新增包裝事件明細
        /// </summary>
        public async Task<bool> InsertDetialPackagingAsync(DetialPackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.DetialPackaging.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialPackagingChanged();
            return result;
        }

        /// <summary>
        /// 刪除包裝事件明細
        /// </summary>
        public async Task<bool> DeleteDetialPackagingAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.DetialPackaging.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.DetialPackaging.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyDetialPackagingChanged();
            return result;
        }

        #endregion

        #region QueuePackaging CRUD

        /// <summary>
        /// 取得全部包裝佇列
        /// </summary>
        public async Task<List<QueuePackaging>> GetQueuePackagingAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.QueuePackaging.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增包裝佇列
        /// </summary>
        public async Task<bool> InsertQueuePackagingAsync(QueuePackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueuePackaging.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueuePackagingChanged();
            return result;
        }

        /// <summary>
        /// 更新包裝佇列
        /// </summary>
        public async Task<bool> UpdateQueuePackagingAsync(QueuePackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.QueuePackaging.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueuePackagingChanged();
            return result;
        }

        /// <summary>
        /// 刪除包裝佇列
        /// </summary>
        public async Task<bool> DeleteQueuePackagingAsync(int uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.QueuePackaging.FirstOrDefaultAsync(x => x.UID == uid);
            if (item == null) return false;

            db.QueuePackaging.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyQueuePackagingChanged();
            return result;
        }

        #endregion

        #region LogPackaging CRUD

        /// <summary>
        /// 取得全部包裝紀錄
        /// </summary>
        public async Task<List<LogPackaging>> GetLogPackagingAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.LogPackaging.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 新增包裝紀錄
        /// </summary>
        public async Task<bool> InsertLogPackagingAsync(LogPackaging entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.LogPackaging.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyLogPackagingChanged();
            return result;
        }

        #endregion
    }
}
