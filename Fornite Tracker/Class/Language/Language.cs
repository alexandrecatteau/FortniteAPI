using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornite_Tracker
{
    public partial class Language
    {
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Récupère l'énumération correspondante à partir d'un int
        /// </summary>
        /// <param name="language">Int du langage 0 : FR, 1 : EN</param>
        /// <returns></returns>
        public static EnumLanguage GetEnum(Int32 language)
        {
            if (language == 0) return EnumLanguage.EN;
            else return EnumLanguage.FR;
        }
    }
}
