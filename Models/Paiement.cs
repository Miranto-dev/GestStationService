namespace GestStationService.Models
{
    public class Paiement
    {
        public int IdPaye { get; set; }
        public DateTime DatePaye { get; set; }
        public double MontantPaye { get; set; }
        public string ModePaye { get; set; }

        public int IdVente { get; set; }
        public virtual Vente Vente { get; set; }
    }
}
