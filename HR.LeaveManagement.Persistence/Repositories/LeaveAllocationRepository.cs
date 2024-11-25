using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domian;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveAllocationRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int Id)
        {
            return await _dbContext.LeaveAllocations
                .Include(x => x.LeaveTyeId)
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
        {
            return await _dbContext.LeaveAllocations.Include(x => x.LeaveTyeId).ToListAsync();
        }
    }
}
