using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceSense.Data.Repositories
{
    public class HealthHistoryRepository
    {
        private readonly AppDbContext _context;

        public HealthHistoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(SnapshotRecord record)
        {
            _context.SnapshotRecords.Add(record);
            await _context.SaveChangesAsync();
        }

        public async Task<List<SnapshotRecord>> GetRecentAsync(int count = 50)
        {
            return await Task.FromResult(
                _context.SnapshotRecords
                    .OrderByDescending(r => r.CapturedAt)
                    .Take(count)
                    .ToList());
        }

        public async Task<List<SnapshotRecord>> GetSinceAsync(DateTime since)
        {
            return await Task.FromResult(
                _context.SnapshotRecords
                    .Where(r => r.CapturedAt >= since)
                    .OrderBy(r => r.CapturedAt)
                    .ToList());
        }
    }
}