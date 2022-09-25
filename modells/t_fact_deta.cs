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
        public t_fact_deta t_fact_Deta { get; set; }
    }
}
