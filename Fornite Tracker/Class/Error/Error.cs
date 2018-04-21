using Newtonsoft.Json;
using System;

namespace Fornite_Tracker
{
    public partial class Error
    {
        public String error { get; set; }
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Retourne une message d'erreur lors de la récupération de données sur l'API
        /// </summary>
        /// <param name="data">data JSON</param>
        /// <returns></returns>
        public static Error GetMessage(String data)
        {
            Error error = JsonConvert.DeserializeObject<Error>(data);
            return error;
        }


    }
}
