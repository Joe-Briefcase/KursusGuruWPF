using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KursusGuru.Data_Layer
{
    // A Class representing books
    public class Book
    {
        int Id { get; set; }
        string Title { get; set; }
        string Author { get; set; }
        string ISBN { get; set; }
        public Book(int Id, string Title, string Author, string ISBN)
        {
            this.Id = Id;
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
        }
    }
}
