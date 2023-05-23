
namespace ShipsGame.Okna
{
    partial class Rozgrywka
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
            this.planczaKomputera = new System.Windows.Forms.PictureBox();
            this.planszaGracza = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.planczaKomputera)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planszaGracza)).BeginInit();
            this.SuspendLayout();
            // 
            // planczaKomputera
            // 
            this.planczaKomputera.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planczaKomputera.Location = new System.Drawing.Point(0, 10);
            this.planczaKomputera.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.planczaKomputera.Name = "planczaKomputera";
            this.planczaKomputera.Size = new System.Drawing.Size(300, 325);
            this.planczaKomputera.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.planczaKomputera.TabIndex = 0;
            this.planczaKomputera.TabStop = false;
            this.planczaKomputera.MouseMove += new System.Windows.Forms.MouseEventHandler(this.planczaKomputera_MouseMove);
            // 
            // planszaGracza
            // 
            this.planszaGracza.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.planszaGracza.Location = new System.Drawing.Point(318, 10);
            this.planszaGracza.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.planszaGracza.Name = "planszaGracza";
            this.planszaGracza.Size = new System.Drawing.Size(300, 325);
            this.planszaGracza.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.planszaGracza.TabIndex = 1;
            this.planszaGracza.TabStop = false;
            // 
            // Rozgrywka
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 366);
            this.Controls.Add(this.planszaGracza);
            this.Controls.Add(this.planczaKomputera);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Rozgrywka";
            this.Text = "Rozgrywka";
            ((System.ComponentModel.ISupportInitialize)(this.planczaKomputera)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planszaGracza)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox planczaKomputera;
        private System.Windows.Forms.PictureBox planszaGracza;
    }
}