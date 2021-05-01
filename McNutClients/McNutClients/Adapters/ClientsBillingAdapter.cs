using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class ClientsBillingAdapter : ClientService, IBilling
    {
        private BillingModel _billingClient;
        public ClientsBillingAdapter()
        {
            _billingClient = new BillingModel();
        }

        public ClientModel GetClientBilling(int ci)
        {
            return GetClient(ci);
        }

        public BillingModel GetBilling(ClientModel client)
        {
            var peanuts = client.Peanuts;
            _billingClient.Client = client;
            foreach (IPeanutService peanut in peanuts)
            {
                _billingClient.Peanuts = new List<string>();
                _billingClient.Peanuts.Add(peanut.GetName());
            }
            return _billingClient;
        }

        public double GetTotalAmount(ClientModel client,int ci)
        {
            int? cantidadInicial = 50;
            var amount = 0.0;
            var peanuts = client.Peanuts;
            foreach (IPeanutService peanut in peanuts)
            {
                cantidadInicial = cantidadInicial - peanut.GetAmount();
                amount = (double)(amount + cantidadInicial*peanut.GetUnitCost());
            }
            return amount;
        }

    }
}
