using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

#nullable disable

namespace Frontend.Models
{
    public partial class Customer
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
        public string AccountNumber { get; set; }
        public int ManagerId { get; set; }
        public string OTP { get; set; }

        public virtual AccountManager Manager { get; set; }
    }
}
