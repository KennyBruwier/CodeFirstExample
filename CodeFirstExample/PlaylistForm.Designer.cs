
namespace CodeFirstExample
{
    partial class PlaylistForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cbPlaylists = new System.Windows.Forms.ComboBox();
            this.btPlayListNew = new System.Windows.Forms.Button();
            this.btPlayListDelete = new System.Windows.Forms.Button();
            this.btPlayListSave = new System.Windows.Forms.Button();
            this.btAlbumsSave = new System.Windows.Forms.Button();
            this.btAlbumsDelete = new System.Windows.Forms.Button();
            this.btAlbumsNew = new System.Windows.Forms.Button();
            this.cbAlbums = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btSongsSave = new System.Windows.Forms.Button();
            this.btSongsDelete = new System.Windows.Forms.Button();
            this.btSongsNew = new System.Windows.Forms.Button();
            this.cbSongs = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btArtistsSave = new System.Windows.Forms.Button();
            this.btArtistsDelete = new System.Windows.Forms.Button();
            this.btArtistsNew = new System.Windows.Forms.Button();
            this.cbArtists = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dgPlaylist = new System.Windows.Forms.DataGridView();
            this.dgSongs = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgPlaylist)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSongs)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Playlists";
            // 
            // cbPlaylists
            // 
            this.cbPlaylists.FormattingEnabled = true;
            this.cbPlaylists.Location = new System.Drawing.Point(69, 72);
            this.cbPlaylists.Name = "cbPlaylists";
            this.cbPlaylists.Size = new System.Drawing.Size(155, 21);
            this.cbPlaylists.TabIndex = 1;
            this.cbPlaylists.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbPlaylists_KeyDown);
            this.cbPlaylists.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbPlaylists_MouseClick);
            // 
            // btPlayListNew
            // 
            this.btPlayListNew.Location = new System.Drawing.Point(239, 70);
            this.btPlayListNew.Name = "btPlayListNew";
            this.btPlayListNew.Size = new System.Drawing.Size(75, 23);
            this.btPlayListNew.TabIndex = 2;
            this.btPlayListNew.Text = "New";
            this.btPlayListNew.UseVisualStyleBackColor = true;
            this.btPlayListNew.Click += new System.EventHandler(this.btPlayListNew_Click);
            // 
            // btPlayListDelete
            // 
            this.btPlayListDelete.Location = new System.Drawing.Point(401, 70);
            this.btPlayListDelete.Name = "btPlayListDelete";
            this.btPlayListDelete.Size = new System.Drawing.Size(75, 23);
            this.btPlayListDelete.TabIndex = 3;
            this.btPlayListDelete.Text = "Delete";
            this.btPlayListDelete.UseVisualStyleBackColor = true;
            // 
            // btPlayListSave
            // 
            this.btPlayListSave.Location = new System.Drawing.Point(320, 70);
            this.btPlayListSave.Name = "btPlayListSave";
            this.btPlayListSave.Size = new System.Drawing.Size(75, 23);
            this.btPlayListSave.TabIndex = 4;
            this.btPlayListSave.Text = "Save";
            this.btPlayListSave.UseVisualStyleBackColor = true;
            this.btPlayListSave.Click += new System.EventHandler(this.btPlayListSave_Click);
            // 
            // btAlbumsSave
            // 
            this.btAlbumsSave.Location = new System.Drawing.Point(816, 16);
            this.btAlbumsSave.Name = "btAlbumsSave";
            this.btAlbumsSave.Size = new System.Drawing.Size(75, 23);
            this.btAlbumsSave.TabIndex = 10;
            this.btAlbumsSave.Text = "Save";
            this.btAlbumsSave.UseVisualStyleBackColor = true;
            this.btAlbumsSave.Click += new System.EventHandler(this.btAlbumsSave_Click);
            // 
            // btAlbumsDelete
            // 
            this.btAlbumsDelete.Location = new System.Drawing.Point(897, 16);
            this.btAlbumsDelete.Name = "btAlbumsDelete";
            this.btAlbumsDelete.Size = new System.Drawing.Size(75, 23);
            this.btAlbumsDelete.TabIndex = 9;
            this.btAlbumsDelete.Text = "Delete";
            this.btAlbumsDelete.UseVisualStyleBackColor = true;
            // 
            // btAlbumsNew
            // 
            this.btAlbumsNew.Location = new System.Drawing.Point(735, 16);
            this.btAlbumsNew.Name = "btAlbumsNew";
            this.btAlbumsNew.Size = new System.Drawing.Size(75, 23);
            this.btAlbumsNew.TabIndex = 8;
            this.btAlbumsNew.Text = "New";
            this.btAlbumsNew.UseVisualStyleBackColor = true;
            this.btAlbumsNew.Click += new System.EventHandler(this.btAlbumsNew_Click);
            // 
            // cbAlbums
            // 
            this.cbAlbums.FormattingEnabled = true;
            this.cbAlbums.Location = new System.Drawing.Point(565, 18);
            this.cbAlbums.Name = "cbAlbums";
            this.cbAlbums.Size = new System.Drawing.Size(155, 21);
            this.cbAlbums.TabIndex = 7;
            this.cbAlbums.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbAlbums_KeyDown);
            this.cbAlbums.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbAlbums_MouseClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(515, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Albums";
            // 
            // btSongsSave
            // 
            this.btSongsSave.Location = new System.Drawing.Point(816, 43);
            this.btSongsSave.Name = "btSongsSave";
            this.btSongsSave.Size = new System.Drawing.Size(75, 23);
            this.btSongsSave.TabIndex = 15;
            this.btSongsSave.Text = "Save";
            this.btSongsSave.UseVisualStyleBackColor = true;
            this.btSongsSave.Click += new System.EventHandler(this.btSongsSave_Click);
            // 
            // btSongsDelete
            // 
            this.btSongsDelete.Location = new System.Drawing.Point(897, 43);
            this.btSongsDelete.Name = "btSongsDelete";
            this.btSongsDelete.Size = new System.Drawing.Size(75, 23);
            this.btSongsDelete.TabIndex = 14;
            this.btSongsDelete.Text = "Delete";
            this.btSongsDelete.UseVisualStyleBackColor = true;
            // 
            // btSongsNew
            // 
            this.btSongsNew.Location = new System.Drawing.Point(735, 43);
            this.btSongsNew.Name = "btSongsNew";
            this.btSongsNew.Size = new System.Drawing.Size(75, 23);
            this.btSongsNew.TabIndex = 13;
            this.btSongsNew.Text = "New";
            this.btSongsNew.UseVisualStyleBackColor = true;
            this.btSongsNew.Click += new System.EventHandler(this.btSongsNew_Click);
            // 
            // cbSongs
            // 
            this.cbSongs.FormattingEnabled = true;
            this.cbSongs.Location = new System.Drawing.Point(565, 45);
            this.cbSongs.Name = "cbSongs";
            this.cbSongs.Size = new System.Drawing.Size(155, 21);
            this.cbSongs.TabIndex = 12;
            this.cbSongs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbSongs_KeyDown);
            this.cbSongs.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbSongs_MouseClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(515, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Songs";
            // 
            // btArtistsSave
            // 
            this.btArtistsSave.Location = new System.Drawing.Point(816, 70);
            this.btArtistsSave.Name = "btArtistsSave";
            this.btArtistsSave.Size = new System.Drawing.Size(75, 23);
            this.btArtistsSave.TabIndex = 20;
            this.btArtistsSave.Text = "Save";
            this.btArtistsSave.UseVisualStyleBackColor = true;
            this.btArtistsSave.Click += new System.EventHandler(this.btArtistsSave_Click);
            // 
            // btArtistsDelete
            // 
            this.btArtistsDelete.Location = new System.Drawing.Point(897, 70);
            this.btArtistsDelete.Name = "btArtistsDelete";
            this.btArtistsDelete.Size = new System.Drawing.Size(75, 23);
            this.btArtistsDelete.TabIndex = 19;
            this.btArtistsDelete.Text = "Delete";
            this.btArtistsDelete.UseVisualStyleBackColor = true;
            // 
            // btArtistsNew
            // 
            this.btArtistsNew.Location = new System.Drawing.Point(735, 70);
            this.btArtistsNew.Name = "btArtistsNew";
            this.btArtistsNew.Size = new System.Drawing.Size(75, 23);
            this.btArtistsNew.TabIndex = 18;
            this.btArtistsNew.Text = "New";
            this.btArtistsNew.UseVisualStyleBackColor = true;
            this.btArtistsNew.Click += new System.EventHandler(this.btArtistsNew_Click);
            // 
            // cbArtists
            // 
            this.cbArtists.FormattingEnabled = true;
            this.cbArtists.Location = new System.Drawing.Point(565, 72);
            this.cbArtists.Name = "cbArtists";
            this.cbArtists.Size = new System.Drawing.Size(155, 21);
            this.cbArtists.TabIndex = 17;
            this.cbArtists.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cbArtists_KeyDown);
            this.cbArtists.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cbArtists_MouseClick);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(515, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Artists";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // dgPlaylist
            // 
            this.dgPlaylist.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPlaylist.Location = new System.Drawing.Point(23, 109);
            this.dgPlaylist.Name = "dgPlaylist";
            this.dgPlaylist.Size = new System.Drawing.Size(454, 197);
            this.dgPlaylist.TabIndex = 21;
            // 
            // dgSongs
            // 
            this.dgSongs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSongs.Location = new System.Drawing.Point(520, 109);
            this.dgSongs.Name = "dgSongs";
            this.dgSongs.Size = new System.Drawing.Size(454, 197);
            this.dgSongs.TabIndex = 22;
            // 
            // PlaylistForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 364);
            this.Controls.Add(this.dgSongs);
            this.Controls.Add(this.dgPlaylist);
            this.Controls.Add(this.btArtistsSave);
            this.Controls.Add(this.btArtistsDelete);
            this.Controls.Add(this.btArtistsNew);
            this.Controls.Add(this.cbArtists);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btSongsSave);
            this.Controls.Add(this.btSongsDelete);
            this.Controls.Add(this.btSongsNew);
            this.Controls.Add(this.cbSongs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btAlbumsSave);
            this.Controls.Add(this.btAlbumsDelete);
            this.Controls.Add(this.btAlbumsNew);
            this.Controls.Add(this.cbAlbums);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btPlayListSave);
            this.Controls.Add(this.btPlayListDelete);
            this.Controls.Add(this.btPlayListNew);
            this.Controls.Add(this.cbPlaylists);
            this.Controls.Add(this.label1);
            this.Name = "PlaylistForm";
            this.Text = "PlaylistForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgPlaylist)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgSongs)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPlaylists;
        private System.Windows.Forms.Button btPlayListNew;
        private System.Windows.Forms.Button btPlayListDelete;
        private System.Windows.Forms.Button btPlayListSave;
        private System.Windows.Forms.Button btAlbumsSave;
        private System.Windows.Forms.Button btAlbumsDelete;
        private System.Windows.Forms.Button btAlbumsNew;
        private System.Windows.Forms.ComboBox cbAlbums;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btSongsSave;
        private System.Windows.Forms.Button btSongsDelete;
        private System.Windows.Forms.Button btSongsNew;
        private System.Windows.Forms.ComboBox cbSongs;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btArtistsSave;
        private System.Windows.Forms.Button btArtistsDelete;
        private System.Windows.Forms.Button btArtistsNew;
        private System.Windows.Forms.ComboBox cbArtists;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgPlaylist;
        private System.Windows.Forms.DataGridView dgSongs;
    }
}