using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace ZombieParty.Models
{
    public class HuntingLog
    {
        public int Id { get; set; }
        [StringLength(25, MinimumLength = 5)]
        public string Title { get; set; }
        [StringLength(255)]
        public string Description { get; set; }
        [ValidateNever]
        public virtual List<Zombie> Zombies { get; set; }
    }
}
