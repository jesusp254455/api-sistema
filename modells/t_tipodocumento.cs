using System.ComponentModel.DataAnnotations;

namespace api_sistema.modells
{
    public class t_tipodocumento
    {
        [Key]
        public int tipodocumentoid { get; set; }

        public string? tipodocumentonombre { get; set; }
    }
}
