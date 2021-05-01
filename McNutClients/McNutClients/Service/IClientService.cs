using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    public interface IClientService
    {
        public bool RegisterClient(ClientModel newClient);
        public bool DeleteClient(ClientModel deleteClient);
        public bool BuyPeanutFlavor(long ci,string flavor,int amount);
        public ClientModel GetClient(long ci);
        public IEnumerable<ClientModel> GetClients();
        public IEnumerable<IPeanutService> GetPeanuts();

    }
}
