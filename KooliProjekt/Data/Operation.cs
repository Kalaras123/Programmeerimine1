using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Operation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [DisplayName("Operation Date")]
        [Required]
        public DateTime OperationDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public Worker Worker { get; set; }
        [DisplayName("Worker")]
        public int WorkerId { get; set; }

        public Status Status { get; set; }
        [DisplayName("Status")]
        public int StatusId { get; set; }

        public Car Car { get; set; }
        [DisplayName("Car")]
        public int CarId { get; set; }
    }
}
