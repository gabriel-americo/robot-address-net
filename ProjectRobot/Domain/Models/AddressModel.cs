namespace Domain.Models
{
    public class AddressModel
    {
        // Identificador único do endereço
        public int Id { get; set; }

        // Código de Endereçamento Postal (CEP)
        public string CEP { get; set; }

        // Nome da rua, avenida, etc
        public string? Logradouro { get; set; }

        // Nome do bairro
        public string? Bairro { get; set; }

        // Unidade Federativa (UF)
        public string? UF { get; set; }
    }
}
