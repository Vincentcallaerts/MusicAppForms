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
        public Form3()
        {
            InitializeComponent();
            UpdateInfo();
        }
        private void UpdateInfo()
        {
            using (MusicAppContext data = new MusicAppContext())
            {

                listBox1.Items.AddRange(data.Artist.Select(c => c.Name).ToArray());
                cbArtisten.DataSource = data.Artist.Select(c => new { Id = c.ArtistId, NaamArtist = c.Name }).ToArray(); ; 

                
                cbArtisten.DisplayMember = "NaamArtist";
                cbArtisten.ValueMember = "Id";
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
    }
}
