using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace CodeFirstExample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           // this.login1.LoggedIn += login1_OnLoggedIn;
        }

        private void Opstarten()
        {
            //using (MusicAppContext ctx = new MusicAppContext())
            //{
            //    //ctx.SaveChanges();
            //    List<Playlist> playlists = new List<Playlist>();
            //    Playlist nieuwePlaylist = new Playlist()
            //    {
            //        Name = "Playlist 1",
            //    };
            //    playlists.Add(nieuwePlaylist);
            //    User nieuweUser = new User()
            //    {
            //        Firstname = "Kenny",
            //        Lastname = "Bruwier",
            //        Email = "kenny.bruwier@gmail.com",
            //        Password = "123",
            //        Playlists = playlists
            //    };
            //    //nieuweUser.Playlists.Add(nieuwePlaylist);
            //    ctx.Users.Add(nieuweUser);
            //    ctx.SaveChanges();
            //}
            //Console.WriteLine("end");
            //Console.ReadLine();
        }

        bool login1_AuthenticateMethode1(object o, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000); //Simulate some long running task.
            return true;
        }
        bool login1_AuthenticateMethode2(object o, EventArgs e)
        {
            System.Threading.Thread.Sleep(2000); //Simulate some long running task.
            return false;
        }
    }
}
