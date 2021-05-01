using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class ClientAccess
    {
        private static ClientAccess _access = null;
        private static object _syncLock = new object();
        private IClientService _client;
        private BillingNotifier _billingNotifier;
        private ClientNotifier _clientNotifier;
        private IBilling _clientsBillingAdapter;

        private ClientAccess()
        {

            _client = new ClientService();
            _clientNotifier = new ClientNotifier(_client);
            _billingNotifier = new BillingNotifier();
        } 

        public static ClientAccess Access
        {
            get
            {
                lock(_syncLock)
                {
                    if (_access == null)
                        _access = new ClientAccess();
                    return _access;
                }
            }
        }


        public bool CreateClient(ClientModel newClient)
        {
            _client.RegisterClient(newClient);
            return true;
        }

        public bool DeleteClient(ClientModel deleteClient)
        {
            _client.DeleteClient(deleteClient);
            return true;
        }

        public void CreateBill(IBilling clientSource)
        {
            _clientsBillingAdapter = clientSource;
        }

        public bool BuyPeanutFlavor(long ci, string flavor, int amount)
        {
            var createBill = new ClientsBillingAdapter();
            CreateBill(createBill);
            _client.BuyPeanutFlavor(ci, flavor, amount);
            var client = _client.GetClient(ci);
            _billingNotifier.ShowBilling(_clientsBillingAdapter, client);
            return true;
        }

        public ClientModel GetClient(long ci)
        {
            return _client.GetClient(ci);
        }

        public IEnumerable<ClientModel> GetClients()
        {
            return _client.GetClients();
        }


        public void ShowClients()
        {
            _clientNotifier.ShowClients();
        }

        public void ShowClient(long ci)
        {
            _clientNotifier.ShowClient(ci);
        }



    }
}
