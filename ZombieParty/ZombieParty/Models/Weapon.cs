using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class Weapon : IValidatableObject
    {
        public int WeaponId { get; set; }

        [Display(Name = "Weapon's Name")]
        [StringLength(250, MinimumLength = 2)]
        public string Name { get; set; }

        [Display(Name = "Weapon's Description")]
        [MaxLength(2500)]
        [DataType(DataType.MultilineText)]
        public string? Description { get; set; }

        [Range(0, Double.MaxValue)]
        public decimal Force { get; set; }

        [Range(0, 100000, ErrorMessage = "The {0} must be between {1} and {2}")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        [Display(Name = "Weapon's Image")]
        [DataType(DataType.ImageUrl)]
        public string? Image { get; set; }

        public int Qty { get; set; }

        [Display(Name = "Qty Bought")]
        public int QtyBought { get; set; }

        public virtual IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var item = validationContext.ObjectInstance as Weapon;
            if (item == null) yield break;
            if (string.IsNullOrWhiteSpace(item.Description)) yield break;
            if (item.Description.Split(" ").Length <= 3)
                yield return new ValidationResult("Description needs to have more than 3 words please.", new[] { "Description" });
        }
    }
}
