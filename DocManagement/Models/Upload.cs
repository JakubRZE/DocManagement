using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocManagement.Models
{
    public class Upload
    {
        [Key]
        [ForeignKey("Document")]
        public int DocumentId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime UploadDate { get; set; }
        
        public virtual Document Document { get; set; }

        [Required]
        public string AplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }
    }
}