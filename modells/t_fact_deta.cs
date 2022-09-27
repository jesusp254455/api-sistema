using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api_sistema.modells
{
    public class t_fact_deta
    {
        [Key]
        public int fd_id { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public int fd_cant { get; set; }

        [Required(ErrorMessage = " este campo es requerido")]
        public decimal fd_pre_uni { get; set; }

        [Required(ErrorMessage = "este campo es requerido")]
        public int fd_pro_id  { get; set; }
        [ForeignKey("fd_pro_id")]
        public t_producto t_producto { get; set; }

        public int fd_enc_id { get; set; }

        public virtual t_fac_enc T_fac_enc { get; set; }
    }
}
