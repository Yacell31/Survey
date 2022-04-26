using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace SurveySystem.Data.Entities
{
    [Table("Categories")]
    public partial class CategoryEntity
    {
        public CategoryEntity()
        {
            Elements = new HashSet<ElementEntity>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }
        public DateTime? CreatedDate { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ElementEntity> Elements { get; set; }
    }
}
