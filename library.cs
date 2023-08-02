using System.Collections.Generic;
using static System.Reflection.Metadata.BlobBuilder;

namespace Program
{
    public class Program
    {
        public static void Main()
        {
            Book book = new Book("The legend", "aymen Eliyas", "191019", 2022);
            MediaItem media = new MediaItem("Friends", "CD", 148);


            Book book2 = new Book("call", "someone", "2219", 2021);
            MediaItem media2 = new MediaItem("throwback", "CD", 18);

            Library lib = new Library("practice library"," somewhere");
            lib.AddBook(book);
            lib.AddBook(book2);
            lib.AddMediaItem(media);
            lib.AddMediaItem(media2);
            lib.RemoveMediaItem(media);

            lib.PrintCatalog();
            Console.WriteLine("enter book to search");
            string input = Console.ReadLine();
            lib.SearchBooks(input);

            Console.WriteLine("enter media to search");
            string med = Console.ReadLine();
            lib.SearchMedia(med);
        }
    }

    public class Library
    {
        public string Name;
        public string Address;
        public List<Book> Books = new List<Book>();
        public List<MediaItem> MediaItems { get; } = new List<MediaItem>();

        public Library(string Name, string Address)
        {
            this.Name = Name;
            this.Address = Address;
        }
        public void AddBook(Book book)
        {
            Books.Add(book);
        }
        public void RemoveBook(Book book)
        {
            Books.Remove(book);
        }
        public void AddMediaItem(MediaItem mediaItem)
        {
            MediaItems.Add(mediaItem);
        }

        public void RemoveMediaItem(MediaItem mediaItem)
        {
            MediaItems.Remove(mediaItem);
        }
    
        public void PrintCatalog()
        {
            int i = 1;
            int j = 1;
            Console.WriteLine($"Library Name: {Name} \n Library Adress:{Address}");
            foreach (var book in Books)
            {
                Console.WriteLine($"{i} book name: {book.Title} written by: {book.Author} ISBN: {book.ISBN} year: {book.PublicationYear} ");
                i++;
            }
            foreach (var media in MediaItems)
            {
                Console.WriteLine($"{j} Media item name: {media.Title} with type: {media.MediaType} and  {media.Duration} mins");
                j++;
            }
        }

        public void SearchBooks(string input)
        {
            bool check = false;
            Console.WriteLine("Search Result:");
            if (Books.Count > 0)
            {
                foreach (Book book in Books)
                {
                    if (input == book.Title || input == book.Author)
                    {
                        Console.WriteLine($"book name: {book.Title} written by: {book.Author} ISBN: {book.ISBN} year: {book.PublicationYear} ");
                        check = true;
                    }
                }
            }
            if (check == false)
                Console.WriteLine("Not Found In Books");
        }

        public void SearchMedia(string input)
        {
            bool check = false;
            Console.WriteLine("\nSearch Result:");
            if (MediaItems.Count > 0)
            {
                foreach (MediaItem media in MediaItems)
                {
                    if (input == media.Title)
                    {
                        Console.WriteLine($"Media item name: {media.Title} with type: {media.MediaType} and  {media.Duration} mins");
                        check = true;
                    }

                }
            }
            if (check == false)
                Console.WriteLine("Not Found In Media");
        }
    }



}



    public class Book
    {
        internal string Title { get; set; }
        internal string Author { get; set; }
        internal string ISBN { get; set; }
        internal int PublicationYear { get; set; }

        public Book(string Title,String Author, String ISBN, int PublicationYear)
        {
            this.Title = Title;
            this.Author = Author;
            this.ISBN = ISBN;
            this.PublicationYear = PublicationYear;
        }
    }


    public class MediaItem
    {
        internal string Title { get; set; }
        internal string MediaType { get; set; }
        internal int Duration { get; set; }

        public MediaItem(string Title,string MediaType,int Duration) 
        { 
            this.Title = Title;
            this.MediaType = MediaType;
            this.Duration = Duration;
        }

    }

