using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class DetailsDocumentViewModel
    {
        public int Id { get; set; }

        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }

        public string UploadBy
        {
            get
            {
                return (UserFirstName + " " + UserLastName);
            }
        }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime UploadDate { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }

        public int Downloads { get; set; }
    }
}