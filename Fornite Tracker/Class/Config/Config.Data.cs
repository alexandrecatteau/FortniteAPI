using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Fornite_Tracker
{
    public partial class Config
    {

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupere tous les noeud du fichier config
        /// </summary>
        /// <param name="pathXML"></param>
        /// <returns></returns>
        private static XmlNode GetDataConfig()
        {
            return GetData("/config");
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération des noeuds a partir d'un fichier XML
        /// </summary>
        /// <param name="pathXML">Chemin du fichier XML</param>
        /// <param name="node">Noeud à utiliser</param>
        /// <returns></returns>
        private static XmlNode GetData(String node)
        {
            String pathXML = GetPathConfig();
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNode;
            try
            {
                xmlDocument.Load(pathXML);

                xmlNode = xmlDocument.DocumentElement.SelectSingleNode(node);
            }
            catch (Exception)
            {
                SaveConfig(new Config());
                return null;
            }

            return xmlNode;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ecriture du fichier XML pour une nouvelle config
        /// </summary>
        /// <param name="config">Objet config</param>
        /// <param name="pathXML">Chemin ou écrire le fichier XML</param>
        private static void SaveConfig(Config config)
        {
            String pathXML = GetPathConfig();
            try
            {
                //------------------------------------------------------------------------
                //On vérifie qu'il y a bien un fichier config sinon on en écrit un nouveau
                //------------------------------------------------------------------------
                if (!FileExist(pathXML))
                    SaveConfig_New();

                SaveConfig(config);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de l'écriture du fichier config. " + Environment.NewLine + ex.Message);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Réecrit un nouveau fichier config vide
        /// </summary>
        private static void SaveConfig_New()
        {
            String data = "<?xml version=\"1.0\"?>"+
                    @"<config>
                        <login></login>
                        <platform>0</platform>
                        <apiKey></apiKey>
                        <language>0</language>
                        <color>
                            <backgroundColor_Form>#033077</backgroundColor_Form>
                            <backgroundColor_Button>#1138d6</backgroundColor_Button>
                            <backgroundColor_Button_Hover>#66660b</backgroundColor_Button_Hover>
                            <fontColor>#e0e028</fontColor>
                        </color>
                      </config>";

            String path = Application.StartupPath + @"\Config\";

            Directory.CreateDirectory(path);
            path += "config.xml";
            

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(data);
            using (XmlTextWriter xmlWriter = new XmlTextWriter(path, null))
            {
                xmlWriter.Formatting = Formatting.Indented;
                doc.Save(xmlWriter);
            }
        }
    }
}
