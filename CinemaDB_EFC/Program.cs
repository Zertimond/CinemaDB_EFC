using CinemaDB_EFC.Models;
using Microsoft.EntityFrameworkCore;

namespace CinemaDB_EFC
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add
            using (CinemaContext db = new CinemaContext())
            {
                Cinema cinema = new Cinema {CinemaId = 3, CinemaName = "Butterfly" };
                db.Cinemas.Add(cinema);
                db.SaveChanges();
            }

            using (CinemaContext db = new CinemaContext())
            {
                var cinemas = db.Cinemas.ToList();
                Console.WriteLine("List of cinemas:");
                foreach (Cinema b in cinemas)
                {
                    Console.WriteLine($"{b.CinemaId}.{b.CinemaName}");
                }
            }

            //Update
            using (CinemaContext db = new CinemaContext())
            {
                var cinema = db.Cinemas.FirstOrDefault(x => x.CinemaName == "Butterfly");

                if (cinema != null)
                {
                    cinema.CinemaName = "Filmax";
                    cinema.WorkerAmmount = 30;
                    db.SaveChanges();
                }

                Console.WriteLine("\nUpdated cinema:");
                var users = db.Cinemas.ToList();
                foreach (var u in users)
                {
                    Console.WriteLine($"{u.CinemaId}.{u.CinemaName} - {u.WorkerAmmount}");
                }
            }

            //Delete
            using (CinemaContext db = new CinemaContext())
            {
                var cinema = db.Cinemas.FirstOrDefault(x => x.CinemaName == "Filmax");

                if (cinema != null)
                {
                    db.Cinemas.Remove(cinema);
                    Console.WriteLine("\nCinema removed");
                    db.SaveChanges();
                }
            }
        }
    }
}
