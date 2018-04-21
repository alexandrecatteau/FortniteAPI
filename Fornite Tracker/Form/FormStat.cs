using Custom_Button;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Alex.Controls;

namespace Fornite_Tracker
{
    public partial class FormStat : Form
    {
        /// <summary>
        /// Objet config
        /// </summary>
        private Config _config = Config.GetConfig();
        /// <summary>
        /// Objet selon la langue choisi
        /// </summary>
        private Translation _translation = null;
        /// <summary>
        /// Enum qui change en fonction du click sur un bouton
        /// </summary>
        private EnumButton_Stat _enumButtonStat = EnumButton_Stat.Solo;
        /// <summary>
        /// Enum qui change en fonction de l'item choisi dans la cmbDay
        /// </summary>
        private EnumCmbDay _enumCmbDay = EnumCmbDay.All;
        /// <summary>
        /// Objet ou est enregistré les stat du joueur dans Config ou par la recherche
        /// </summary>
        private FortniteTracker _fortniteTracker;
        /// <summary>
        /// Délégué pour mettre les données a jout en Async
        /// </summary>
        private delegate void DelegateSetFormAsync();
        /// <summary>
        /// Permet de désactiver ou d'activer un le bouton rechercher
        /// </summary>
        /// <param name="isEnable"></param>
        private delegate void DelegateButtonEnable(Object button, Boolean isEnable);
        /// <summary>
        /// Permet de charger les données toutes les 3 minutes
        /// </summary>
        private DateTime? _in3Minutes = null;
        /// <summary>
        /// Permet de savoir si on est sur un autre joueur pour les stats,
        /// pr éviter d'afficher les données de config
        /// </summary>
        private Boolean _isOtherPlayer = false;
        /// <summary>
        /// Item a ajouter dans la cmb time
        /// </summary>
        private ArrayList _cmbTime_Items = new ArrayList(new String[] { "Tous", "1 jours", "7 jours", "30 jour" });

