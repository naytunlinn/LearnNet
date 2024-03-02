using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class AssessmentRepository : IRepository<AssessmentEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public AssessmentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(AssessmentEntity entity)
        {
            _applicationDbContext.Assessments.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var assessmentEntity = await _applicationDbContext.Assessments.FindAsync(Id);
                if (assessmentEntity != null)
                {
                    _applicationDbContext.Assessments.Remove(assessmentEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<AssessmentEntity>> GetAll()
        {
            return await _applicationDbContext.Assessments.ToListAsync();
        }

        public async Task<AssessmentEntity> GetById(string Id)
        {
            var assessment = await _applicationDbContext.Assessments.FirstOrDefaultAsync(m => m.AssessmentId == Id);
            if (assessment == null)
            {
                throw new Exception("No Assessment Data To Show");
            }
            return assessment;
        }

        public async Task Update(AssessmentEntity entity)
        {
            _applicationDbContext.Assessments.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}