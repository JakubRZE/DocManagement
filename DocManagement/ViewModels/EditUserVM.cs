using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class EditUserVM
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}