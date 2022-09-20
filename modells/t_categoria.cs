using System.ComponentModel.DataAnnotations;

namespace api_sistema.modells
{
    public class t_categoria
    {
        
        [Key]
        public int cat_id { get; set; }
        
        [Required(ErrorMessage ="Este Campo Es Requerido")]
        public string? cat_nombre { get; set; }
    }
}
