using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class RoleMap:EntityTypeConfiguration<RoleEntity>
    {
        public RoleMap()
        {
            ToTable("Roles");
            Property(p => p.ID).IsRequired();
            Property(p => p.RoleName).IsRequired().HasMaxLength(50).IsUnicode(true);
            Property(p => p.Mark).IsOptional().HasMaxLength(200);
            Property(p => p.DeleteStatus).IsRequired();
        }
    }
}
