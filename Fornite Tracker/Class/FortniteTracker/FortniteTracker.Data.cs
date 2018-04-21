using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Fornite_Tracker
{
    public partial class FortniteTracker
    {

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupération d'un string sur l'api sous forme de JSON (async)
        /// </summary>
        /// <param name="platform">Nom de la plateform</param>
        /// <param name="login">Nom du joueur</param>
        /// <param name="apiKey">Clé API</param>
        /// <returns></returns>
        private async static Task<String> GetStat_Data(String platform, String login, String apiKey)
        {
            String url = "https://api.fortnitetracker.com/v1/profile/" + platform.ToLower() + "/" + login;
            String data = "";

            using (WebClient webClient = new WebClient())
            {
                webClient.Headers.Add("TRN-Api-Key", apiKey);
                data = await webClient.DownloadStringTaskAsync(url);
            }

            return data;
        }
    }
}
