using System;
using System.Collections.Generic;

#nullable disable

namespace OptoCoderSampleApi.Data.Entities
{
    public partial class Company
    {
        public Company()
        {
            Customers = new HashSet<Customer>();
            Employees = new HashSet<Employee>();
            Users = new HashSet<User>();
        }

        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string LicenseKey { get; set; }
        public DateTime LicenseKeyStartDate { get; set; }
        public DateTime LicenseKeyExpireDate { get; set; }
        public DateTime? TodaysDate { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
