using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    public abstract class IPeanutService
    {

        public PeanutModel Peanut = new PeanutModel();
        /*public IPeanutService()
        {
            Peanut = new PeanutModel();
        }*/
        public void AddAmount(int amount)
        {
            if (amount < 0 && Peanut.Amount > 0 || amount > 0)
            {
                Peanut.Amount = Peanut.Amount + amount;
            }
        }

        public int? GetAmount()
        {
            return Peanut.Amount;
        }
        public string GetName()
        {
            return Peanut.Name;
        }
        
        public long? GetWholesalePrice()
        {
            return Peanut.WholesalePrice;
        }

        public long? GetUnitCost()
        {
            return Peanut.UnitCost;
        }
        public abstract void CreatePeanutFlavor();
    }
}
