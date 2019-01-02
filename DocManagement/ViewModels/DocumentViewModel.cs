using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class DocumentViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime UploadDate { get; set; }

        public string Name { get; set; }

        public int Downloads { get; set; }
    }
}