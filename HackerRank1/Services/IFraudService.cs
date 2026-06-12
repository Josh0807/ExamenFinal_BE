using System.Collections.Generic;
using System.Threading.Tasks;
using LibraryService.WebAPI.Data;

namespace LibraryService.WebAPI.Services
{
    public interface IFraudService
    {
        Task<IEnumerable<Fraud>> GetAll();
        Task<Fraud> Add(Fraud fraud);
    }
}