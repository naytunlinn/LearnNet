using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class VideoRepository : IRepository<VideoEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public VideoRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(VideoEntity entity)
        {
            _applicationDbContext.Videos.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var videoEntity = await _applicationDbContext.Videos.FindAsync(Id);
                if (videoEntity != null)
                {
                    _applicationDbContext.Videos.Remove(videoEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<VideoEntity>> GetAll()
        {
            return await _applicationDbContext.Videos.ToListAsync();
        }

        public async Task<VideoEntity> GetById(string Id)
        {
            var video = await _applicationDbContext.Videos.FirstOrDefaultAsync(m => m.VideoId == Id);
            if (video == null)
            {
                throw new Exception("No Video Data To Show");
            }
            return video;
        }

        public async Task Update(VideoEntity entity)
        {
            _applicationDbContext.Videos.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}