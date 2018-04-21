using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alex.Controls;

namespace Fornite_Tracker
{
    public partial class FormHistoric : Form
    {
        public FormHistoric()
        {
            InitializeComponent();
            InitializeForm();
            SetDatagridviewColumn();
            SetDatagridviewValue();
        }

        private async void SetDatagridviewValue()
        {
            List<FileSave> fileSaves = await FileSave.GetFileSaves();

            foreach (FileSave fileSave in fileSaves)
            {
                //-----------------------------------------------
                //Calcul du ratio pour avoir un chiffre à virgule
                //On vérifie que ce n'est pas égal a 0
                //-----------------------------------------------
                Decimal winRatio = fileSave.FortniteTracker.lifeTimeStatObject.wins == 0 ? 0 :
                                    Decimal.Parse(fileSave.FortniteTracker.lifeTimeStatObject.wins.ToString())
                                    /
                                    Decimal.Parse(fileSave.FortniteTracker.lifeTimeStatObject.matchesPlayed.ToString())
                                    *
                                    100;

                dgv.Rows.Add(new Object[]
                {
                    fileSave.DateTime,
                    fileSave.FortniteTracker.lifeTimeStatObject.matchesPlayed,
                    fileSave.FortniteTracker.lifeTimeStatObject.wins,
                    Math.Round(winRatio, 2) + "%",
                    fileSave.FortniteTracker.lifeTimeStatObject.killDeath,
                });
            }
            dgv.Sort(dgv.Columns[(Int32)EnumColumnDGV.Date], ListSortDirection.Descending);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation des controls
        /// </summary>
        private void InitializeForm()
        {
            FormInitialize.InitializeForm_Small(this);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DoubleBuffered(true);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Création des colonnes de la DGV
        /// </summary>
        private void SetDatagridviewColumn()
        {
            dgv.Columns.Add("date", "Date");
            dgv.Columns.Add("gamePlayed", "Parties jouées");
            dgv.Columns.Add("wins", "Victoire");
            dgv.Columns.Add("winRate", "% Victoire");
            dgv.Columns.Add("killDeath", "Elimination/Mort");

            dgv.Columns[(Int32)EnumColumnDGV.Date].ValueType = typeof(DateTime);
            dgv.Columns[(Int32)EnumColumnDGV.GamesPlayed].ValueType = typeof(Int32);
            dgv.Columns[(Int32)EnumColumnDGV.Wins].ValueType = typeof(Int32);
            dgv.Columns[(Int32)EnumColumnDGV.WinRate].ValueType = typeof(Int32);
            dgv.Columns[(Int32)EnumColumnDGV.KillDeath].ValueType = typeof(Decimal);
        }
    }
}
