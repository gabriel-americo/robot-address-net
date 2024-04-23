using Domain.Entidades;
using Domain.Interfaces.Repository;
using EFCore.BulkExtensions;

namespace Infrastructure.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        // Contexto do banco de dados
        private readonly AppDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public AddressRepository(AppDbContext context)
        {
            _context = context;
        }

        // Método para adicionar uma lista de endereços
        public async Task Add(List<Address> addresses)
        {
            await _context.BulkInsertAsync(addresses);
        }

        // Método para atualizar um endereço
        public async Task UpdateData(Address address)
        {
            _context.Addresses.Update(address);
            await _context.SaveChangesAsync();
        }

        // Método para obter um endereço pelo ID
        public async Task<Address?> Get(int id)
        {
            return _context.Addresses.Where(x => x.Id == id).FirstOrDefault();
        }

        // Método para listar todos os endereços
        public async Task<List<Address>> List()
        {
            return _context.Addresses.ToList();
        }

        // Método para obter um endereço pelo processo CEP
        public async Task<Address?> GetCepProcess(string robot)
        {
            var cepExisting = _context.Addresses.Where(x => x.Status == Domain.Enums.EnumStatus.Progress && x.Robo == robot).FirstOrDefault();

            if (cepExisting != null)
            {
                return cepExisting;
            }

            var cep = _context.Addresses.Where(x => x.Status == Domain.Enums.EnumStatus.Open && string.IsNullOrEmpty(x.Robo)).FirstOrDefault();

            return cep;
        }
    }
}
