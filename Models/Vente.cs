namespace GestStationService.Models
{
    public class Vente
    {
        public int IdVente { get; set; }
        public DateTime DateHeure { get; set; }
        public int QteLitre { get; set; }
        public double MontantV { get; set; }
        public int NumFact { get; set; }
        public DateTime DateEmis { get; set; }
        public string StatutFact { get; set; }

        public int IdCli { get; set; }
        public int IdEmp { get; set; }
        public int IdPompe { get; set; }
        public virtual Client Client { get; set; }
        public virtual Employe Employe { get; set; }
        public virtual Pompe Pompe { get; set; }
        public virtual List<Paiement> Paiement { get; set; }
    }
}
