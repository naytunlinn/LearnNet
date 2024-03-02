using LearnNet.Models.DataModels;
using LearnNet.Models.ViewModels;
using LearnNet.Repositories;

namespace LearnNet.Services
{
    public class ModuleService : IService<ModuleViewModel>
    {
        private readonly IRepository<ModuleEntity> _moduleRepository;

        public ModuleService(IRepository<ModuleEntity> moduleRepository)
        {
            this._moduleRepository = moduleRepository;
        }
        public async Task Create(ModuleViewModel moduleViewModel)
        {
            try
            {
                var modules = await _moduleRepository.GetAll();
                var Isexists = modules.Any(w => w.Title == moduleViewModel.Title);
                if (Isexists)
                {
                    return;
                }
                //Data exchange from view model to data model
                var module = new ModuleEntity()
                {
                    ModuleId = Guid.NewGuid().ToString(),
                    Title = moduleViewModel.Title,
                    CourseId = moduleViewModel.CourseId,
                };
                await _moduleRepository.Create(module);
            }
            catch (Exception ex)
            {
                throw new Exception("Title already exists in the System.");
            }
        }

        public async Task Delete(string id)
        {
            await _moduleRepository.Delete(id);
        }

        public async Task<IList<ModuleViewModel>> GetAll()
        {
            var modules = await _moduleRepository.GetAll();
            return modules.Select(s => new ModuleViewModel
            {
                ModuleId = s.ModuleId,
                Title = s.Title,
                CourseId = s.CourseId,
            }).ToList();

        }

        public async Task<ModuleViewModel> GetById(string id)
        {
            var moduleEntity = await _moduleRepository.GetById(id);
            return new ModuleViewModel()
            {
                ModuleId = moduleEntity.ModuleId,
                Title = moduleEntity.Title,
                CourseId = moduleEntity.CourseId,
            };
        }

        public async Task Update(ModuleViewModel moduleViewModel)
        {
            try
            {
                var modules = await _moduleRepository.GetAll();
                var Isexist = modules.Where(w => w.Title == moduleViewModel.Title).Any();
                if (Isexist)
                {
                    return;
                }
                var module = new ModuleEntity()
                {
                    ModuleId = moduleViewModel.ModuleId,
                    Title = moduleViewModel.Title,
                    CourseId = moduleViewModel.CourseId,
                    ModifiedAt = DateTime.Now
                };
                await _moduleRepository.Update(module);
            }
            catch (Exception ex)
            {

                throw new Exception("Title already exists in the System.");
            }
        }
        //public void Create(ModuleViewModel moduleViewModel)
        //{
        //    try
        //    {
        //        var IsModuleAlreadyExist = _moduleRepository.GetAll().Where(w => w.Title == moduleViewModel.Title).Any();
        //        if (IsModuleAlreadyExist)
        //        {
        //            throw new Exception("Title already exists in the System.");
        //        }
        //        //Data exchange from view model to data model
        //        var module = new ModuleEntity()
        //        {
        //            ModuleId = Guid.NewGuid().ToString(),
        //            Title = moduleViewModel.Title,
        //            CourseId = moduleViewModel.CourseId,
        //        };
        //        _moduleRepository.Create(module);
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //public void Delete(string id)
        //{
        //    _moduleRepository.Delete(id);
        //}

        //public IList<ModuleViewModel> GetAll()
        //{
        //    return _moduleRepository.GetAll().Select(
        //         s => new ModuleViewModel
        //         {
        //             ModuleId = s.ModuleId,
        //             Title = s.Title,
        //             CourseId = s.CourseId,
        //         }).ToList();
        //}

        //public ModuleViewModel GetById(string id)
        //{
        //    var moduleEntity = _moduleRepository.GetById(id);
        //    return new ModuleViewModel()
        //    {
        //        ModuleId = moduleEntity.ModuleId,
        //        Title = moduleEntity.Title,
        //        CourseId = moduleEntity.CourseId,
        //    };
        //}

        //public void Update(ModuleViewModel moduleViewModel)
        //{
        //    var module = new ModuleEntity()
        //    {
        //        ModuleId = Guid.NewGuid().ToString(),
        //        Title = moduleViewModel.Title,
        //        CourseId = moduleViewModel.CourseId,
        //        ModifiedAt = DateTime.Now
        //    };
        //    _moduleRepository.Update(module);
        //}
    }
}