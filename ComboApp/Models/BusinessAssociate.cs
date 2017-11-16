namespace ComboApp.Models
{
    public class BusinessAssociate
    {
        public int BusinessAssociateId { get; set; }
        public string Number { get; set; }
        public string Matchcode { get; set; }
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Blocked { get; set; }
        public string Information { get; set; }
    }
}
