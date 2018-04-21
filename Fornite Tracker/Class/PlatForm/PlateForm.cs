using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornite_Tracker
{

    public partial class PlateForm
    {
        /// <summary>
        /// Tableau avec le nom des plateforms
        /// </summary>
        private static ArrayList _platforms = new ArrayList { "PC", "PS4", "XBOX1"};
        /// <summary>
        /// Tableau avec le nom des plateforms pour la connexion à l'API
        /// </summary>
        public static ArrayList Platforms_Api = new ArrayList { "pc", "psn", "xbl" };
        /// <summary>
        /// Tableau avec le nom des plateforms
        /// </summary>
        public static ArrayList Platforms
        {
            get
            {
                return _platforms;
            }

            set
            {
                _platforms = value;
            }
        }
    }
}
