
namespace MusicAppForms
{
    partial class Form4
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
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.cbPlaylistSelect = new System.Windows.Forms.ComboBox();
            this.cbSongInPlaylistSelect = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(427, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(361, 420);
            this.listBox1.TabIndex = 0;
            // 
            // cbPlaylistSelect
            // 
            this.cbPlaylistSelect.FormattingEnabled = true;
            this.cbPlaylistSelect.Location = new System.Drawing.Point(12, 27);
            this.cbPlaylistSelect.Name = "cbPlaylistSelect";
            this.cbPlaylistSelect.Size = new System.Drawing.Size(387, 21);
            this.cbPlaylistSelect.TabIndex = 1;
            this.cbPlaylistSelect.SelectedIndexChanged += new System.EventHandler(this.cbPlaylistSelect_SelectedIndexChanged);
            this.cbPlaylistSelect.SelectedValueChanged += new System.EventHandler(this.cbPlaylistSelect_SelectedValueChanged);
            // 
            // cbSongInPlaylistSelect
            // 
            this.cbSongInPlaylistSelect.FormattingEnabled = true;
            this.cbSongInPlaylistSelect.Location = new System.Drawing.Point(13, 238);
            this.cbSongInPlaylistSelect.Name = "cbSongInPlaylistSelect";
            this.cbSongInPlaylistSelect.Size = new System.Drawing.Size(286, 21);
            this.cbSongInPlaylistSelect.TabIndex = 2;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(305, 238);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(94, 23);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Delete Song";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnStop
            // 
            this.btnStop.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnStop.Location = new System.Drawing.Point(12, 341);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(137, 90);
            this.btnStop.TabIndex = 4;
            this.btnStop.Text = "Exit";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.cbSongInPlaylistSelect);
            this.Controls.Add(this.cbPlaylistSelect);
            this.Controls.Add(this.listBox1);
            this.Name = "Form4";
            this.Text = "Form4";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ComboBox cbPlaylistSelect;
        private System.Windows.Forms.ComboBox cbSongInPlaylistSelect;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnStop;
    }
}