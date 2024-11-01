using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Worker
    {
        public int Id { get; set; }

        [DisplayName("Worker Name")]
        [Required]
        [StringLength(100)]
        public string WorkerName { get; set; }

        [StringLength(20)]
        public string? Phone {  get; set; }

        [StringLength(100)]
        public string? Email { get; set; }

        public IList<Operation> Operations { get; set; }

        public Worker()
        {
            Operations = new List<Operation>();
        }
    }
}
