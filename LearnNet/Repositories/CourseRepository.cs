using LearnNet.DAO;
using LearnNet.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LearnNet.Repositories
{
    public class CourseRepository : IRepository<CourseEntity>
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CourseRepository(ApplicationDbContext applicationDbContext)
        {
            this._applicationDbContext = applicationDbContext;
        }

        public async Task Create(CourseEntity entity)
        {
            _applicationDbContext.Courses.Add(entity);
            await _applicationDbContext.SaveChangesAsync();
        }

        public async Task Delete(string Id)
        {
            if (null != Id)
            {
                var courseEntity = await _applicationDbContext.Courses.FindAsync(Id);
                if (courseEntity != null)
                {
                    _applicationDbContext.Courses.Remove(courseEntity);
                }

                await _applicationDbContext.SaveChangesAsync();
            }
        }

        public async Task<IList<CourseEntity>> GetAll()
        {
            return await _applicationDbContext.Courses.ToListAsync();
        }

        public async Task<CourseEntity> GetById(string Id)
        {
            var course = await _applicationDbContext.Courses.FirstOrDefaultAsync(m => m.CourseId == Id);
            if (course == null)
            {
                throw new Exception("No Course Data To Show");
            }
            return course;
        }

        public async Task Update(CourseEntity entity)
        {
            _applicationDbContext.Courses.Update(entity);
            await _applicationDbContext.SaveChangesAsync();
        }
    }
}