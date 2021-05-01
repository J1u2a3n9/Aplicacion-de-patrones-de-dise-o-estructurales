using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    interface IBilling
    {
        public BillingModel GetBilling(ClientModel client);
        public ClientModel GetClientBilling(int ci);
        public double GetTotalAmount(ClientModel client,int ci);
    }
}