        public FormStat()
        {
            InitializeComponent();
            SetPictureBoxLoading_Position();
            SetVisibleComponent(false);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage de la txtSearch avec les dernieres recherches
        /// </summary>
        private void SetAutoCompleteTxt()
        {
            List<PlayerTextBox> playerTextBoxs = PlayerTextBox.GetPlayerTextBoxs();

            //----------------------------------------------------
            //Vérification qu'il y a bien des éléments a récupérer
            //----------------------------------------------------
            if (playerTextBoxs == null) return;

            String[] s = playerTextBoxs.Select(e => (String)e.NamePlayer).ToArray();

            AutoCompleteStringCollection autoCompleteStringCollection = new AutoCompleteStringCollection();
            autoCompleteStringCollection.AddRange(s);
            txtPlayerName.AutoCompleteCustomSource = autoCompleteStringCollection;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Position de l'image de chargement
        /// </summary>
        private void SetPictureBoxLoading_Position()
        {
            FormInitialize.InitializeForm_Small(this);
            pnlLoading.Dock = DockStyle.Fill;
            picLoading.Top = pnlLoading.Height / 2 - picLoading.Height / 2;
            picLoading.Left = pnlLoading.Width / 2 - picLoading.Width / 2;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Modifie la visibilité de tous les control de la form
        /// la fenetre de chargement est visible si les autres son cachés
        /// </summary>
        /// <param name="isVisible">true : les composants son visible sauf le panel de chargement</param>
        private void SetVisibleComponent(Boolean isVisible)
        {
            pnlLoading.Visible = !isVisible;
            pnlLine.Visible = isVisible;
            foreach (Control control in this.Controls)
            {
                if (control.Name == "pnlLoading") continue;
                control.Visible = isVisible;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage des différents controls depuis _translation
        /// </summary>
        private void SetStat_Text()
        {
            //------------------
            //Initialisation btn
            //------------------
            btnSolo.Text = _translation.ButtonText.Solo;
            btnDuo.Text = _translation.ButtonText.Duo;
            btnSquad.Text = _translation.ButtonText.Squad;
            btnSearch.Text = _translation.ButtonText.Search;

            //------------------
            //Initialisation cmb
            //------------------
            //CmbPlatform
            //-----------
            ArrayList platforms = PlateForm.Platforms;
            for (int index = 0; index < platforms.Count; index++)
                cmbPlayer_Platform.Items.Add(new ItemData(index, platforms[index].ToString()));

            foreach (ItemData itemData in cmbPlayer_Platform.Items)
                if (((Int32)itemData.Item).ToString() == _config.Platform) cmbPlayer_Platform.SelectedItem = itemData;



            //----
            //Stat
            //----
            lblStat_Score.Text = _translation.LabelText.Stat.Score;
            lblStat_Matches.Text = _translation.LabelText.Stat.MatchesPlayed;
            lblStat_WinRatio.Text = _translation.LabelText.Stat.WinRatio;
            lblStat_Kill.Text = _translation.LabelText.Stat.Kill;
            lblStat_KillDeath.Text = _translation.LabelText.Stat.KillDeath;
            lblStat_KillMinute.Text = _translation.LabelText.Stat.KillMinute;
            lblStat_KillGame.Text = _translation.LabelText.Stat.KillGame;
            lblStat_TimePlayed.Text = _translation.LabelText.Stat.TimePlayed;

            //-------------
            //Lifetime Stat
            //-------------
            lblTitle_LifeTimeStat.Text = _translation.LabelText.LifeTimeStat.Title;
            lblLifeTimeStat_Score.Text = _translation.LabelText.LifeTimeStat.Score;
            lblLifeTimeStat_MatchesPlayed.Text = _translation.LabelText.LifeTimeStat.MatchsPlayed;
            lblLifeTimeStat_Wins.Text = _translation.LabelText.LifeTimeStat.Wins;
            lblLifeTimeStat_WinsPercentage.Text = _translation.LabelText.LifeTimeStat.WinPercentage;
            lblLifeTimeStat_Kills.Text = _translation.LabelText.LifeTimeStat.Kill;
            lblLifeTimeStat_KillDeath.Text = _translation.LabelText.LifeTimeStat.KillDeath;
            lblLifeTimeStat_KillMinute.Text = _translation.LabelText.LifeTimeStat.KillMinute;
            lblLifeTimeStat_TimePlayed.Text = _translation.LabelText.LifeTimeStat.TimePlayed;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplissage des texte selon la langue choisie
        /// </summary>
        /// <param name="translation"></param>
        private void SetStatSoloDuoSquad(FortniteTracker fortniteTracker)
        {
            switch (_enumButtonStat)
            {
                case EnumButton_Stat.Solo:
                    lblStat_Title.Text = _translation.LabelText.Stat.Title.Solo;
                    lblStat_Top1.Text = _translation.LabelText.Stat.Top.Top1;
                    lblStat_Top10.Text = _translation.LabelText.Stat.Top.Top10;
                    lblStat_Top25.Text = _translation.LabelText.Stat.Top.Top25;
                    SetStat_Solo(fortniteTracker);
                    break;

                case EnumButton_Stat.Duo:
                    lblStat_Title.Text = _translation.LabelText.Stat.Title.Duo;
                    lblStat_Top1.Text = _translation.LabelText.Stat.Top.Top1;
                    lblStat_Top10.Text = _translation.LabelText.Stat.Top.Top6;
                    lblStat_Top25.Text = _translation.LabelText.Stat.Top.Top12;
                    SetStat_Duo(fortniteTracker);
                    break;

                case EnumButton_Stat.Squad:
                    lblStat_Title.Text = _translation.LabelText.Stat.Title.Squad;
                    lblStat_Top1.Text = _translation.LabelText.Stat.Top.Top1;
                    lblStat_Top10.Text = _translation.LabelText.Stat.Top.Top3;
                    lblStat_Top25.Text = _translation.LabelText.Stat.Top.Top6;
                    SetStat_Squad(fortniteTracker);
                    break;
                default:
                    break;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Initialisation de la form
        /// </summary>
        private void InitializeForm()
        {
            //----------------------------
            //Initialisation de la fenetre
            //----------------------------
            FormInitialize.InitializeForm_Small(this);

            //------------------------
            //Font de tous les control
            //------------------------
            foreach (Control control in this.Controls)
                FormInitialize.InitializeControl(control);

            List<Label> labels = new List<Label>();

            foreach (Control control in this.Controls)
                if (control is Label) labels.Add(control as Label);

            FormInitialize.ForeColor_Label(labels);
            FormInitialize.InitializeLabel(lblTitle_LifeTimeStat, 40f);
            FormInitialize.InitializeLabel(lblStat_Title, 40f);
            FormInitialize.InitializeLabel(lblPlayerName, 30f);
            FormInitialize.InitializeBtn(new List<_Button> { btnSolo, btnDuo, btnSquad }, 70f, true);
            FormInitialize.InitializeBtn(new List<_Button> { btnSearch, btnReset }, 20f, false);
            FormInitialize.InitializeBtn(new List<_Button> { btnOption, btnHistoric }, 30f, true);
            FormInitialize.InitializeCmb(new List<_ComboBox> { cmbPlayer_Platform });


            //---------------------------------------
            //Placement des boutons et du label timer 
            //a la meme hauteur que la txt 
            //---------------------------------------
            btnSearch.Height = txtPlayerName.Height + 4;
            btnSearch.Top = txtPlayerName.Top + txtPlayerName.Height + 2;

            btnReset.Height = txtPlayerName.Height + 4;
            btnReset.Top = txtPlayerName.Top + txtPlayerName.Height + 2;

            lblTimer_Value.Height = txtPlayerName.Height;
            lblTimer_Value.Top = txtPlayerName.Top + 2;

            lblTimer_Text.Height = txtPlayerName.Height;
            lblTimer_Text.Top = txtPlayerName.Top + 2;

            Padding padding = new Padding(0, 4, 0, 0);
            btnSearch.Padding = padding;
            btnReset.Padding = padding;

            //-------------------
            //Panel de séparation
            //-------------------
            FormInitialize.SetPanel_BackGround(pnlLine);
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rafraichissement des données
        /// </summary>
        private async Task RefreshStatAsync()
        {
            Object errorOrFortniteTracker = null;
            Error error = new Error();
            FortniteTracker fortniteTracker = new FortniteTracker();

            //--------------------------------------------------
            //On recommence tant qu'on ne récupère rien de l'api
            //--------------------------------------------------
            do
            {
                //----------------------------------------------------------------------
                //On essaie de récupérer un objet qui peut etre Error ou FortniteTracker
                //----------------------------------------------------------------------
                try
                {
                    errorOrFortniteTracker = await FortniteTracker.GetStat(Config.GetConfig());
                }
                catch (Exception e)
                {
                    //Si erreur lors de la récupération de l'objet message d'erreur
                    //et ouverture de la fenetre option
                    //-------------------------------------------------------------
                    MessageBox.Show("Impossible de contacter le serveur. Merci de vérifier le nom d'utilisateur, la plateform ou la clé API"
                         + Environment.NewLine + e.Message);

                    DialogResult dialogResult = new FormOption().ShowDialog();

                    if (dialogResult != DialogResult.OK) Application.Exit();

                    _config = Config.GetConfig();
                }

                //Si erreur on affiche un message d'erreur
                //ET FormOption
                //----------------------------------------
                if (errorOrFortniteTracker is Error)
                {
                    error = errorOrFortniteTracker as Error;

                    MessageBox.Show(error.error);

                    DialogResult dialogResult = new FormOption().ShowDialog();

                    if (dialogResult != DialogResult.OK) Application.Exit();
                    _config = Config.GetConfig();
                }
            } while ((errorOrFortniteTracker == null) || (errorOrFortniteTracker is Error));



            //----------------------------
            //On vérifie l'objet récupérer
            //----------------------------

            //Sinon on rempli
            //---------------
            if (errorOrFortniteTracker is FortniteTracker)
            {
                fortniteTracker = errorOrFortniteTracker as FortniteTracker;
                _fortniteTracker = fortniteTracker;
                SetLifeTimeStat_Value(fortniteTracker);
                SetStatSoloDuoSquad(fortniteTracker);

                await WriteNewFileStatAsync();
            }

            //Si autre que error ou fortnite tracker return null
            //--------------------------------------------------
            else
                _fortniteTracker = null;
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Remplie les données LifeTimeStat
        /// </summary>
        /// <param name="fortniteTracker">Objet fortnite</param>
        private void SetLifeTimeStat_Value(FortniteTracker fortniteTracker)
        {
            lblLifeTimeStat_Score_Value.Text = fortniteTracker.lifeTimeStatObject.score.ToString();
            lblLifeTimeStat_MatchesPlayed_Value.Text = fortniteTracker.lifeTimeStatObject.matchesPlayed.ToString();
            lblLifeTimeStat_Wins_Value.Text = fortniteTracker.lifeTimeStatObject.wins.ToString();
            lblLifeTimeStat_WinsPercentage_Value.Text = fortniteTracker.lifeTimeStatObject.winPercentage;
            lblLifeTimeStat_Kills_Value.Text = fortniteTracker.lifeTimeStatObject.kills.ToString();
            lblLifeTimeStat_KillDeath_Value.Text = fortniteTracker.lifeTimeStatObject.killDeath.ToString();
            lblLifeTimeStat_KillMinute_Value.Text = fortniteTracker.lifeTimeStatObject.killPerMin.ToString();
            lblLifeTimeStat_TimePlayed_Value.Text =
                FortniteTracker.GetString_MinutePlayed(fortniteTracker.lifeTimeStatObject.timePlayed, _config);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Bouton chercher
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnSearch_Click(object sender, EventArgs e)
        {
            _isOtherPlayer = true;
            SetAutoCompleteTxt();


            //-------------------------------------------
            //On cache le délais de maj pour éviter de 
            //tromper le client sur les stats sauvegardé
            //-----------------------------------------
            if (txtPlayerName.Text.ToLower() != _config.Login.ToLower())
            {
                lblTimer_Value.Visible = false;
                lblTimer_Text.Visible = false;
            }
            else _in3Minutes = null;

            //------------------------------------------------------------------------------------
            //Thread qui va bloquer le bouton chercher pdt 2 sec pour pas avoir d'erreur sur l'api
            //------------------------------------------------------------------------------------
            Thread thread = new Thread(new ThreadStart(SetButtonEnable_2Sec));
            thread.IsBackground = true;
            thread.Start();

            //-------------------------------------------
            //Ajout du pseudo entré dans un fichier texte
            //en Async
            //-------------------------------------------
            PlayerTextBox playerTextBox = new PlayerTextBox();
            playerTextBox.NamePlayer = txtPlayerName.Text.Trim();
            playerTextBox.Date = DateTime.Now;
            PlayerTextBox.WritePlayerTextBox(playerTextBox);


            String platform =
                PlateForm.Platforms_Api[(Int32)((ItemData)cmbPlayer_Platform.SelectedItem).Item].ToString();

            Object errorOrFortniteTracker = null;

            //----------------------------------------------------------------------
            //On essaie de récupérer un objet qui peut etre Error ou FortniteTracker
            //----------------------------------------------------------------------
            try
            {
                errorOrFortniteTracker = await FortniteTracker.GetStatAsync(_config, txtPlayerName.Text.Trim(), platform);
            }
            catch (Exception ex)
            {
                //Si erreur lors de la récupération de l'objet message d'erreur
                //et ouverture de la fenetre option
                //-------------------------------------------------------------
                MessageBox.Show("Impossible de contacter le serveur. Merci de vérifier le nom d'utilisateur, la plateform ou la clé API"
                     + Environment.NewLine + ex.Message);
            }


            Error error = new Error();
            FortniteTracker fortniteTracker = new FortniteTracker();

            //----------------------------
            //On vérifie l'objet récupérer
            //----------------------------

            //Si erreur on affiche un message d'erreur
            //----------------------------------------
            if (errorOrFortniteTracker is Error)
            {
                error = errorOrFortniteTracker as Error;

                MessageBox.Show(error.error);
            }

            //Sinon on rempli
            //---------------
            if (errorOrFortniteTracker is FortniteTracker)
            {
                _enumButtonStat = EnumButton_Stat.Solo;
                fortniteTracker = errorOrFortniteTracker as FortniteTracker;
                _fortniteTracker = fortniteTracker;
                SetLifeTimeStat_Value(fortniteTracker);
                SetStat_Text();
                SetStatSoloDuoSquad(fortniteTracker);
                lblPlayerName.Text = "Stats de " + txtPlayerName.Text;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Désactive le btnSearch pdt 2 secondes
        /// </summary>
        private async void SetButtonEnable_2Sec()
        {
            //------------------------------------------------
            //Vérification que la fenetre est toujours affiché
            //------------------------------------------------
            if (this.IsHandleCreated == false) return;

            DelegateButtonEnable delegateButtonEnable = new DelegateButtonEnable(BtnEnable);

            //----------------------------
            //On désactive le boutonSearch
            //----------------------------
            Invoke(delegateButtonEnable, btnSearch, false);
            Invoke(delegateButtonEnable, btnReset, false);

            //---------------------
            //On attends x secondes
            //---------------------
            await Task.Delay(2000);

            //------------------------------------------------
            //Vérification que la fenetre est toujours affiché
            //------------------------------------------------
            if (this.IsHandleCreated == false) return;

            //---------------------
            //On réactive le bouton
            //---------------------
            Invoke(delegateButtonEnable, btnSearch, true);
            Invoke(delegateButtonEnable, btnReset, true);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Active ou désactive le bouton search
        /// </summary>
        /// <param name="isEnable">true : btn activé</param>
        /// <param name="button">bouton a modifier</param>
        private void BtnEnable(Object button, Boolean isEnable)
        {
            (button as _Button).Enabled = isEnable;
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Btn solo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSolo_Click(object sender, EventArgs e)
        {
            _enumButtonStat = EnumButton_Stat.Solo;
            SetStat_Text();
            SetStatSoloDuoSquad(_fortniteTracker);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Btn duo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDuo_Click(object sender, EventArgs e)
        {
            _enumButtonStat = EnumButton_Stat.Duo;
            SetStat_Text();
            SetStatSoloDuoSquad(_fortniteTracker);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// btn squad
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSquad_Click(object sender, EventArgs e)
        {
            _enumButtonStat = EnumButton_Stat.Squad;
            SetStat_Text();
            SetStatSoloDuoSquad(_fortniteTracker);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rafraichissement des données si duo choisi
        /// </summary>
        /// <param name="fortniteTracker">Objet FortniteTracker</param>
        private void SetStat_Duo(FortniteTracker fortniteTracker)
        {
            Double winRatio = (Double)fortniteTracker.stats.p10.top1.valueInt / (Double)fortniteTracker.stats.p10.matches.valueInt * 100;

            lblStat_Score_Value.Text = fortniteTracker.stats.p10.score.valueInt.ToString();
            lblStat_Matches_Value.Text = fortniteTracker.stats.p10.matches.valueInt.ToString();
            lblStat_Top1_Value.Text = fortniteTracker.stats.p10.top1.valueInt.ToString();
            lblStat_Top10_Value.Text = fortniteTracker.stats.p10.top5.valueInt.ToString();
            lblStat_Top25_Value.Text = fortniteTracker.stats.p10.top12.valueInt.ToString();
            lblStat_WinRatio_Value.Text = Math.Round(winRatio, 2).ToString() + "%";
            lblStat_Kill_Value.Text = fortniteTracker.stats.p10.kills.valueInt.ToString();
            lblStat_KillDeath_Value.Text = fortniteTracker.stats.p10.kd.valueDec.ToString();
            lblStat_KillMinute_Value.Text = fortniteTracker.stats.p10.kpm.valueDec.ToString();
            lblStat_KillGame_Value.Text = fortniteTracker.stats.p10.kpg.valueDec.ToString();

            TimeSpan timeSpan = TimeSpan.FromMinutes(fortniteTracker.stats.p10.minutesPlayed.valueInt);
            lblStat_TimePlayed_Value.Text = FortniteTracker.GetString_MinutePlayed(timeSpan, _config);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rafraichissement des données si squad choisi
        /// </summary>
        /// <param name="fortniteTracker">Objet FortniteTracker</param>
        private void SetStat_Squad(FortniteTracker fortniteTracker)
        {
            Double winRatio = (Double)fortniteTracker.stats.p9.top1.valueInt / (Double)fortniteTracker.stats.p9.matches.valueInt * 100;

            lblStat_Score_Value.Text = fortniteTracker.stats.p9.score.valueInt.ToString();
            lblStat_Matches_Value.Text = fortniteTracker.stats.p9.matches.valueInt.ToString();
            lblStat_Top1_Value.Text = fortniteTracker.stats.p9.top1.valueInt.ToString();
            lblStat_Top10_Value.Text = fortniteTracker.stats.p9.top3.valueInt.ToString();
            lblStat_Top25_Value.Text = fortniteTracker.stats.p9.top6.valueInt.ToString();
            lblStat_WinRatio_Value.Text = Math.Round(winRatio, 2).ToString() + "%";
            lblStat_Kill_Value.Text = fortniteTracker.stats.p9.kills.valueInt.ToString();
            lblStat_KillDeath_Value.Text = fortniteTracker.stats.p9.kd.valueDec.ToString();
            lblStat_KillMinute_Value.Text = fortniteTracker.stats.p9.kpm.valueDec.ToString();
            lblStat_KillGame_Value.Text = fortniteTracker.stats.p9.kpg.valueDec.ToString();

            TimeSpan timeSpan = TimeSpan.FromMinutes(fortniteTracker.stats.p9.minutesPlayed.valueInt);
            lblStat_TimePlayed_Value.Text = FortniteTracker.GetString_MinutePlayed(timeSpan, _config);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Rafraichissement des données si solo choisi
        /// </summary>
        /// <param name="fortniteTracker">Objet FortniteTracker</param>
        private void SetStat_Solo(FortniteTracker fortniteTracker)
        {
            lblStat_Score_Value.Text = fortniteTracker.stats.p2.score.valueInt.ToString();
            lblStat_Matches_Value.Text = fortniteTracker.stats.p2.matches.valueInt.ToString();
            lblStat_Top1_Value.Text = fortniteTracker.stats.p2.top1.valueInt.ToString();
            lblStat_Top10_Value.Text = fortniteTracker.stats.p2.top10.valueInt.ToString();
            lblStat_Top25_Value.Text = fortniteTracker.stats.p2.top25.valueInt.ToString();
            lblStat_WinRatio_Value.Text = (fortniteTracker.stats.p2.winRatio == null) ? "0%" : fortniteTracker.stats.p2.winRatio.valueDec.ToString() + "%";
            lblStat_Kill_Value.Text = fortniteTracker.stats.p2.kills.valueInt.ToString();
            lblStat_KillDeath_Value.Text = fortniteTracker.stats.p2.kd.valueDec.ToString();
            lblStat_KillMinute_Value.Text = fortniteTracker.stats.p2.kpm == null ? "KO" : fortniteTracker.stats.p2.kpm.valueDec.ToString();
            lblStat_KillGame_Value.Text = fortniteTracker.stats.p2.kpg.valueDec.ToString();

            if (fortniteTracker.stats.p2.minutesPlayed == null)
            {
                lblStat_TimePlayed_Value.Text = "KO";
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromMinutes(fortniteTracker.stats.p2.minutesPlayed.valueInt);
                lblStat_TimePlayed_Value.Text = FortniteTracker.GetString_MinutePlayed(timeSpan, _config);
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Appui sur entré sur le cmb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbPlayer_Platform_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                btnSearch_Click(btnSearch, null);
                e.Handled = true;
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// appui sur entrée sur la txt
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txtPlayerName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                btnSearch_Click(btnSearch, null);
                e.Handled = true;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Clic sur le bouton RESET
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnReset_Click(object sender, EventArgs e)
        {
            _isOtherPlayer = false;
            await RefreshStatAsync();

            _in3Minutes = null;
            lblTimer_Value.Visible = true;
            lblTimer_Text.Visible = true;

            //--------------------------------------------------------
            //Vérification que si le timer n'est pas lancé on le lance
            //--------------------------------------------------------
            if (!timerRefresh.Enabled)
                timerRefresh.Start();

            SetButtonEnable_2Sec();
            txtPlayerName.Text = "";
            lblPlayerName.Text = "Stats de " + _config.Login;

            foreach (ItemData itemData in cmbPlayer_Platform.Items)
                if (((Int32)itemData.Item).ToString() == _config.Platform) cmbPlayer_Platform.SelectedItem = itemData;


            _enumButtonStat = EnumButton_Stat.Solo;
            SetStatSoloDuoSquad(_fortniteTracker);
            SetLifeTimeStat_Value(_fortniteTracker);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Chargement des données en Async et rend visible les composants a la fin du chargement de la form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void FormStat_Shown(object sender, EventArgs e)
        {
            //-----------------------------------------------
            //Vérification qu'il y a bien un login et clé api
            //sinon on demande a mettre a jour
            //-----------------------------------------------
            while (!Config.IsFileOk(_config))
            {
                MessageBox.Show("Aucun login ou clé Api n'est renseigné.");
                DialogResult dialogResult = new FormOption().ShowDialog();

                if (dialogResult != DialogResult.OK) Application.Exit();

                _config = Config.GetConfig();
            }

            //--------------------------------------------------------
            //on va récupérer le traduction selon les paramètre choisi
            //--------------------------------------------------------
            _translation = Translation.GetTranslation(_config);

            lblPlayerName.Text = "Stats de " + _config.Login;

            //-------------------
            //Affichage des stats
            //-------------------
            await RefreshStatAsync();

            //--------------------------------------------------
            //Vérification qu'il y a bien des stats de récupérés
            //--------------------------------------------------
            if (_fortniteTracker == null)
            {
                //On recommence la Methode tant que c'est pas bon
                //-----------------------------------------------
                FormStat_Shown(sender, e);
                return;
            }

            //---------------------------------------
            //Remplissage des données selon la langue
            //---------------------------------------
            SetStat_Text();
            //-------------------------
            //Initialisation de la form
            //-------------------------
            InitializeForm();
            //-------------------------
            //On affiche les composents
            //-------------------------
            SetVisibleComponent(true);
            //----------------------------------------------
            //On rempli les joueur déja cherchés dans la txt
            //----------------------------------------------
            SetAutoCompleteTxt();
            //-----------------
            //On démare le timer
            //-----------------
            timerRefresh.Start();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Timer pour mettre a jour la fenetre toute les 3 minutes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void timerRefresh_Tick(object sender, EventArgs e)
        {
            //-----------------------------
            //Datetime avec le temps + 3min
            //-----------------------------
            if (_in3Minutes == null) _in3Minutes = DateTime.Now.AddMinutes(3);

            TimeSpan timeSpan = _in3Minutes.Value - DateTime.Now;

            //----------------------
            //Ecriture dans le label
            //----------------------
            lblTimer_Value.Text = timeSpan.Minutes + ":" + ((timeSpan.Seconds.ToString().Length > 1)
                ? timeSpan.Seconds.ToString()
                : "0" + timeSpan.Seconds.ToString());

            //-----------------------------------------------
            //Relancement de l'opération si le timer est fini
            //-----------------------------------------------
            if (DateTime.Now > _in3Minutes.Value)
            {
                _in3Minutes = null;
                timerRefresh.Stop();
                //On vérifie que l'on est pas sur les stats d'un autre 
                //pour éviter d'éffacer ce qu'il y a l'écran
                //----------------------------------------------------
                if (!_isOtherPlayer) await RefreshStatAsync();
                timerRefresh.Start();
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Ecriture d'un nouveau fichier config si les nouvelles données sont différentes
        /// </summary>
        private async Task WriteNewFileStatAsync()
        {
            //------------------------------------------
            //Récupération du la plus récente sauvegarde
            //------------------------------------------
            FortniteTracker fortniteTrackers_Recent = await FileSave.GetStat_Last();

            DateTime dateTimeNow = DateTime.Now;

            //-------------------------------------------------
            //On vérifie que l'on a joué depuis la derniere maj
            //-------------------------------------------------
            if (fortniteTrackers_Recent != null)
            {
                if (_fortniteTracker.lifeTimeStatObject.matchesPlayed <=
                    fortniteTrackers_Recent.lifeTimeStatObject.matchesPlayed) return;
            }

            //-------------------
            //On écrit le fichier
            //-------------------
            await FileSave.SaveFileAsync(_fortniteTracker);
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Clic sur le bouton option
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnOption_Click(object sender, EventArgs e)
        {
            FormOption formOption = new FormOption();
            DialogResult dialogResult = formOption.ShowDialog();

            if (dialogResult != DialogResult.OK) return;

            _config = Config.GetConfig();
            _translation = Translation.GetTranslation(_config);

            timerRefresh.Stop();
            await RefreshStatAsync();
            timerRefresh.Start();

            foreach (ItemData itemData in cmbPlayer_Platform.Items)
                if (((Int32)itemData.Item).ToString() == _config.Platform) cmbPlayer_Platform.SelectedItem = itemData;

            InitializeForm();
            SetStat_Text();
        }


        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        //--------------------------------------------------------------------------------------------------------------------------------------------
        /// <summary>
        /// Affichage de l'historique
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnHistoric_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = new FormHistoric().ShowDialog();
        }




        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            taskBar.Visible = false;
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void FormStat_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                taskBar.Visible = true;
                taskBar.Icon = this.Icon;
                this.WindowState = FormWindowState.Minimized;
                this.ShowInTaskbar = false;
            }
        }
    }
}
