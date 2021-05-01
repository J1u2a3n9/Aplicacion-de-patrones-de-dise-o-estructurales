using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace McNutClients
{
    public class ClientService : IClientService
    {
        private List<ClientModel> _clients;
        private PeanutFacade _peanut;
        public ClientService()
        {
            _peanut = new PeanutFacade();
            _clients = new List<ClientModel>();
            _clients.Add(new ClientModel()
            {
                Ci = 14419455,
                Name = "Juan Luis",
                Address = "Av Blanco Galindo",
                SurName = "Canedo Villarroel",
                DateOfBirth = new DateTime(1999, 11, 06),
                Phone=78348873
            });
            _clients.Add(new ClientModel()
            {
                Ci = 3003688,
                Name = "Jose Luis",
                Address = "Av Papa Paulo",
                SurName = "Villarroel Gonzales",
                DateOfBirth = new DateTime(2000, 10, 06),
                Phone = 71745068
            });
            _clients.Add(new ClientModel()
            {
                Ci = 15519844,
                Name = "Maria",
                Address = "Av America",
                SurName = "Espinoza Castro",
                DateOfBirth = new DateTime(2000, 08, 06),
                Phone = 78348873
            });

        }
        public bool BuyPeanutFlavor(long ci, string flavor, int amount)
        {
            string codPeanut;
            switch(flavor.ToLower())
            {
                case "coco":
                case "leche condensada":
                case "coco y leche condensada":
                    codPeanut = "Coco1";
                    break;
                case "miel":
                case "mostaza":
                case "miel y mostaza":
                    codPeanut = "MM1";
                    break;
                case "picante":
                    codPeanut = "Picante1";
                    break;
                default:
                    codPeanut = "Oreo1";
                    break;
            }
            var client = GetClient(ci);
            
            _peanut.AddAmount(codPeanut,-amount);
            client.Peanuts=_peanut.GetPeanuts();
            return true;
        }

        public bool DeleteClient(ClientModel deleteClient)
        {
            if(ExistingClient(deleteClient.Ci)==false)
            {
                throw new Exception($"El cliente con id {deleteClient.Ci} no existe ");
            }
            _clients.Remove(deleteClient);
            return true;
        }

        public ClientModel GetClient(long ci)
        {
            return  _clients.FirstOrDefault(c => c.Ci == ci);
        }

        public IEnumerable<ClientModel> GetClients()
        {
            return _clients;
        }

        public IEnumerable<IPeanutService> GetPeanuts()
        {
            return _peanut.GetPeanuts();
        }

        public bool RegisterClient(ClientModel newClient)
        {
            ExistingClient(newClient.Ci);
            _clients.Add(newClient);
            return true;
        }

        private bool ExistingClient(long ci)
        {
            bool answer = false;
            var client = _clients.FirstOrDefault(c => c.Ci == ci);
            if(client!=null)
            {
                answer= true ;
            }
            return answer;
        }
    }
}
