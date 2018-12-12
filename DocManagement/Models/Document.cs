using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocManagement.Models
{
    public class Document
    {
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UploadDate { get; set; }

        [Required]
        public string File { get; set; }

        public int Views { get; set; }

        [Required]
        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }

        public virtual ICollection<Download> Download { get; set; }
    }
} 