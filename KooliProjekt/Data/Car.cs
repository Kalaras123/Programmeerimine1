using System.Buffers;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Car
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Mark {  get; set; }

        [Required]
        [StringLength(50)]
        public string Model { get; set; }

        [Required]
        [StringLength(20)]
        public string RegistrationNumber { get; set; }

        public IList<Operation> Operations { get; set; }

        public Car() 
        {
            Operations = new List<Operation>();
        }

    } 
}
