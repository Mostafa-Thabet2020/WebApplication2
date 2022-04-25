using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Governrote
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter name of Governrote")]
        [StringLength(maximumLength:100,ErrorMessage ="should less then 100 letters and more than 3",MinimumLength =3)]
        [DisplayName("Governrote name")]
        public string Name { get; set; }
    }
}
