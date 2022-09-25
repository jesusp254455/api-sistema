using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sistema.modells
{
    public class t_fac_enc
    {
        [Key]
        public int fe_id { get; set; }

        [Required(ErrorMessage = ("este campo es requerido"))]
        public DateTime fe_fecha { get; set; }

        [Required( ErrorMessage = "este campo es requerido")]
        public int fe_numfac { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public decimal fe_total { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public DateTime fe_venc { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public int fe_cli_id   { get; set; }
        [ForeignKey("fe_cli_id")]
        public t_cliente t_cliente { get; set; }
    }
}
