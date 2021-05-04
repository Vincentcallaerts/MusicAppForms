using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicAppForms.Form1;

namespace MusicAppForms
{
    public partial class Form3 : Form
    {
        public User LoggedIn { get; set; }
        public Form3()
        {
            InitializeComponent();
            UpdateInfo();
        }
        public Form3(User loggedin)
        {
            InitializeComponent();
            LoggedIn = loggedin;
            lbUser.Text = "User: " + LoggedIn.Email;
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                listBox1.Items.Clear();
                listBox1.Items.AddRange(data.Artist.Select(c => c.Name).ToArray());

                listBox2.Items.Clear();
                listBox2.Items.AddRange(data.Song.Select(c => new { Info = c.Title + " " + c.Album.Artist.Name }).ToArray());

                listBox3.Items.Clear();
                listBox3.Items.AddRange(data.Interactions.Where(c => c.UserId == LoggedIn.UserId).Select(c => new { Info = c.Song.Title + " Liked: " + c.Liked + " PlayCount: " + c.PlayCount }).ToArray());

                cbArtisten.DataSource = data.Artist.Select(c => new { Id = c.ArtistId, NaamArtist = c.Name }).ToArray(); ; 
           
                cbArtisten.DisplayMember = "NaamArtist";
                cbArtisten.ValueMember = "Id";

                cbPlaylistPlaylist.DataSource = data.Playlists.Where(c => c.UserId == LoggedIn.UserId).Select(c => new { Id = c.PlaylistId, NamePlaylist = c.Name }).ToArray();

                cbPlaylistPlaylist.DisplayMember = "NamePlaylist";
                cbPlaylistPlaylist.ValueMember = "Id";

                cbSongsPlaylist.DataSource = data.Song.Select(c => new { Id = c.SongId, NameSong = c.Title }).ToArray();
                cbSongsPlaylist.DisplayMember = "NameSong";
                cbSongsPlaylist.ValueMember = "Id";

                cbAlbums.DataSource = data.Album.Select(c => new { Id = c.AlbumId, NameAlbum = c.Title }).ToArray();
                cbAlbums.DisplayMember = "NameAlbum";
                cbAlbums.ValueMember = "Id";

            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {

            this.Close();
        }
        private void btnAddArtist_Click(object sender, EventArgs e)
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                data.Artist.Add(new Artist() { Name = tbArtistName.Text, CreatedAt = new DateTime().ToString("dd/MM/yyyy"), UpdatedAt = new DateTime().ToString("dd/MM/yyyy") });
                data.SaveChanges();
                UpdateInfo();
                
            }
        }
        
        private void btnAddAlbum_Click(object sender, EventArgs e)
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                data.Album.Add(new Album() { ArtistId = Convert.ToInt32(cbArtisten.SelectedValue), Title = tbAlbumName.Text, Lenght = 0, CreatedAt = new DateTime().ToString("dd/MM/yyyy"), UpdatedAt = new DateTime().ToString("dd/MM/yyyy") });
                data.SaveChanges();
                UpdateInfo();

            }
        }

        private void btnAddSong_Click(object sender, EventArgs e)
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                data.Song.Add(new Song() { Title = tbSongName.Text, AlbumId = Convert.ToInt32(cbAlbums.SelectedValue), Lenght = Convert.ToInt32(nupdLengte.Value), CreatedAt = new DateTime().ToString("dd/MM/yyyy"), UpdatedAt = new DateTime().ToString("dd/MM/yyyy") });
                data.SaveChanges();
                UpdateInfo();

            }
        }

        private void btnSongToPlaylist_Click(object sender, EventArgs e)
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                int Playlistid = Convert.ToInt32(cbPlaylistPlaylist.SelectedValue);

                data.PlaylistSongs.Add(new PlaylistSongs() { PlaylistId = Playlistid, SongId = Convert.ToInt32(cbSongsPlaylist.SelectedValue)});
                data.Playlists.Where(c => c.PlaylistId == Playlistid).FirstOrDefault().UpdatedAt = new DateTime().ToString("dd/MM/yyyy");

                data.SaveChanges();
                UpdateInfo();

            }
        }

        private void btnAddPlaylist_Click(object sender, EventArgs e)
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                data.Playlists.Add(new Playlist() { Name = tbPlaylist.Text, UserId = LoggedIn.UserId, CreatedAt = new DateTime().ToString("dd/MM/yyyy"), UpdatedAt = new DateTime().ToString("dd/MM/yyyy") });
                data.SaveChanges();
                UpdateInfo();

            }
        }

        private void btnPlaylistInhoud_Click(object sender, EventArgs e)
        {
            using (Form4 form4 = new Form4(LoggedIn))
            {

                switch (form4.ShowDialog())
                {
                    case DialogResult.OK:
                        UpdateInfo();
                        break;
                }
            }
        }
    }
}
