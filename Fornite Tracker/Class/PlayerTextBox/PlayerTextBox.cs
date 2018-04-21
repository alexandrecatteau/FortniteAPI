using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fornite_Tracker
{
    partial class PlayerTextBox
    {
        private String _namePlayer;
        private DateTime _date;

        private String _directoryPath = Application.StartupPath + "/Players";
        private String _filePath = Application.StartupPath + "/Players/Players.txt";

        /// <summary>
        /// Nom du joueur
        /// </summary>
        public string NamePlayer
        {
            get
            {
                return _namePlayer;
            }

            set
            {
                _namePlayer = value;
            }
        }
        /// <summary>
        /// Date à laquelle on a fait la derniere recherche sur le joueur
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }

            set
            {
                _date = value;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération du chemin avec tous les pseudo deja tapé
        /// si le dossier n'existe pas on le crée
        /// </summary>
        /// <returns></returns>
        public static String GetPath()
        {
            return new PlayerTextBox()._filePath;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ajout d'un nouveau joueur dans un fichier texte Async
        /// </summary>
        /// <param name="playerTextBox"></param>
        public async static void WritePlayerTextBox(PlayerTextBox playerTextBox)
        {
            if (!IsPathExist(GetPath())) WriteNewPlayerTextBox();

            using (StreamWriter streamWriter = new StreamWriter(GetPath(), true))
            {
                await streamWriter.WriteLineAsync(playerTextBox.NamePlayer + "->" + playerTextBox.Date.ToString("s"));
            }

        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération des données dans le fichier texte
        /// trier par date sans doublons de pseudo
        /// </summary>
        /// <returns>null si le fichier n'existe pas</returns>
        public static List<PlayerTextBox> GetPlayerTextBoxs()
        {
            if (!IsPathExist(GetPath()))
            {
                WriteNewPlayerTextBox();
                return null;
            }

            List<PlayerTextBox> playerTextBoxs = new List<PlayerTextBox>();
            PlayerTextBox playerTextBox;

            using (StreamReader streamReader = new StreamReader(GetPath()))
            {
                while (!streamReader.EndOfStream)
                {
                    playerTextBox = new PlayerTextBox();

                    String line = streamReader.ReadLine();
                    String[] datas = line.Split(new string[] { "->" }, StringSplitOptions.None);

                    playerTextBox._namePlayer = datas[(Int32)EnumPlayerTextBox.PlayerLogin];
                    playerTextBox._date = DateTime.Parse(datas[(Int32)EnumPlayerTextBox.Date]);

                    playerTextBoxs.Add(playerTextBox);
                }
            }

            playerTextBoxs.Reverse();

            playerTextBoxs =
                (from p in playerTextBoxs
                 group p by p._namePlayer
                 into g
                 select g.First()).ToList();

            return playerTextBoxs;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ecriture d'un nouveau fichier
        /// </summary>
        public static void WriteNewPlayerTextBox()
        {
            Directory.CreateDirectory(new PlayerTextBox()._directoryPath);

            using (StreamWriter streamWriter = new StreamWriter(GetPath(), true))
            {

            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Vérification que le chemin existe
        /// </summary>
        /// <param name="path">Chemin du fichier</param>
        /// <returns></returns>
        public static Boolean IsPathExist(String path)
        {
            if (File.Exists(path)) return true;

            return false;
        }
    }
}
