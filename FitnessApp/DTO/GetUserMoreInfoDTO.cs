namespace FitnessApp.DTO
{
    public class GetUserMoreInfoDTO : BaseEntity
    {
        public string ProfilePicture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}
