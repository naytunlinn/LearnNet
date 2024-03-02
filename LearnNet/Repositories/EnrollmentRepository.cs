using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class EnrollmentRepository : IRepository<EnrollmentEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public EnrollmentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(EnrollmentEntity entity)
        {
            _applicationDbContext.Enrollments.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var enrollmentEntity = await _applicationDbContext.Enrollments.FindAsync(Id);
                if (enrollmentEntity != null)
                {
                    _applicationDbContext.Enrollments.Remove(enrollmentEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<EnrollmentEntity>> GetAll()
        {
            return await _applicationDbContext.Enrollments.ToListAsync();
        }

        public async Task<EnrollmentEntity> GetById(string Id)
        {
            var enrollment = await _applicationDbContext.Enrollments.FirstOrDefaultAsync(m => m.EnrollmentId == Id);
            if (enrollment == null)
            {
                throw new Exception("No Enrollment Data To Show");
            }
            return enrollment;
        }

        public async Task Update(EnrollmentEntity entity)
        {
            _applicationDbContext.Enrollments.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}