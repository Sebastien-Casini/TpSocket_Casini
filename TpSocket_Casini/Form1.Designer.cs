using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
namespace TpSocket_Casini
{
    partial class Form1
    {
        private Socket SSocketUDP;

        private EndPoint Destination, Reception;

        private Stopwatch Timer = new Stopwatch();

        private bool MessageRecu;

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.MessageR = new System.Windows.Forms.TextBox();
            this.MessageSaisit = new System.Windows.Forms.TextBox();
            this.Envoyer = new System.Windows.Forms.Button();
            this.Fermer = new System.Windows.Forms.Button();
            this.Creer = new System.Windows.Forms.Button();
            this.IPDestination = new System.Windows.Forms.TextBox();
            this.IPReception = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PortDestinataire = new System.Windows.Forms.TextBox();
            this.PortRCP = new System.Windows.Forms.TextBox();
            this.Rcp = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(33, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(79, 13);
            this.label6.TabIndex = 25;
            this.label6.Text = "Message Reçu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Message à saisir";
            // 
            // MessageR
            // 
            this.MessageR.Location = new System.Drawing.Point(36, 92);
            this.MessageR.Name = "MessageR";
            this.MessageR.Size = new System.Drawing.Size(308, 20);
            this.MessageR.TabIndex = 23;
            this.MessageR.TextChanged += new System.EventHandler(this.MessageR_TextChanged);
            // 
            // MessageSaisit
            // 
            this.MessageSaisit.Location = new System.Drawing.Point(36, 34);
            this.MessageSaisit.Name = "MessageSaisit";
            this.MessageSaisit.Size = new System.Drawing.Size(308, 20);
            this.MessageSaisit.TabIndex = 22;
            this.MessageSaisit.TextChanged += new System.EventHandler(this.MessageSaisit_TextChanged);
            // 
            // Envoyer
            // 
            this.Envoyer.Location = new System.Drawing.Point(387, 112);
            this.Envoyer.Name = "Envoyer";
            this.Envoyer.Size = new System.Drawing.Size(203, 49);
            this.Envoyer.TabIndex = 21;
            this.Envoyer.Text = "Envoyer ";
            this.Envoyer.UseVisualStyleBackColor = true;
            this.Envoyer.Click += new System.EventHandler(this.Envoyer_Click);
            // 
            // Fermer
            // 
            this.Fermer.Location = new System.Drawing.Point(387, 415);
            this.Fermer.Name = "Fermer";
            this.Fermer.Size = new System.Drawing.Size(203, 23);
            this.Fermer.TabIndex = 20;
            this.Fermer.Text = "Fermer socket";
            this.Fermer.UseVisualStyleBackColor = true;
            this.Fermer.Click += new System.EventHandler(this.Fermer_Click);
            // 
            // Creer
            // 
            this.Creer.Location = new System.Drawing.Point(36, 415);
            this.Creer.Name = "Creer";
            this.Creer.Size = new System.Drawing.Size(203, 23);
            this.Creer.TabIndex = 19;
            this.Creer.Text = "Créer socket";
            this.Creer.UseVisualStyleBackColor = true;
            this.Creer.Click += new System.EventHandler(this.Creer_Click);
            // 
            // IPDestination
            // 
            this.IPDestination.Location = new System.Drawing.Point(460, 66);
            this.IPDestination.Name = "IPDestination";
            this.IPDestination.Size = new System.Drawing.Size(100, 20);
            this.IPDestination.TabIndex = 29;
            this.IPDestination.TextChanged += new System.EventHandler(this.IPDestination_TextChanged);
            // 
            // IPReception
            // 
            this.IPReception.Location = new System.Drawing.Point(460, 38);
            this.IPReception.Name = "IPReception";
            this.IPReception.Size = new System.Drawing.Size(100, 20);
            this.IPReception.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(384, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Destination";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 26;
            this.label1.Text = "Reception";
            // 
            // PortDestinataire
            // 
            this.PortDestinataire.Location = new System.Drawing.Point(566, 66);
            this.PortDestinataire.Name = "PortDestinataire";
            this.PortDestinataire.Size = new System.Drawing.Size(53, 20);
            this.PortDestinataire.TabIndex = 31;
            // 
            // PortRCP
            // 
            this.PortRCP.Location = new System.Drawing.Point(566, 38);
            this.PortRCP.Name = "PortRCP";
            this.PortRCP.Size = new System.Drawing.Size(54, 20);
            this.PortRCP.TabIndex = 30;
            // 
            // Rcp
            // 
            this.Rcp.Location = new System.Drawing.Point(387, 187);
            this.Rcp.Name = "Rcp";
            this.Rcp.Size = new System.Drawing.Size(203, 35);
            this.Rcp.TabIndex = 32;
            this.Rcp.Text = "Reception";
            this.Rcp.UseVisualStyleBackColor = true;
            this.Rcp.Click += new System.EventHandler(this.Rcp_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 450);
            this.Controls.Add(this.Rcp);
            this.Controls.Add(this.PortDestinataire);
            this.Controls.Add(this.PortRCP);
            this.Controls.Add(this.IPDestination);
            this.Controls.Add(this.IPReception);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.MessageR);
            this.Controls.Add(this.MessageSaisit);
            this.Controls.Add(this.Envoyer);
            this.Controls.Add(this.Fermer);
            this.Controls.Add(this.Creer);
            this.Name = "Form1";
            this.Text = "Communication par socket UDP";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox MessageR;
        private System.Windows.Forms.TextBox MessageSaisit;
        private System.Windows.Forms.Button Envoyer;
        private System.Windows.Forms.Button Fermer;
        private System.Windows.Forms.Button Creer;
        private System.Windows.Forms.TextBox IPDestination;
        private System.Windows.Forms.TextBox IPReception;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PortDestinataire;
        private System.Windows.Forms.TextBox PortRCP;
        private System.Windows.Forms.Button Recep;
        private System.Windows.Forms.Button Rcp;
    }
}

