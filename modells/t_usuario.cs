using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sistema.modells
{
    public class t_usuario
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public int tipodocumentoid { get; set; }

        [ForeignKey("tipodocumentoid")]

        public t_tipodocumento t_tipodocumento { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public string numdocumento { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public string apellidos { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public long telefono { get; set; }

        [Required(ErrorMessage = "Este Campo Es Requerido")]
        public int rolid { get; set; }
        [ForeignKey("rolid")]

        public t_rol t_rol { get; set; }
    }
}
