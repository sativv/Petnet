namespace WebApi.Models.APIModels
{
    public class RegisterUser
    {
        public bool? IsPrivateSeller { get; set; }

        public bool? IsVerified { get; set; }
        public long? OrganizationNumber { get; set; }
        public string? OrganizationName { get; set; }
        public string? BuisnessContact { get; set; }
        public string? Adress { get; set; }
        public int? Postcode { get; set; }
        public string? City { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }

        public List<FileModel> MyFiles { get; set; } = new List<FileModel>();
    }
}
