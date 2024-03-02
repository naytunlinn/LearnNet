namespace LearnNet.Services
{
    public interface IService<T> where T : class
    {
        Task Create(T viewModel);

        Task<IList<T>> GetAll();

        Task<T> GetById(string id);

        Task Update(T viewModel);

        Task Delete(string id);
    }
}