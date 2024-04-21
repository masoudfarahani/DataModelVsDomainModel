using DomainModel.Snapshots;

namespace DomainModel
{
    public class Document : IEquatable<Document>
    {

        private Document() { }

        private void ValidateDocumentUrl(string url)
        {
            if (string.IsNullOrEmpty(url)) //or whatever you want to check
                throw new Exception("Invalid Document URL");
        }

        private void PreventToSetPastDateAsValidityDate(DateTime validUntile)
        {
            if (validUntile < DateTime.Now)
                throw new Exception("Invalid Validity Date");

        }

        public Document(string documentUrl, DateTime validUntil)
        {
            this.Id = Guid.NewGuid();
            ValidateDocumentUrl(documentUrl);
            PreventToSetPastDateAsValidityDate(validUntil);
            this.DocumentUrl = documentUrl;
            this.ValidUntile = validUntil;
        }
        public Guid Id { get; private set; }
        public string DocumentUrl { get; private set; }
        public DateTime ValidUntile { get; private set; }


        public DocumentSnapshot GetSnapshot()
        {
            return new DocumentSnapshot
            {
                DocumentUrl = this.DocumentUrl,
                Id = this.Id,
                ValidUntile = this.ValidUntile
            };
        }


        public static Document CreateFrom(DocumentSnapshot snapshot)
        {
            return new Document
            {
                Id = snapshot.Id,
                DocumentUrl = snapshot.DocumentUrl,
                ValidUntile = snapshot.ValidUntile,
            };
        }
        public override bool Equals(object? obj) => Equals(obj as Document);

        public bool Equals(Document? other)
        {
            return other != null
                && other.DocumentUrl == this.DocumentUrl
                && other.ValidUntile == this.ValidUntile
                && other.Id == this.Id;
        }


        public override int GetHashCode()
        {
            int hash = 13;
            hash = (hash * 7) + Id.GetHashCode();
            hash = (hash * 7) + DocumentUrl.GetHashCode();
            hash = (hash * 7) + ValidUntile.GetHashCode();
            return hash;
        }
    }
}
