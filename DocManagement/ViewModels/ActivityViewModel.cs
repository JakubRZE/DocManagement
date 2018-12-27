using DocManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class ActivityViewModel
    {
        public List<Document> Uploads { get; set; }
        public List<Document> Downloads { get; set; }
    }
}