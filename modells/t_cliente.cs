using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sistema.modells
{
    public class t_cliente
    {
        [Key]
        [Required(ErrorMessage = "este campo es requerido")]
        public int cli_doc { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public string cli_nombre { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public string cli_apellido { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public string cli_correo { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public long cli_telefono { get; set; }

        public int cli_tp_doc { get; set; }
        [ForeignKey("cli_tp_doc")]
        public t_tipodocumento t_tipodocumento { get; set; }
    }
}
