using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class UserMap: EntityTypeConfiguration<UserEntity>
    {
        public UserMap()
        {
            ToTable("Users");
            //加上下面这句，会生成一张关联表UserRoleRelations，与DataBaseContext中的OnModelCreating()相辅相成
            //HasMany(t => t.Roles).WithMany(t => t.Users).Map(m => m.ToTable("UserRoleRelations").MapLeftKey("UserID").MapRightKey("RoleID"));
            Property(p => p.ID).IsRequired();//可以不写，因为CodeFirst会自动将ID设为主键
            Property(p => p.Name).HasMaxLength(50).IsRequired().IsUnicode(true);
            Property(p => p.Age).IsRequired();
            Property(p => p.DeleteStatus).IsRequired();
            HasRequired(p => p.Photo).WithRequiredPrincipal(a => a.User);//Map(a => a.MapKey("PhotoID"));
        }
    }
}
