using Project411.DTO;

namespace Project411.Service
{
    public interface IExecutiveMemoRepository
    {
        Task<IEnumerable<ExecutiveMemoModel>> GetAllAsync();
        Task<ExecutiveMemoModel> GetAsync(int id);
        Task<int> CreateAsync(ExecutiveMemoModel memo);
        Task UpdateAsync(ExecutiveMemoModel memo);
        Task DeleteAsync(int id);
    }
}