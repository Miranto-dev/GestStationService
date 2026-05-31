
namespace GestStationService.Models
{
    public class Cuve
    {
        public int IdCuve { get; set; }
        public int CapaciteMax { get; set; }
        private int _niveauActu;
        public int NiveauActu
        {
            get => _niveauActu;
            set
            {
                if(value > CapaciteMax)
                {
                    throw new Exception($"La valeur {value} doit être inférieur à {CapaciteMax} de la cuve");
                }
                _niveauActu = value;
            }
        }

        public int IdProd { get; set; }
        public virtual Produit Produit { get; set; }
    }
}
