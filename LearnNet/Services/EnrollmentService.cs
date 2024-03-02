using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class EnrollmentService : IService<EnrollmentViewModel>
    {
        private readonly IRepository<EnrollmentEntity> _enrollmentRepository;

        public EnrollmentService(IRepository<EnrollmentEntity> enrollmentRepository)
        {
            this._enrollmentRepository = enrollmentRepository;
        }
        public async Task Create(EnrollmentViewModel enrollmentViewModel)
        {
            try
            {
               
                //Data exchange from view model to data model
                var enrollment = new EnrollmentEntity()
                {
                    EnrollmentId = Guid.NewGuid().ToString(),
                    StudentId = enrollmentViewModel.StudenId,
                    CourseId = enrollmentViewModel.CourseId,
                    EnrollmentDate = enrollmentViewModel.EnrollmentDate,
                };
                await _enrollmentRepository.Create(enrollment);
            }
            catch (Exception ex)
            {
                throw;// new Exception("Email already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _enrollmentRepository.Delete(id);
        }

        public async Task<IList<EnrollmentViewModel>> GetAll()
        {
            var enrollments = await _enrollmentRepository.GetAll();
            return enrollments.Select(s => new EnrollmentViewModel
            {
                EnrollmentId = s.EnrollmentId,
                StudenId = s.StudentId,
                CourseId = s.CourseId,
                EnrollmentDate = s.EnrollmentDate,
            }).ToList();

        }

        public async Task<EnrollmentViewModel> GetById(string id)
        {
            var enrollmentEntity = await _enrollmentRepository.GetById(id);
            return new EnrollmentViewModel()
            {
                EnrollmentId = enrollmentEntity.EnrollmentId,
                StudenId = enrollmentEntity.StudentId,
                CourseId = enrollmentEntity.CourseId,
                EnrollmentDate = enrollmentEntity.EnrollmentDate,
            };
        }

        public async Task Update(EnrollmentViewModel enrollmentViewModel)
        {
            try
            {
               
                var enrollment = new EnrollmentEntity()
                {
                    EnrollmentId = enrollmentViewModel.EnrollmentId,
                    StudentId = enrollmentViewModel.StudenId,
                    CourseId = enrollmentViewModel.CourseId,
                    EnrollmentDate = enrollmentViewModel.EnrollmentDate,
                    ModifiedAt = DateTime.Now
                };
                await _enrollmentRepository.Update(enrollment);
            }
            catch (Exception ex)
            {

                throw;// new Exception("Email already exists in the System.");
            }
        }
        //public void Create(EnrollmentViewModel enrollmentViewModel)
        //{
        //    try
        //    {
        //        //var IsEnrollmentAlreadyExist = _enrollmentRepository.GetAll().Where(w => w.Title == enrollmentViewModel.Title).Any();
        //        //if (IsEnrollmentAlreadyExist)
        //        //{
        //        //    throw new Exception("Title already exists in the System.");
        //        //}
        //        //Data exchange from view model to data model
        //        var enrollment = new EnrollmentEntity()
        //        {
        //            EnrollmentId = Guid.NewGuid().ToString(),
        //            UserId = enrollmentViewModel.UserId,
        //            CourseId = enrollmentViewModel.CourseId,
        //            EnrollmentDate = enrollmentViewModel.EnrollmentDate,
        //        };
        //        _enrollmentRepository.Create(enrollment);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _enrollmentRepository.Delete(id);
        //}

        //public IList<EnrollmentViewModel> GetAll()
        //{
        //    return _enrollmentRepository.GetAll().Select(
        //         s => new EnrollmentViewModel
        //         {
        //             EnrollmentId = s.EnrollmentId,
        //             UserId = s.UserId,
        //             CourseId = s.CourseId,
        //             EnrollmentDate = s.EnrollmentDate,
        //         }).ToList();
        //}

        //public EnrollmentViewModel GetById(string id)
        //{
        //    var enrollmentEntity = _enrollmentRepository.GetById(id);
        //    return new EnrollmentViewModel()
        //    {
        //        EnrollmentId = enrollmentEntity.EnrollmentId,
        //        UserId = enrollmentEntity.UserId,
        //        CourseId = enrollmentEntity.CourseId,
        //        EnrollmentDate = enrollmentEntity.EnrollmentDate,
        //    };
        //}

        //public void Update(EnrollmentViewModel enrollmentViewModel)
        //{
        //    var enrollment = new EnrollmentEntity()
        //    {
        //        EnrollmentId = Guid.NewGuid().ToString(),
        //        UserId = enrollmentViewModel.UserId,
        //        CourseId = enrollmentViewModel.CourseId,
        //        EnrollmentDate = enrollmentViewModel.EnrollmentDate,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _enrollmentRepository.Update(enrollment);
        //}
    }
}