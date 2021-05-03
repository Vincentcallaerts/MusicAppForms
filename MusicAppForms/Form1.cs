﻿using System;
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

namespace MusicAppForms
{
    public partial class Form1 : Form
    {
        public string Email { get; set; }
        public string Password { get; set; }

        public Form1()
        {
            InitializeComponent();
           
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            Email = tbEmail.Text;
            Password = tbPassword.Text;
            User loginAtempt;
            using (MusicAppContext data = new MusicAppContext())
            {
                loginAtempt = data.User.Where(u => u.Email == Email && u.Password == Password).FirstOrDefault();

            }
            if (loginAtempt != null)
            {
                Program.OpenDetailFormOnClose = true;

                this.Close();
            }
            
        }
        private void btnSignUp_Click(object sender, EventArgs e)
        {
            using (Form2 form2 = new Form2())
            {

                switch (form2.ShowDialog())
                {
                    case DialogResult.OK:

                        using (MusicAppContext data = new MusicAppContext())
                        {
                            data.User.Add(new User() { FirstName = form2.FirstName, LastName = form2.LastName, Email = form2.Email, Password = form2.Password });
                            data.SaveChanges();

                        }

                        break;
                }
            }
        }

        public class User
        {
            public int UserId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }

        }
        public class Interactions
        {
            public int InteractionsId { get; set; }

            [ForeignKey("User")]
            public int UserId { get; set; }
            public User User { get; set; }

            [ForeignKey("Song")]
            public int SongId { get; set; }
            public Song Song { get; set; }

            public int Liked { get; set; }
            public int PlayCount { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class Playlist
        {
            public int PlaylistId { get; set; }
            [ForeignKey("User")]
            public int UserId { get; set; }
            public User User { get; set; }
            public string Name { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class PlaylistSongs
        {
            [Key]
            [Column(Order = 1)]
            [ForeignKey("Playlist")]
            public int PlaylistId { get; set; }
            public Playlist Playlist { get; set; }

            [Key]
            [Column(Order = 2)]
            [ForeignKey("Song")]
            public int SongId { get; set; }
            public Song Song { get; set; }

        }
        public class Song
        {
            public int SongId { get; set; }
            [ForeignKey("Album")]
            public int AlbumId { get; set; }
            public Album Album { get; set; }
            public string Title { get; set; }
            public int Lenght { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class Artist
        {
            public int ArtistId { get; set; }
            public string Name { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class Album
        {
            public int AlbumId { get; set; }
            [ForeignKey("Artist")]
            public int ArtistId { get; set; }
            public Artist Artist { get; set; }
            public string Title { get; set; }
            public int Lenght { get; set; }
            public string CreatedAt { get; set; }
            public string UpdatedAt { get; set; }

        }
        public class MusicAppContext : DbContext
        {
            public MusicAppContext() : base("name = ConnectString")
            {
                //Database.SetInitializer(new CreateDatabaseIfNotExists<NotitieboekjeContext>());
                System.Data.Entity.Database.SetInitializer(new DropCreateDatabaseIfModelChanges<MusicAppContext>());
               
            }

            public DbSet<User> User { get; set; }
            public DbSet<Album> Album { get; set; }
            public DbSet<Artist> Artist { get; set; }
            public DbSet<Song> Song { get; set; }
            public DbSet<PlaylistSongs> PlaylistSongs { get; set; }
            public DbSet<Interactions> Interactions { get; set; }

        }
    }
}
