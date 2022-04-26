using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SurveySystem.Data.Entities
{
    [Table("Elements")]
    public partial class ElementEntity
    {

        public ElementEntity()
        {
            Answers = new HashSet<AnswerEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public string Type { get; set; }
        public int CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }
        public string ElementType { get; set; }

        public virtual CategoryEntity Category { get; set; }
        public virtual ICollection<AnswerEntity> Answers { get; set; }

    }
}
