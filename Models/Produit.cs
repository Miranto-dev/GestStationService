namespace GestStationService.Models
{
    public class Produit
    {
        public int IdProd { get; set; }
        public string NomProd { get; set; }
        public double PrixUnitaire { get; set; }
        public string TypeCarb { get; set; }
        public virtual List<Cuve> Cuve { get; set; }
        public virtual List<Pompe> Pompe { get; set; }
    }
}
