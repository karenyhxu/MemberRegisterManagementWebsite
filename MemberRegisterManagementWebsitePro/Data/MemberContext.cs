using MemberRegisterManagementWebsitePro.Models;
using Microsoft.EntityFrameworkCore;

namespace MemberRegisterManagementWebsitePro.Data {
    public class MemberContext : DbContext {

        public MemberContext(DbContextOptions<MemberContext> options) : base(options) {
        }

        public DbSet<Member> Members { get; set; }
    }
}
