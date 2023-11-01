namespace dotnetcaching.Entities
{
    public class Policy
    {
        public int idPolicy { get; set; }
        public string? code { get; set; }
        public string? description { get; set; }
        public string? route { get; set; }
        public DateTime systemDate { get; set; }
        public byte status { get; set; }
    }
}