using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodeFirstExample
{
    public class LoginEventArgs : EventArgs
    {
        
    }
    public partial class Login : UserControl
    {
        public delegate void OnLoginEventHandler(object sender, EventArgs e);
        public event EventHandler<EventArgs> OnLogin = delegate { };
        public delegate bool AuthenticationEventHandler(object sender, EventArgs e);
        public event AuthenticationEventHandler Authenticated;
        public event EventHandler LoggedIn;
        public event EventHandler LoggedError;
        public string Username
        {
            get { return tbUsername.Text; }
        }
        public string Password
        {
            get { return tbPassword.Text; }
        }
        public Login()
        {
            InitializeComponent();
        }
        protected virtual void OnAuthenticate(EventArgs e)
        {
            AuthenticationEventHandler authHandler = Authenticated;
            if (authHandler != null)
            {
                foreach (AuthenticationEventHandler handler in authHandler.GetInvocationList())
                {
                    handler.BeginInvoke(this, e, new AsyncCallback(Callback), handler);
                }
            }
        }
        void Callback(IAsyncResult ar)
        {
            AuthenticationEventHandler d = (AuthenticationEventHandler)ar.AsyncState;
            if (d.EndInvoke(ar))
            {
                OnLoggedIn(new EventArgs());
            }
            else
            {
                OnLoggedError(new EventArgs());
            }
        }
        private void OnLoggedIn(EventArgs e)
        {
            EventHandler loggedIn = this.LoggedIn;
            if (loggedIn != null)
            {
                loggedIn(this, e);
            }
        }
        private void OnLoggedError(EventArgs e)
        {
            EventHandler loggedError = this.LoggedError;
            if (loggedError != null)
            {
                loggedError(this, e);
            }
        }
        private void tbUsername_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnAuthenticate(new EventArgs());
            }
        }
        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OnAuthenticate(new EventArgs());
            }
        }
        private void btLogin_Click(object sender, EventArgs e)
        {
            OnAuthenticate(new EventArgs());
        }
    }
}
