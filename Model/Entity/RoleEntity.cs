using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class RoleEntity
    {
        public int ID { get; set; }
        public string RoleName { get; set; }
        public string Mark { get; set; }
        public bool DeleteStatus { get; set; }
        public string Temp { get; set; }
        //public ICollection<UserEntity> Users { get; set; } = new List<UserEntity>();
    }
}
