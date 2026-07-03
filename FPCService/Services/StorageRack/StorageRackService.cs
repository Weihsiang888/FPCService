using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.StorageRack
{
    public class StorageRackService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;
        private readonly DataChangeNotificationService _notificationService;

        public StorageRackService(
            IDbContextFactory<DSDBContext> dbContextFactory,
            DataChangeNotificationService notificationService)
        {
            _dbContextFactory = dbContextFactory;
            _notificationService = notificationService;
        }

        #region MainStorageRack CRUD

        /// <summary>
        /// 取得全部儲存架主檔
        /// </summary>
        public async Task<List<MainStorageRack>> GetMainStorageRackAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainStorageRack.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得儲存架主檔
        /// </summary>
        public async Task<MainStorageRack?> GetMainStorageRackByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainStorageRack.AsNoTracking()
                .FirstOrDefaultAsync(x => x.StorageRackUid == uid);
        }

        /// <summary>
        /// 新增儲存架主檔
        /// </summary>
        public async Task<bool> InsertMainStorageRackAsync(MainStorageRack entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainStorageRack.Add(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainStorageRackChanged();
            return result;
        }

        /// <summary>
        /// 更新儲存架主檔
        /// </summary>
        public async Task<bool> UpdateMainStorageRackAsync(MainStorageRack entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainStorageRack.Update(entity);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainStorageRackChanged();
            return result;
        }

        /// <summary>
        /// 刪除儲存架主檔
        /// </summary>
        public async Task<bool> DeleteMainStorageRackAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainStorageRack.FirstOrDefaultAsync(x => x.StorageRackUid == uid);
            if (item == null) return false;

            db.MainStorageRack.Remove(item);
            var result = await db.SaveChangesAsync() > 0;
            if (result) _notificationService.NotifyMainStorageRackChanged();
            return result;
        }

        #endregion
    }
}
