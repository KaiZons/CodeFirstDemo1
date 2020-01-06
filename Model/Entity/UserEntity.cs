using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class UserEntity
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "年龄")]
        public int Age { get; set; }
        public bool DeleteStatus { get; set; }

        public string TempProperty { get; set; }


        //public int RoleID { get; set; }
        //[ForeignKey("Photo")]
        //public int PhotoID { get; set; }
        
        public virtual PhotoEntity Photo { get; set; }
        //public ICollection<RoleEntity> Roles { get; set; } = new List<RoleEntity>();
    }
}
