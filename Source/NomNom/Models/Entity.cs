using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NomNom.Models
{
        public abstract class Entity<TPrimaryKey> 
        {
        public virtual TPrimaryKey Id { get; set; }
    }
}