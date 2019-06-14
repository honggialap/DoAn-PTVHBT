using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NomNom.Models
{
    public class BaseModel : Entity<int>
    {
        public bool IsDeleted { get; set; }
        //nếu có thời gian thi thêm vào
        //các trường như thời gian tạo,
        // người tạo, lần cuối update,
        // người update
    }
}