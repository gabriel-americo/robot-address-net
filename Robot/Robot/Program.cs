using Robot;
using Robot.Driver;

const string BASE_URL = "https://localhost:7286/Address/";

var request = new RequestProvider();
var buscar = new BuscaCepDriver();
            
while (true) 
{
    var address = await request.GetAsync<AddressModel>(BASE_URL + "GetCepProcess?robot=robot_dev_1");

    if (address != null && !string.IsNullOrEmpty(address.CEP))
    {
        Console.WriteLine($"Consultando CEP: {address.CEP} para tratamento");

        buscar.BuscarCep(address);

        Console.WriteLine($"Atualizando dados do CEP: {address.CEP} com o bairro {address.Bairro}");

        await request.PutAsync(BASE_URL + "UpdateData", address);
    }
    Thread.Sleep(TimeSpan.FromSeconds(1));
}
