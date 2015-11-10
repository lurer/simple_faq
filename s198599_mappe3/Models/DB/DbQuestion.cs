using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.DB
{
    public class DbQuestion : IAuditedEntity
    {
        [Key]
        public int QuestionID { get; set; }

        public string Heading { get; set; }

        public string Body { get; set; }

        public string Answer { get; set; }

        public int RelevanceScore { get; set; }

        public string RespondEmail { get; set; }


        [ForeignKey("Category")]
        public int CategoryID { get; set; }

        public virtual DbCategory Category { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}