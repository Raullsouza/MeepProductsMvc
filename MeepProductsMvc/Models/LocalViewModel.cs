namespace MeepProductsMvc.Models
{
    public class LocalViewModel
    {
        public int Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public ICollection<PortalViewModel> Portais { get; set; }
    }
}
