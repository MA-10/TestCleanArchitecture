using Core.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class User : IEntity
    {
        public Guid Id { get; set; } = new Guid();
        public String Name { get; set; }
        public String Email { get; set; }

    }
}
