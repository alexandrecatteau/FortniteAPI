using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mime;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Fornite_Tracker
{
    public partial class FortniteTracker
    {
        /// <summary>
        /// Id du compte
        /// </summary>
        public string accountId { get; set; }
        /// <summary>
        /// id de la platform
        /// </summary>
        public int platformId { get; set; }
        /// <summary>
        /// nom de la platform
        /// </summary>
        public string platformName { get; set; }
        /// <summary>
        /// nom long de la plateform
        /// </summary>
        public string platformNameLong { get; set; }
        /// <summary>
        /// Pseudo sur le jeu
        /// </summary>
        public string epicUserHandle { get; set; }
        /// <summary>
        /// Stat dans le jeux
        /// </summary>
        public Stats stats { get; set; }
        /// <summary>
        /// Stat sous forme de tableau
        /// </summary>
        public List<LifeTimeStat> lifeTimeStats { get; set; }
        /// <summary>
        /// Stat sous form d'objet
        /// </summary>
        public LifeTimeStat_Object lifeTimeStatObject { get; set; }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération de toute les infos du joueur par défaut si on n'y arrive pas objet ERROR
        /// </summary>
        /// <param name="config">config du logiciel</param>
        /// <returns></returns>
        public async static Task<Object> GetStat(Config config)
        {
            //-------------------------
            //Récupération fichier json
            //-------------------------
            String data = await GetStat_Data(PlateForm.Platforms_Api[Int32.Parse(config.Platform)].ToString(), config.Login, config.ApiKey);
            Console.WriteLine(data);

            //------------------------------
            //Création objet FortniteTracker
            //------------------------------
            FortniteTracker fortniteTracker = JsonConvert.DeserializeObject<FortniteTracker>(data);

            //---------------------------------------------------------------
            //Vérification si des données son disponible sinon message erreur
            //---------------------------------------------------------------
            if (fortniteTracker.lifeTimeStats == null || fortniteTracker.lifeTimeStats.Count < 1) return Error.GetMessage(data);


            fortniteTracker.lifeTimeStatObject = GetLifeTimeStat_Object(fortniteTracker);
            return fortniteTracker;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un objet LifeTimeStat_Object pour ajouter dans objet FortniteTracker
        /// </summary>
        /// <param name="fortniteTracker"></param>
        /// <returns></returns>
        private static LifeTimeStat_Object GetLifeTimeStat_Object(FortniteTracker fortniteTracker)
        {
            //-------------------------
            //Objet LifeTimeStat_Object
            //-------------------------
            LifeTimeStat_Object lifeTimeStatObject = new LifeTimeStat_Object();

            foreach (LifeTimeStat lifeTimeStat in fortniteTracker.lifeTimeStats)
            {
                switch (lifeTimeStat.key)
                {
                    case "Top 10s":
                        lifeTimeStatObject.top10 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Top 5s":
                        lifeTimeStatObject.top5 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Top 3s":
                        lifeTimeStatObject.top3 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Top 6s":
                        lifeTimeStatObject.top6 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Top 12s":
                        lifeTimeStatObject.top12 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Top 25s":
                        lifeTimeStatObject.top25 = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Score":
                        lifeTimeStatObject.score = Decimal.Parse(lifeTimeStat.value.Replace('.', ','));
                        break;
                    case "Matches Played":
                        lifeTimeStatObject.matchesPlayed = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Wins":
                        lifeTimeStatObject.wins = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "Win%":
                        lifeTimeStatObject.winPercentage = lifeTimeStat.value;
                        break;
                    case "Kills":
                        lifeTimeStatObject.kills = Int32.Parse(lifeTimeStat.value);
                        break;
                    case "K/d":
                        lifeTimeStatObject.killDeath = Decimal.Parse(lifeTimeStat.value.Replace('.', ','));
                        break;
                    case "Kills Per Min":
                        lifeTimeStatObject.killPerMin = Decimal.Parse(lifeTimeStat.value.Replace('.', ','));
                        break;
                    case "Time Played":
                        lifeTimeStatObject.timePlayed = lifeTimeStat.value;
                        break;
                    default:
                        break;
                }
            }

            return lifeTimeStatObject;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un Objet FortniteTracker si possible sinon objet Error
        /// </summary>
        /// <param name="config">Objet config</param>
        /// <param name="login">Login a rechercher</param>
        /// <param name="platFormAPI">soit : pc, psn, xbl</param>
        /// <returns></returns>
        public async static Task<Object> GetStatAsync(Config config, String login, String platFormAPI)
        {
            //-------------------------
            //Récupération fichier json
            //-------------------------
            String data = await GetStat_Data(platFormAPI, login, config.ApiKey);

            //------------------------------
            //Création objet FortniteTracker
            //------------------------------
            FortniteTracker fortniteTracker = JsonConvert.DeserializeObject<FortniteTracker>(data);

            //---------------------------------------------------------------
            //Vérification si des données son disponible sinon message erreur
            //---------------------------------------------------------------
            if (fortniteTracker.lifeTimeStats == null || fortniteTracker.lifeTimeStats.Count < 1) return Error.GetMessage(data);

            fortniteTracker.lifeTimeStatObject = GetLifeTimeStat_Object(fortniteTracker);

            return fortniteTracker;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'une chaine de caractere avec le temps de jeu sous forme "01d 01h 01m"
        /// change selon la langue choisi dans config
        /// </summary>
        /// <param name="timeSpan">objet timeSpan ou on été mis les minutes</param>
        /// <param name="config">Objet Config</param>
        /// <returns></returns>
        public static String GetString_MinutePlayed(TimeSpan timeSpan, Config config)
        {
            String time = timeSpan.Days.ToString() + "d " + timeSpan.Hours.ToString() + "h " +
                          timeSpan.Minutes.ToString() + "m";

            if (Language.GetEnum(Int32.Parse(config.Language)) == EnumLanguage.FR) time = time.Replace('d', 'j');

            return time;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'une chaine de caractere avec le temps de jeu sous forme "01d 01h 01m"
        /// change selon la langue choisi dans config
        /// </summary>
        /// <param name="time">Chaine de caractere sous forme "01d 01h 01m"</param>
        /// <param name="config">Objet Config</param>
        /// <returns></returns>
        public static String GetString_MinutePlayed(String time, Config config)
        {
            if (Language.GetEnum(Int32.Parse(config.Language)) == EnumLanguage.FR) time = time.Replace('d', 'j');

            return time;
        }
        
        #region CLASS API JSON
        public class Score
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top1
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top5
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top6
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top10
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top12
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top25
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kd
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class WinRatio
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Matches
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kills
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class MinutesPlayed
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpm
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpg
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class P2
        {
            public Score score { get; set; }
            public Top1 top1 { get; set; }
            public Top3 top3 { get; set; }
            public Top5 top5 { get; set; }
            public Top6 top6 { get; set; }
            public Top10 top10 { get; set; }
            public Top12 top12 { get; set; }
            public Top25 top25 { get; set; }
            public Kd kd { get; set; }
            public WinRatio winRatio { get; set; }
            public Matches matches { get; set; }
            public Kills kills { get; set; }
            public MinutesPlayed minutesPlayed { get; set; }
            public Kpm kpm { get; set; }
            public Kpg kpg { get; set; }
        }

        public class Score2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top13
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top32
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top52
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top62
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top102
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top122
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top252
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Kd2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Matches2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kills2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class MinutesPlayed2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpm2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpg2
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class P10
        {
            public Score2 score { get; set; }
            public Top13 top1 { get; set; }
            public Top32 top3 { get; set; }
            public Top52 top5 { get; set; }
            public Top62 top6 { get; set; }
            public Top102 top10 { get; set; }
            public Top122 top12 { get; set; }
            public Top252 top25 { get; set; }
            public Kd2 kd { get; set; }
            public Matches2 matches { get; set; }
            public Kills2 kills { get; set; }
            public MinutesPlayed2 minutesPlayed { get; set; }
            public Kpm2 kpm { get; set; }
            public Kpg2 kpg { get; set; }
        }

        public class Score3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top14
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top33
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top53
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top63
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Top103
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top123
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Top253
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public string displayValue { get; set; }
        }

        public class Kd3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Matches3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kills3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class MinutesPlayed3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public int valueInt { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpm3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class Kpg3
        {
            public string label { get; set; }
            public string field { get; set; }
            public string category { get; set; }
            public double valueDec { get; set; }
            public string value { get; set; }
            public int rank { get; set; }
            public double percentile { get; set; }
            public string displayValue { get; set; }
        }

        public class P9
        {
            public Score3 score { get; set; }
            public Top14 top1 { get; set; }
            public Top33 top3 { get; set; }
            public Top53 top5 { get; set; }
            public Top63 top6 { get; set; }
            public Top103 top10 { get; set; }
            public Top123 top12 { get; set; }
            public Top253 top25 { get; set; }
            public Kd3 kd { get; set; }
            public Matches3 matches { get; set; }
            public Kills3 kills { get; set; }
            public MinutesPlayed3 minutesPlayed { get; set; }
            public Kpm3 kpm { get; set; }
            public Kpg3 kpg { get; set; }
        }

        public class Stats
        {
            public P2 p2 { get; set; }
            public P10 p10 { get; set; }
            public P9 p9 { get; set; }
        }

        public class LifeTimeStat_Object
        {
            public int top10 { get; set; }
            public int top5 { get; set; }
            public int top3 { get; set; }
            public int top6 { get; set; }
            public int top12 { get; set; }
            public int top25 { get; set; }
            public decimal score { get; set; }
            public int matchesPlayed { get; set; }
            public int wins { get; set; }
            public string winPercentage { get; set; }
            public int kills { get; set; }
            public decimal killDeath { get; set; }
            public decimal killPerMin { get; set; }
            public String timePlayed { get; set; }

        }

        public class LifeTimeStat
        {
            public string key { get; set; }
            public string value { get; set; }
        }

        #endregion
    }
}
