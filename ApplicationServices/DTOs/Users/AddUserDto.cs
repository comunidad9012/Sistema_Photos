namespace ApplicationsServices.DTOs.Users
{
    public class AddUserDto
    {

        // es toda la informacion que se va a mostrar al usuario 
        public long Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string? Mobile { get; set; }
        public long UserRol { get; set; }
    }
}
