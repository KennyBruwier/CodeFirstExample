using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("starting...");
            using(var ctx = new NotitieboekjeContext())
            {
                ctx.Notitieboekjes.Add(new Notitieboekje() { Naam = "Dagboek" }) ;
                ctx.SaveChanges();
            }
            Console.WriteLine("end");
            Console.ReadLine();
        }
    }
    public class Notitieboekje
    {
        public int NotitieboekjeId { get; set; }
        public string Naam { get; set; }
    }
    public class Pagina
    {
        public int PaginaId { get; set; }
        public string Tekst { get; set; }
        public Notitieboekje Notitieboekje { get; set; }
    }

    public class NotitieboekjeContext : DbContext
    {
        public NotitieboekjeContext() : base("name=NotitieboekjeDBConnectionString")
        {

        }

        public DbSet<Notitieboekje> Notitieboekjes { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
    }
}
