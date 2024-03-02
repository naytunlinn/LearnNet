using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class StudentRepository : IRepository<StudentEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public StudentRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(StudentEntity entity)
        {
            _applicationDbContext.Students.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var studentEntity = await _applicationDbContext.Students.FindAsync(Id);
                if (studentEntity != null)
                {
                    _applicationDbContext.Students.Remove(studentEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<StudentEntity>> GetAll()
        {
            return await _applicationDbContext.Students.ToListAsync();
        }

        public async Task<StudentEntity> GetById(string Id)
        {
            
            var student = await _applicationDbContext.Students.AsNoTracking().FirstOrDefaultAsync(m => m.StudentId == Id);
            if (student == null)
            {
                throw new Exception("No Student Data To Show");
            }
            return student;
        }

        public async Task Update(StudentEntity entity)
        {
            try
            {
                _applicationDbContext.Update(entity);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
           
        }
    }
}