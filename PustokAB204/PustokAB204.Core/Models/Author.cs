using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PustokAB204.Core.Models
{
    public class Author : BaseEntity
    {
        public string Name { get; set; }
        public List<Book>? Book { get; set; } 

    }
}
