using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class SubmissionRepository : IRepository<SubmissionEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public SubmissionRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(SubmissionEntity entity)
        {
            _applicationDbContext.Submissions.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var submissionEntity = await _applicationDbContext.Submissions.FindAsync(Id);
                if (submissionEntity != null)
                {
                    _applicationDbContext.Submissions.Remove(submissionEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<SubmissionEntity>> GetAll()
        {
            return await _applicationDbContext.Submissions.ToListAsync();
        }

        public async Task<SubmissionEntity> GetById(string Id)
        {
            var submission = await _applicationDbContext.Submissions.FirstOrDefaultAsync(m => m.SubmissionId == Id);
            if (submission == null)
            {
                throw new Exception("No Submission Data To Show");
            }
            return submission;
        }

        public async Task Update(SubmissionEntity entity)
        {
            _applicationDbContext.Submissions.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}