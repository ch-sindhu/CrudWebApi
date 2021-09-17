using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_CRUD.Models
{
    [Table("Persons",Schema="dbo")]
     public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "UserPassword")]
        public string UserPassword { get; set; }
        [Required]
        [Display(Name = "UserEmail")]
        public string UserEmail { set; get; }
        [Required]
        [Display(Name = "CreatedOn")]
        public DateTime CreatedOn { set; get; } = DateTime.Now;
        [Required]
        [Display(Name = "IsDeleted")]
        public bool IsDeleted { set; get; } = false;
    }
}
