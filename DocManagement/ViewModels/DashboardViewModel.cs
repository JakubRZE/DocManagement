using DocManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class DashboardViewModel
    {
        public string Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }

        public string FullName
        {
            get
            {
                return (FirstName + " " + LastName);
            }
        }

        public int UploadsCount { get; set; }
        public List<DashboardViewModel> Uploads { get; set; }


        public string Description { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime UploadDate { get; set; }
        public string File { get; set; }

        public int Downloads { get; set; }
    }
}