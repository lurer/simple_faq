using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace s198599_mappe3.Models.Domain
{
    public class Question
    {
        public int QuestionID { get; set; }

        [Required, MinLength(20, ErrorMessage ="A meaningful heading should be atleast 20 characters long")]
        [MaxLength(50, ErrorMessage = "The maximum length of the message is 50 characters")]
        public string Heading { get; set; }

        [Required, MinLength(20, ErrorMessage = "A meaningful message body should be atleast 30 characters long")]
        [MaxLength(5000, ErrorMessage = "The maximum length of the message is 5000 characters")]
        public string Body { get; set; }

        public string Answer { get; set; }

        public int RelevanceScore { get; set; }

        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Please enter a valid email address")]
        public string RespondEmail { get; set; }

        [Required]
        public int CategoryID { get; set; }


        public DateTime CreatedAt { get; set; }

        public DateTime LastModifiedAt { get; set; }
    }
}