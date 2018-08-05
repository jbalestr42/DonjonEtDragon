namespace DonjonEtDragon
{
    partial class ItemGenerator
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
            this.tbNiveau = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerer = new System.Windows.Forms.Button();
            this.lblJet = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rtbAttributs = new System.Windows.Forms.RichTextBox();
            this.lbNomObjet = new System.Windows.Forms.Label();
            this.btnInventaire = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbNiveau
            // 
            this.tbNiveau.Location = new System.Drawing.Point(117, 6);
            this.tbNiveau.Name = "tbNiveau";
            this.tbNiveau.Size = new System.Drawing.Size(41, 20);
            this.tbNiveau.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Niveau du monstre : ";
            // 
            // btnGenerer
            // 
            this.btnGenerer.Location = new System.Drawing.Point(164, 3);
            this.btnGenerer.Name = "btnGenerer";
            this.btnGenerer.Size = new System.Drawing.Size(75, 23);
            this.btnGenerer.TabIndex = 2;
            this.btnGenerer.Text = "Générer";
            this.btnGenerer.UseVisualStyleBackColor = true;
            this.btnGenerer.Click += new System.EventHandler(this.btnGenerer_Click);
            // 
            // lblJet
            // 
            this.lblJet.AutoSize = true;
            this.lblJet.Location = new System.Drawing.Point(245, 9);
            this.lblJet.Name = "lblJet";
            this.lblJet.Size = new System.Drawing.Size(10, 13);
            this.lblJet.TabIndex = 3;
            this.lblJet.Text = "-";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rtbAttributs);
            this.groupBox1.Controls.Add(this.lbNomObjet);
            this.groupBox1.Location = new System.Drawing.Point(3, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(282, 245);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Objet";
            // 
            // rtbAttributs
            // 
            this.rtbAttributs.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.rtbAttributs.Location = new System.Drawing.Point(3, 39);
            this.rtbAttributs.Name = "rtbAttributs";
            this.rtbAttributs.Size = new System.Drawing.Size(276, 203);
            this.rtbAttributs.TabIndex = 6;
            this.rtbAttributs.Text = "";
            // 
            // lbNomObjet
            // 
            this.lbNomObjet.AutoSize = true;
            this.lbNomObjet.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbNomObjet.Location = new System.Drawing.Point(6, 16);
            this.lbNomObjet.Name = "lbNomObjet";
            this.lbNomObjet.Size = new System.Drawing.Size(123, 20);
            this.lbNomObjet.TabIndex = 5;
            this.lbNomObjet.Text = "Nom de l\'objet";
            // 
            // btnInventaire
            // 
            this.btnInventaire.Location = new System.Drawing.Point(49, 32);
            this.btnInventaire.Name = "btnInventaire";
            this.btnInventaire.Size = new System.Drawing.Size(190, 23);
            this.btnInventaire.TabIndex = 6;
            this.btnInventaire.Text = "Envoyer dans l\'inventaire";
            this.btnInventaire.UseVisualStyleBackColor = true;
            this.btnInventaire.Click += new System.EventHandler(this.btnInventaire_Click);
            // 
            // ItemGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(287, 309);
            this.Controls.Add(this.btnInventaire);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblJet);
            this.Controls.Add(this.btnGenerer);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbNiveau);
            this.Name = "ItemGenerator";
            this.Text = "Générateur d\'objets";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbNiveau;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerer;
        private System.Windows.Forms.Label lblJet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbNomObjet;
        private System.Windows.Forms.RichTextBox rtbAttributs;
        private System.Windows.Forms.Button btnInventaire;
    }
}