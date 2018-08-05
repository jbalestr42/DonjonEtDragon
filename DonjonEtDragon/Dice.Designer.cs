namespace DonjonEtDragon
{
    partial class Dice
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
            this.btnLance = new System.Windows.Forms.Button();
            this.tbLance = new System.Windows.Forms.TextBox();
            this.rtbView = new System.Windows.Forms.RichTextBox();
            this.lbTotal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tbMultiplicateur = new System.Windows.Forms.TextBox();
            this.lblDegat = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tbcc = new System.Windows.Forms.TextBox();
            this.lblDegatCritique = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnLance
            // 
            this.btnLance.Location = new System.Drawing.Point(118, 10);
            this.btnLance.Name = "btnLance";
            this.btnLance.Size = new System.Drawing.Size(75, 23);
            this.btnLance.TabIndex = 2;
            this.btnLance.Text = "Lance";
            this.btnLance.UseVisualStyleBackColor = true;
            this.btnLance.Click += new System.EventHandler(this.btnLance_Click);
            // 
            // tbLance
            // 
            this.tbLance.Location = new System.Drawing.Point(12, 12);
            this.tbLance.Name = "tbLance";
            this.tbLance.Size = new System.Drawing.Size(100, 20);
            this.tbLance.TabIndex = 1;
            this.tbLance.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLance_KeyDown);
            // 
            // rtbView
            // 
            this.rtbView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.rtbView.Location = new System.Drawing.Point(12, 151);
            this.rtbView.Name = "rtbView";
            this.rtbView.ReadOnly = true;
            this.rtbView.Size = new System.Drawing.Size(181, 194);
            this.rtbView.TabIndex = 3;
            this.rtbView.Text = "";
            // 
            // lbTotal
            // 
            this.lbTotal.AutoSize = true;
            this.lbTotal.Location = new System.Drawing.Point(13, 39);
            this.lbTotal.Name = "lbTotal";
            this.lbTotal.Size = new System.Drawing.Size(40, 13);
            this.lbTotal.TabIndex = 3;
            this.lbTotal.Text = "Total : ";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Multiplicateur : ";
            // 
            // tbMultiplicateur
            // 
            this.tbMultiplicateur.Location = new System.Drawing.Point(93, 55);
            this.tbMultiplicateur.Name = "tbMultiplicateur";
            this.tbMultiplicateur.Size = new System.Drawing.Size(43, 20);
            this.tbMultiplicateur.TabIndex = 5;
            this.tbMultiplicateur.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLance_KeyDown);
            // 
            // lblDegat
            // 
            this.lblDegat.AutoSize = true;
            this.lblDegat.Location = new System.Drawing.Point(13, 78);
            this.lblDegat.Name = "lblDegat";
            this.lblDegat.Size = new System.Drawing.Size(50, 13);
            this.lblDegat.TabIndex = 6;
            this.lblDegat.Text = "Dégats : ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Coup critique : ";
            // 
            // tbcc
            // 
            this.tbcc.Location = new System.Drawing.Point(106, 97);
            this.tbcc.Name = "tbcc";
            this.tbcc.Size = new System.Drawing.Size(43, 20);
            this.tbcc.TabIndex = 8;
            this.tbcc.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbLance_KeyDown);
            // 
            // lblDegatCritique
            // 
            this.lblDegatCritique.AutoSize = true;
            this.lblDegatCritique.Location = new System.Drawing.Point(13, 122);
            this.lblDegatCritique.Name = "lblDegatCritique";
            this.lblDegatCritique.Size = new System.Drawing.Size(87, 13);
            this.lblDegatCritique.TabIndex = 9;
            this.lblDegatCritique.Text = "Dégats critique : ";
            // 
            // Dice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(205, 357);
            this.Controls.Add(this.lblDegatCritique);
            this.Controls.Add(this.tbcc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblDegat);
            this.Controls.Add(this.tbMultiplicateur);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbTotal);
            this.Controls.Add(this.rtbView);
            this.Controls.Add(this.tbLance);
            this.Controls.Add(this.btnLance);
            this.Name = "Dice";
            this.Text = "Des";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLance;
        private System.Windows.Forms.TextBox tbLance;
        private System.Windows.Forms.RichTextBox rtbView;
        private System.Windows.Forms.Label lbTotal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbMultiplicateur;
        private System.Windows.Forms.Label lblDegat;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbcc;
        private System.Windows.Forms.Label lblDegatCritique;
    }
}

