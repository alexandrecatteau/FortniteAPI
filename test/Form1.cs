using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace ControlInvokeSample
{
    public class Form1 : System.Windows.Forms.Form
    {
        private System.Windows.Forms.Label label_Affichage;
        private System.Windows.Forms.Button button_Start;
        private System.ComponentModel.Container components = null;

        public Form1()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.label_Affichage = new System.Windows.Forms.Label();
            this.button_Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_Affichage 
            // 
            this.label_Affichage.Location = new System.Drawing.Point(8, 40);
            this.label_Affichage.Name = "label_Affichage";
            this.label_Affichage.Size = new System.Drawing.Size(472, 72);
            this.label_Affichage.TabIndex = 0;
            // 
            // button_Start 
            // 
            this.button_Start.Location = new System.Drawing.Point(8, 8);
            this.button_Start.Name = "button_Start";
            this.button_Start.TabIndex = 1;
            this.button_Start.Text = "Start";
            this.button_Start.Click += new System.EventHandler(this.button_Start_Click);
            // 
            // Form1 
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(488, 117);
            this.Controls.Add(this.button_Start);
            this.Controls.Add(this.label_Affichage);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }
        #endregion

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        // **************** 
        // définition du delegate qui sera utilisé 
        private delegate void UpdateLabelDelegate(string text);
        // **************** 

        private UpdateLabelDelegate m_upLbl;
        private Thread m_monThread;


        private void button_Start_Click(object sender, System.EventArgs e)
        {
            button_Start.Enabled = false;

            // affectation du nom du thread courant 
            Thread.CurrentThread.Name = "Thread principal";

            // initialisation de l'instance de UpdateLabelDelegate qui sera utilisée dans le thread 
            m_upLbl = new UpdateLabelDelegate(this.MaMethodeDeMajDuLabel);

            // création et lancement du thread "supplémentaire" 
            m_monThread = new Thread(new ThreadStart(this.ThreadProc));
            m_monThread.Name = "Thread supplémentaire";
            m_monThread.Start();
        }

        private void ThreadProc()
        {
            // le tableau d'object qui sera utilisé pour le passage des paramètres. 
            object[] args = new object[1];

            for (int i = 0; i <= 10; i++)
            {
                // affectation du texte, c'est lui qui sera reçu en paramètre "text" de notre méthode 
                args[0] = string.Format("{0} (depuis : {1})", i.ToString(), Thread.CurrentThread.Name);

                // **************** 
                label_Affichage.Invoke(m_upLbl, args);
                // **************** 

                // petite pause 
                Thread.Sleep(500);
            }

            args[0] = string.Format("C'est fini :-) (depuis : {0})", Thread.CurrentThread.Name);
            label_Affichage.Invoke(m_upLbl, args);
        }

        // **************** 
        // la méthode correspondant à la déclaration de UpdateLabelDelegate 
        // qui fera la MAJ du texte du Label dans le thread auquel appartient le contrôle. 
        private void MaMethodeDeMajDuLabel(string text)
        {
            // MAJ du texte en ajoutant le nom du thread depuis lequel cette maj est faite. 
            label_Affichage.Text = string.Format("{0}\r\nLabel mis à jour depuis : {1}", text, Thread.CurrentThread.Name);
        }
        // **************** 
    }
}
