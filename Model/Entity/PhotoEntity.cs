using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entity
{
    public class PhotoEntity
    {
        public int ID { get; set; }
        //[ForeignKey("User")]
        //public int UserID { get; set; }
        public string Path { get; set; }
        public string Caption { get; set; }
        
        public virtual UserEntity User { get; set; }
    }
}
