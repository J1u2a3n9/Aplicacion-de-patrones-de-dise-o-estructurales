using System;
using System.Collections.Generic;
using System.Text;

namespace McNutClients
{
    public class PeanutFacade
    {
        private PeanutLecheCondensadaService _lecheCondensada;
        private PeanutMielYMostazaService _mielYMostaza;
        private PeanutOreoService _oreo;
        private PeanutPicanteService _picante;
        private List<IPeanutService> _peanuts;
        public PeanutFacade()
        {
            _peanuts = new List<IPeanutService>();
            _lecheCondensada = new PeanutLecheCondensadaService();
            _mielYMostaza = new PeanutMielYMostazaService();
            _oreo = new PeanutOreoService();
            _picante = new PeanutPicanteService();
        }

        public IEnumerable<IPeanutService> GetPeanuts()
        {
            return _peanuts;

        }
        public void CreatePeanutStore()
        {
            _lecheCondensada.CreatePeanutFlavor();
            _mielYMostaza.CreatePeanutFlavor();
            _oreo.CreatePeanutFlavor();
            _picante.CreatePeanutFlavor();
            _peanuts.Add(_lecheCondensada);
            _peanuts.Add(_mielYMostaza);
            _peanuts.Add(_oreo);
            _peanuts.Add(_picante);
        }

        public void AddAmount(string Flavorpeanut,int amount)
        {
            IPeanutService peanut;
            switch (Flavorpeanut)
            {
                case "Coco1":
                    peanut = _lecheCondensada;
                    break;
                case "MM1":
                    peanut =_mielYMostaza;
                    break;
                case "Picante1":
                    peanut = _picante;
                    break;
                default:
                    peanut = _oreo;
                    break;
            }
            peanut.AddAmount(amount);
            _peanuts.Add(peanut);
        }



    }
}
