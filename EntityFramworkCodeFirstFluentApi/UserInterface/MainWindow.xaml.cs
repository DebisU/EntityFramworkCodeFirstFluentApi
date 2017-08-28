using EntityFramworkCodeFirstFluentApi.Controller;
using EntityFramworkCodeFirstFluentApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EntityFramworkCodeFirstFluentApi
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private BookController booksController;
        private ReviewController reviewsController;
        private LibraryController libraryConroller;
        private List<Book> myBooks;
        private List<Library> myLibraries;

        public MainWindow()
        {
            InitializeComponent();
            booksController = new BookController();
            reviewsController = new ReviewController();
            libraryConroller = new LibraryController();
            myBooks = new List<Book>();
            myLibraries = new List<Library>();
            LoadLibraries();
        }

        private void BtInsert_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book()
            {
                BookID = TransformStringIntoInt(TbBookId.Text),
                BookName = TbBookName.Text,
                ISBN = TbISBN.Text,
                LibraryId = TransformStringIntoInt(TbLibId.Text)
            };


            Book createdBook = booksController.Create(book);
            TbBookId.Text = createdBook.BookID.ToString();
            MessageBox.Show("The book with " + createdBook.ToString() + " has been created successfully.");
            LoadBooks();
        }

        private void BtInsertReview_Click(object sender, RoutedEventArgs e)
        {
            Review review = new Review()
            {
                ReviewID = TransformStringIntoInt(TbReviewId.Text),
                BookID = TransformStringIntoInt(TbBookId.Text),
                ReviewText = TbReviewText.Text
            };


            Review createdReview = reviewsController.Create(review);
            TbReviewId.Text = createdReview.ReviewID.ToString(); //change de lb id to the real one
            TbReviewBookId.Text = createdReview.ReviewID.ToString();
            MessageBox.Show("The review with " + createdReview.ToString() + " has been created successfully.");
            LoadBooks();
            LoadReviewsGridByBookId(review.BookID);
        }



        private void BtUpdate_Click(object sender, RoutedEventArgs e)
        {
            Book book = new Book()
            {
                BookID = TransformStringIntoInt(TbBookId.Text),
                BookName = TbBookName.Text,
                ISBN = TbISBN.Text,
                LibraryId = TransformStringIntoInt(TbLibId.Text)
            };

            foreach (var item in book.Reviews)
            {
                item.BookID = book.BookID;
            }  /////////////////////////////////////////////////

            Book editedBook = booksController.Edit(book.BookID, book);
            MessageBox.Show("The book with " + editedBook.ToString() + " has been updated successfully.");
            LoadBooks();
        }

        private void BtUpdateReview_Click(object sender, RoutedEventArgs e)
        {
            Review review = new Review()
            {
                ReviewID = TransformStringIntoInt(TbReviewId.Text),
                BookID = TransformStringIntoInt(TbReviewBookId.Text),
                ReviewText = TbReviewText.Text
            };

            Review editedReview = reviewsController.Edit(review.ReviewID, review);
            MessageBox.Show("The review with " + editedReview.ToString() + " has been updated successfully.");
            LoadBooks();
            LoadReviewsGridByBookId(review.BookID);

        }

        private void BtDelete_Click(object sender, RoutedEventArgs e)
        {
            Book seletedBook = dataGrid.SelectedItems[0] as Book;
            int selectedId = !string.IsNullOrEmpty(TbBookId.Text) ? TransformStringIntoInt(TbBookId.Text) : seletedBook.BookID;

            Book deletedBook = booksController.Delete(selectedId);
            MessageBox.Show("The book with " + deletedBook.ToString() + "has been deleted succesfully");
            LoadBooks();
        }

        private void BtDeleteReview_Click(object sender, RoutedEventArgs e)
        {
            Review seletedReview = reviewDataGrid.SelectedItems[0] as Review;
            int selectedId = !string.IsNullOrEmpty(TbReviewId.Text) ? TransformStringIntoInt(TbReviewId.Text) : seletedReview.BookID;

            Review deletedReview = reviewsController.Delete(selectedId);
            MessageBox.Show("The Review with " + deletedReview.ToString() + "has been deleted succesfully");
            LoadBooks();
            LoadReviewsGridByBookId(deletedReview.BookID);

        }

        private void dataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TbBookId.Text = ((Book)dataGrid.SelectedItem).BookID.ToString();
                TbBookName.Text = ((Book)dataGrid.SelectedItem).BookName;
                TbISBN.Text = ((Book)dataGrid.SelectedItem).ISBN.ToString();
                LoadReviewsGridByBookId(Convert.ToInt32(TbBookId.Text));
            }
            catch (Exception ex) { }
        }

        private void reviewDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TbReviewId.Text = ((Review)reviewDataGrid.SelectedItem).ReviewID.ToString();
                TbReviewBookId.Text = ((Review)reviewDataGrid.SelectedItem).BookID.ToString();
                TbReviewText.Text = ((Review)reviewDataGrid.SelectedItem).ReviewText;
            }
            catch (Exception ex) { }
        }

        private void LoadReviewsGridByBookId(int id)
        {
            try
            {
                List<Review> load = reviewsController.Index().Where(r => r.BookID == id).ToList();
                if (load != null)
                {
                    reviewDataGrid.ItemsSource = load;
                }
            }
            catch (Exception e) { }
        }

        private void LoadBooks()
        {
            myBooks = booksController.Index();
            dataGrid.ItemsSource = myBooks;
        }

        private void LoadLibraries()
        {
            myLibraries = libraryConroller.Index();
            libDataGrid.ItemsSource = myLibraries;
        }

        private void LoadBooksGridByLibraryId(int id)
        {
            try
            {
                List<Book> load = booksController.Index().Where(b => b.LibraryId == id).ToList();
                if (load != null)
                {
                    dataGrid.ItemsSource = load;
                }
            }
            catch (Exception e) { }
        }

        private int TransformStringIntoInt(string input)
        {
            int output;
            int.TryParse(input, out output);
            return output;
        }

        private void BtInsertLibrary_Click(object sender, RoutedEventArgs e)
        {
            Library lib = new Library()
            {
                Id = TransformStringIntoInt(TbLibId.Text),
                Name = TbLibName.Text,
                address = TbLibAddress.Text
            };


            Library createdLibray = libraryConroller.Create(lib);
            TbLibId.Text = createdLibray.Id.ToString();
            MessageBox.Show("The review with " + createdLibray.ToString() + " has been created successfully.");
            LoadLibraries();
            LoadBooks();
        }

        private void BtUpdateLibrary_Click(object sender, RoutedEventArgs e)
        {
            Library library = new Library()
            {
                Id = TransformStringIntoInt(TbLibId.Text),
                Name = TbLibName.Text,
                address = TbLibAddress.Text
 
            };

            Library editedLibrary = libraryConroller.Edit(library.Id, library);
            MessageBox.Show("The library with " + editedLibrary.ToString() + " has been updated successfully.");
            LoadLibraries();
            Test();

        }

        private void BtDeleteLibrary_Click(object sender, RoutedEventArgs e)
        {
            Library selectedLibrary = libDataGrid.SelectedItems[0] as Library;
            int selectedId = !string.IsNullOrEmpty(TbBookId.Text) ? TransformStringIntoInt(TbBookId.Text) : selectedLibrary.Id;

            Library deletedLibrary = libraryConroller.Delete(selectedId);
            MessageBox.Show("The library with " + deletedLibrary.ToString() + "has been deleted succesfully");
            LoadLibraries();
        }

        private void libDataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                TbLibId.Text = ((Library)libDataGrid.SelectedItem).Id.ToString();
                TbLibName.Text = ((Library)libDataGrid.SelectedItem).Name;
                TbLibAddress.Text = ((Library)libDataGrid.SelectedItem).address;
                LoadBooksGridByLibraryId(Convert.ToInt32(TbLibId.Text));
            }
            catch (Exception ex) { }

        }

        private void Test() {
            List<Review> myRevs = new List<Review>();
            myRevs.Add(new Review
            {
                BookID = 1,
                Book = new Book(),
                ReviewID = 1,
                ReviewText = ""
            });
            Book book = new Book()
            {
                BookID = TransformStringIntoInt(TbBookId.Text),
                BookName = TbBookName.Text,
                ISBN = TbISBN.Text,
                LibraryId = TransformStringIntoInt(TbLibId.Text),
                Reviews = myRevs
            };


            Book createdBook = booksController.Create(book);
        }
    }
}
