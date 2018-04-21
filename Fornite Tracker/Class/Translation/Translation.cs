using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;

namespace Fornite_Tracker
{
    [XmlRoot(ElementName = "language")]
    public partial class Translation
    {
        [XmlElement(ElementName = "button")]
        public Button_Text ButtonText { get; set; }

        [XmlElement(ElementName = "label")]
        public Label_Text LabelText { get; set; }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Recupération objet selon la langue choisi dans option
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static Translation GetTranslation(Config config)
        {
            //------------------------------------------------
            //Création d'un nouveau fichier si il n'existe pas
            //------------------------------------------------
            if (!FileExist(GetPath(EnumLanguage.FR)) || !FileExist(GetPath(EnumLanguage.EN)))
            {
                SetXML_EN(GetPath(EnumLanguage.EN));
                SetXML_FR(GetPath(EnumLanguage.FR));
            }

            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Translation));
            Translation translation = new Translation();

            using (StreamReader streamReader = new StreamReader(GetPath(Language.GetEnum(Int32.Parse(config.Language)))))
            {
                translation = xmlSerializer.Deserialize(streamReader) as Translation;
            }

            return translation;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération du chemin pour le xml langage
        /// </summary>
        /// <param name="enumLanguage">Langue choisie</param>
        /// <returns></returns>
        public static String GetPath(EnumLanguage enumLanguage)
        {
            String path = Application.StartupPath + @"\Translation\";
            Directory.CreateDirectory(path);

            switch (enumLanguage)
            {
                case EnumLanguage.FR:
                    path += "FR.xml";
                    break;
                case EnumLanguage.EN:
                    path += "EN.xml";
                    break;
                default:
                    path = null;
                    break;
            }

            return path;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Vérification qu'un fichier xml existe, si ko on écrit un nouveau fichier
        /// </summary>
        /// <param name="path">Chemin du fichier XML</param>
        /// <returns></returns>
        public static Boolean FileExist(String path)
        {
            if(File.Exists(path)) return true;

            return false;
        }
    }

    #region CLASS XML
    [XmlRoot(ElementName = "color")]
    public class ColorText
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "window")]
        public string Window { get; set; }
        [XmlElement(ElementName = "button")]
        public string Button { get; set; }
        [XmlElement(ElementName = "buttonHover")]
        public string ButtonHover { get; set; }
        [XmlElement(ElementName = "font")]
        public string Font { get; set; }
    }
    [XmlRoot(ElementName = "button")]
    public class Button_Text
    {
        [XmlElement(ElementName = "stat")]
        public string Stat { get; set; }
        [XmlElement(ElementName = "history")]
        public string History { get; set; }
        [XmlElement(ElementName = "option")]
        public string Option { get; set; }
        [XmlElement(ElementName = "ok")]
        public string Ok { get; set; }
        [XmlElement(ElementName = "cancel")]
        public string Cancel { get; set; }
        [XmlElement(ElementName = "search")]
        public string Search { get; set; }
        [XmlElement(ElementName = "allStat")]
        public string AllStat { get; set; }
        [XmlElement(ElementName = "solo")]
        public string Solo { get; set; }
        [XmlElement(ElementName = "duo")]
        public string Duo { get; set; }
        [XmlElement(ElementName = "squad")]
        public string Squad { get; set; }
    }

    [XmlRoot(ElementName = "lifeTimeStat")]
    public class LifeTimeStat_Text
    {
        [XmlElement(ElementName = "title")]
        public string Title { get; set; }
        [XmlElement(ElementName = "score")]
        public string Score { get; set; }
        [XmlElement(ElementName = "matchsPlayed")]
        public string MatchsPlayed { get; set; }
        [XmlElement(ElementName = "wins")]
        public string Wins { get; set; }
        [XmlElement(ElementName = "winPercentage")]
        public string WinPercentage { get; set; }
        [XmlElement(ElementName = "kill")]
        public string Kill { get; set; }
        [XmlElement(ElementName = "killDeath")]
        public string KillDeath { get; set; }
        [XmlElement(ElementName = "killMinute")]
        public string KillMinute { get; set; }
        [XmlElement(ElementName = "timePlayed")]
        public string TimePlayed { get; set; }
    }

    [XmlRoot(ElementName = "label")]
    public class Label_Text
    {
        [XmlElement(ElementName = "apiKeyGenerate")]
        public string ApiKeyGenerate { get; set; }
        [XmlElement(ElementName = "color")]
        public ColorText Color { get; set; }
        [XmlElement(ElementName = "titleOption")]
        public string TitleOption { get; set; }
        [XmlElement(ElementName = "login")]
        public string Login { get; set; }
        [XmlElement(ElementName = "platform")]
        public string Platform { get; set; }
        [XmlElement(ElementName = "apiKey")]
        public string ApiKey { get; set; }
        [XmlElement(ElementName = "language")]
        public string Language { get; set; }
        [XmlElement(ElementName = "lifeTimeStat")]
        public LifeTimeStat_Text LifeTimeStat { get; set; }
        [XmlElement(ElementName = "stat")]
        public Stat Stat { get; set; }
    }

    [XmlRoot(ElementName = "stat")]
    public class Stat
    {
        [XmlElement(ElementName = "title")]
        public Title Title { get; set; }
        [XmlElement(ElementName = "score")]
        public string Score { get; set; }
        [XmlElement(ElementName = "matchesPlayed")]
        public string MatchesPlayed { get; set; }
        [XmlElement(ElementName = "top")]
        public Top Top { get; set; }
        [XmlElement(ElementName = "winRatio")]
        public string WinRatio { get; set; }
        [XmlElement(ElementName = "kill")]
        public string Kill { get; set; }
        [XmlElement(ElementName = "killDeath")]
        public string KillDeath { get; set; }
        [XmlElement(ElementName = "killMinute")]
        public string KillMinute { get; set; }
        [XmlElement(ElementName = "killGame")]
        public string KillGame { get; set; }
        [XmlElement(ElementName = "timePlayed")]
        public string TimePlayed { get; set; }
    }

    [XmlRoot(ElementName = "top")]
    public class Top
    {
        [XmlElement(ElementName = "top1")]
        public string Top1 { get; set; }
        [XmlElement(ElementName = "top5")]
        public string Top5 { get; set; }
        [XmlElement(ElementName = "top12")]
        public string Top12 { get; set; }
        [XmlElement(ElementName = "top3")]
        public string Top3 { get; set; }
        [XmlElement(ElementName = "top6")]
        public string Top6 { get; set; }
        [XmlElement(ElementName = "top10")]
        public string Top10 { get; set; }
        [XmlElement(ElementName = "top25")]
        public string Top25 { get; set; }
    }

    [XmlRoot(ElementName = "title")]
    public class Title
    {
        [XmlElement(ElementName = "solo")]
        public string Solo { get; set; }
        [XmlElement(ElementName = "duo")]
        public string Duo { get; set; }
        [XmlElement(ElementName = "squad")]
        public string Squad { get; set; }
    }

    #endregion
}
