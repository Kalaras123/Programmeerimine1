using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Operation
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Action { get; set; }

        [Required]
        public DateTime OperationDate { get; set; }

        [Required]
        public decimal Cost { get; set; }

        public Worker Worker { get; set; }
        public int WorkerId { get; set; }

        public Status Status { get; set; }
        public int StatusId { get; set; }

        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
