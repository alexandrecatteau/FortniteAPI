using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Fornite_Tracker
{
    partial class Translation
    {
        private static XmlReader GetData(String path)
        {
            XmlReader xmlReader;
            using (xmlReader = XmlReader.Create(path))
            {
                return xmlReader;
            }
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
        private static XmlNode GetData(String pathXML, String node)
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlNode xmlNode;
            try
            {
                xmlDocument.Load(pathXML);

                xmlNode = xmlDocument.DocumentElement.SelectSingleNode(node);
            }
            catch (Exception e)
            {
                throw new Exception("Impossible d'ouvrir le fichier de Language." + e.Message);
            }

            return xmlNode;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Réecrit un nouveau fichier FR
        /// </summary>
        /// <param name="path"></param>
        private static void SetXML_FR(String path)
        {
            String xml =
                "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>" +
              @"    <language>
                      <button>
                        <stat>Statistiques</stat>
                        <history>Historiques</history>
                        <option>Options</option>
                        <ok>OK</ok>
                        <cancel>Annuler</cancel>
                        <search>Chercher</search>
                        <allStat>Tous</allStat>
                        <solo>Solo</solo>
                        <duo>Duo</duo>
                        <squad>Section</squad>
                      </button>
                      <label>
                        <titleOption>Options</titleOption>
                        <login>Pseudo</login>
                        <platform>Plateforme</platform>
                        <apiKey>Clé API</apiKey>
                        <apiKeyGenerate>Générer une clé API</apiKeyGenerate>
                        <language>Langage</language>
                        <lifeTimeStat>
                            <title>Stats générales</title>
                            <score>Score</score>
                            <matchsPlayed>Matchs joués</matchsPlayed>
                            <wins>Victoires</wins>
                            <winPercentage>% Victoires</winPercentage>
                            <kill>Eliminations</kill>
                            <killDeath>Eliminations / Mort</killDeath>
                            <killMinute>Elimination / Minute</killMinute>
                            <timePlayed>Temps joué</timePlayed>
                        </lifeTimeStat>

                        <stat>
                            <title>
                                <solo>Stats Solo</solo>
                                <duo>Stats Duo</duo>
                                <squad>Stats Section</squad>
                            </title>
                            <score>Score</score>
                            <matchesPlayed>Matchs joués</matchesPlayed>
                            <top>
                                <top1>Top 1</top1>
                                <top5>Top 5</top5>
                                <top12>Top 12</top12>
                                <top3>Top 3</top3>
                                <top6>Top 6</top6>
                                <top10>Top 10</top10>
                                <top25>Top 25</top25>
                            </top>
                            <winRatio>% Victoires</winRatio>
                            <kill>Eliminations</kill>
                            <killDeath>Eliminations / Mort</killDeath>
                            <killMinute>Eliminations / Minute</killMinute>
                            <killGame>Eliminations / Partie</killGame>
                            <timePlayed>Temps joué</timePlayed>
                        </stat>

                        <color>
                            <title>Couleurs</title>
                            <window>Fenêtre</window>
                            <button>Bouttons</button>
                            <buttonHover>Bouton survol</buttonHover>
                            <font>Police</font>
                        </color>

                      </label>
                    </language>";

            WriteXml(path, xml);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Réecrit un nouveau fichier EN
        /// </summary>
        /// <param name="path"></param>
        private static void SetXML_EN(String path)
        {
            String xml =
                "<?xml version=\"1.0\" encoding=\"utf - 8\" ?>" +
              @"    <language>
                      <button>
                        <stat>Statistics</stat>
                        <history>Historic</history>
                        <option>Options</option>	
                        <ok>OK</ok>
                        <cancel>Cancel</cancel>
                        <search>Search</search>
                        <allStat>All</allStat>
                        <solo>Solo</solo>
                        <duo>Duo</duo>
                        <squad>Squad</squad>
                      </button>
                      <label>
                        <titleOption>Options</titleOption>
                        <login>Login</login>
                        <platform>Platforme</platform>
                        <apiKey>API Key</apiKey>
                        <apiKeyGenerate>Generate API Key</apiKeyGenerate>
                        <language>Language</language>
                        <lifeTimeStat>
                            <title>Life time stats</title>
                            <score>Score</score>
                            <matchsPlayed>Matches played</matchsPlayed>
                            <wins>Wins</wins>
                            <winPercentage>Wins %</winPercentage>
                            <kill>Kills</kill>
                            <killDeath>Kills / Death</killDeath>
                            <killMinute>Killes / Minute</killMinute>
                            <timePlayed>Time played</timePlayed>
                        </lifeTimeStat>

                        <stat>
                            <title>
                                <solo>Stats Solo</solo>
                                <duo>Stats Duo</duo>
                                <squad>Stats Squad</squad>
                            </title>
                            <score>Score</score>
                            <matchesPlayed>Matches played</matchesPlayed>
                            <top>
                            <top1>Top 1</top1>
                            <top5>Top 5</top5>
                            <top12>Top 12</top12>
                            <top3>Top 3</top3>
                            <top6>Top 6</top6>
                            <top10>Top 10</top10>
                            <top25>Top 25</top25>
                            </top>
                            <winRatio>Wins %</winRatio>
                            <kill>Kills</kill>
                            <killDeath>Kills / Death</killDeath>
                            <killMinute>Kills / Minute</killMinute>
                            <killGame>Kills / Game</killGame>
                            <timePlayed>Time played</timePlayed>
                        </stat>

                        <color>
                            <title>Colors</title>
                            <window>Window</window>
                            <button>Buttons</button>
                            <buttonHover>Buttons Hover</buttonHover>
                            <font>Font</font>
                        </color>

                      </label>
                    </language>";
            WriteXml(path, xml);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ecrit un fichier Langage xml sur le disque
        /// </summary>
        /// <param name="path">chemin du fichier</param>
        /// <param name="dataXml">data XML</param>
        private static void WriteXml(String path, String dataXml)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(dataXml);
            using (XmlTextWriter writer = new XmlTextWriter(path, null))
            {
                writer.Formatting = Formatting.Indented;
                doc.Save(writer);
            }
        }

    }
}
