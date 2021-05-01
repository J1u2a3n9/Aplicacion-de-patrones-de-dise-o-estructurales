using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class PeanutNotifier
    {
        private IPeanutService _peanutService;
        public PeanutNotifier(string flavor)
        {
            switch (flavor.ToLower())
            {
                case "coco":
                case "leche condensada":
                case "coco y leche condensada":
                case "Coco1":
                    _peanutService = new PeanutLecheCondensadaService();
                    break;
                case "miel":
                case "mostaza":
                case "miel y mostaza":
                case "MM1":
                    _peanutService = new PeanutMielYMostazaService();
                    break;
                case "picante":
                case "Picante1":
                    _peanutService = new PeanutPicanteService();
                    break;
                default:
                    _peanutService = new PeanutOreoService();
                    break;
            }
        }

        public void ShowPeanut()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine($"Nombre: {_peanutService.Peanut.Name}");
            Console.WriteLine($"Fecha de elaboracion: {_peanutService.Peanut.ElaborationDate.ToString()}");
            Console.WriteLine($"Fecha de expiracion: {_peanutService.Peanut.ExpirationDate.ToString()}");
            Console.WriteLine($"Precio Unitario: {_peanutService.Peanut.UnitCost}");
            Console.WriteLine($"Precio Por mayor: {_peanutService.Peanut.WholesalePrice}");
            Console.WriteLine($"Cantidad en stock: {_peanutService.Peanut.Amount}");
            Console.WriteLine($"La produccion de este sabor es {(_peanutService.Peanut.ProductionStatus.ToString())}");
        }



        public void ShowPeanutBillingUnitCost(IEnumerable<IPeanutService> peanuts)
        {
            int? cantidad = 50;
            foreach(var peanut in peanuts)
            {
                cantidad = cantidad - peanut.GetAmount();
                Console.WriteLine("CANTIDAD             CONCEPTO            PRECIO UNITARIO         SUBTOTAL");
                Console.WriteLine($"{cantidad}                   {_peanutService.Peanut.Name}            {_peanutService.Peanut.UnitCost}            {_peanutService.Peanut.UnitCost} ");
            }   
        }
    }

}
