using EntityFramworkCodeFirstFluentApi.Infrastructure;
using EntityFramworkCodeFirstFluentApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramworkCodeFirstFluentApi.Controller
{
    class LibraryController : IDbController<Library>
    {
        Context context;

        public LibraryController()
        {
            context = new Context();
        }

        public List<Library> Index()
        {
            List<Library> libraries = context.Libraries.ToList();
            return libraries;
        }


        public Library Details(int id)
        {
            Library library = context.Libraries.SingleOrDefault(b => b.Id == id);

            if (library == null)
            {
                return new Library();
            }
            return library;
        }

        public Library Create()
        {
            return new Library();
        }


        public Library Create(Library library)
        {
            context.Libraries.Add(library);
            context.SaveChanges();
            return library;
        }

        public Library Edit(int id)
        {
            Library library = context.Libraries.Single(p => p.Id == id);
            if (library == null)
            {
                return new Library();
            }
            return library;
        }

        public Library Edit(int id, Library library)
        {
            Library _library = context.Libraries.Single(p => p.Id == id);

            _library = library;
            context.SaveChanges();

            return library;
        }

        public Library Delete(int id)
        {
            Library library = context.Libraries.Single(p => p.Id == id);
            this.Delete(id, library);
            return library;
        }

        public Library Delete(int id, Library book)
        {
            Library _library = context.Libraries.Single(p => p.Id == id);
            context.Libraries.Remove(_library);
            context.SaveChanges();
            return _library;
        }
    }
}
