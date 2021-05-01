using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    class PrincipalMainNotifier
    {
        private ClientModel _clientModel;
        public PrincipalMainNotifier()
        {
            _clientModel = new ClientModel();
        }
        public void LaunchPrincipalMenu()
        {
            int opc;
            do
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("         BIENVENIDO AL SISTEMA DE ADMINISTRACION MCNUTS        ");
                Console.WriteLine("1) Comprar Mani");
                Console.WriteLine("2) Visualizar Cliente");
                Console.WriteLine("3) Visualizar Clientes");
                Console.Write("Que opcion desea ? :");
                opc = Convert.ToInt32(Console.ReadLine());
                SelectOption(opc);
            } while (opc < 5);

        }

        private void SelectOption(int opc)
        {
            switch (opc)
            {
                case 1:
                    LauchBuyPeanut();
                    break;
                case 2:
                    LauchVisualizeClient();
                    break;
                case 3:
                    LaunchVisualizeClients();
                    break;
            }
        }


        private void LauchBuyPeanut()
        {
            LaunchPeanutSelection();
        }

        private void LaunchPeanutSelection()
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("         ESTOS SON NUESTROS SABORES DISPONIBLES EN MCNUTS        ");
            Console.WriteLine(" Miel y Mostaza");
            Console.WriteLine(" Leche condesada y coco");
            Console.WriteLine(" Oreo");
            Console.WriteLine(" Picante");
            Console.Write("Que opcion desea ? :");
            string flavor= Convert.ToString(Console.ReadLine());
            Console.Write("Cuantos manis comparara:  ");
            int amount= Convert.ToInt32(Console.ReadLine());
            Console.Write("Cual es su ci:  ");
            long ci = Convert.ToInt64(Console.ReadLine());
            ClientAccess.Access.BuyPeanutFlavor(ci,flavor,amount);


        }

        private void LaunchDeleteClient()
        {
            long ci = LaunchRequestCi();
            ClientAccess.Access.DeleteClient(_clientModel);
        }

        private void LaunchVisualizeClients()
        {
            ClientAccess.Access.ShowClients();
        }

        private void LauchVisualizeClient()
        {
            int ci = LaunchRequestCi();
            ClientAccess.Access.ShowClient(ci);
        }

        private int LaunchRequestCi()
        {
            int ci;
            Console.Write("Ingrese su Ci: ");
            ci = Convert.ToInt32(Console.ReadLine());
            return ci;
        }


  

    }
}

