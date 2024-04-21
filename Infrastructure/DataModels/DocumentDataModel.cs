namespace Infrastructure.DataModels
{
    public class DocumentDataModel
    {
        public Guid Id { get; set; }
        public string DocumentUrl { get; set; }

        public DateTime ValidUntile { get; set; }

        // we merge all documents in one table and use this property for detect original property that it belongs to
        public string Descriminator { get; set; }

        //suppose we need it for better query's performance
        public int PersianValidUntil_Year { get; set; }
        //suppose we need it for better query's performance
        public int PersianValidUntil_Month { get; set; }
        //suppose we need it for better query's performance
        public int PersianValidUntil_Day { get; set; }

    }
}
