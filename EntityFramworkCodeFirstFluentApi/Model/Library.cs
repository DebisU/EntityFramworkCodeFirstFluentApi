using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi.Model
{
    class Library
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string address { get; set; }

        public virtual ICollection<Book> BooksInLibrary { get; set; }

        public override string ToString()
        {
            return "Id: " + Id + ", Name: " + Name + ", Address: " + address;
        }
    }
}
