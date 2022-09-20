using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sistema.modells
{
    public class t_producto
    {
        [Key]
        public int pro_id { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public int pro_cod { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public string? pro_nombre { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public decimal pro_precio { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public string? pro_descripcion{ get; set; }

        
        public int pro_cat_id { get; set; }
        [ForeignKey("pro_cat_id")]
        public t_categoria? t_categoria { get; set; }

    }
}
