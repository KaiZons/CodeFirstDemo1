using Model.Entity;
using Model.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class DataBaseContext:DbContext
    {
        public DataBaseContext() : base("name=conn")//“name = conn”表示在配置文件中，name等于“conn”的配置项的值表示数据库连接字符串
        {
            //禁用延迟加载
            //延迟加载：每次调用子实体(外键所在的实体)的时候，才去查询数据库. 主表数据加载的时候，不去查询外键所在的从表。
            //关闭延迟加载的办法： db.Configuration.LazyLoadingEnabled = false; 
            //特别注意：关闭延迟加载后,查询主表数据时候,主表的中从表实体为null.
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 禁用默认表名复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            //移除一对多的级联删除约定，想要级联删除可以在 EntityTypeConfiguration<TEntity>的实现类中进行控制（统一设置和单独在具体实体中设置的区别）
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //多对多启用级联删除约定，不想级联删除可以在删除前判断关联的数据进行拦截
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            //-----通过下面的语句将实体的配置信息加进来-----

            //不使用modelBuilder.Configurations.AddFromAssembly方法则需要逐个添加,如果数量多的话比较麻烦,如：
            //modelBuilder.Configurations.Add(new UserMap());
            //modelBuilder.Configurations.Add(new RoleMap());
            //此方法可以将当前程序集下所有继承了ComplexTypeConfiguration、EntityTypeConfiguration类型的类添加到注册器
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<UserEntity> UserEntities { get; set; }

        public DbSet<RoleEntity> RoleEntities { get; set; }

    }
}
