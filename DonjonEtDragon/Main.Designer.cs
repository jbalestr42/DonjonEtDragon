using System.Windows.Forms;

namespace DonjonEtDragon
{
    partial class Main
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
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.msFichier = new System.Windows.Forms.ToolStripMenuItem();
            this.msfOuvrir = new System.Windows.Forms.ToolStripMenuItem();
            this.msfEnregistrer = new System.Windows.Forms.ToolStripMenuItem();
            this.msfQuitter = new System.Windows.Forms.ToolStripMenuItem();
            this.msOutils = new System.Windows.Forms.ToolStripMenuItem();
            this.msoGenerateur = new System.Windows.Forms.ToolStripMenuItem();
            this.msoDes = new System.Windows.Forms.ToolStripMenuItem();
            this.tcMain = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tpPlus = new System.Windows.Forms.TabPage();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAjouterObjet = new System.Windows.Forms.Button();
            this.ficPerso1 = new DonjonEtDragon.FicPerso();
            this.msMain.SuspendLayout();
            this.tcMain.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msFichier,
            this.msOutils});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(645, 24);
            this.msMain.TabIndex = 1;
            this.msMain.Text = "menuStrip2";
            // 
            // msFichier
            // 
            this.msFichier.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msfOuvrir,
            this.msfEnregistrer,
            this.msfQuitter});
            this.msFichier.Name = "msFichier";
            this.msFichier.Size = new System.Drawing.Size(59, 20);
            this.msFichier.Text = "Fichiers";
            // 
            // msfOuvrir
            // 
            this.msfOuvrir.Name = "msfOuvrir";
            this.msfOuvrir.Size = new System.Drawing.Size(139, 22);
            this.msfOuvrir.Text = "Ouvrir...";
            this.msfOuvrir.Click += new System.EventHandler(this.msfOuvrir_Click);
            // 
            // msfEnregistrer
            // 
            this.msfEnregistrer.Name = "msfEnregistrer";
            this.msfEnregistrer.Size = new System.Drawing.Size(139, 22);
            this.msfEnregistrer.Text = "Enregistrer...";
            this.msfEnregistrer.Click += new System.EventHandler(this.msfEnregistrer_Click);
            // 
            // msfQuitter
            // 
            this.msfQuitter.Name = "msfQuitter";
            this.msfQuitter.Size = new System.Drawing.Size(139, 22);
            this.msfQuitter.Text = "Quitter";
            // 
            // msOutils
            // 
            this.msOutils.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msoGenerateur,
            this.msoDes});
            this.msOutils.Name = "msOutils";
            this.msOutils.Size = new System.Drawing.Size(50, 20);
            this.msOutils.Text = "Outils";
            // 
            // msoGenerateur
            // 
            this.msoGenerateur.Name = "msoGenerateur";
            this.msoGenerateur.Size = new System.Drawing.Size(177, 22);
            this.msoGenerateur.Text = "Générateur d\'objets";
            this.msoGenerateur.Click += new System.EventHandler(this.msoGenerateur_Click);
            // 
            // msoDes
            // 
            this.msoDes.Name = "msoDes";
            this.msoDes.Size = new System.Drawing.Size(177, 22);
            this.msoDes.Text = "Dés";
            this.msoDes.Click += new System.EventHandler(this.msoDes_Click);
            // 
            // tcMain
            // 
            this.tcMain.Controls.Add(this.tabPage2);
            this.tcMain.Controls.Add(this.tpPlus);
            this.tcMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcMain.Location = new System.Drawing.Point(0, 24);
            this.tcMain.Name = "tcMain";
            this.tcMain.SelectedIndex = 0;
            this.tcMain.Size = new System.Drawing.Size(645, 532);
            this.tcMain.TabIndex = 2;
            this.tcMain.SelectedIndexChanged += new System.EventHandler(this.tcMain_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ficPerso1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(637, 506);
            this.tabPage2.TabIndex = 2;
            this.tabPage2.Text = "Joueur 1";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tpPlus
            // 
            this.tpPlus.Location = new System.Drawing.Point(4, 22);
            this.tpPlus.Name = "tpPlus";
            this.tpPlus.Padding = new System.Windows.Forms.Padding(3);
            this.tpPlus.Size = new System.Drawing.Size(637, 506);
            this.tpPlus.TabIndex = 1;
            this.tpPlus.Text = "    +";
            this.tpPlus.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(621, 24);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(22, 20);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "X";
            this.btnClose.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAjouterObjet
            // 
            this.btnAjouterObjet.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAjouterObjet.Location = new System.Drawing.Point(607, 318);
            this.btnAjouterObjet.Name = "btnAjouterObjet";
            this.btnAjouterObjet.Size = new System.Drawing.Size(29, 20);
            this.btnAjouterObjet.TabIndex = 67;
            this.btnAjouterObjet.Text = "+";
            this.btnAjouterObjet.UseVisualStyleBackColor = false;
            this.btnAjouterObjet.Click += new System.EventHandler(this.btnAjouterObjet_Click);
            // 
            // ficPerso1
            // 
            this.ficPerso1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ficPerso1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ficPerso1.Location = new System.Drawing.Point(0, 0);
            this.ficPerso1.Name = "ficPerso1";
            this.ficPerso1.Size = new System.Drawing.Size(637, 506);
            this.ficPerso1.TabIndex = 0;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(645, 556);
            this.Controls.Add(this.btnAjouterObjet);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.tcMain);
            this.Controls.Add(this.msMain);
            this.Name = "Main";
            this.Text = "Main";
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.tcMain.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msMain;
        private System.Windows.Forms.ToolStripMenuItem msFichier;
        private System.Windows.Forms.ToolStripMenuItem msfOuvrir;
        private System.Windows.Forms.ToolStripMenuItem msfEnregistrer;
        private System.Windows.Forms.ToolStripMenuItem msfQuitter;
        private ToolStripMenuItem msOutils;
        private ToolStripMenuItem msoGenerateur;
        private ToolStripMenuItem msoDes;
        private TabControl tcMain;
        private TabPage tpPlus;
        private TabPage tabPage2;
        private FicPerso ficPerso1;
        private Button btnClose;
        private Button btnAjouterObjet;
    }
}