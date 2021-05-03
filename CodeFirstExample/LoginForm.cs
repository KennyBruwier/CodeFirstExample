using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstExample
{
    public partial class LoginForm : Form
    {
        private string regFirstName { get { return tbRegFirstName.Text.Trim(); }}
        private string regLastName { get { return tbRegLastName.Text.Trim(); } }
        private string regEmail { get { return tbRegEmail.Text.Trim(); } }
        private string regPassword { get { return tbRegPassword.Text.Trim(); } }
        private string logEmail { get { return tbLogEmail.Text.Trim(); } }
        private string logPassword { get { return tbLogPassword.Text.Trim(); } }
        public bool UserLoggedIn = false;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }



        private bool ValidUser()
        {
            if (ValidEmail(regEmail) && ValidName(regLastName) && ValidPassword(regPassword))
                if (EmailFound(regEmail))
                    MessageBox.Show(regEmail + " already registered");
                else
                    return true;
            return false;
        }
        private bool ValidEmail(string email)
        {
            Regex validEmail = new Regex(@"[^@ \t\r\n]+@[^@ \t\r\n]+\.[^@ \t\r\n]+");
            if (validEmail.IsMatch(email))
                return true;
            MessageBox.Show(email + " is an invalid email");
            return false;
        }
        private bool EmailFound(string email)
        {
            using (MusicAppContext ctx = new MusicAppContext())
            {
                if (ctx.Users.Any(u => u.Email.Trim() == regEmail))
                    return true;
                else
                    MessageBox.Show(email + " already exists");
            }
            MessageBox.Show("connection to database failed");
            return false;
        }
        private bool ValidName(string name)
        {
            Regex ValidFirstname = new Regex(@"\w");
            if (ValidFirstname.IsMatch(name))
                return true;
            MessageBox.Show(name + " is an invalid name");
            return false;
        }

        private bool ValidPassword(string password)
        {
            // Minimum eight characters, at least one upper case English letter, one lower case English letter, one number and one special character
            Regex validPassword = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-]).{8,}$");
            if (validPassword.IsMatch(password))
                return true;
            MessageBox.Show(password + " is an invalid password");
            return false;
        }
        private void btRegister_Click(object sender, EventArgs e)
        {
            if (ValidUser())
            {
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    User nieuwUser = new User()
                    {
                        Firstname = regFirstName,
                        Lastname = regLastName,
                        Email = regEmail,
                        Password = regPassword
                    };
                    ctx.Users.Add(nieuwUser);
                    ctx.SaveChanges();
                }
                UserLoggedIn = LoginSuccess(regEmail, regPassword);
            }
            else
                MessageBox.Show("Invalid user");
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            UserLoggedIn = LoginSuccess(logEmail, logPassword);
        }

        private bool LoginSuccess(string email, string password)
        {
            using (MusicAppContext ctx = new MusicAppContext())
            {
                var currentUser = ctx.Users.FirstOrDefault(u => (u.Email.Trim() == email) && (u.Password.Trim() == password));
                if (currentUser != null)
                {
                    this.Hide();
                    PlaylistForm newPlaylistForm = new PlaylistForm(currentUser.UserId);
                    MessageBox.Show("logged in successfull");
                    newPlaylistForm.Show();
                    return true;
                }
            }
            MessageBox.Show("connection to database failed or user not found");
            return false;
        }
    }
}
