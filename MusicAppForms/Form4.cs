using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MusicAppForms.Form1;

namespace MusicAppForms
{
    public class TestClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public TestClass()
        {
        }
    }

    public partial class Form4 : Form
    {
        public User LoggedIn { get; set; }


        public Form4(User user)
        {
            LoggedIn = user;

            InitializeComponent();

            using (MusicAppContext data = new MusicAppContext())
            {
                cbPlaylistSelect.DataSource = data.Playlists.Where(c => c.UserId == LoggedIn.UserId).Select(c => new TestClass { Id = c.PlaylistId, Name = c.Name }).ToArray();
                cbPlaylistSelect.DisplayMember = "PlaylistNaam";
                cbPlaylistSelect.ValueMember = "Id";
            }

            UpdateForm();

        }
        private void UpdateForm()
        {
            using (MusicAppContext data = new MusicAppContext())
            {
                cbSongInPlaylistSelect.DataSource = null;
                listBox1.DataSource = null;

                TestClass a = cbPlaylistSelect.SelectedItem as TestClass;
                int vari = a.Id;
                var collection = data.PlaylistSongs.Where(p => p.PlaylistId == vari).Join(data.Song, p => p.SongId, s => s.SongId, (p, s) => new { SongId = s.SongId, SongName = s.Title }).ToArray();

                cbSongInPlaylistSelect.DataSource = collection;
                cbSongInPlaylistSelect.DisplayMember = "SongName";
                cbSongInPlaylistSelect.ValueMember = "SongId";


                listBox1.DataSource = collection;
                listBox1.DisplayMember = "SongName";
                listBox1.ValueMember = "SongId";
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            
        }

        private void cbPlaylistSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {

        }

        private void cbPlaylistSelect_SelectedValueChanged(object sender, EventArgs e)
        {
            UpdateForm();
        }
    }
}
