using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domian;
using HR.LeaveManagement.Persistence;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagemen.Persistence.Repositories
{
    public class LeaveRequestRepository : GenericRepository<LeaveRequest>, ILeaveRequestRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveRequestRepository(LeaveManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

            
        public async Task ChangeApprovalStatus(LeaveRequest leaveRequest, bool ApprovalStatus)
        {
            leaveRequest.Approved = ApprovalStatus;
            _dbContext.Entry(leaveRequest).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<LeaveRequest> GetLeaveRequestWithDetails(int Id)
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(x => x.LeaveTypeId)
                .FirstOrDefaultAsync(x => x.Id == Id);

            return leaveRequest;
        }

        public async Task<List<LeaveRequest>> GetLeaveRequestWithDetails()
        {
            var leaveRequest = await _dbContext.LeaveRequests
                .Include(x => x.LeaveTypeId)
                .ToListAsync();
            return leaveRequest;
        }
    }
}
