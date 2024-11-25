using HR.LeaveManagement.Application.Dtos.LeaveType;
using HR.LeaveManagement.Application.Persistence.Contracts;
using HR.LeaveManagement.Domian;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Persistence.Repositories
{
    public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
    {
        private readonly LeaveManagementDbContext _dbContext;

        public LeaveTypeRepository(LeaveManagementDbContext dbContext) : base(dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<LeaveType> GetLeaveTypeWithDetails(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<LeaveType>> GetLeaveTypeWithDetails()
        {
            throw new NotImplementedException();
        }
    }
}
