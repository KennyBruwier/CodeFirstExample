using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeFirstExample
{
    class Program
    {
        /* When database is still in use and you can't change it, do the following query in msSQL:
         * 
         * alter database YourDb set single_user with rollback immediate

           alter database YourDb set MULTI_USER
         */
        static void Main(string[] args)
        {
            Console.WriteLine("starting...");
            //using(NotitieboekjeContext ctx = new NotitieboekjeContext())
            //{
            //    ctx.Notitieboekjes.Add(new Notitieboekje() 
            //    { 
            //        Naam = "Dagboek", 
            //        Kleur = "rood",
            //        Grootte = 10
            //    }) ;
            //    ctx.SaveChanges();
            //}
            using(PeopleHobbiesOrdersContext ctx = new PeopleHobbiesOrdersContext())
            {
                ctx.Role.Add(new Role()
                {
                    Name = "MijnRol"
                });
                ctx.People.Add(new People()
                {
                    First_name = "Kenny",
                    Last_name = "Bruwier",
                    Birthday = new DateTime(year: 1981, month: 7, day: 13),
                    VDAB_Nummer = "546654644",
                    Getrouwd = false,
                    Email = "kenny.bruwier@gmail.com",
                    Role = new Role() { Name = "KennyRol" }
                });
                ctx.SaveChanges();
            }
            Console.WriteLine("end");

            Console.ReadLine();
        }
    }
    public class People
    {
        [Key]
        public int PeopleId { get; set; }
        public string First_name { get; set; }
        public string Last_name { get; set; }
        public DateTime Birthday { get; set; }
        public string VDAB_Nummer { get; set; }
        public bool Getrouwd { get; set; }
        public string Email { get; set; }
        //[ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public ICollection<People_Hobbies> People_Hobbies { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        public string Name { get; set; }
        public ICollection<People> People { get; set; }
    }
    public class People_Hobbies
    {
        [Key]
        [Column(Order = 1)]
        public int PeopleId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int HobbieId { get; set; }
        public People People { get; set; }
        public Hobbie Hobbie { get; set; }
    }
    public class Hobbie
    {
        [Key]
        public int HobbieId { get; set; }
        public string Name { get; set; }
        public ICollection<People_Hobbies> People_Hobbies { get; set; }
    }
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int StatusId { get; set; }
        public int PeopleId { get; set; }
        public People People { get; set; }
        public int Quantity { get; set; }
        public double Unit_Price { get; set; }
        public DateTime Order_date { get; set; }
    }
    public class PeopleHobbiesOrdersContext : DbContext
    {
        public PeopleHobbiesOrdersContext() : 
            base("name=PeopleHobbiesOrdersDBConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PeopleHobbiesOrdersContext>());
        }
        public DbSet<People> People { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<People_Hobbies> People_Hobbies { get; set; }
        public DbSet<Hobbie> Hobbie { get; set; }
        public DbSet<Order> Order { get; set; }
    }

    // ---------------------------------------------------------------------------------

    public class Notitieboekje
    {
        [Key]
        public int NotitieboekjeId { get; set; }
        [MaxLength(50)]
        public string Naam { get; set; }
        public string Kleur { get; set; }
        public int Grootte { get; set; }
    }
    public class Pagina
    {
        [Key]
        public int PaginaId { get; set; }
        public string Tekst { get; set; }
        // [ForeignKey("Notitieboekjes")]
        public Notitieboekje Notitieboekje { get; set; }
    }
    public class NotitieboekjeHobbies
    {
        [Key]
        [Column(Order = 1)]
        public int NotitieboekjeId { get; set; }
        [Key]
        [Column(Order = 2)]
        public int HobbyId { get; set; }
    }
    public class NotitieboekjeContext : DbContext
    {
        public NotitieboekjeContext() : base("name=NotitieboekjeDBConnectionString")
        {
            //Database.SetInitializer(new CreateDatabaseIfNotExists<NotitieboekjeContext>());
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<NotitieboekjeContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<NotitieboekjeContext>());
        }
        public DbSet<Notitieboekje> Notitieboekjes { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<NotitieboekjeHobbies> Hobbies { get; set; }
    }
}
