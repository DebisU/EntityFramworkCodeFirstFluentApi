using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi.Model
{
    class Book
    {
        public int BookID { get; set; }
        public string BookName { get; set; }
        public string ISBN { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

        public override string ToString()
        {
            return "Id: " + BookID + ", Name: " + BookName + ", ISBN: " + ISBN;
        }
    }
}
