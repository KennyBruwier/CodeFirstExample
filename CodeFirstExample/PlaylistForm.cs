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
    public partial class PlaylistForm : Form
    {
        public int CurrentUserId { get; set; }
        public PlaylistForm()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btPlayListNew_Click(object sender, EventArgs e)
        {
            cbPlaylists.Text = "<playlist name required>";
            cbPlaylists.Focus();
        }
        private void btAlbumsNew_Click(object sender, EventArgs e)
        {
            cbAlbums.Text = "<album name required>";
            cbAlbums.Focus();
        }
        private void btSongsNew_Click(object sender, EventArgs e)
        {
            cbSongs.Text = "<song name required>";
            cbSongs.Focus();
        }
        private void btArtistsNew_Click(object sender, EventArgs e)
        {
            cbArtists.Text = "<artist name required>";
            cbArtists.Focus();
        }
        private void cbPlaylists_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbPlaylists.Text == "<playlist name required>") cbPlaylists.Text = "";
        }
        private void cbAlbums_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbAlbums.Text == "<album name required>") cbAlbums.Text = "";
        }
        private void cbSongs_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbSongs.Text == "<song name required>") cbSongs.Text = "";
        }

        private void cbPlaylists_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbPlaylists.Text == "<playlist name required>") cbPlaylists.Text = "";
        }

        private void cbAlbums_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbAlbums.Text == "<album name required>") cbAlbums.Text = "";
        }

        private void cbSongs_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbSongs.Text == "<song name required>") cbSongs.Text = "";
        }

        private void cbArtists_KeyDown(object sender, KeyEventArgs e)
        {
            if (cbArtists.Text == "<artist name required>") cbArtists.Text = "";
        }

        private void cbArtists_MouseClick(object sender, MouseEventArgs e)
        {
            if (cbArtists.Text == "<artist name required>") cbArtists.Text = "";
        }

        private void btPlayListSave_Click(object sender, EventArgs e)
        {
            if (cbPlaylists.Text != "")
            {
                if (cbPlaylists.ValueMember == "")
                {
                    using (MusicAppContext ctx = new MusicAppContext())
                    {
                        Playlist newPlaylist = new Playlist();
                        newPlaylist.Name = cbPlaylists.Text;
                        newPlaylist.UserId = CurrentUserId;
                        ctx.Playlists.Add(newPlaylist);
                        ctx.SaveChanges();
                        MessageBox.Show(cbPlaylists.Text + " created");
                    }
                }
            }
        }

        private void btAlbumsSave_Click(object sender, EventArgs e)
        {
            if (cbAlbums.Text != "")
            {
                if (cbAlbums.ValueMember == "")
                {
                    using (MusicAppContext ctx = new MusicAppContext())
                    {
                        Album newAlbum = new Album();
                        newAlbum.Name = cbAlbums.Text;
                        ctx.Albums.Add(newAlbum);
                        ctx.SaveChanges();
                        MessageBox.Show(cbAlbums.Text + " created");
                    }
                }
            }
        }

        private void btSongsSave_Click(object sender, EventArgs e)
        {
            if (cbSongs.Text != "")
            {
                if (cbSongs.ValueMember == "")
                {
                    using (MusicAppContext ctx = new MusicAppContext())
                    {
                        Song newSong = new Song();
                        newSong.Title = cbSongs.Text;
                        ctx.Songs.Add(newSong);
                        ctx.SaveChanges();
                        MessageBox.Show(cbSongs.Text + " created");
                    }
                }
            }
        }

        private void btArtistsSave_Click(object sender, EventArgs e)
        {
            if (cbArtists.Text != "")
            {
                if (cbArtists.ValueMember == "")
                {
                    using (MusicAppContext ctx = new MusicAppContext())
                    {
                        Artist newArtist = new Artist();
                        newArtist.Name = cbArtists.Text;
                        ctx.Artists.Add(newArtist);
                        ctx.SaveChanges();
                        MessageBox.Show(cbArtists.Text + " created");
                    }
                }
            }
        }
    }
}
