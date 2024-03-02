using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class PostService : IService<PostViewModel>
    {
        private readonly IRepository<PostEntity> _postRepository;

        public PostService(IRepository<PostEntity> postRepository)
        {
            this._postRepository = postRepository;
        }
        public async Task Create(PostViewModel postViewModel)
        {
            try
            {

                //Data exchange from view model to data model
                var post = new PostEntity()
                {
                    PostId = Guid.NewGuid().ToString(),
                    Content = postViewModel.Content,
                    DiscussionForumId = postViewModel.DiscussionForumId,
                    StudentId = postViewModel.StudentId,
                    PostDate = postViewModel.PostDate
                };
                    await _postRepository.Create(post);
            }
            catch (Exception ex)
            {
                throw;// new Exception("Email already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _postRepository.Delete(id);
        }

        public async Task<IList<PostViewModel>> GetAll()
        {
            var posts = await _postRepository.GetAll();
            return posts.Select(s => new PostViewModel
            {
                PostId = s.PostId,
                Content = s.Content,
                DiscussionForumId = s.DiscussionForumId,
                StudentId = s.StudentId,
                PostDate = s.PostDate
            }).ToList();

        }

        public async Task<PostViewModel> GetById(string id)
        {
            var postEntity = await _postRepository.GetById(id);
            return new PostViewModel()
            {
                PostId = postEntity.PostId,
                Content = postEntity.Content,
                DiscussionForumId = postEntity.DiscussionForumId,
                StudentId = postEntity.StudentId,
                PostDate = postEntity.PostDate
            };
        }

        public async Task Update(PostViewModel postViewModel)
        {
            try
            {
                
                var post = new PostEntity()
                {
                    PostId = postViewModel.PostId,
                    Content = postViewModel.Content,
                    DiscussionForumId = postViewModel.DiscussionForumId,
                    StudentId = postViewModel.StudentId,
                    PostDate = postViewModel.PostDate,
                    ModifiedAt = DateTime.Now
                };
                await _postRepository.Update(post);
            }
            catch (Exception ex)
            {

                throw;// new Exception("Email already exists in the System.");
            }
        }
        //public void Create(PostViewModel postViewModel)
        //{
        //    try
        //    {
        //        //var IsPostAlreadyExist = _postRepository.GetAll().Where(w => w.Title == postViewModel.Title).Any();
        //        //if (IsPostAlreadyExist)
        //        //{
        //        //    throw new Exception("Title already exists in the System.");
        //        //}
        //        //Data exchange from view model to data model
        //        var post = new PostEntity()
        //        {
        //            PostId = Guid.NewGuid().ToString(),
        //            Content = postViewModel.Content,
        //            DiscussionForumId = postViewModel.DiscussionForumId,
        //            PostId = postViewModel.StudenId,
        //            PostDate = postViewModel.PostDate,
        //        };
        //        _postRepository.Create(post);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _postRepository.Delete(id);
        //}

        //public IList<PostViewModel> GetAll()
        //{
        //    return _postRepository.GetAll().Select(
        //         s => new PostViewModel
        //         {
        //             PostId = s.PostId,
        //             Content = s.Content,
        //             DiscussionForumId = s.DiscussionForumId,
        //             StudenId = s.UserId,
        //             PostDate = s.PostDate,
        //         }).ToList();
        //}

        //public PostViewModel GetById(string id)
        //{
        //    var postEntity = _postRepository.GetById(id);
        //    return new PostViewModel()
        //    {
        //        PostId = postEntity.PostId,
        //        Content = postEntity.Content,
        //        DiscussionForumId = postEntity.DiscussionForumId,
        //        StudenId = postEntity.UserId,
        //        PostDate = postEntity.PostDate,
        //    };
        //}

        //public void Update(PostViewModel postViewModel)
        //{
        //    var post = new PostEntity()
        //    {
        //        PostId = Guid.NewGuid().ToString(),
        //        Content = postViewModel.Content,
        //        DiscussionForumId = postViewModel.DiscussionForumId,
        //        PostId = postViewModel.StudenId,
        //        PostDate = postViewModel.PostDate,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _postRepository.Update(post);
        //}
    }
}