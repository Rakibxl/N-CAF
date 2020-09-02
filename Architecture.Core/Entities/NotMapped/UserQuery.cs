
namespace Architecture.Core.Entities.NotMapped
{
    public class UserQuery : IQueryObject
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}


