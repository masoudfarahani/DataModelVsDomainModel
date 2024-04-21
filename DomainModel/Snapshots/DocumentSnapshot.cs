namespace DomainModel.Snapshots
{
    public class DocumentSnapshot
    {
        public Guid Id { get;  set; }
        public string DocumentUrl { get;  set; }
        public DateTime ValidUntile { get;  set; }
    }
}
