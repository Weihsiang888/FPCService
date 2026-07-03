using FPCService.Data;
using Microsoft.EntityFrameworkCore;

namespace FPCService.Services.Place
{
    public class PlaceService
    {
        private readonly IDbContextFactory<DSDBContext> _dbContextFactory;

        public PlaceService(IDbContextFactory<DSDBContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        #region MainPlace CRUD

        /// <summary>
        /// 取得全部場域主檔
        /// </summary>
        public async Task<List<MainPlace>> GetMainPlaceAsync()
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPlace.AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// 依 UID 取得場域主檔
        /// </summary>
        public async Task<MainPlace?> GetMainPlaceByUidAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            return await db.MainPlace.AsNoTracking()
                .FirstOrDefaultAsync(x => x.PlaceUid == uid);
        }

        /// <summary>
        /// 新增場域主檔
        /// </summary>
        public async Task<bool> InsertMainPlaceAsync(MainPlace entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPlace.Add(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 更新場域主檔
        /// </summary>
        public async Task<bool> UpdateMainPlaceAsync(MainPlace entity)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            db.MainPlace.Update(entity);
            return await db.SaveChangesAsync() > 0;
        }

        /// <summary>
        /// 刪除場域主檔
        /// </summary>
        public async Task<bool> DeleteMainPlaceAsync(string uid)
        {
            await using var db = await _dbContextFactory.CreateDbContextAsync();
            var item = await db.MainPlace.FirstOrDefaultAsync(x => x.PlaceUid == uid);
            if (item == null) return false;

            db.MainPlace.Remove(item);
            return await db.SaveChangesAsync() > 0;
        }

        #endregion
    }
}
