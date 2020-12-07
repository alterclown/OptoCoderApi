using System;
using System.Collections.Generic;

#nullable disable

namespace OptoCoderSampleApi.Data.Entities
{
    public partial class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerFullName { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }

        public virtual Company Company { get; set; }
        public virtual User User { get; set; }
    }
}
