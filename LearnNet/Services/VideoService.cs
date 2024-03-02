using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class VideoService : IService<VideoViewModel>
    {
        private readonly IRepository<VideoEntity> _videoRepository;

        public VideoService(IRepository<VideoEntity> videoRepository)
        {
            this._videoRepository = videoRepository;
        }

        public async Task Create(VideoViewModel videoViewModel)
        {
            try
            {
                var videos = await _videoRepository.GetAll();
                var Isexists = videos.Any(w => w.Title == videoViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var video = new VideoEntity()
                {
                    VideoId = Guid.NewGuid().ToString(),
                    Title = videoViewModel.Title,
                    VideoUrl = videoViewModel.VideoUrl,
                    ModuleId = videoViewModel.ModuleId,
                    CourseId = videoViewModel.CourseId,
                };
                await _videoRepository.Create(video);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _videoRepository.Delete(id);
        }

        public async Task<IList<VideoViewModel>> GetAll()
        {
            var videos = await _videoRepository.GetAll();
            return videos.Select(s => new VideoViewModel
            {
                VideoId = s.VideoId,
                Title = s.Title,
                VideoUrl = s.VideoUrl,
                ModuleId = s.ModuleId,
                CourseId = s.CourseId,
            }).ToList();
        }

        public async Task<VideoViewModel> GetById(string id)
        {
            var videoEntity = await _videoRepository.GetById(id);
            return new VideoViewModel()
            {
                VideoId = videoEntity.VideoId,
                Title = videoEntity.Title,
                VideoUrl = videoEntity.VideoUrl,
                ModuleId = videoEntity.ModuleId,
                CourseId = videoEntity.CourseId,
            };
        }

        public async Task Update(VideoViewModel videoViewModel)
        {
            try
            {
                var videos = await _videoRepository.GetAll();
                var Isexist = videos.Where(w => w.Title == videoViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var video = new VideoEntity()
                {
                    VideoId = videoViewModel.VideoId,
                    Title = videoViewModel.Title,
                    VideoUrl = videoViewModel.VideoUrl,
                    ModuleId = videoViewModel.ModuleId,
                    CourseId = videoViewModel.CourseId,
                    ModifiedAt = DateTime.Now
                };
                await _videoRepository.Update(video);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        //public void Create(VideoViewModel videoViewModel)
        //{
        //    try
        //    {
        //        var IsVideoAlreadyExist = _videoRepository.GetAll().Where(w => w.Title == videoViewModel.Title || w.VideoUrl == videoViewModel.VideoUrl).Any();
        //        if (IsVideoAlreadyExist)
        //        {
        //            throw new Exception("Title or Video already exist in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var video = new VideoEntity()
        //        {
        //            VideoId = Guid.NewGuid().ToString(),
        //            Title = videoViewModel.Title,
        //            VideoUrl = videoViewModel.VideoUrl,
        //            ModuleId = videoViewModel.ModuleId,
        //            CourseId = videoViewModel.CourseId,
        //        };
        //        _videoRepository.Create(video);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _videoRepository.Delete(id);
        //}

        //public IList<VideoViewModel> GetAll()
        //{
        //    return _videoRepository.GetAll().Select(
        //         s => new VideoViewModel
        //         {
        //             VideoId = s.VideoId,
        //             Title = s.Title,
        //             VideoUrl = s.VideoUrl,
        //             ModuleId = s.ModuleId,
        //             CourseId = s.CourseId,
        //         }).ToList();
        //}

        //public VideoViewModel GetById(string id)
        //{
        //    var videoEntity = _videoRepository.GetById(id);
        //    return new VideoViewModel()
        //    {
        //        VideoId = videoEntity.VideoId,
        //        Title = videoEntity.Title,
        //        VideoUrl = videoEntity.VideoUrl,
        //        ModuleId = videoEntity.ModuleId,
        //        CourseId = videoEntity.CourseId,
        //    };
        //}

        //public void Update(VideoViewModel videoViewModel)
        //{
        //    var video = new VideoEntity()
        //    {
        //        VideoId = Guid.NewGuid().ToString(),
        //        Title = videoViewModel.Title,
        //        VideoUrl = videoViewModel.VideoUrl,
        //        ModuleId = videoViewModel.ModuleId,
        //        CourseId = videoViewModel.CourseId,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _videoRepository.Update(video);
        //}
    }
}