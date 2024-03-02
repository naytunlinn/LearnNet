using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class CourseService : IService<CourseViewModel>
    {
        private readonly IRepository<CourseEntity> _courseRepository;

        public CourseService(IRepository<CourseEntity> courseRepository)
        {
            this._courseRepository = courseRepository;
        }
        public async Task Create(CourseViewModel courseViewModel)
        {
            try
            {
                var courses = await _courseRepository.GetAll();
                var Isexists = courses.Any(w => w.Title == courseViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var course = new CourseEntity()
                {
                    CourseId = Guid.NewGuid().ToString(),
                    Title = courseViewModel.Title,
                    Description = courseViewModel.Description,
                };
                await _courseRepository.Create(course);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _courseRepository.Delete(id);
        }

        public async Task<IList<CourseViewModel>> GetAll()
        {
            var courses = await _courseRepository.GetAll();
            return courses.Select(s => new CourseViewModel
            {
                CourseId = s.CourseId,
                Title = s.Title,
                Description = s.Description,
            }).ToList();

        }

        public async Task<CourseViewModel> GetById(string id)
        {
            var courseEntity = await _courseRepository.GetById(id);
            return new CourseViewModel()
            {
                CourseId = courseEntity.CourseId,
                Title = courseEntity.Title,
                Description = courseEntity.Description,
            };
        }

        public async Task Update(CourseViewModel courseViewModel)
        {
            try
            {
                var courses = await _courseRepository.GetAll();
                var Isexist = courses.Where(w => w.Title == courseViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var course = new CourseEntity()
                {
                    CourseId = courseViewModel.CourseId,
                    Title = courseViewModel.Title,
                    Description = courseViewModel.Description,
                    ModifiedAt = DateTime.Now
                };
                await _courseRepository.Update(course);
            }
            catch (Exception ex)
            {

                throw new Exception("Title already exists in the System.");
            }
        }
        //public void Create(CourseViewModel courseViewModel)
        //{
        //    try
        //    {
        //        var IsCourseAlreadyExist = _courseRepository.GetAll().Where(w => w.Title == courseViewModel.Title).Any();
        //        if (IsCourseAlreadyExist)
        //        {
        //            throw new Exception("Title already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var course = new CourseEntity()
        //        {
        //            CourseId = Guid.NewGuid().ToString(),
        //            Title = courseViewModel.Title,
        //            Description = courseViewModel.Description,
        //        };
        //        _courseRepository.Create(course);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _courseRepository.Delete(id);
        //}

        //public IList<CourseViewModel> GetAll()
        //{
        //    return _courseRepository.GetAll().Select(
        //         s => new CourseViewModel
        //         {
        //             CourseId = s.CourseId,
        //             Title = s.Title,
        //             Description = s.Description,
        //         }).ToList();
        //}

        //public CourseViewModel GetById(string id)
        //{
        //    var courseEntity = _courseRepository.GetById(id);
        //    return new CourseViewModel()
        //    {
        //        CourseId = courseEntity.CourseId,
        //        Title = courseEntity.Title,
        //        Description = courseEntity.Description,
        //    };
        //}

        //public void Update(CourseViewModel courseViewModel)
        //{
        //    var course = new CourseEntity()
        //    {
        //        CourseId = Guid.NewGuid().ToString(),
        //        Title = courseViewModel.Title,
        //        Description = courseViewModel.Description,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _courseRepository.Update(course);
        //}
    }
}