namespace PortalUsuario.Shared.Models;

public class TicketsModel
{
    public dynamic reopenedIn { get; set; }
    public dynamic closedIn { get; set; }
    public dynamic resolvedIn { get; set; }
    public string status { get; set; }
    public int origin { get; set; }
    public int Type { get; set; }
    public int Id { get; set; }
    public List<Owner> owner { get; set; }
    
    public class Owner
    {
        public string id { get; set; }
        public int personType { get; set; }
        public int profileType { get; set; }
        public string businessName { get; set; }
        public string email { get; set; }
        public string phone { get; set; }
        public string pathPicture { get; set; }
    }
    
}

