using System;
using System.Collections.Generic;

#nullable disable

namespace Frontend.Models
{
    public partial class AccountManager
    {
        public AccountManager()
        {
            Customers = new HashSet<Customer>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}
