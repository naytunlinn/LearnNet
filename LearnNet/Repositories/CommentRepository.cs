using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class CommentRepository : IRepository<CommentEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CommentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(CommentEntity entity)
        {
            _applicationDbContext.Comments.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var commentEntity = await _applicationDbContext.Comments.FindAsync(Id);
                if (commentEntity != null)
                {
                    _applicationDbContext.Comments.Remove(commentEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<CommentEntity>> GetAll()
        {
            return await _applicationDbContext.Comments.ToListAsync();
        }

        public async Task<CommentEntity> GetById(string Id)
        {
            var comment = await _applicationDbContext.Comments.FirstOrDefaultAsync(m => m.CommentId == Id);
            if (comment == null)
            {
                throw new Exception("No Comment Data To Show");
            }
            return comment;
        }

        public async Task Update(CommentEntity entity)
        {
            _applicationDbContext.Comments.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}