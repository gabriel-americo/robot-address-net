using Application.Adapters;
using Domain.Interfaces.Repository;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Application.Services
{
    public class AddressService : IAddressService
    {
        private readonly IAddressRepository _repository;

        public AddressService(IAddressRepository repository)
        {
            _repository = repository;
        }

        public async Task Add(List<AddressModel> addresses)
        {
            var domains = AddressAdapter.Map(addresses);
            await _repository.Add(domains);
        }

        public async Task UpdateData(AddressModel address)
        {
            var domain = await _repository.Get(address.Id);

            if (domain == null)
            {
                throw new Exception("Cep bão localizado");
            }

            domain.Logradouro = address.Logradouro;
            domain.Bairro = address.Bairro;
            domain.UF = address.UF;
            domain.Status = Domain.Enums.EnumStatus.Finished;

            await _repository.UpdateData(domain);
        }

        public async Task<List<AddressModel>> List()
        {
            var addresses = await _repository.List();
            return AddressAdapter.Map(addresses);
        }

        public async Task<AddressModel> GetCepProcess(string robot)
        {
            var domain = await _repository.GetCepProcess(robot);

            if (domain == null) return default;

            domain.Status = Domain.Enums.EnumStatus.Progress;
            domain.Robo = robot;

            await _repository.UpdateData(domain);

            return AddressAdapter.Map(domain);
        }
    }
}
