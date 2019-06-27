using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Common
{
    public class UserLogin
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Avatar { get; set; }
        public string Name { get; set; }
        public int ChucVuID { get; set; }
    }
}