﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NewsApp2.Models.Entities
{
    public class News : BaseEntity
    {
        [StringLength(50, ErrorMessage = "{0} length must be between {2} and {1}.", MinimumLength = 3)]
        //[StringLength(50, MinimumLength = 3)]
        public required string Title { get; set; }

        [StringLength(4000, ErrorMessage = "عدد الحروف لا يقل عن 5 أحرف ولا يزيد عن 4000 حرف", MinimumLength = 5)]
        [Required(ErrorMessage = "News details is required")]
        public required string Details { get; set; }
        public string? ImageUrl { get; set; }
        public bool State { get; set; } = true;

        [ValidateNever]
        public Section Sections { get; set; }

        [Required(ErrorMessage = "Section is required")]
        [Display(Name = "Sections")]

        public Guid SectionId { get; set; }

        [NotMapped]
        public IFormFile? Image { get; set; }

    }
}
