using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class SubmissionService : IService<SubmissionViewModel>
    {
        private readonly IRepository<SubmissionEntity> _submissionRepository;

        public SubmissionService(IRepository<SubmissionEntity> submissionRepository)
        {
            this._submissionRepository = submissionRepository;
        }

        public async Task Create(SubmissionViewModel submissionViewModel)
        {
            try
            {
                //Data exchange from view model to data model
                var submission = new SubmissionEntity()
                {
                    SubmissionId = Guid.NewGuid().ToString(),

                    AssessmentId = submissionViewModel.AssessmentId,
                    SubmissionDate = submissionViewModel.SubmissionDate,
                };
                await _submissionRepository.Create(submission);
            }
            catch (Exception ex)
            {
                throw;// new Exception("Email already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _submissionRepository.Delete(id);
        }

        public async Task<IList<SubmissionViewModel>> GetAll()
        {
            var submissions = await _submissionRepository.GetAll();
            return submissions.Select(s => new SubmissionViewModel
            {
                SubmissionId = s.SubmissionId,
                AssessmentId = s.AssessmentId,
                SubmissionDate = s.SubmissionDate,
            }).ToList();
        }

        public async Task<SubmissionViewModel> GetById(string id)
        {
            var submissionEntity = await _submissionRepository.GetById(id);
            return new SubmissionViewModel()
            {
                SubmissionId = submissionEntity.SubmissionId,

                AssessmentId = submissionEntity.AssessmentId,
                SubmissionDate = submissionEntity.SubmissionDate,
            };
        }

        public async Task Update(SubmissionViewModel submissionViewModel)
        {
            try
            {
                var submission = new SubmissionEntity()
                {
                    SubmissionId = submissionViewModel.SubmissionId,
                    AssessmentId = submissionViewModel.AssessmentId,
                    SubmissionDate = submissionViewModel.SubmissionDate,
                    ModifiedAt = DateTime.Now
                };
                await _submissionRepository.Update(submission);
            }
            catch (Exception ex)
            {
                throw;// new Exception("Email already exists in the System.");
            }
        }

        //public void Create(SubmissionViewModel submissionViewModel)
        //{
        //    try
        //    {
        //        //var IsSubmissionAlreadyExist = _submissionRepository.GetAll().Where(w => w.Title == submissionViewModel.Title).Any();
        //        //if (IsSubmissionAlreadyExist)
        //        //{
        //        //    throw new Exception("Title already exists in the System.");
        //        //}
        //        //Data exchange from view model to data model
        //        var submission = new SubmissionEntity()
        //        {
        //            SubmissionId = Guid.NewGuid().ToString(),
        //            SubmissionId = submissionViewModel.StudenId,
        //            AssessmentId = submissionViewModel.AssessmentId,
        //            SubmissionDate = submissionViewModel.SubmissionDate,
        //        };
        //        _submissionRepository.Create(submission);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _submissionRepository.Delete(id);
        //}

        //public IList<SubmissionViewModel> GetAll()
        //{
        //    return _submissionRepository.GetAll().Select(
        //         s => new SubmissionViewModel
        //         {
        //             SubmissionId = s.SubmissionId,
        //             StudenId = s.UserId,
        //             AssessmentId = s.AssessmentId,
        //             SubmissionDate = s.SubmissionDate,
        //         }).ToList();
        //}

        //public SubmissionViewModel GetById(string id)
        //{
        //    var submissionEntity = _submissionRepository.GetById(id);
        //    return new SubmissionViewModel()
        //    {
        //        SubmissionId = submissionEntity.SubmissionId,
        //        StudenId = submissionEntity.UserId,
        //        AssessmentId = submissionEntity.AssessmentId,
        //        SubmissionDate = submissionEntity.SubmissionDate,
        //    };
        //}

        //public void Update(SubmissionViewModel submissionViewModel)
        //{
        //    var submission = new SubmissionEntity()
        //    {
        //        SubmissionId = Guid.NewGuid().ToString(),
        //        SubmissionId = submissionViewModel.StudenId,
        //        AssessmentId = submissionViewModel.AssessmentId,
        //        SubmissionDate = submissionViewModel.SubmissionDate,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _submissionRepository.Update(submission);
        //}
    }
}