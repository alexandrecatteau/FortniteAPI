using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Custom_Button
{
    public class _Button : Button
    {
        private String _backgroundColor;
        private String _backgroundColor_Hover;
        private String _fontColor;

        /// <summary>
        /// Couleur du background 
        /// </summary>
        public string BackgroundColor
        {
            get
            {
                return _backgroundColor;
            }

            set
            {
                _backgroundColor = value;
            }
        }
        /// <summary>
        /// Couleur du background qd on passe la souris
        /// </summary>
        public string BackgroundColor_Hover
        {
            get
            {
                return _backgroundColor_Hover;
            }

            set
            {
                _backgroundColor_Hover = value;
            }
        }
        /// <summary>
        /// Couleur de la font
        /// </summary>
        public string FontColor
        {
            get
            {
                return _fontColor;
            }

            set
            {
                _fontColor = value;
            }
        }

        public _Button()
        {
            this.MouseEnter += _Button_MouseEnter;
            this.MouseLeave += _Button_MouseLeave;
            this.BackColor = ColorTranslator.FromHtml(_backgroundColor);
            this.ForeColor = ColorTranslator.FromHtml(_fontColor);
        }

        public void SetBackGroundColor(Color color)
        {
            this.BackColor = color;
        }

        private void _Button_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(_backgroundColor);
        }

        private void _Button_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = ColorTranslator.FromHtml(_backgroundColor_Hover);
        }
    }
}
