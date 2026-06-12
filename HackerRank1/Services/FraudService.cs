using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using LibraryService.WebAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace LibraryService.WebAPI.Services
{
    public class FraudService : IFraudService
    {
        private readonly LibraryContext _context;

        public FraudService(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Fraud>> GetAll()
        {
            return await _context.Frauds
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();
        }

        public async Task<Fraud> Add(Fraud fraud)
        {
            fraud.CreatedAt = DateTime.UtcNow;

            _context.Frauds.Add(fraud);
            await _context.SaveChangesAsync();

            return fraud;
        }
    }
}