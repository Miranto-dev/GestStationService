namespace GestStationService.Models
{

    public class Employe
    {
        public int IdEmp { get; set; }
        public string NomEmp { get; set; }
        public string? PrenomEmp { get; set; }
        public string MDPHash { get; set; }
        public string RoleEmp { get; set; }
        public virtual List<Vente> Vente { get; set; }
    }
}
