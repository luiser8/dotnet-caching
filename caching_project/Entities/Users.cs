namespace dotnetcaching.Entities
{
    public class Users
    {
        public int idUser { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public DateTime systemDate { get; set; }
        public byte status { get; set; }
    }

    public class UserDto
    {
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public string? password { get; set; }
        public int idRol { get; set; }
    }

    public class UsersRolPolicy
    {
        public DataUser? dataUser { get; set; }
        public DataUserRol? dataUserRol { get; set; }
        [Newtonsoft.Json.JsonProperty("policyUser")]
        public List<PolicyUser>? policyUser { get; set; }
    }

    public class DataUser
    {
        public int idUser { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? email { get; set; }
        public bool? statusUser { get; set; }
    }

    public class DataUserRol
    {
        public int idRol { get; set; }
        public string? codeRol { get; set; }
        public string? descriptionRol { get; set; }
        public bool statusRol { get; set; }
    }

    public class PolicyUser
    {
        public int idPolicy { get; set; }
        public string? codePolicy { get; set; }
        public string? descriptionPolicy { get; set; }
        public string? routePolicy { get; set; }
        public bool? statusPolicy { get; set; }
    }
}
