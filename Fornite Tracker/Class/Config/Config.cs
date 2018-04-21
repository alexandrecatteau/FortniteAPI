using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Fornite_Tracker
{
    [XmlRoot(ElementName = "config")]
    public partial class Config
    {
        /// <summary>
        /// Login du compte
        /// </summary>
        [XmlElement(ElementName = "login")]
        public string Login { get; set; }
        /// <summary>
        /// Plateform du jeu
        /// </summary>
        [XmlElement(ElementName = "platform")]
        public String Platform { get; set; }
        /// <summary>
        /// Clé API pour la connexion sur le net
        /// </summary>
        [XmlElement(ElementName = "apiKey")]
        public string ApiKey { get; set; }
        /// <summary>
        /// Language choisi
        /// </summary>
        [XmlElement(ElementName = "language")]
        public String Language { get; set; }
        /// <summary>
        /// Objet color avec les différentes couleurs
        /// </summary>
        [XmlElement(ElementName = "color")]
        public Color_Form Color { get; set; }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupère le fichier config
        /// </summary>
        /// <returns></returns>
        public static Config GetConfig()
        {
            if (!FileExist(GetPathConfig())) SaveConfig_New();

            Config config = new Config();
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));

            using (StreamReader streamReader = new StreamReader(GetPathConfig()))
            {
                config = xmlSerializer.Deserialize(streamReader) as Config;
            }



            return config;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sauvegarde de la config dans un fichier xml
        /// </summary>
        /// <param name="config">Objet config</param>
        public static void SetConfig(Config config)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Config));
            using (StreamWriter streamWriter = new StreamWriter(GetPathConfig()))
            {
                xmlSerializer.Serialize(streamWriter, config);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération du fichier xml config
        /// </summary>
        /// <returns></returns>
        public static String GetPathConfig()
        {
            String path = Application.StartupPath + @"\Config\config.xml";
            return path;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Vérification que le fichier config existe
        /// </summary>
        /// <param name="path">Chemin du fichier</param>
        /// <returns></returns>
        private static Boolean FileExist(String path)
        {
            return File.Exists(path);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un chaine de caractere en Hexadécimal depuis une couleur
        /// </summary>
        /// <param name="color">Couleur a récupérer</param>
        /// <returns></returns>
        public static String GetColor_String(Color color)
        {
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Vérification qu'il y a bien un login et une clé api dans le fichier config
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Boolean IsFileOk(Config config)
        {
            if (String.IsNullOrEmpty(config.ApiKey)) return false;
            if (String.IsNullOrEmpty(config.Login)) return false;

            return true;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un couleur depuis
        /// </summary>
        /// <param name="hexa"></param>
        /// <returns></returns>
        public static Color GetColor(String hexa)
        {
            return ColorTranslator.FromHtml(hexa);
        }
    }

    #region Class XML

    [XmlRoot(ElementName = "color")]
    public class Color_Form
    {
        [XmlElement(ElementName = "backgroundColor_Form")]
        public string BackgroundColor_Form { get; set; }
        [XmlElement(ElementName = "backgroundColor_Button")]
        public string BackgroundColor_Button { get; set; }
        [XmlElement(ElementName = "backgroundColor_Button_Hover")]
        public string BackgroundColor_Button_Hover { get; set; }
        [XmlElement(ElementName = "fontColor")]
        public string FontColor { get; set; }
    }

    #endregion
}
