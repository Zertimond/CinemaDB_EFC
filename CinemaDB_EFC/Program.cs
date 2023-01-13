using CinemaDB_EFC.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace CinemaDB_EFC
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // lock
            var locker = new object();
            int Index = 0;
            var clientThread = new ThreadStart(() =>
            {
                Console.WriteLine($"Client thread started{Thread.CurrentThread.ManagedThreadId}");
                using (var context = new CinemaContext())
                {
                    for (int i = 0; i < 2; i++)
                    {

                        lock (locker)
                        {
                            Index++;
                            context.Tickets.Add(new Ticket
                            {
                                TicketId = 20 + Index,
                                ShowId = 4,
                                Place = Index,
                                Cost = 100
                            });
                            context.SaveChanges();
                        }
                    }
                }
            });
            var thread1 = new Thread(clientThread);
            var thread2 = new Thread(clientThread);
            var thread3 = new Thread(clientThread);

            thread1.Start();
            thread2.Start();
            thread3.Start();

            var allThreadsAreDone = false;
            while (!allThreadsAreDone)
            {
                allThreadsAreDone = thread1.ThreadState == System.Threading.ThreadState.Stopped &&
                                    thread2.ThreadState == System.Threading.ThreadState.Stopped &&
                                    thread3.ThreadState == System.Threading.ThreadState.Stopped;
            }
            Console.WriteLine(Index);


            //// паралельно зчитаю з БД
            //// використовуючи Thread
            //var db = new CinemaContext();
            //var tickets = await db.Tickets.ToListAsync();


            //ThreadStart action = () =>
            //{
            //    for (int i = 0; i < (tickets.Count - 1) / 2; i++)
            //    {
            //        Console.WriteLine(tickets[i].Place + " " + tickets[i].Cost + " " + Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(500);
            //    }
            //};
            //ThreadStart action2 = () =>
            //{
            //    for (int i = (tickets.Count - 1) / 2; i < tickets.Count - 1; i++)
            //    {
            //        Console.WriteLine(tickets[i].Place + " " + tickets[i].Cost + " " + Thread.CurrentThread.ManagedThreadId);
            //        Thread.Sleep(500);
            //    }
            //};

            //var thread1 = new Thread(action);
            //var thread2 = new Thread(action2);

            //thread1.Start();
            //thread2.Start();

            //await db.DisposeAsync();

            //// використовуючи Task
            //var db = new CinemaContext();
            //var tickets = await db.Tickets.ToListAsync();

            //var task1 = Task.Run(() =>
            //{
            //    for (int i = 0; i < (tickets.Count - 1) / 2; i++)
            //    {
            //        Console.WriteLine(tickets[i].Place + " " + tickets[i].Cost + " " + Thread.CurrentThread.ManagedThreadId);
            //        Task.Delay(500).Wait();
            //    }
            //});

            //var task2 = Task.Run(() =>
            //{
            //    for (int i = (tickets.Count - 1) / 2; i < tickets.Count - 1; i++)
            //    {
            //        Console.WriteLine(tickets[i].Place + " " + tickets[i].Cost + " " + Thread.CurrentThread.ManagedThreadId);
            //        Task.Delay(500).Wait();
            //    }
            //});

            //await Task.WhenAll(task1, task2);

            //await db.DisposeAsync();
        }
    }
}
