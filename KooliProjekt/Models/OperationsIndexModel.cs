using KooliProjekt.Search;
using KooliProjekt.Data;

namespace KooliProjekt.Models
{
    public class OperationsIndexModel
    {
        public OperationsSearch Search { get; set; }
        public List<Operation> Data { get; set; }

    }
}
