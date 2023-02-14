using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace PCE.WebApp.MVC.Models
{
    public class CellViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(50, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        [DisplayName("Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayName("Status")]
        public int IdStatus { get; set; }

        [DisplayName("Operation")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int IdOperation { get; set; }

        [DisplayName("Código Operação")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CodOperation { get; set; }        
        public IEnumerable<Operation> Operations { get; set; }
        
        public IEnumerable<Status> listStatus { get; set; }     
        
    }
}
