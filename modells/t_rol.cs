using System.ComponentModel.DataAnnotations;

namespace api_sistema.modells
{
    public class t_rol
    {
        [Key]
        public int rolId { get; set; }

        public string? rolnombre { get; set; }
    }
}
