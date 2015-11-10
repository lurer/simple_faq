using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.DB
{
    public class DbCategory : IAuditedEntity
    {

        [Key]
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public virtual List<DbQuestion> Questions { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string LastModifiedBy { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}