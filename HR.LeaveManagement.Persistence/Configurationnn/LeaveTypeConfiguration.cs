//using HR.LeaveManagement.Domian;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace HR.LeaveManagement.Persistence.Configuration
//{
//    public class LeaveTypeConfiguration : IEntityTypeConfiguration<LeaveType>
//    {
//        public void Configure(EntityTypeBuilder<LeaveType> builder)
//        {
//            builder.HasData(
//                new LeaveType
//                {
//                    Id = 1,
//                    DefaultDays = 10, 
//                    Name = "Vacation"
//                });

//            builder.HasData(
//                new LeaveType
//                {
//                    Id = 2,
//                    DefaultDays = 15,
//                    Name = "Vacation22Name = \"Vacation\""
//                });
//        }
//    }
//}
