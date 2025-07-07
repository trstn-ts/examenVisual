using System.ComponentModel.DataAnnotations.Schema;

namespace ExamenAPI.Models
{
    public class Registros
    {
        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Sinopsis { get; set; }
        public string? Portada { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }
        public string? Genero { get; set; }
    }
}
