using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class DocumentDetailsViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime UploadDate { get; set; }

        public string File { get; set; }

        public int Views { get; set; }

        public string ApplicationUserId { get; set; }
    }
}