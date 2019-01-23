using DocManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DocManagement.ViewModels
{
    public class CreateDocumentViewModel
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Byte[] File { get; set; }

        public string Name { get; set; }

        public string ContentType { get; set; }
    }
}