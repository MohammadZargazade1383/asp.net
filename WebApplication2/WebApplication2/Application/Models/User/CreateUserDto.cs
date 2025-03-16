namespace WebApplication2.Application.Models.User
{
    public class CreateUserDto
    {

        public string UserName { get; set; }
        public int Password { get; set; }

        public int AgainPassword { get; set; }
    }
}
