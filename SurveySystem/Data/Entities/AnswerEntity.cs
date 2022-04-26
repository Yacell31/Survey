using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SurveySystem.Data.Entities
{
    [Table("Answers")]
    public partial class AnswerEntity
    {
        public int Id { get; set; }
        public int QuestionElementId { get; set; }
        public string AnswerElement { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ElementEntity QuestionElement { get; set; }
    }
}
