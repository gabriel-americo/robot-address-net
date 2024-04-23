using Domain.Entidades;

namespace Domain.Interfaces.Repository
{
    public interface IAddressRepository
    {
        Task Add(List<Address> address);
        Task UpdateData(Address address);
        Task<Address?> GetCepProcess(string robot);
        Task<Address?> Get(int id);
        Task<List<Address>> List();
    }
}
