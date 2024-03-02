using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class DiscussionForumService : IService<DiscussionForumViewModel>
    {
        private readonly IRepository<DiscussionForumEntity> _discussionforumRepository;

        public DiscussionForumService(IRepository<DiscussionForumEntity> discussionforumRepository)
        {
            this._discussionforumRepository = discussionforumRepository;
        }
        public async Task Create(DiscussionForumViewModel discussionforumViewModel)
        {
            try
            {
                var discussionforums = await _discussionforumRepository.GetAll();
                var Isexists = discussionforums.Any(w => w.Title == discussionforumViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var discussionforum = new DiscussionForumEntity()
                {
                    DiscussionForumId = Guid.NewGuid().ToString(),
                    Title = discussionforumViewModel.Title,
                    CourseId = discussionforumViewModel.CourseId,
                };
                await _discussionforumRepository.Create(discussionforum);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _discussionforumRepository.Delete(id);
        }

        public async Task<IList<DiscussionForumViewModel>> GetAll()
        {
            var discussionforums = await _discussionforumRepository.GetAll();
            return discussionforums.Select(s => new DiscussionForumViewModel
            {
                DiscussionForumId = s.DiscussionForumId,
                Title = s.Title,
                CourseId = s.CourseId,
            }).ToList();

        }

        public async Task<DiscussionForumViewModel> GetById(string id)
        {
            var discussionforumEntity = await _discussionforumRepository.GetById(id);
            return new DiscussionForumViewModel()
            {
                DiscussionForumId = discussionforumEntity.DiscussionForumId,
                Title = discussionforumEntity.Title,
                CourseId = discussionforumEntity.CourseId,
            };
        }

        public async Task Update(DiscussionForumViewModel discussionforumViewModel)
        {
            try
            {
                var discussionforums = await _discussionforumRepository.GetAll();
                var Isexist = discussionforums.Where(w => w.Title == discussionforumViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var discussionforum = new DiscussionForumEntity()
                {
                    DiscussionForumId = discussionforumViewModel.DiscussionForumId,
                    Title = discussionforumViewModel.Title,
                    CourseId = discussionforumViewModel.CourseId,
                    ModifiedAt = DateTime.Now
                };
                await _discussionforumRepository.Update(discussionforum);
            }
            catch (Exception ex)
            {

                throw new Exception("Title already exists in the System.");
            }
        }
        //public void Create(DiscussionForumViewModel discussionforumViewModel)
        //{
        //    try
        //    {
        //        var IsDiscussionForumAlreadyExist = _discussionforumRepository.GetAll().Where(w => w.Title == discussionforumViewModel.Title).Any();
        //        if (IsDiscussionForumAlreadyExist)
        //        {
        //            throw new Exception("Title already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var discussionforum = new DiscussionForumEntity()
        //        {
        //            DiscussionForumId = Guid.NewGuid().ToString(),
        //            Title = discussionforumViewModel.Title,
        //            CourseId = discussionforumViewModel.CourseId,
        //        };
        //        _discussionforumRepository.Create(discussionforum);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _discussionforumRepository.Delete(id);
        //}

        //public IList<DiscussionForumViewModel> GetAll()
        //{
        //    return _discussionforumRepository.GetAll().Select(
        //         s => new DiscussionForumViewModel
        //         {
        //             DiscussionForumId = s.DiscussionForumId,
        //             Title = s.Title,
        //             CourseId = s.CourseId,
        //         }).ToList();
        //}

        //public DiscussionForumViewModel GetById(string id)
        //{
        //    var discussionforumEntity = _discussionforumRepository.GetById(id);
        //    return new DiscussionForumViewModel()
        //    {
        //        DiscussionForumId = discussionforumEntity.DiscussionForumId,
        //        Title = discussionforumEntity.Title,
        //        CourseId = discussionforumEntity.CourseId,
        //    };
        //}

        //public void Update(DiscussionForumViewModel discussionforumViewModel)
        //{
        //    var discussionforum = new DiscussionForumEntity()
        //    {
        //        DiscussionForumId = Guid.NewGuid().ToString(),
        //        Title = discussionforumViewModel.Title,
        //        CourseId = discussionforumViewModel.CourseId,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _discussionforumRepository.Update(discussionforum);
        //}
    }
}