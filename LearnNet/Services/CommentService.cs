using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class CommentService : IService<CommentViewModel>
    {
        private readonly IRepository<CommentEntity> _commentRepository;

        public CommentService(IRepository<CommentEntity> commentRepository)
        {
            this._commentRepository = commentRepository;
        }

        public async Task Create(CommentViewModel commentViewModel)
        {
            try
            {
               
                //Data exchange from view model to data model
                var comment = new CommentEntity()
                {
                    CommentId = Guid.NewGuid().ToString(),
                    Content = commentViewModel.Content,
                    PostId = commentViewModel.PostId,
                    StudentId = commentViewModel.StudentId,
                    CommentDate = commentViewModel.CommentDate
                };
                await _commentRepository.Create(comment);
            }
            catch (Exception ex)
            {
                throw new Exception("Email already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _commentRepository.Delete(id);
        }

        public async Task<IList<CommentViewModel>> GetAll()
        {
            var comments = await _commentRepository.GetAll();
            return comments.Select(s => new CommentViewModel
            {
                CommentId = s.CommentId,
                Content = s.Content,
                PostId = s.PostId,
                StudentId = s.StudentId,
                CommentDate = s.CommentDate
            }).ToList();

        }

        public async Task<CommentViewModel> GetById(string id)
        {
            var commentEntity = await _commentRepository.GetById(id);
            return new CommentViewModel()
            {
                CommentId = commentEntity.CommentId,
                Content = commentEntity.Content,
                PostId = commentEntity.PostId,
                StudentId = commentEntity.StudentId,
                CommentDate = commentEntity.CommentDate
            };
        }

        public async Task Update(CommentViewModel commentViewModel)
        {
            try
            {
              
                var comment = new CommentEntity()
                {
                    CommentId = commentViewModel.CommentId,
                    Content = commentViewModel.Content,
                    PostId = commentViewModel.PostId,
                    StudentId = commentViewModel.StudentId,
                    CommentDate = commentViewModel.CommentDate,
                    ModifiedAt = DateTime.Now
                };
                await _commentRepository.Update(comment);
            }
            catch (Exception ex)
            {

                throw;// new Exception("Email already exists in the System.");
            }
        }
        //public void Create(CommentViewModel commentViewModel)
        //{
        //    try
        //    {
        //        //Data exchange from view model to data model
        //        var comment = new CommentEntity()
        //        {
        //            CommentId = Guid.NewGuid().ToString(),
        //            Content = commentViewModel.Content,
        //            PostId = commentViewModel.PostId,
        //            UserId = commentViewModel.UserId,
        //            CommentDate = commentViewModel.CommentDate
        //        };
        //        _commentRepository.Create(comment);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _commentRepository.Delete(id);
        //}

        //public IList<CommentViewModel> GetAll()
        //{
        //    return _commentRepository.GetAll().Select(
        //         s => new CommentViewModel
        //         {
        //             CommentId = s.CommentId,
        //             Content = s.Content,
        //             PostId = s.PostId,
        //             UserId = s.UserId,
        //             CommentDate = s.CommentDate
        //         }).ToList();
        //}

        //public CommentViewModel GetById(string id)
        //{
        //    var commentEntity = _commentRepository.GetById(id);
        //    return new CommentViewModel()
        //    {
        //        CommentId = commentEntity.CommentId,
        //        Content = commentEntity.Content,
        //        PostId = commentEntity.PostId,
        //        UserId = commentEntity.UserId,
        //        CommentDate = commentEntity.CommentDate
        //    };
        //}

        //public void Update(CommentViewModel commentViewModel)
        //{
        //    var comment = new CommentEntity()
        //    {
        //        CommentId = Guid.NewGuid().ToString(),
        //        Content = commentViewModel.Content,
        //        PostId = commentViewModel.PostId,
        //        UserId = commentViewModel.UserId,
        //        CommentDate = commentViewModel.CommentDate,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _commentRepository.Update(comment);
        //}
    }
}