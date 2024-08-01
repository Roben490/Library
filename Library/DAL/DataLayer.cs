using Library.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Library.DAL
{
    public class DataLayer : DbContext
    {
        //יוצרים בנאי ואת הפונקציות הקיימות בו מחברים לו בייס 
        public DataLayer(string connectionString) : base(GetOption(connectionString))
        {
            //וידוא שקיים כבר DB כזה
            Database.EnsureCreated();
            seed();
        }

    private void seed()
    {

        if (Lliberies.Count() > 0)
        {
            return;
        }
            //מופע חדש של פרינד בתוך הטבלה
            Libery firstLibery = new Libery();
            //השמת הנתונים 
            firstLibery.zzaner = "חסידות";
            //הכנסה של התוצאה לתוך הפרינד'ס 
            Shelf shelf = new Shelf()
            {
                liberies = firstLibery,
                High = 2,
                Widgh = 30
            };
            Book book = new Book()
            {
                Name = "חפץ חיים",
                High = 2,
                Widgh = 2,
                shelf = shelf
            };
            shelves.Add(shelf);
            books.Add(book);   
            Lliberies.Add(firstLibery);
            SaveChanges();
        }



    //יצירת טבלה בדאטה בייס
    public DbSet<Libery> Lliberies { get; set; }
    public DbSet<Shelf> shelves { get; set; }
    public DbSet<Book> books { get; set; }
 
        
        //פונקציה שיוצרת חיבות לאסקיואל סרבר היא מקבל את הכתובת חיבור
        private static DbContextOptions GetOption(string connectionString)
        {
            //ואז נכנסים לקלאס שיוצר ובוחרים את האסקיאל ושמים לו אופציה של יצירת דאטה בייס עם הקונקט סטרינג
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }
    }



}

