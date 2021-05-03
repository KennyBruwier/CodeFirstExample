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
        public PlaylistForm(int userId)
        {
            CurrentUserId = userId;
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LoadRefresh()
        {
            using (MusicAppContext ctx = new MusicAppContext())
            {
                cbPlaylists.Items.Clear();
                cbAlbums.Items.Clear();
                cbSongs.Items.Clear();
                cbArtists.Items.Clear();
                dgPlaylist.Rows.Clear();
                dgSongs.Rows.Clear();
                var userPlaylists = ctx.Playlists.Where(p => p.UserId == CurrentUserId);
                foreach (Playlist playlist in userPlaylists)
                {
                    ComboboxItem newItem = new ComboboxItem(playlist.PlaylistId, playlist.Name);
                    cbPlaylists.Items.Add(newItem);
                }

                cbAlbums.Items.Clear();
                foreach (Album album in ctx.Albums)
                {
                    ComboboxItem newItem = new ComboboxItem(album.AlbumId, album.Name);
                    cbAlbums.Items.Add(album);
                }
                var allSongs = ctx.Songs.GroupJoin(ctx.SongAlbums,
                                                s => s.SongId,
                                                sa => sa.SongId,
                                                (s, sa) => new { s, sa })
                                            .SelectMany(
                                                saWithNull => saWithNull.sa.DefaultIfEmpty(),
                                                (s, saWithNull) => new { }
                foreach (Song song in ctx.Songs)
                {
                    ComboboxItem newItem = new ComboboxItem(song.SongId, song.Title);
                    cbSongs.Items.Add(newItem);
                }
                foreach(Artist artist in ctx.Artists)
                {
                    ComboboxItem newItem = new ComboboxItem(artist.ArtistId, artist.Name);
                    cbArtists.Items.Add(newItem);
                }
            }
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
        public class ComboboxItem
        {
            public object Value { get; set; }
            public string Text { get; set; }
            public ComboboxItem(object value, string text)
            {
                Value = value;
                Text = text;
            }
            public override string ToString()
            {
                return Text;
            }
        }
    }
}
