using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KooliProjekt.Data
{
    public class Status
    {
        public int Id { get; set; }

        [DisplayName("Status Type")]
        [Required]
        [StringLength(50)]
        public string StatusType { get; set; }

    }
}
