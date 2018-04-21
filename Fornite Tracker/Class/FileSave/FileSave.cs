using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fornite_Tracker
{
    partial class FileSave
    {
        private FortniteTracker _fortniteTracker;
        private DateTime _dateTime;
        private String _path;

        /// <summary>
        /// Objet Fortnite tracker sauvegardé
        /// </summary>
        public FortniteTracker FortniteTracker
        {
            get
            {
                return _fortniteTracker;
            }

            set
            {
                _fortniteTracker = value;
            }
        }
        /// <summary>
        /// Date a laquelle le fichier a été crée
        /// </summary>
        public DateTime DateTime
        {
            get
            {
                return _dateTime;
            }

            set
            {
                _dateTime = value;
            }
        }
        /// <summary>
        /// Chemin du fichier
        /// </summary>
        public string Path
        {
            get
            {
                return _path;
            }

            set
            {
                _path = value;
            }
        }



        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération des stats sauvegardé depuis une date
        /// </summary>
        /// <param name="sinceDate"></param>
        /// <returns></returns>
        public async static Task<List<FileSave>> GetFileSavesAsync(DateTime sinceDate)
        {
            List<String> paths = GetPaths_Save();
            List<FileSave> fileSaves_All = await GetFileSaves();
            List<FileSave> fileSaves_New = new List<FileSave>();

            foreach (FileSave fileSave in fileSaves_All)
            {
                if (fileSave._dateTime.Date < sinceDate.Date) continue;

                fileSaves_New.Add(fileSave);
            }

            return fileSaves_New;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération de toutes les stats sauvegardés
        /// </summary>
        /// <returns></returns>
        public async static Task<List<FileSave>> GetFileSaves()
        {
            List<FileSave> fileSaves = new List<FileSave>();
            FileSave fileSave = new FileSave();
            List<String> paths = GetPaths_Save();

            foreach (String path in paths)
            {
                fileSave = new FileSave();
                fileSave._dateTime = File.GetLastWriteTime(path);
                fileSave._path = path;
                Object errorOrFortniteTracker = await GetStatSave(path);

                if (!(errorOrFortniteTracker is FortniteTracker)) continue;

                fileSave._fortniteTracker = errorOrFortniteTracker as FortniteTracker;
                fileSaves.Add(fileSave);
            }

            return fileSaves;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupère tous les fichiers .save dans le dossier
        /// </summary>
        /// <returns></returns>
        public static List<String> GetPaths_Save()
        {
            List<String> paths = new List<String>();

            paths = Directory.GetFiles(GetPathSave()).ToList();

            return paths;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupère sous forme de liste toutes les stats sauvegardées
        /// </summary>
        /// <returns></returns>
        public async static Task<List<FortniteTracker>> GetStats_SavesAsync()
        {
            List<FortniteTracker> fortniteTrackers = new List<FortniteTracker>();
            String data = "";

            foreach (String path in GetPaths_Save())
            {

                try
                {
                    using (StreamReader streamReader = new StreamReader(path))
                    {
                        data = await streamReader.ReadToEndAsync();
                        FortniteTracker fortniteTracker = JsonConvert.DeserializeObject<FortniteTracker>(data);
                        fortniteTrackers.Add(fortniteTracker);
                    }
                }
                catch (Exception)
                {
                    continue;
                }
            }

            return fortniteTrackers;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération de toute les infos du joueur depuis un fichier save
        /// Retourne null si ce n'est pas un objet Fortnite
        /// </summary>
        ///<param name="path">Chemin du fichier</param>
        /// <returns></returns>
        public async static Task<FortniteTracker> GetStatSave(String path)
        {
            //-------------------------
            //Récupération fichier json
            //-------------------------
            String data = null;
            FortniteTracker forniteTracker;
            try
            {
                using (StreamReader streamReader = new StreamReader(path))
                {
                    data = await streamReader.ReadToEndAsync();
                    forniteTracker = JsonConvert.DeserializeObject<FortniteTracker>(data);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return forniteTracker;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Sauvegarde les fichier json sur le DD, avec comme nom la Datetime
        /// </summary>
        /// <param name="fortniteTracker">Object FortniteTracker</param>
        public async static Task SaveFileAsync(FortniteTracker fortniteTracker)
        {
            String path = GetPathSave();

            path += "/" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".save";

            using (StreamWriter streamWriter = new StreamWriter(path, false))
            {
                String data = JsonConvert.SerializeObject(fortniteTracker);
                await streamWriter.WriteAsync(data);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération de la derniere sauvegarde de stat
        /// </summary>
        /// <returns></returns>
        public async static Task<FortniteTracker> GetStat_Last()
        {
            Boolean ok = false;
            FortniteTracker fortniteTracker = null;
            do
            {
                List<String> paths = Directory.GetFiles(GetPathSave()).ToList();

                if (paths == null || paths.Count < 1) return null;

                String pathLast = "";
                DateTime? dateTime = null;

                foreach (String path in paths)
                {
                    if (dateTime == null)
                    {
                        dateTime = File.GetLastWriteTime(path);
                        pathLast = path;
                    }

                    if (File.GetLastWriteTime(path) > dateTime)
                    {
                        dateTime = File.GetCreationTime(path);
                        pathLast = path;
                    }
                }

                String data = "";
                using (StreamReader streamReader = new StreamReader(pathLast))
                {
                    data = await streamReader.ReadToEndAsync();
                }

                try
                {
                    fortniteTracker = JsonConvert.DeserializeObject<FortniteTracker>(data);
                    ok = true;
                }
                catch (Exception)
                {
                    File.Delete(pathLast);
                    ok = false;
                }
            } while (!ok);

            return fortniteTracker;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération du dernier FileSave sauvegardé depuis une list
        /// </summary>
        /// <param name="fileSaves">List</param>
        /// <returns></returns>
        public static FileSave GetFileSave_Recent(List<FileSave> fileSaves)
        {
            DateTime? dateTime = null;
            FileSave fileSave_Last = new FileSave();
            foreach (FileSave fileSave in fileSaves)
            {
                if (dateTime == null)
                {
                    dateTime = fileSave._dateTime;
                    fileSave_Last = fileSave;
                    continue;
                }

                if (dateTime.Value < fileSave._dateTime)
                {
                    dateTime = fileSave._dateTime;
                    fileSave_Last = fileSave;
                }
            }

            return fileSave_Last;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération du preimier FileSave sauvegardé depuis une list
        /// </summary>
        /// <param name="fileSaves">List</param>
        /// <returns></returns>
        public static FileSave GetFileSave_Old(List<FileSave> fileSaves)
        {
            DateTime? dateTime = null;
            FileSave fileSave_Last = new FileSave();
            foreach (FileSave fileSave in fileSaves)
            {
                if (dateTime == null)
                {
                    dateTime = fileSave._dateTime;
                    fileSave_Last = fileSave;
                    continue;
                }

                if (dateTime.Value > fileSave._dateTime)
                {
                    dateTime = fileSave._dateTime;
                    fileSave_Last = fileSave;
                }
            }

            return fileSave_Last;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupère le chemin pour sauvegarder les fichier, si il n'existe pas il est crée
        /// </summary>
        /// <returns></returns>
        public static String GetPathSave()
        {
            String path = Application.StartupPath + @"\Save";
            Directory.CreateDirectory(path);

            return path;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un nouvel objet en calculant la différence entre 2 objet
        /// </summary>
        /// <param name="fileSave_Old">Objet le plus ancien</param>
        /// <param name="fileSave_Recent">Objet le plus récent</param>
        /// <returns></returns>
        /*public static void GetFileSave_Old_Recent(FileSave fileSave_Old, FileSave fileSave_Recent)
        {
            Fornite_Tracker.FortniteTracker fortniteTracker_Old = fileSave_Old._fortniteTracker;
            Fornite_Tracker.FortniteTracker fortniteTracker_Recent = fileSave_Recent._fortniteTracker;

            Fornite_Tracker.FortniteTracker fortniteTracker_New = new FortniteTracker();

            //------------
            //LifetimeStat
            //------------
            FortniteTracker.LifeTimeStat_Object lifeTimeStatObject_New = new FortniteTracker.LifeTimeStat_Object();
            FortniteTracker.LifeTimeStat_Object lifeTimeStatObject_Recent = fortniteTracker_Recent.lifeTimeStatObject;
            FortniteTracker.LifeTimeStat_Object lifeTimeStatObject_Old = fortniteTracker_Old.lifeTimeStatObject;

            lifeTimeStatObject_New.score = lifeTimeStatObject_Recent.score - lifeTimeStatObject_Old.score;
            lifeTimeStatObject_New.matchesPlayed = lifeTimeStatObject_Recent.matchesPlayed -
                                                   lifeTimeStatObject_Old.matchesPlayed;
            lifeTimeStatObject_New.wins = lifeTimeStatObject_Recent.wins - lifeTimeStatObject_Old.wins;

            Decimal winRatio = 0;
            if ((Decimal)lifeTimeStatObject_New.matchesPlayed != 0)
            {
                winRatio = (Decimal)lifeTimeStatObject_New.wins / (Decimal)lifeTimeStatObject_New.matchesPlayed * 100;
            }

            else
                winRatio = 0;
            lifeTimeStatObject_New.winPercentage = Math.Round(winRatio, 2).ToString();

            lifeTimeStatObject_New.kills = lifeTimeStatObject_Recent.kills - lifeTimeStatObject_Old.kills;

            Decimal killDeath = (Decimal)lifeTimeStatObject_New.kills / (Decimal)lifeTimeStatObject_New.matchesPlayed * 100;
            lifeTimeStatObject_New.killDeath = killDeath;

            //"1d 23h 26m "
            String date = "1d 23h 26m ";//lifeTimeStatObject_Recent.timePlayed.Replace(" ", "").Trim();
            String[] datas = date.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            Int32 day = 0;
            Int32 hour = 0;
            Int32 minute = 0;

            foreach (string data in datas)
            {
                if (data.Contains('d')) day = Int32.Parse(data.Replace("d", ""));
                if (data.Contains('h')) hour = Int32.Parse(data.Replace("h", ""));
                if (data.Contains('m')) minute = Int32.Parse(data.Replace("m", ""));
            }
        }*/
    }
}
