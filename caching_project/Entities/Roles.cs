namespace dotnetcaching.Entities
{
    public class Roles
    {
        public int idRol { get; set; }
        public string? code { get; set; }
        public string? description { get; set; }
        public DateTime systemDate { get; set; }
        public byte status { get; set; }
    }
}