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
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Description { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //// not supose to be here \/
        [DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public DateTime UploadDate { get; set; }

        [Required]
        public Byte[] File { get; set; }

        [Required]
        public int Views { get; set; }

        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Download> Download { get; set; }
    }
} 