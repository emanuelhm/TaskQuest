using Microsoft.AspNet.Identity.EntityFramework;

namespace TaskQuest.Models
{
    public class UserRole : IdentityUserRole<int>
    {
        public int Id { get; set; }
    }

    public class UserClaim : IdentityUserClaim<int>
    {
    }

    public class UserLogin : IdentityUserLogin<int>
    {
        public int Id { get; set; }
    }

    public class Role : IdentityRole<int, UserRole>
    {
        public Role()
        {
        }

        public Role(string name)
        {
            Name = name;
        }
    }

    public class UserStore : UserStore<User, Role, int,
        UserLogin, UserRole, UserClaim>
    {
        public UserStore(DbContext context)
            : base(context)
        {
        }

        public int Id { get; set; }
    }

    public class RoleStore : RoleStore<Role, int, UserRole>
    {
        public RoleStore(DbContext context)
            : base(context)
        {
        }

        public int Id { get; set; }
    }
}