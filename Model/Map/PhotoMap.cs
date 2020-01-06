using Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Map
{
    public class PhotoMap: EntityTypeConfiguration<PhotoEntity>
    {
        public PhotoMap()
        {
            //https://blog.csdn.net/jackljf/article/details/8258199
            ToTable("Photos");
            Property(a => a.ID).IsRequired();
            //Property(a => a.UserID).IsRequired();
            Property(a => a.Path).IsRequired();
            Property(a => a.Caption).IsRequired();
            HasRequired(a => a.User).WithRequiredDependent(a => a.Photo);//Map(a=>a.MapKey("UserID2"));//Photo必须要有对应的User，User包含一个可为空的Photo  （WithOptional配合HasRequired使用）
            //Map必须指定一个不存在的属性名  WithRequiredDependent会在Photo实体中创建一个外键
        }
    }
}
