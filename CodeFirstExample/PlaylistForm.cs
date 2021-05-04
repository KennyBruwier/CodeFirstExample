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
            LoadRefresh();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void LoadRefresh()
        {
            using (MusicAppContext ctx = new MusicAppContext())
            {
                DataTable dtSongs = new DataTable();
                DataTable dtPlaylists = new DataTable();

                cbPlaylists.Items.Clear();
                cbAlbums.Items.Clear();
                cbSongs.Items.Clear();
                cbArtists.Items.Clear();
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
                    cbAlbums.Items.Add(newItem);
                }
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
                dtSongs.Columns.Add(new DataColumn("Song Title", typeof(string)));
                dtSongs.Columns.Add(new DataColumn("Albums", typeof(string)));
                dtSongs.Columns.Add(new DataColumn("Artists", typeof(string)));
                var SongsWithAlbums = ctx.Songs.Include(nameof(Song.Albums));
                foreach (var Song in SongsWithAlbums)
                {
                    List<string> newRow = new List<string>();
                    string albums = "";
                    string artists = "";
                    int iCount = 0;
                    newRow.Add(Song.Title);
                    foreach (var album in Song.Albums)
                    {
                        if (iCount++ > 0) albums += ", ";
                        albums += album.Name;
                    }

                    if (iCount > 0) 
                        newRow.Add(albums);
                    iCount = 0;
                    foreach (var artist in Song.Artists)
                    {
                        if (iCount++ > 0) artists += ", ";
                        artists += artist.Name;
                    }
                    if (iCount > 0)
                        newRow.Add(artists);
                    dtSongs.Rows.Add(newRow.ToArray());
                }
                dgSongs.DataSource = dtSongs;
            }
        }
        private void RefreshPlaylistGrid()
        {
            if ((cbPlaylists.Text != "") && ((cbPlaylists.SelectedItem as ComboboxItem) != null))
            {
                DataTable dtSongsOfPlaylist = new DataTable();
                ComboboxItem selectedPlaylist = (cbPlaylists.SelectedItem as ComboboxItem);
                dtSongsOfPlaylist.Columns.Add(new DataColumn("Song Title", typeof(string)));
                dtSongsOfPlaylist.Columns.Add(new DataColumn("Albums", typeof(string)));
                dtSongsOfPlaylist.Columns.Add(new DataColumn("Artists", typeof(string)));
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    var PlaylistWithSongs = ctx.Playlists.FirstOrDefault(p => p.PlaylistId == selectedPlaylist.Key);
                    List<string> newRow = new List<string>();
                    foreach (var playlistSong in PlaylistWithSongs.Songs.ToList())
                    {
                        dtSongsOfPlaylist.Rows.Add(playlistSong.Title);
                    }
                }
                dgPlaylist.DataSource = dtSongsOfPlaylist;
            }
        }
        private void btPlayListNew_Click(object sender, EventArgs e)
        {
            EmptySongArtistAlbum();
            cbPlaylists.Text = "<playlist name required>";
            cbPlaylists.Focus();
        }
        private void btAlbumsNew_Click(object sender, EventArgs e)
        {
            EmptySongArtistAlbum();
            cbAlbums.Text = "<album name required>";
            cbAlbums.Focus();
        }
        private void btSongsNew_Click(object sender, EventArgs e)
        {
            EmptySongArtistAlbum();
            cbSongs.Text = "<song name required>";
            cbSongs.Focus();
        }
        private void btArtistsNew_Click(object sender, EventArgs e)
        {
            EmptySongArtistAlbum();
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
                    LoadRefresh();
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
                    LoadRefresh();
                }
            }
        }

        private void btSongsSave_Click(object sender, EventArgs e)
        {
            if (cbSongs.Text != "")
            {
                //if (cbSongs.SelectedValue == null)
                //{
                bool newSong = false;
                string msg = " updated";
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    Song SongToSave = new Song();
                    if ((cbSongs.Text != "") && ((cbSongs.SelectedItem as ComboboxItem) != null) && ((cbSongs.SelectedItem as ComboboxItem).Key != null))
                    {
                        ComboboxItem SongSelected = (cbSongs.SelectedItem as ComboboxItem);
                        SongToSave = ctx.Songs.FirstOrDefault(s => s.SongId == SongSelected.Key);
                    }
                    else
                        newSong = true;
                    SongToSave.Title = cbSongs.Text;
                    if ((cbAlbums.Text != "") && ((cbAlbums.SelectedItem as ComboboxItem) != null))
                    {
                        ComboboxItem albumToAttach = cbAlbums.SelectedItem as ComboboxItem;
                        Album attachAlbum = ctx.Albums.FirstOrDefault(a => a.AlbumId == albumToAttach.Key);
                        if (SongToSave.Albums == null) SongToSave.Albums = new List<Album>();
                        SongToSave.Albums.Add(attachAlbum);
                    }
                    if ((cbArtists.Text != "") && ((cbArtists.SelectedItem as ComboboxItem)!=null))
                    {
                        ComboboxItem artistSelected = cbArtists.SelectedItem as ComboboxItem;
                        Artist artistToAdd = ctx.Artists.FirstOrDefault(a => a.ArtistId == artistSelected.Key);
                        if (SongToSave.Artists == null)
                    }
                    if (newSong)
                    {
                        ctx.Songs.Add(SongToSave);
                        msg = " created";
                    }
                    ctx.SaveChanges();
                    MessageBox.Show(cbSongs.Text + msg);
                }
                LoadRefresh();
                //}
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
                        if ((cbSongs.Text != "") && ((cbSongs.SelectedItem as ComboboxItem)!= null))
                        {
                            ComboboxItem songSelected = cbSongs.SelectedItem as ComboboxItem;
                            Song SongToArtist = ctx.Songs.FirstOrDefault(s => s.SongId == songSelected.Key);
                            newArtist.Songs.Add(SongToArtist);
                        }
                        ctx.Artists.Add(newArtist);
                        ctx.SaveChanges();
                        MessageBox.Show(cbArtists.Text + " created");
                    }
                    LoadRefresh();
                }
            }
        }
        public class ComboboxItem
        {
            public int Key { get; set; }
            public string Text { get; set; }
            public ComboboxItem(int key, string text)
            {
                Key = key;
                Text = text;
            }
            public ComboboxItem()
            {

            }
            public override string ToString()
            {
                return Text;
            }
        }

        private void cbPlaylists_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPlaylistGrid();
        }

        private void btAddToPlaylist_Click(object sender, EventArgs e)
        {
            if ((cbPlaylists.Text != null) && ((cbPlaylists.SelectedItem as ComboboxItem) != null))
                if ((cbSongs.Text != null) && (cbSongs.SelectedItem as ComboboxItem)!=null)
                {
                    ComboboxItem songToAdd = cbSongs.SelectedItem as ComboboxItem;
                    ComboboxItem toPlaylist = cbPlaylists.SelectedItem as ComboboxItem;
                    using (MusicAppContext ctx = new MusicAppContext())
                    {
                        Playlist playlist = ctx.Playlists.FirstOrDefault(p => p.PlaylistId == toPlaylist.Key);
                        Song song = ctx.Songs.FirstOrDefault(s => s.SongId == songToAdd.Key);
                        playlist.Songs.Add(song);
                        ctx.SaveChanges();
                    }
                    RefreshPlaylistGrid();
                }
        }

        private void btSongsDelete_Click(object sender, EventArgs e)
        {
            if ((cbSongs.Text != null) && (cbSongs.SelectedItem as ComboboxItem) != null)
            {
                ComboboxItem songSelected = cbSongs.SelectedItem as ComboboxItem;
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    Song songToDelete = ctx.Songs.FirstOrDefault(s => s.SongId == songSelected.Key);
                    ctx.Songs.Remove(songToDelete);
                    ctx.SaveChanges();
                }
                LoadRefresh();
            }
        }

        private void btAlbumsDelete_Click(object sender, EventArgs e)
        {
            if ((cbAlbums.Text != null) && (cbAlbums.SelectedItem as ComboboxItem) != null)
            {
                ComboboxItem albumSelected = cbAlbums.SelectedItem as ComboboxItem;
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    Album albumToDelete = ctx.Albums.FirstOrDefault(s => s.AlbumId == albumSelected.Key);
                    ctx.Albums.Remove(albumToDelete);
                    ctx.SaveChanges();
                }
                LoadRefresh();
            }
        }

        private void EmptySongArtistAlbum()
        {
            ComboboxItem empty = new ComboboxItem();
            cbAlbums.SelectedItem = empty;
            cbArtists.SelectedItem = empty;
            cbSongs.SelectedItem = empty;
        }

        private void btArtistsDelete_Click(object sender, EventArgs e)
        {
            if ((cbArtists.Text != null) && (cbArtists.SelectedItem as ComboboxItem) != null)
            {
                ComboboxItem artistSelected = cbArtists.SelectedItem as ComboboxItem;
                using (MusicAppContext ctx = new MusicAppContext())
                {
                    Artist artistToDelete = ctx.Artists.FirstOrDefault(s => s.ArtistId == artistSelected.Key);
                    ctx.Artists.Remove(artistToDelete);
                    ctx.SaveChanges();
                }
                LoadRefresh();
            }
        }
    }
}
