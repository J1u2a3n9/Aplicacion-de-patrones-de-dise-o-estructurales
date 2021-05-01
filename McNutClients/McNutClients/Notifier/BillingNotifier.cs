using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class BillingNotifier
    {
        
        public void ShowBilling(IBilling _myBilling,ClientModel client)
        {
            PeanutNotifier _peanutNotifier;
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("                FACTURA                    ");
            Console.WriteLine($"Cochabamba, {DateTime.Now.Day.ToString()}, {DateTime.Now.Month.ToString()}, {DateTime.Now.Year.ToString()}      NIT/CI: {_myBilling.GetClientBilling(Convert.ToInt32(client.Ci)).Ci}");
            Console.WriteLine($"Señor(es): {_myBilling.GetClientBilling(Convert.ToInt32(client.Ci)).Name} {_myBilling.GetClientBilling(Convert.ToInt32(client.Ci)).SurName}");
            var peanuts = _myBilling.GetBilling(client).Peanuts;
            foreach (var peanut in peanuts)
            {
                _peanutNotifier = new PeanutNotifier(peanut);
                _peanutNotifier.ShowPeanutBillingUnitCost(client.Peanuts);
            }
            Console.WriteLine($"TOTAL Bs: {_myBilling.GetTotalAmount(client,Convert.ToInt32(client.Ci))}");



        }
    }
}
