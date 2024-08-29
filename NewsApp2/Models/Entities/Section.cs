using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewsApp2.Models.Entities
{
    public class Section : BaseEntity
    {
        [Remote(action: "NameExists", controller: "Sections")]
        [MaxLength(50)]
        [MinLength(3)]
        public required string Name { get; set; }

        public List<News>? News { get; set; }

        [NotMapped]
        public int SectionNewsCount { get; set; }
    }
}
