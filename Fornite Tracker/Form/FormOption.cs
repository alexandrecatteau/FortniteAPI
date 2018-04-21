using Alex.Controls;
using Custom_Button;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fornite_Tracker
{
    public partial class FormOption : Form
    {
        /// <summary>
        /// Objet config
        /// </summary>
        private Config _config = Config.GetConfig();


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Constructeur, si autre forme que FormMenu mettre null
        /// </summary>
        /// <param name="formMenu"></param>
        public FormOption()
        {
            InitializeComponent();
            InitializeForm();
            FillComponents();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage des composants de la form
        /// </summary>
        private void FillComponents()
        {
            //Button
            Translation translation = Translation.GetTranslation(_config);
            btnOk.Text = translation.ButtonText.Ok;
            btnCancel.Text = translation.ButtonText.Cancel;

            //Label
            lblOption_Title.Text = translation.LabelText.TitleOption;
            lblLogin.Text = translation.LabelText.Login;
            lblPlatform.Text = translation.LabelText.Platform;
            lblApiKey.Text = translation.LabelText.ApiKey;
            lblLanguage.Text = translation.LabelText.Language;
            lblColor_BackgroundForm.Text = translation.LabelText.Color.Title;
            lblColor_BackgroundForm.Text = translation.LabelText.Color.Window;
            lblColor_BackgroundButton.Text = translation.LabelText.Color.Button;
            lblColor_BackgroundButton_Hover.Text = translation.LabelText.Color.ButtonHover;
            lblColor_Font.Text = translation.LabelText.Color.Font;
            linkLabelApiKey.Text = translation.LabelText.ApiKeyGenerate;

            //Combobox
            FillCmbLanguage();
            FillCmbPlatForm();

            //Remplissage des controls auto
            FillComponents_Config();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rempli les composants a partir du fichier config
        /// </summary>
        private void FillComponents_Config()
        {
            txtLogin.Text = _config.Login;
            txtApiKey.Text = _config.ApiKey;

            //-------------------------------
            //Recherche du cmb a sélectionner
            //-------------------------------
            foreach (ItemData itemData in cmbLanguage.Items)
            {
                if (((Int32)itemData.Item).ToString() == _config.Language)
                {
                    cmbLanguage.SelectedItem = itemData;
                    break;
                }
            }

            //-------------------------------
            //Recherche du cmb a sélectionner
            //-------------------------------
            foreach (ItemData itemData in cmbPlatform.Items)
            {
                if (((Int32)itemData.Item).ToString() == _config.Platform)
                {
                    cmbPlatform.SelectedItem = itemData;
                    break;
                }
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage cmb language
        /// </summary>
        private void FillCmbLanguage()
        {
            cmbLanguage.Items.Add(new ItemData((Int32)EnumLanguage.FR, "FR"));
            cmbLanguage.Items.Add(new ItemData((Int32)EnumLanguage.EN, "EN"));
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage cmb platform
        /// </summary>
        private void FillCmbPlatForm()
        {
            cmbPlatform.Items.Add(new ItemData((Int32)EnumPlatform.PC, "PC"));
            cmbPlatform.Items.Add(new ItemData((Int32)EnumPlatform.PS4, "PS4"));
            cmbPlatform.Items.Add(new ItemData((Int32)EnumPlatform.XBOX1, "XBOX1"));
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation de la form et des composants
        /// </summary>
        private void InitializeForm()
        {
            //Initialisation de la font
            foreach (Control control in this.Controls)
            {
                if (control is LinkLabel)
                {
                    FormInitialize.ForeColor_LinkLabel(linkLabelApiKey);
                    continue;
                }
                FormInitialize.InitializeControl(control);
            }

            //Initialisation de la Form
            FormInitialize.InitializeForm_Small(this);

            //Gestion Label...
            FormInitialize.InitializeLabel(lblOption_Title, 50f);
            FormInitialize.InitializeLabel(lblColor_Title, 50f);
            FormInitialize.InitializeCmb(new List<_ComboBox> { cmbLanguage, cmbPlatform });
            FormInitialize.ForeColor_Label(new List<Label>
                { lblApiKey, lblLanguage, lblLogin, lblPlatform, lblColor_BackgroundForm, lblColor_BackgroundButton, lblColor_BackgroundButton_Hover, lblColor_Font });
            FormInitialize.InitializeBtn(new List<_Button> { btnOk, btnCancel }, null, true);

            btnColor_Background_Button.BackColor = Config.GetColor(_config.Color.BackgroundColor_Button);
            btnColor_Background_Form.BackColor = Config.GetColor(_config.Color.BackgroundColor_Form);
            btnColor_Background_Button_Hover.BackColor = Config.GetColor(_config.Color.BackgroundColor_Button_Hover);
            btnColor_Font.BackColor = Config.GetColor(_config.Color.FontColor);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sauvegarde le fichier config
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                _config.Login = txtLogin.Text;
                _config.Platform = ((Int32)((ItemData)cmbPlatform.SelectedItem).Item).ToString();
                _config.ApiKey = txtApiKey.Text;
                _config.Language = ((Int32)((ItemData)cmbLanguage.SelectedItem).Item).ToString();

                Config.SetConfig(_config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Changement de couleur pour les Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Background_Form_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Config.GetColor(_config.Color.BackgroundColor_Form);
            colorDialog.FullOpen = true;

            DialogResult dir = colorDialog.ShowDialog();

            if (dir != DialogResult.OK) return;

            _config.Color.BackgroundColor_Form = Config.GetColor_String(colorDialog.Color);

            this.BackColor = colorDialog.Color;

            (sender as Button).BackColor = colorDialog.Color;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Changement de couleur pour le hover des boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Background_Button_Hover_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Config.GetColor(_config.Color.BackgroundColor_Button_Hover);
            colorDialog.FullOpen = true;

            DialogResult dir = colorDialog.ShowDialog();

            if (dir != DialogResult.OK) return;

            _config.Color.BackgroundColor_Button_Hover = Config.GetColor_String(colorDialog.Color);

            btnOk.BackgroundColor_Hover = Config.GetColor_String(colorDialog.Color);
            btnCancel.BackgroundColor_Hover = Config.GetColor_String(colorDialog.Color);

            (sender as Button).BackColor = colorDialog.Color;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Changement de couleur pour les boutons
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Background_Button_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Config.GetColor(_config.Color.BackgroundColor_Button);
            colorDialog.FullOpen = true;

            DialogResult dir = colorDialog.ShowDialog();

            if (dir != DialogResult.OK) return;

            _config.Color.BackgroundColor_Button = Config.GetColor_String(colorDialog.Color);

            btnCancel.BackgroundColor = Config.GetColor_String(colorDialog.Color);
            btnOk.BackgroundColor = Config.GetColor_String(colorDialog.Color);

            btnOk.SetBackGroundColor(colorDialog.Color);
            btnCancel.SetBackGroundColor(colorDialog.Color);
            
            (sender as Button).BackColor = colorDialog.Color;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Changement de fontColor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnColor_Font_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog = new ColorDialog();
            colorDialog.Color = Config.GetColor(_config.Color.FontColor);
            colorDialog.FullOpen = true;

            DialogResult dir = colorDialog.ShowDialog();

            if (dir != DialogResult.OK) return;

            _config.Color.FontColor = Config.GetColor_String(colorDialog.Color);

            foreach (Control control in this.Controls)
            {
                if(control is _TextBox)
                    continue;

                if (control is LinkLabel)
                {
                    (control as LinkLabel).LinkColor = colorDialog.Color;
                }

                control.ForeColor = colorDialog.Color;
            }

            (sender as Button).BackColor = colorDialog.Color;
        }

        private void linkLabelApiKey_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://fortnitetracker.com/site-api");
        }
    }
}
