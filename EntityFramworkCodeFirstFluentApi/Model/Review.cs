using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi.Model
{
    class Review
    {
        public int ReviewID { get; set; }
        public int BookID { get; set; }
        public string ReviewText { get; set; }

        // This will keep track of the book this review belong too
        public virtual Book Book { get; set; }

        public override string ToString()
        {
            return "Review Id: " + ReviewID + ", Book Id: " + BookID + ", Review Text: " + ReviewText;
        }
    }
}
