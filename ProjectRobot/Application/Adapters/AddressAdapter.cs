using Domain.Entidades;
using Domain.Models;

namespace Application.Adapters
{
    public static class AddressAdapter
    {
        public static AddressModel Map(Address address)
        {
            var model = new AddressModel();
            model.Id = address.Id;
            model.CEP = address.CEP;
            model.Logradouro = address.Logradouro;
            model.Bairro = address.Bairro;
            model.UF = address.UF;
            return model;
        }

        public static Address Map(AddressModel address)
        {
            var model = new Address();
            model.Id = address.Id;
            model.CEP = address.CEP;
            model.Logradouro = address.Logradouro;
            model.Bairro = address.Bairro;
            model.UF = address.UF;
            return model;
        }

        public static List<AddressModel> Map(List<Address> address)
        {
            return address.Select(Map).ToList();
        }

        public static List<Address> Map(List<AddressModel> address)
        {
            return address.Select(Map).ToList();
        }
    }
}
