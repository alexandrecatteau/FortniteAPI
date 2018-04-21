using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.IO;
using Custom_Button;
using System.Reflection;

namespace Fornite_Tracker
{
    public partial class FormMenu : Form
    {
        private Config _config = Config.GetConfig();
        public FormMenu()
        {
            InitializeComponent();
            InitializeForm();
            SetComponents(this);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation de la form
        /// </summary>
        private void InitializeForm()
        {
            //Initialisation de la police de tout les controls
            foreach (Control control in tableLayoutPanel1.Controls)
                FormInitialize.InitializeControl(control);

            //Paramètre de la fenêtre
            FormInitialize.InitializeForm_Small(this);

            //Gestion des _Button
            FormInitialize.InitializeBtn(new List<_Button> { btnHistory, btnOption, btnStat }, 60f, true);

        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage des composants de la form
        /// </summary>
        /// <param name="formMenu">Fenetre menu à rafraichir</param>
        public static void SetComponents(FormMenu formMenu)
        {
            try
            {
                formMenu._config = Config.GetConfig();

                Translation translation = Translation.GetTranslation(formMenu._config);
                formMenu.btnStat.Text = translation.ButtonText.Stat;
                formMenu.btnHistory.Text = translation.ButtonText.History;
                formMenu.btnOption.Text = translation.ButtonText.Option;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        } 


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ouverture de la fenetre option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOption_Click(object sender, EventArgs e)
        {
            FormOption formOption = new FormOption();
            DialogResult dir = formOption.ShowDialog();

            //---------------------------------------------
            //Rafraichissement des textes si on clic sur OK
            //---------------------------------------------
            if (dir != DialogResult.OK) return;

            SetComponents(this);
            InitializeForm();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ouverture de la fenetre stat
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStat_Click(object sender, EventArgs e)
        {
            FormStat formStat;
            DialogResult dir;

            try
            {
                formStat = new FormStat();
                dir = formStat.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.InnerException.Message);
                dir = new FormOption().ShowDialog();
            }

            //if (dir != DialogResult.OK) return;
        }
    }
}
