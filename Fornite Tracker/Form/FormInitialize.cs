using Alex.Controls;
using Custom_Button;
using Fornite_Tracker.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fornite_Tracker
{
    class FormInitialize
    {
        private readonly String _backgroundColor_Form;
        private readonly String _backgroundColor_Button;
        private readonly String _backgroundColorHover_Button;
        private readonly String _fontColor;

        private const float C_FontSize_Text = 20f;
        private const float C_FontSize_Button = 30f;

        public FormInitialize()
        {
            Config config = Config.GetConfig();

            _backgroundColor_Form = config.Color.BackgroundColor_Form;
            _backgroundColor_Button = config.Color.BackgroundColor_Button;
            _backgroundColorHover_Button = config.Color.BackgroundColor_Button_Hover;
            _fontColor = config.Color.FontColor;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Défini le background d'un panel
        /// </summary>
        /// <param name="panel"></param>
        public static void SetPanel_BackGround(Panel panel)
        {
            FormInitialize formInitialize = new FormInitialize();
            panel.BackColor = ColorTranslator.FromHtml(formInitialize._fontColor);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Changement de la couleur de l'arriere plan d'une FORM
        /// </summary>
        /// <param name="form">Form ou changer la couleur</param>
        public static void BackgroundColor_Window(Form form)
        {
            FormInitialize formInitialize = new FormInitialize();
            form.BackColor = ColorTranslator.FromHtml(formInitialize._backgroundColor_Form);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation d'un control d'une FORM
        /// </summary>
        /// <param name="controls">control de la form</param>
        public static void InitializeControl(Control control)
        {
            Font font = new Font("Burbank Big Cd Md", C_FontSize_Text, FontStyle.Regular);
            control.Font = font;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Configuration des labels titres
        /// </summary>
        /// <param name="label">Label ou il faut changer la couleur</param>
        /// <param name="fontSize">false si par defaut</param>
        public static void InitializeLabel(Label label, float? fontSize)
        {
            if (fontSize == null) fontSize = C_FontSize_Text;

            FormInitialize formInitialize = new FormInitialize();
            label.ForeColor = ColorTranslator.FromHtml(formInitialize._fontColor);
            Font font = new Font("Burbank Big Cd Md", fontSize.Value, FontStyle.Bold);
            label.Font = font;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initilisation d'une petite fenetre
        /// </summary>
        /// <param name="form">Form à initialiser</param>
        public static void InitializeForm_Small(Form form)
        {
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MaximizeBox = false;
            form.MinimumSize = form.Size;
            form.MaximumSize = form.Size;
            BackgroundColor_Window(form);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Change FontColor des labels
        /// </summary>
        /// <param name="labels">List de label</param>
        public static void ForeColor_Label(List<Label> labels)
        {
            FormInitialize formInitialize = new FormInitialize();
            foreach (Label label in labels)
            {
                label.ForeColor = ColorTranslator.FromHtml(formInitialize._fontColor);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Change FontColor d'un control
        /// </summary>
        /// <param name="control">Control ou changer la couleur</param>
        public static void ForeColor_LinkLabel(LinkLabel control)
        {
            FormInitialize formInitialize = new FormInitialize();
            control.LinkColor = ColorTranslator.FromHtml(formInitialize._fontColor);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation de comboboxs
        /// </summary>
        /// <param name="comboboxs">List de _ComboBox</param>
        public static void InitializeCmb(List<_ComboBox> comboboxs)
        {
            foreach (_ComboBox combobox in comboboxs)
            {
                combobox.AutoCompleteMode = AutoCompleteMode.None;
                combobox.FlatStyle = FlatStyle.System;
                combobox.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation des buttons customs (_Button)
        /// </summary>
        /// <param name="buttons">List des _Buttons</param>
        /// <param name="fontSize">null si valeur par defaut</param>
        /// <param name="bold">true = gras</param>
        public static void InitializeBtn(List<_Button> buttons, float? fontSize, Boolean bold)
        {
            if (fontSize == null) fontSize = C_FontSize_Button;

            FontStyle fontStyle;
            if (bold) fontStyle = FontStyle.Bold;
            else fontStyle = FontStyle.Regular;

            FormInitialize formInitialize = new FormInitialize();

            foreach (_Button button in buttons)
            {
                Font font = new Font("Burbank Big Cd Md", fontSize.Value, fontStyle);
                button.Font = font;
                button.BackColor = ColorTranslator.FromHtml(formInitialize._backgroundColor_Button);
                button.ForeColor = ColorTranslator.FromHtml(formInitialize._fontColor);
                button.BackgroundColor = formInitialize._backgroundColor_Button;
                button.BackgroundColor_Hover = formInitialize._backgroundColorHover_Button;
                button.FontColor = formInitialize._fontColor;
            }
        }
    }
}
