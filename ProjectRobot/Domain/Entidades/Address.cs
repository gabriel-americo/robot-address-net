using Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entidades
{
    [Table("address")]
    public class Address
    {
        [Key]
        public int Id { get; set; }
        public string CEP { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public string? UF { get; set; }
        public EnumStatus Status { get; set; } = EnumStatus.Open;
        public string? Robo { get; set; }
    }
}
