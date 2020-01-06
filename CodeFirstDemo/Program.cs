using Model;
using Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDataBase.Init();
            //数据库连接字符串只能写在启动项的App.config中
            using (DataBaseContext ctx = new DataBaseContext())
            {
                ctx.Database.Log = (c) => Console.WriteLine(c);
                PhotoEntity photo = new PhotoEntity();
                photo.Path = "sdsd";
                photo.Caption = "sdsd";
                UserEntity user = new UserEntity();
                user.Name = "zhoukaikai"; 
                user.Age = 23;
                user.DeleteStatus = false;
                user.Photo = photo;
                //user.PhotoID = 3; 

                ctx.UserEntities.Add(user);
                //如果设置了Database.SetInitializer(new CreateDatabaseIfNotExists<DataBaseContext>());，
                //并且没有数据库时，执行SaveChanges会生成数据库,也可以通过数据迁移来生成数据库
                ctx.SaveChanges();
            }
        }
    }
}
