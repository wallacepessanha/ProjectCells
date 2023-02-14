using System.ComponentModel.DataAnnotations;

namespace PCE.Cells.API.Models
{
    public class CellModel
    {        
        public int Id { get; set; }
        [Required(ErrorMessage = "O campo Name é requerido.")]
        public string Name { get; set; }
        [Range(1, 2, ErrorMessage = "Informe apenas os valores 1 ou 2.")]
        public int IdOperation { get; set; }
        [Range(0, 1, ErrorMessage = "Informe apenas os valores 0 ou 1.")]
        public int IdStatus { get; set; }
        [Required(ErrorMessage = "O campo CodOperation é requerido.")]
        public int CodOperation { get; set; }
    }
}
