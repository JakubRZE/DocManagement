﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace DocManagement.Models
{
    public class Download
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime DownloadDate { get; set; }

        [Required]
        public int DocumentId { get; set; }
        public virtual Document Document { get; set; }

        [Required]
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser AplicationUser { get; set; }
    }
}