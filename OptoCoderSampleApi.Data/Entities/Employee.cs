using System;
using System.Collections.Generic;

#nullable disable

namespace OptoCoderSampleApi.Data.Entities
{
    public partial class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public DateTime EmployeeHireDate { get; set; }
        public DateTime EmployeeLeaveDate { get; set; }
        public decimal Salary { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
