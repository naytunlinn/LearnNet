using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services

{
    public class ResourceService : IService<ResourceViewModel>
    {
        private readonly IRepository<ResourceEntity> _resourceRepository;

        public ResourceService(IRepository<ResourceEntity> resourceRepository)
        {
            this._resourceRepository = resourceRepository;
        }
        public async Task Create(ResourceViewModel resourceViewModel)
        {
            try
            {
                var resources = await _resourceRepository.GetAll();
                var Isexists = resources.Any(w => w.Title == resourceViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var resource = new ResourceEntity()
                {
                    ResourceId = Guid.NewGuid().ToString(),
                    Title = resourceViewModel.Title,
                    ModuleId = resourceViewModel.ModuleId,
                    Type = resourceViewModel.Type,
                };
                await _resourceRepository.Create(resource);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _resourceRepository.Delete(id);
        }

        public async Task<IList<ResourceViewModel>> GetAll()
        {
            var resources = await _resourceRepository.GetAll();
            return resources.Select(s => new ResourceViewModel
            {
                ResourceId = s.ResourceId,
                Title = s.Title,
                ModuleId = s.ModuleId,
                Type = s.Type,
            }).ToList();

        }

        public async Task<ResourceViewModel> GetById(string id)
        {
            var resourceEntity = await _resourceRepository.GetById(id);
            return new ResourceViewModel()
            {
                ResourceId = resourceEntity.ResourceId,
                Title = resourceEntity.Title,
                ModuleId = resourceEntity.ModuleId,
                Type = resourceEntity.Type,
            };
        }

        public async Task Update(ResourceViewModel resourceViewModel)
        {
            try
            {
                var resources = await _resourceRepository.GetAll();
                var Isexist = resources.Where(w => w.Title == resourceViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var resource = new ResourceEntity()
                {
                    ResourceId = resourceViewModel.ResourceId,
                    Title = resourceViewModel.Title,
                    ModuleId = resourceViewModel.ModuleId,
                    Type = resourceViewModel.Type,
                    ModifiedAt = DateTime.Now
                };
                await _resourceRepository.Update(resource);
            }
            catch (Exception ex)
            {

                throw new Exception("Title already exists in the System.");
            }
        }
        //public void Create(ResourceViewModel resourceViewModel)
        //{
        //    try
        //    {
        //        var IsResourceAlreadyExist = _resourceRepository.GetAll().Where(w => w.Title == resourceViewModel.Title).Any();
        //        if (IsResourceAlreadyExist)
        //        {
        //            throw new Exception("Title already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var resource = new ResourceEntity()
        //        {
        //            ResourceId = Guid.NewGuid().ToString(),
        //            Title = resourceViewModel.Title,
        //            ModuleId = resourceViewModel.ModuleId,
        //            Type = resourceViewModel.Type,
        //        };
        //        _resourceRepository.Create(resource);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _resourceRepository.Delete(id);
        //}

        //public IList<ResourceViewModel> GetAll()
        //{
        //    return _resourceRepository.GetAll().Select(
        //         s => new ResourceViewModel
        //         {
        //             ResourceId = s.ResourceId,
        //             Title = s.Title,
        //             ModuleId = s.ModuleId,
        //             Type = s.Type,
        //         }).ToList();
        //}

        //public ResourceViewModel GetById(string id)
        //{
        //    var resourceEntity = _resourceRepository.GetById(id);
        //    return new ResourceViewModel()
        //    {
        //        ResourceId = resourceEntity.ResourceId,
        //        Title = resourceEntity.Title,
        //        ModuleId = resourceEntity.ModuleId,
        //        Type = resourceEntity.Type,
        //    };
        //}

        //public void Update(ResourceViewModel resourceViewModel)
        //{
        //    var resource = new ResourceEntity()
        //    {
        //        ResourceId = Guid.NewGuid().ToString(),
        //        Title = resourceViewModel.Title,
        //        ModuleId = resourceViewModel.ModuleId,
        //        Type = resourceViewModel.Type,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _resourceRepository.Update(resource);
        //}
    }
}