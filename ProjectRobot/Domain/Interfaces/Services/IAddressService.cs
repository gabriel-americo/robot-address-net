using Domain.Models;

namespace Domain.Interfaces.Services
{
    public interface IAddressService
    {
        // Método para adicionar uma lista de endereços
        Task Add(List<AddressModel> address);

        // Método para atualizar um endereço
        Task UpdateData(AddressModel address);

        // Método para obter um endereço pelo processo CEP
        Task<AddressModel> GetCepProcess(string robot);

        // Método para listar todos os endereços
        Task<List<AddressModel>> List();
    }
}
