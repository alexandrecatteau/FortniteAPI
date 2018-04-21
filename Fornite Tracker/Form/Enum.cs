using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fornite_Tracker
{
    /// <summary>
    /// CHoix du boutton
    /// </summary>
    public enum EnumButton_Stat
    {
        //Solo
        Solo,
        /// <summary>
        /// Duo
        /// </summary>
        Duo,
        /// <summary>
        /// Squad
        /// </summary>
        Squad
    }

    /// <summary>
    /// Enumération pour les colonnes de la DGV
    /// </summary>
    public enum EnumColumnDGV
    {
        Date,
        GamesPlayed,
        Wins,
        WinRate,
        KillDeath
    }

    public enum EnumCmbDay
    {
        All,
        Days1,
        Days7,
        Days30
    }
}
