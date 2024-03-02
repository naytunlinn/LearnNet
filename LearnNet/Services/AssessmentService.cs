using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class AssessmentService : IService<AssessmentViewModel>
    {
        private readonly IRepository<AssessmentEntity> _assessmentRepository;

        public AssessmentService(IRepository<AssessmentEntity> assessmentRepository)
        {
            this._assessmentRepository = assessmentRepository;
        }
        public async Task Create(AssessmentViewModel assessmentViewModel)
        {
            try
            {
                var assessments = await _assessmentRepository.GetAll();
                var Isexists = assessments.Any(w => w.Title == assessmentViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var assessment = new AssessmentEntity()
                {
                    AssessmentId = Guid.NewGuid().ToString(),
                    Title = assessmentViewModel.Title,
                    CourseId = assessmentViewModel.CourseId,
                    DueDate = assessmentViewModel.DueDate
                };
                await _assessmentRepository.Create(assessment);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _assessmentRepository.Delete(id);
        }

        public async Task<IList<AssessmentViewModel>> GetAll()
        {
            var assessments = await _assessmentRepository.GetAll();
            return assessments.Select(s => new AssessmentViewModel
            {
                AssessmentId = Guid.NewGuid().ToString(),
                Title = s.Title,
                CourseId = s.CourseId,
                DueDate = s.DueDate
            }).ToList();

        }

        public async Task<AssessmentViewModel> GetById(string id)
        {
            var assessmentEntity = await _assessmentRepository.GetById(id);
            return new AssessmentViewModel()
            {
                AssessmentId = assessmentEntity.AssessmentId,
                Title = assessmentEntity.Title,
                CourseId = assessmentEntity.CourseId,
                DueDate = assessmentEntity.DueDate
            };
        }

        public async Task Update(AssessmentViewModel assessmentViewModel)
        {
            try
            {
                var assessments = await _assessmentRepository.GetAll();
                var Isexist = assessments.Where(w => w.Title == assessmentViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var assessment = new AssessmentEntity()
                {
                    AssessmentId = assessmentViewModel.AssessmentId,
                    Title = assessmentViewModel.Title,
                    CourseId = assessmentViewModel.CourseId,
                    DueDate = assessmentViewModel.DueDate,
                    ModifiedAt = DateTime.Now
                };
                await _assessmentRepository.Update(assessment);
            }
            catch (Exception ex)
            {

                throw new Exception("Title already exists in the System.");
            }
        }

        //public void Create(AssessmentViewModel assessmentViewModel)
        //{
        //    try
        //    {
        //        var IsAssessmentTitleAlreadyExists = _assessmentRepository.GetAll().Where(w => w.Title == assessmentViewModel.Title).Any();
        //        if (IsAssessmentTitleAlreadyExists)
        //        {
        //            throw new Exception("Title already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var assessment = new AssessmentEntity()
        //        {
        //            AssessmentId = Guid.NewGuid().ToString(),
        //            Title = assessmentViewModel.Title,
        //            CourseId = assessmentViewModel.CourseId,
        //            DueDate = assessmentViewModel.DueDate
        //        };
        //        _assessmentRepository.Create(assessment);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _assessmentRepository.Delete(id);
        //}

        //public IList<AssessmentViewModel> GetAll()
        //{
        //    return _assessmentRepository.GetAll().Select(
        //         s => new AssessmentViewModel
        //         {
        //             AssessmentId = Guid.NewGuid().ToString(),
        //             Title = s.Title,
        //             CourseId = s.CourseId,
        //             DueDate = s.DueDate
        //         }).ToList();
        //}

        //public AssessmentViewModel GetById(string id)
        //{
        //    var assessmentEntity = _assessmentRepository.GetById(id);
        //    return new AssessmentViewModel()
        //    {
        //        AssessmentId = Guid.NewGuid().ToString(),
        //        Title = assessmentEntity.Title,
        //        CourseId = assessmentEntity.CourseId,
        //        DueDate = assessmentEntity.DueDate
        //    };
        //}

        //public void Update(AssessmentViewModel assessmentViewModel)
        //{
        //    var assessment = new AssessmentEntity()
        //    {
        //        AssessmentId = Guid.NewGuid().ToString(),
        //        Title = assessmentViewModel.Title,
        //        CourseId = assessmentViewModel.CourseId,
        //        DueDate = assessmentViewModel.DueDate,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _assessmentRepository.Update(assessment);
        //}
    }
}