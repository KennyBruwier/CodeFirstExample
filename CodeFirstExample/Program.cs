using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


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
            Application.Run(new LoginForm());
            Console.WriteLine("starting...");
            #region NotitieboekjeCode
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
            //using(PeopleHobbiesOrdersContext ctx = new PeopleHobbiesOrdersContext())
            //{
            //    ctx.Role.Add(new Role()
            //    {
            //        Name = "MijnRol"
            //    });
            //    ctx.People.Add(new People()
            //    {
            //        First_name = "Kenny",
            //        Last_name = "Bruwier",
            //        Birthday = new DateTime(year: 1981, month: 7, day: 13),
            //        VDAB_Nummer = "546654644",
            //        Getrouwd = false,
            //        Email = "kenny.bruwier@gmail.com",
            //        Role = new Role() { Name = "KennyRol" }
            //    });
            //    ctx.SaveChanges();
            //}
            #endregion
            
        }
    }
    #region DBContexts
    #region MusicApp
    public class MusicAppContext : DbContext
    {
        public MusicAppContext() : base("name=MusicAppDBConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MusicAppContext>());
            this.Configuration.LazyLoadingEnabled = true;   // Entity framework staat lazyloading bij default aan;
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            //modelBuilder.Entity<ArtistSong>()
            //   .HasRequired(f => f.Song)
            //   .WithRequiredDependent()
            //   .WillCascadeOnDelete(false);

            modelBuilder.Entity<Album>()
                .HasMany(a => a.Songs)
                .WithMany(s => s.Albums)
                .Map(cs =>
                {
                    cs.MapLeftKey("AlbumId");
                    cs.MapRightKey("SongId");
                    cs.ToTable("AlbumSongs");
                });
            modelBuilder.Entity<Song>()
                .HasMany(s => s.Artists)
                .WithMany(a => a.Songs)
                .Map(cs =>
                {
                    cs.MapLeftKey("SongId");
                    cs.MapRightKey("ArtistId");
                    cs.ToTable("ArtistSongs");
                });
            modelBuilder.Entity<Song>()
                .HasMany(s => s.Playlists)
                .WithMany(p => p.Songs)
                .Map(cs =>
                {
                    cs.MapLeftKey("SongId");
                    cs.MapRightKey("PlaylistId");
                    cs.ToTable("PlaylistSongs");
                });
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Interaction> Interactions { get; set; }
        public DbSet<Song> Songs { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Playlist> Playlists { get; set; }
       // public DbSet<PlaylistSong> PlaylistSongs { get; set; }
       // public DbSet<SongAlbum> SongAlbums { get; set; }
        // public DbSet<ArtistSong> ArtistSongs { get; set; }
    }
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Firstname { get; set; } = "";
        [MaxLength(50)]
        [Required]
        public string Lastname { get; set; } = "";
        [MaxLength(50)]
        [Required]
        public string Email { get; set; } = "";
        [MaxLength(50)]
        [Required]
        public string Password { get; set; } = "";
        virtual public ICollection<Playlist>Playlists { get; set; } //  Source: https://www.ryadel.com/en/enable-or-disable-lazyloading-in-entity-framework/
                                                                    //  why virtual? it enables Lazy loading and will be overridden.   
                                                                    //  lazy loading = the "SQL query" loads only the data we need instead of loading all data (+relations) and filter afterwards.
        virtual public ICollection<Interaction>Interactions { get; set; }
        public User()
        {
            Playlists = new HashSet<Playlist>();
            Interactions = new HashSet<Interaction>();
        }
    }
    public class Song
    {
        [Key]
        public int SongId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; } = "";
        public int Length { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public virtual ICollection<Interaction> Interactions { get; set; }
        public virtual ICollection<Playlist> Playlists { get; set; }
        //public virtual ICollection<SongAlbum> SongAlbums { get; set; }
        //[InverseProperty(nameof(Album.Songs))]
        public virtual ICollection<Album>Albums { get; set; }
        public virtual ICollection<Artist>Artists { get; set; }
        public Song()
        {
            Albums = new HashSet<Album>();
            Artists = new HashSet<Artist>();
            Playlists = new HashSet<Playlist>();
            Interactions = new HashSet<Interaction>();
        }
    }
    public class Album
    {
        [Key]
        public int AlbumId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
       // public virtual ICollection<SongAlbum> SongAlbums { get; set; }
        public virtual ICollection<Song>Songs { get; set; }
        public Album()
        {
            Songs = new HashSet<Song>();
        }
    }
    public class Artist
    {
        [Key]
        public int ArtistId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public virtual ICollection<Song> Songs { get; set; }
        public Artist()
        {
            Songs = new HashSet<Song>();
        }
    }
    public class Playlist
    {
        [Key]
        public int PlaylistId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; } = "";
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
        public virtual ICollection<Song> Songs { get; set; }
        public Playlist()
        {
            Songs = new HashSet<Song>();
        }
    }
    public class Interaction
    {
        [Key]
        [Column(Order = 1)]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        public bool Liked { get; set; } = false;
        public int PlayCount { get; set; } = 0;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdateAt { get; set; } = DateTime.Now;
    }

    // --------------------- Koppeltabellen / Using Data Annotations ------------------------------------

    public class SongAlbum
    {
        [Key]
        [Column(Order=1)]
        public int AlbumId { get; set; }
        public virtual Album Album { get; set; }
        [Key]
        [Column(Order = 2)]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
    public class ArtistSong
    {
        [Key]
        [Column(Order = 1)]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ArtistId { get; set; }
        public virtual Artist Artist { get; set; }
    }
    public class PlaylistSong
    {
        [Key]
        [Column(Order=1)]
        public int PlaylistId { get; set; }
        public virtual Playlist Playlist { get; set; }
        [Key]
        [Column(Order=2)]
        public int SongId { get; set; }
        public virtual Song Song { get; set; }
    }
    #endregion
    // ---------------------------------------------------------------------------------
    #region PeopleHobbiesOrders
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
    #endregion
    // ---------------------------------------------------------------------------------
    #region Notitieboekje
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
    #endregion
    #endregion
}
