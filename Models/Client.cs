

namespace GestStationService.Models
{
    public class Client
    {
        
        public int IdCli{ get; set; }
        public string NomCli { get; set; }
        public string? PrenomCli { get; set; }
        public string TelCli { get; set; }
        public virtual List<Vente> Vente { get; set; }
    }

}
