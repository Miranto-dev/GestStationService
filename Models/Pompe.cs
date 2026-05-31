namespace GestStationService.Models
{
    public class Pompe
    {
        public int IdPompe { get; set; }
        public string LibelleP { get; set; }
        public string EtatP { get; set; }
        public double VolTotalDist { get; set; }

        public int IdProd { get; set; }
        public virtual Produit Produit { get; set; }
        public virtual List<Vente> Vente { get; set; }
    }
}
