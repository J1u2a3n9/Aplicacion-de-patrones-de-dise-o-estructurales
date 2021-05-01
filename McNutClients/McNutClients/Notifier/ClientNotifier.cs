using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class ClientNotifier
    {
        private IClientService _clientService;
        public ClientNotifier(IClientService clientService)
        {
            _clientService = clientService;
        }

        public void ShowClients()
        {
            int counter = 1;
            var clients = _clientService.GetClients();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("         LISTA ADMINISTRADORES MCNUTS        ");
            foreach (var client in clients)
            {
                Console.WriteLine(counter);
                Console.WriteLine($"Nombre: {client.Name}");
                Console.WriteLine($"Apellido: {client.SurName}");
                Console.WriteLine($"Ci: {client.Ci}");
                Console.WriteLine($"Fecha Nacimiento: {client.DateOfBirth.ToString()}");
                Console.WriteLine($"Numero: {client.Phone}");
                Console.WriteLine($"Direccion: {client.Address}");
                counter++;
            }
        }

        public void ShowClient(long ci)
        {
            Console.WriteLine("-------------------------------------------");
            var client = _clientService.GetClient(ci);
            Console.WriteLine($"Nombre: {client.Name}");
            Console.WriteLine($"Apellido: {client.SurName}");
            Console.WriteLine($"Ci: {client.Ci}");
            Console.WriteLine($"Fecha Nacimiento: {client.DateOfBirth.ToString()}");
            Console.WriteLine($"Numero: {client.Phone}");
            Console.WriteLine($"Direccion: {client.Address}");
        }
    }
}
