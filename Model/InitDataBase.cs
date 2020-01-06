using Model.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public static class InitDataBase
    {
        public static void Init()
        {
            //当Model发生改变时，会重新创建数据库(这个初始化方法SetInitializer的参数有关，
            //当为DropCreateDatabaseIfModelChanges时，每次更改模型都会重建数据库)，
            //可参看：https://www.cnblogs.com/happyframework///archive/2013/03/04/2942578.html
            //注意：在重创数据库的过程中，sqlServer中不能有活动的会话
            //注意：1.没有这句话也会自动创建数据库
            //建议在第一次生成数据库后，将该行代码删掉，
            //或者改成Database.SetInitializer<DataBaseContext>(null);
            //以后通过数据迁移的方式做变更，初次什么都不设置，直接可以用数据迁移来初始化数据库
            //可参考：https://www.cnblogs.com/loverwangshan/p/9915745.html

            /*
             * Entity Framework数据库初始化方式:
                　　Entity Framework通过Database.SetInitializer来指定需要的数据库初始化方式，在方法 protected override void OnModelCreating(DbModelBuilder modelBuilder)进行设置，Database.SetInitializer可指定的数据库共有3种：
                 
                　　1>. CreateDatabaseIfNotExists
                　　CreateDatabaseIfNotExists是Database.SetInitializer指定数据库的默认方式，用于当数据库不存在时，自动创建数据库。由于该方式是默认方式，所以可以不需要任何代码进行指定，当然也可以使用代码来明确的指定。
                Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
                　　2>. DropCreateDatabaseWhenModelChanges
                　　DropCreateDatabaseWhenModelChanges用于当数据模型发生改变时，先删除原数据库，后创建新的数据库。
                Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataBaseContext>());
                　　3>. DropCreateDatabaseAlways
                　　DropCreateDatabaseAlways用于每次均先删除原数据库再创建新的数据库，不管数据模型是否发生改变。
                Database.SetInitializer(new DropCreateDatabaseAlways<DataBaseContext>());
                　　但是，在很多时候，我们希望即使在Entity Framework Code First与数据库不匹配时，宁可Entity Framework Code First报出数据库连接错误，而不希望对数据库进行任何的删除创建操作。Entity Framework Code First提供关闭数据库初始化操作：
                Database.SetInitializer<DataBaseContext>(null);
             */
            //Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());
            //Database.SetInitializer<DataBaseContext>(null);
            //下面这种初始化方式，会在应用程序启动时自动升级，前提需要创建一个迁移配置文件：
            //------(1)打开迁移，会在-ProjectName命令中指定的项目下创建Migrations文件夹，并生成Configuration.cs文件
            //------PM > Enable - Migrations - ContextTypeName "Model.DataBaseContext" - ProjectName "Model" - StartUpProjectName "CodeFirstDemo" - ConnectionStringName "conn" - EnableAutomaticMigrations
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataBaseContext, Configuration>());
        }
    }
}
