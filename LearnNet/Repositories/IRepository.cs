namespace LearnNet.Repositories
{
    public interface IRepository<T> where T : class
    {
        //IEnumerable<T> GetAll();
        //T GetById(int id);
        //void Add(T entity);
        //void Update(T entity);
        //void Delete(int id);

        Task Create(T entity);

        Task<IList<T>> GetAll();

        Task<T> GetById(string Id);

        Task Update(T entity);

        Task Delete(string Id);


        //Task<List<T>> GetAllAsync();
        //Task<T> GetByIdAsync(int id);
        //Task AddAsync(T entity);
        //Task UpdateAsync(T entity);
        //Task DeleteAsync(int id);
    }
}