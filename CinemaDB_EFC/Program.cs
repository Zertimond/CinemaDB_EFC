using CinemaDB_EFC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CinemaDB_EFC
{
    class Program
    {
        static void Main(string[] args)
        {
            //union, except, intersect, join, distinct, group by, агрегатні функції

            ////список фільмів та сеансів
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var film = db.Films.Select(x => new
            //    {
            //        FilmId = x.FilmId,
            //        FilmName = x.FilmName,
            //    });
            //    foreach (var item in film)
            //    {
            //        Console.WriteLine($"FilmName: {item.FilmName}");
            //        Console.WriteLine($"FilmId: {item.FilmId}\n");
            //    }
            //    Console.WriteLine("***********************");
            //    var show = db.Shows.Select(x => new
            //    {
            //        FilmId = x.FilmId,
            //        BoughtTickets = x.BoughtTickets,
            //    });
            //    foreach (var item in show)
            //    {
            //        Console.WriteLine($"BoughtTickets: {item.BoughtTickets}");
            //        Console.WriteLine($"FilmId: {item.FilmId}\n");
            //    }
            //    var cinema = db.Cinemas.Select(x => new
            //    {
            //        CinemaId = x.CinemaId,
            //        CinemaName = x.CinemaName,
            //    });
            //    foreach (var item in cinema)
            //    {
            //        Console.WriteLine($"CinemaId: {item.CinemaId}");
            //        Console.WriteLine($"CinemaName: {item.CinemaName}\n");
            //    }
            //}

            ////union
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var films = db.Films.Where(u => u.FilmName == "Spider Man")
            //        .Union(db.Films.Where(u => u.Genre == "Superhero"));
            //    foreach (var item in films)
            //        Console.WriteLine($"FilmName: {item.FilmName}");
            //}

            ////except
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var films = db.Films.Where(u => u.Genre == "Superhero")
            //        .Except(db.Films.Where(u => u.FilmName == "Spider Man"));
            //    foreach (var item in films)
            //        Console.WriteLine($"FilmName: {item.FilmName}");
            //}

            ////intersect
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var films = db.Films.Where(u => u.Genre == "Superhero")
            //        .Intersect(db.Films.Where(u => u.FilmName == "Spider Man"));
            //    foreach (var item in films)
            //        Console.WriteLine($"FilmName: {item.FilmName}");
            //}

            ////join
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var films = db.Shows.Join(db.Films, // второй набор
            //        u => u.FilmId, // свойство-селектор объекта из первого набора
            //        c => c.FilmId, // свойство-селектор объекта из второго набора
            //        (u, c) => new // результат
            //        {
            //            FilmName = c.FilmName,
            //            Genre = c.Genre,
            //            BoughtTickets = u.BoughtTickets
            //        });
            //    foreach (var u in films)
            //        Console.WriteLine($"{u.FilmName} ({u.Genre}) - {u.BoughtTickets}");
            //}

            ////distinct
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var result = db.Shows.Select(x => x.BoughtTickets).Distinct();
            //    foreach (var show in result)
            //    {
            //        Console.WriteLine($"BoughtTickets: {show}");
            //    }
            //}

            ////group by and Count
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var groups = from u in db.Tickets
            //                 group u by u.Show!.FilmId into g
            //                 select new
            //                 {
            //                     g.Key,
            //                     Count = g.Count()
            //                 };
            //    foreach (var group in groups)
            //    {
            //        Console.WriteLine($"FilmID: {group.Key} - Ticket number: {group.Count}");
            //    }
            //}

            //приклади різних стратегій завантаження зв'язаних даних

            ////Eager
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var show = db.Shows.Include(x => x.Hall).ToList();
            //    foreach (var film in show)
            //    {
            //        Console.WriteLine($"ShowId: {film.ShowId}");
            //        Console.WriteLine($"BoughtTickets: {film.BoughtTickets}");
            //        Console.WriteLine($"HallId: {film.Hall.HallId}");
            //        Console.WriteLine("**********************************************");
            //    }
            //}

            ////Explicit
            //using (CinemaContext db = new CinemaContext())
            //{
            //    Show? show = db.Shows.FirstOrDefault();
            //    if (show != null)
            //    {
            //        db.Tickets.Where(u => u.ShowId == show.ShowId).Load();
            //        Console.WriteLine($"ShowId: {show.ShowId}");
            //        foreach (var u in show.Tickets)
            //        {
            //            Console.WriteLine($"Place: {u.Place}");
            //            Console.WriteLine($"Cost: {u.Cost}");
            //            Console.WriteLine("***********");
            //        }
            //    }
            //}

            ////Lazy
            //using (CinemaContext db = new CinemaContext())
            //{
            //    Show? show = db.Shows.FirstOrDefault();
            //    if (show != null)
            //    {
            //        Console.WriteLine($"ShowId: {show.ShowId}");
            //        foreach (var u in show.Tickets)
            //        {
            //            Console.WriteLine($"Place: {u.Place}");
            //            Console.WriteLine($"Cost: {u.Cost}");
            //            Console.WriteLine("***********");
            //        }
            //    }
            //}

            ////завантаження даних що не відслідковуються
            //using (CinemaContext db = new CinemaContext())
            //{
            //    var show = db.Shows.AsNoTracking().FirstOrDefault(x => x.ShowId == 2);
            //    if (show != null)
            //    {
            //        show.BoughtTickets = 10;
            //        db.SaveChanges();
            //    }
            //    var shows = db.Shows.AsNoTracking().ToList();
            //    foreach (var x in shows)
            //        Console.WriteLine($"{x.ShowId} - {x.BoughtTickets}");
            //}

            ////виклик збережених процедур та функцій за допомогою Entity Framework
            //using (CinemaContext db = new CinemaContext())
            //{
            //    SqlParameter param = new SqlParameter("@id", 2);
            //    var films = db.Films.FromSqlRaw("SELECT * FROM GetFilmGenre (@id);", param).ToList();
            //    foreach (var p in films)
            //        Console.WriteLine($"FilmName: {p.FilmName} - Genre: {p.Genre}");
            //}

            //Найпопулярніші кінотеатри
            using (CinemaContext db = new CinemaContext())
            {
                var result = db.Shows
                    //.Where(x => x.ShowDate.DayOfWeek.ToString() == "Saturday")
                    .GroupBy(x => x.Hall!.CinemaId)
                    .Select(x => new
                    {
                        CinemaId = x.Key,
                        Tickets = x.Sum(y => y.BoughtTickets)
                    })
                    .OrderByDescending(x => x.Tickets)
                    .Take(3)
                    .Join(db.Cinemas, x => x.CinemaId, y => y.CinemaId, (x, y) => new
                    {
                        CinemaName = y.CinemaName,
                        Tickets = x.Tickets
                    })
                    .ToList();
                foreach (var x in result)
                    Console.WriteLine($"CinemaName: {x.CinemaName} - Tickets: {x.Tickets}");
            }
        }
    }
}
