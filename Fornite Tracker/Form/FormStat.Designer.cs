namespace Fornite_Tracker
{
    partial class FormStat
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStat));
            this.btnSolo = new Custom_Button._Button();
            this.btnDuo = new Custom_Button._Button();
            this.btnSquad = new Custom_Button._Button();
            this.btnSearch = new Custom_Button._Button();
            this.cmbPlayer_Platform = new Alex.Controls._ComboBox();
            this.txtPlayerName = new Alex.Controls._TextBox();
            this.lblStat_Score = new System.Windows.Forms.Label();
            this.lblStat_Matches = new System.Windows.Forms.Label();
            this.lblStat_Top1 = new System.Windows.Forms.Label();
            this.lblStat_Kill = new System.Windows.Forms.Label();
            this.lblStat_Top25 = new System.Windows.Forms.Label();
            this.lblStat_WinRatio = new System.Windows.Forms.Label();
            this.lblStat_KillMinute = new System.Windows.Forms.Label();
            this.lblStat_KillDeath = new System.Windows.Forms.Label();
            this.lblStat_TimePlayed = new System.Windows.Forms.Label();
            this.lblStat_KillGame = new System.Windows.Forms.Label();
            this.lblStat_Top10 = new System.Windows.Forms.Label();
            this.lblStat_TimePlayed_Value = new System.Windows.Forms.Label();
            this.lblStat_Score_Value = new System.Windows.Forms.Label();
            this.lblStat_KillGame_Value = new System.Windows.Forms.Label();
            this.lblStat_Top10_Value = new System.Windows.Forms.Label();
            this.lblStat_KillMinute_Value = new System.Windows.Forms.Label();
            this.lblStat_Matches_Value = new System.Windows.Forms.Label();
            this.lblStat_KillDeath_Value = new System.Windows.Forms.Label();
            this.lblStat_Top25_Value = new System.Windows.Forms.Label();
            this.lblStat_Kill_Value = new System.Windows.Forms.Label();
            this.lblStat_Top1_Value = new System.Windows.Forms.Label();
            this.lblStat_WinRatio_Value = new System.Windows.Forms.Label();
            this.lblStat_Title = new System.Windows.Forms.Label();
            this.lblTitle_LifeTimeStat = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Score = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_WinsPercentage = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_TimePlayed = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_KillMinute = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_MatchesPlayed = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_KillDeath = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Wins = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Kills = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_TimePlayed_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Score_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_KillMinute_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_WinsPercentage_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_KillDeath_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_MatchesPlayed_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Wins_Value = new System.Windows.Forms.Label();
            this.lblLifeTimeStat_Kills_Value = new System.Windows.Forms.Label();
            this.picLoading = new System.Windows.Forms.PictureBox();
            this.pnlLoading = new System.Windows.Forms.Panel();
            this.btnReset = new Custom_Button._Button();
            this.lblTimer_Value = new System.Windows.Forms.Label();
            this.timerRefresh = new System.Windows.Forms.Timer(this.components);
            this.pnlLine = new System.Windows.Forms.Panel();
            this.lblTimer_Text = new System.Windows.Forms.Label();
            this.btnOption = new Custom_Button._Button();
            this.lblPlayerName = new System.Windows.Forms.Label();
            this.btnHistoric = new Custom_Button._Button();
            this.taskBar = new System.Windows.Forms.NotifyIcon(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).BeginInit();
            this.pnlLoading.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSolo
            // 
            this.btnSolo.BackgroundColor = null;
            this.btnSolo.BackgroundColor_Hover = null;
            this.btnSolo.FontColor = null;
            this.btnSolo.Location = new System.Drawing.Point(12, 12);
            this.btnSolo.Name = "btnSolo";
            this.btnSolo.Size = new System.Drawing.Size(282, 132);
            this.btnSolo.TabIndex = 3;
            this.btnSolo.Text = "solo";
            this.btnSolo.UseVisualStyleBackColor = false;
            this.btnSolo.Click += new System.EventHandler(this.btnSolo_Click);
            // 
            // btnDuo
            // 
            this.btnDuo.BackgroundColor = null;
            this.btnDuo.BackgroundColor_Hover = null;
            this.btnDuo.FontColor = null;
            this.btnDuo.Location = new System.Drawing.Point(312, 12);
            this.btnDuo.Name = "btnDuo";
            this.btnDuo.Size = new System.Drawing.Size(258, 132);
            this.btnDuo.TabIndex = 4;
            this.btnDuo.Text = "duo";
            this.btnDuo.UseVisualStyleBackColor = false;
            this.btnDuo.Click += new System.EventHandler(this.btnDuo_Click);
            // 
            // btnSquad
            // 
            this.btnSquad.BackgroundColor = null;
            this.btnSquad.BackgroundColor_Hover = null;
            this.btnSquad.FontColor = null;
            this.btnSquad.Location = new System.Drawing.Point(588, 12);
            this.btnSquad.Name = "btnSquad";
            this.btnSquad.Size = new System.Drawing.Size(282, 132);
            this.btnSquad.TabIndex = 5;
            this.btnSquad.Text = "squad";
            this.btnSquad.UseVisualStyleBackColor = false;
            this.btnSquad.Click += new System.EventHandler(this.btnSquad_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.BackgroundColor = null;
            this.btnSearch.BackgroundColor_Hover = null;
            this.btnSearch.FontColor = null;
            this.btnSearch.Location = new System.Drawing.Point(12, 201);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(114, 34);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cmbPlayer_Platform
            // 
            this.cmbPlayer_Platform.FormattingEnabled = true;
            this.cmbPlayer_Platform.Location = new System.Drawing.Point(202, 163);
            this.cmbPlayer_Platform.Name = "cmbPlayer_Platform";
            this.cmbPlayer_Platform.Size = new System.Drawing.Size(81, 21);
            this.cmbPlayer_Platform.TabIndex = 1;
            this.cmbPlayer_Platform.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbPlayer_Platform_KeyPress);
            // 
            // txtPlayerName
            // 
            this.txtPlayerName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.txtPlayerName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPlayerName.FocusColor = System.Drawing.Color.Empty;
            this.txtPlayerName.Location = new System.Drawing.Point(13, 163);
            this.txtPlayerName.Name = "txtPlayerName";
            this.txtPlayerName.Size = new System.Drawing.Size(183, 20);
            this.txtPlayerName.TabIndex = 0;
            this.txtPlayerName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPlayerName_KeyDown);
            // 
            // lblStat_Score
            // 
            this.lblStat_Score.Location = new System.Drawing.Point(19, 332);
            this.lblStat_Score.Name = "lblStat_Score";
            this.lblStat_Score.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Score.TabIndex = 1;
            this.lblStat_Score.Text = "Score";
            this.lblStat_Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_Matches
            // 
            this.lblStat_Matches.Location = new System.Drawing.Point(19, 364);
            this.lblStat_Matches.Name = "lblStat_Matches";
            this.lblStat_Matches.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Matches.TabIndex = 1;
            this.lblStat_Matches.Text = "Matchs joués";
            this.lblStat_Matches.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_Top1
            // 
            this.lblStat_Top1.Location = new System.Drawing.Point(19, 396);
            this.lblStat_Top1.Name = "lblStat_Top1";
            this.lblStat_Top1.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top1.TabIndex = 1;
            this.lblStat_Top1.Text = "Top 1";
            this.lblStat_Top1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_Kill
            // 
            this.lblStat_Kill.Location = new System.Drawing.Point(19, 524);
            this.lblStat_Kill.Name = "lblStat_Kill";
            this.lblStat_Kill.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Kill.TabIndex = 1;
            this.lblStat_Kill.Text = "Elimination";
            this.lblStat_Kill.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_Top25
            // 
            this.lblStat_Top25.Location = new System.Drawing.Point(19, 460);
            this.lblStat_Top25.Name = "lblStat_Top25";
            this.lblStat_Top25.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top25.TabIndex = 1;
            this.lblStat_Top25.Text = "Top 25";
            this.lblStat_Top25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_WinRatio
            // 
            this.lblStat_WinRatio.Location = new System.Drawing.Point(19, 492);
            this.lblStat_WinRatio.Name = "lblStat_WinRatio";
            this.lblStat_WinRatio.Size = new System.Drawing.Size(200, 32);
            this.lblStat_WinRatio.TabIndex = 1;
            this.lblStat_WinRatio.Text = "% victoires";
            this.lblStat_WinRatio.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_KillMinute
            // 
            this.lblStat_KillMinute.Location = new System.Drawing.Point(19, 588);
            this.lblStat_KillMinute.Name = "lblStat_KillMinute";
            this.lblStat_KillMinute.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillMinute.TabIndex = 1;
            this.lblStat_KillMinute.Text = "Elimination / Minute";
            this.lblStat_KillMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_KillDeath
            // 
            this.lblStat_KillDeath.Location = new System.Drawing.Point(19, 556);
            this.lblStat_KillDeath.Name = "lblStat_KillDeath";
            this.lblStat_KillDeath.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillDeath.TabIndex = 1;
            this.lblStat_KillDeath.Text = "Eliminations / Mort";
            this.lblStat_KillDeath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_TimePlayed
            // 
            this.lblStat_TimePlayed.Location = new System.Drawing.Point(19, 652);
            this.lblStat_TimePlayed.Name = "lblStat_TimePlayed";
            this.lblStat_TimePlayed.Size = new System.Drawing.Size(200, 32);
            this.lblStat_TimePlayed.TabIndex = 1;
            this.lblStat_TimePlayed.Text = "Temps joué";
            this.lblStat_TimePlayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_KillGame
            // 
            this.lblStat_KillGame.Location = new System.Drawing.Point(19, 620);
            this.lblStat_KillGame.Name = "lblStat_KillGame";
            this.lblStat_KillGame.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillGame.TabIndex = 1;
            this.lblStat_KillGame.Text = "Elimination / Partie";
            this.lblStat_KillGame.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_Top10
            // 
            this.lblStat_Top10.Location = new System.Drawing.Point(19, 428);
            this.lblStat_Top10.Name = "lblStat_Top10";
            this.lblStat_Top10.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top10.TabIndex = 1;
            this.lblStat_Top10.Text = "Top 10";
            this.lblStat_Top10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStat_TimePlayed_Value
            // 
            this.lblStat_TimePlayed_Value.Location = new System.Drawing.Point(232, 653);
            this.lblStat_TimePlayed_Value.Name = "lblStat_TimePlayed_Value";
            this.lblStat_TimePlayed_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_TimePlayed_Value.TabIndex = 1;
            this.lblStat_TimePlayed_Value.Text = "Score";
            this.lblStat_TimePlayed_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Score_Value
            // 
            this.lblStat_Score_Value.Location = new System.Drawing.Point(232, 332);
            this.lblStat_Score_Value.Name = "lblStat_Score_Value";
            this.lblStat_Score_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Score_Value.TabIndex = 1;
            this.lblStat_Score_Value.Text = "Score";
            this.lblStat_Score_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_KillGame_Value
            // 
            this.lblStat_KillGame_Value.Location = new System.Drawing.Point(232, 621);
            this.lblStat_KillGame_Value.Name = "lblStat_KillGame_Value";
            this.lblStat_KillGame_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillGame_Value.TabIndex = 1;
            this.lblStat_KillGame_Value.Text = "Score";
            this.lblStat_KillGame_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Top10_Value
            // 
            this.lblStat_Top10_Value.Location = new System.Drawing.Point(232, 428);
            this.lblStat_Top10_Value.Name = "lblStat_Top10_Value";
            this.lblStat_Top10_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top10_Value.TabIndex = 1;
            this.lblStat_Top10_Value.Text = "Score";
            this.lblStat_Top10_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_KillMinute_Value
            // 
            this.lblStat_KillMinute_Value.Location = new System.Drawing.Point(232, 589);
            this.lblStat_KillMinute_Value.Name = "lblStat_KillMinute_Value";
            this.lblStat_KillMinute_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillMinute_Value.TabIndex = 1;
            this.lblStat_KillMinute_Value.Text = "Score";
            this.lblStat_KillMinute_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Matches_Value
            // 
            this.lblStat_Matches_Value.Location = new System.Drawing.Point(232, 364);
            this.lblStat_Matches_Value.Name = "lblStat_Matches_Value";
            this.lblStat_Matches_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Matches_Value.TabIndex = 1;
            this.lblStat_Matches_Value.Text = "Score";
            this.lblStat_Matches_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_KillDeath_Value
            // 
            this.lblStat_KillDeath_Value.Location = new System.Drawing.Point(232, 557);
            this.lblStat_KillDeath_Value.Name = "lblStat_KillDeath_Value";
            this.lblStat_KillDeath_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_KillDeath_Value.TabIndex = 1;
            this.lblStat_KillDeath_Value.Text = "Score";
            this.lblStat_KillDeath_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Top25_Value
            // 
            this.lblStat_Top25_Value.Location = new System.Drawing.Point(232, 461);
            this.lblStat_Top25_Value.Name = "lblStat_Top25_Value";
            this.lblStat_Top25_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top25_Value.TabIndex = 1;
            this.lblStat_Top25_Value.Text = "Score";
            this.lblStat_Top25_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Kill_Value
            // 
            this.lblStat_Kill_Value.Location = new System.Drawing.Point(232, 525);
            this.lblStat_Kill_Value.Name = "lblStat_Kill_Value";
            this.lblStat_Kill_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Kill_Value.TabIndex = 1;
            this.lblStat_Kill_Value.Text = "Score";
            this.lblStat_Kill_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Top1_Value
            // 
            this.lblStat_Top1_Value.Location = new System.Drawing.Point(232, 396);
            this.lblStat_Top1_Value.Name = "lblStat_Top1_Value";
            this.lblStat_Top1_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_Top1_Value.TabIndex = 1;
            this.lblStat_Top1_Value.Text = "Score";
            this.lblStat_Top1_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_WinRatio_Value
            // 
            this.lblStat_WinRatio_Value.Location = new System.Drawing.Point(232, 493);
            this.lblStat_WinRatio_Value.Name = "lblStat_WinRatio_Value";
            this.lblStat_WinRatio_Value.Size = new System.Drawing.Size(200, 32);
            this.lblStat_WinRatio_Value.TabIndex = 1;
            this.lblStat_WinRatio_Value.Text = "Score";
            this.lblStat_WinRatio_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblStat_Title
            // 
            this.lblStat_Title.Location = new System.Drawing.Point(19, 260);
            this.lblStat_Title.Name = "lblStat_Title";
            this.lblStat_Title.Size = new System.Drawing.Size(413, 72);
            this.lblStat_Title.TabIndex = 0;
            this.lblStat_Title.Text = "Stats Top1";
            this.lblStat_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTitle_LifeTimeStat
            // 
            this.lblTitle_LifeTimeStat.Location = new System.Drawing.Point(457, 260);
            this.lblTitle_LifeTimeStat.Name = "lblTitle_LifeTimeStat";
            this.lblTitle_LifeTimeStat.Size = new System.Drawing.Size(413, 72);
            this.lblTitle_LifeTimeStat.TabIndex = 0;
            this.lblTitle_LifeTimeStat.Text = "Stats générales";
            this.lblTitle_LifeTimeStat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblLifeTimeStat_Score
            // 
            this.lblLifeTimeStat_Score.Location = new System.Drawing.Point(457, 364);
            this.lblLifeTimeStat_Score.Name = "lblLifeTimeStat_Score";
            this.lblLifeTimeStat_Score.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Score.TabIndex = 1;
            this.lblLifeTimeStat_Score.Text = "Score";
            this.lblLifeTimeStat_Score.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_WinsPercentage
            // 
            this.lblLifeTimeStat_WinsPercentage.Location = new System.Drawing.Point(457, 460);
            this.lblLifeTimeStat_WinsPercentage.Name = "lblLifeTimeStat_WinsPercentage";
            this.lblLifeTimeStat_WinsPercentage.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_WinsPercentage.TabIndex = 1;
            this.lblLifeTimeStat_WinsPercentage.Text = "Pourcentage victoire";
            this.lblLifeTimeStat_WinsPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_TimePlayed
            // 
            this.lblLifeTimeStat_TimePlayed.Location = new System.Drawing.Point(457, 589);
            this.lblLifeTimeStat_TimePlayed.Name = "lblLifeTimeStat_TimePlayed";
            this.lblLifeTimeStat_TimePlayed.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_TimePlayed.TabIndex = 1;
            this.lblLifeTimeStat_TimePlayed.Text = "Temps joué";
            this.lblLifeTimeStat_TimePlayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_KillMinute
            // 
            this.lblLifeTimeStat_KillMinute.Location = new System.Drawing.Point(457, 557);
            this.lblLifeTimeStat_KillMinute.Name = "lblLifeTimeStat_KillMinute";
            this.lblLifeTimeStat_KillMinute.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_KillMinute.TabIndex = 1;
            this.lblLifeTimeStat_KillMinute.Text = "Eliminations / Minute";
            this.lblLifeTimeStat_KillMinute.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_MatchesPlayed
            // 
            this.lblLifeTimeStat_MatchesPlayed.Location = new System.Drawing.Point(457, 396);
            this.lblLifeTimeStat_MatchesPlayed.Name = "lblLifeTimeStat_MatchesPlayed";
            this.lblLifeTimeStat_MatchesPlayed.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_MatchesPlayed.TabIndex = 1;
            this.lblLifeTimeStat_MatchesPlayed.Text = "Matchs joués";
            this.lblLifeTimeStat_MatchesPlayed.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_KillDeath
            // 
            this.lblLifeTimeStat_KillDeath.Location = new System.Drawing.Point(457, 525);
            this.lblLifeTimeStat_KillDeath.Name = "lblLifeTimeStat_KillDeath";
            this.lblLifeTimeStat_KillDeath.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_KillDeath.TabIndex = 1;
            this.lblLifeTimeStat_KillDeath.Text = "Eliminations / Morts";
            this.lblLifeTimeStat_KillDeath.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_Wins
            // 
            this.lblLifeTimeStat_Wins.Location = new System.Drawing.Point(457, 428);
            this.lblLifeTimeStat_Wins.Name = "lblLifeTimeStat_Wins";
            this.lblLifeTimeStat_Wins.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Wins.TabIndex = 1;
            this.lblLifeTimeStat_Wins.Text = "Victoires";
            this.lblLifeTimeStat_Wins.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_Kills
            // 
            this.lblLifeTimeStat_Kills.Location = new System.Drawing.Point(457, 493);
            this.lblLifeTimeStat_Kills.Name = "lblLifeTimeStat_Kills";
            this.lblLifeTimeStat_Kills.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Kills.TabIndex = 1;
            this.lblLifeTimeStat_Kills.Text = "Eliminations";
            this.lblLifeTimeStat_Kills.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblLifeTimeStat_TimePlayed_Value
            // 
            this.lblLifeTimeStat_TimePlayed_Value.Location = new System.Drawing.Point(670, 589);
            this.lblLifeTimeStat_TimePlayed_Value.Name = "lblLifeTimeStat_TimePlayed_Value";
            this.lblLifeTimeStat_TimePlayed_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_TimePlayed_Value.TabIndex = 1;
            this.lblLifeTimeStat_TimePlayed_Value.Text = "Score";
            this.lblLifeTimeStat_TimePlayed_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_Score_Value
            // 
            this.lblLifeTimeStat_Score_Value.Location = new System.Drawing.Point(670, 364);
            this.lblLifeTimeStat_Score_Value.Name = "lblLifeTimeStat_Score_Value";
            this.lblLifeTimeStat_Score_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Score_Value.TabIndex = 1;
            this.lblLifeTimeStat_Score_Value.Text = "Score";
            this.lblLifeTimeStat_Score_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_KillMinute_Value
            // 
            this.lblLifeTimeStat_KillMinute_Value.Location = new System.Drawing.Point(670, 557);
            this.lblLifeTimeStat_KillMinute_Value.Name = "lblLifeTimeStat_KillMinute_Value";
            this.lblLifeTimeStat_KillMinute_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_KillMinute_Value.TabIndex = 1;
            this.lblLifeTimeStat_KillMinute_Value.Text = "Score";
            this.lblLifeTimeStat_KillMinute_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_WinsPercentage_Value
            // 
            this.lblLifeTimeStat_WinsPercentage_Value.Location = new System.Drawing.Point(670, 460);
            this.lblLifeTimeStat_WinsPercentage_Value.Name = "lblLifeTimeStat_WinsPercentage_Value";
            this.lblLifeTimeStat_WinsPercentage_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_WinsPercentage_Value.TabIndex = 1;
            this.lblLifeTimeStat_WinsPercentage_Value.Text = "Score";
            this.lblLifeTimeStat_WinsPercentage_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_KillDeath_Value
            // 
            this.lblLifeTimeStat_KillDeath_Value.Location = new System.Drawing.Point(670, 525);
            this.lblLifeTimeStat_KillDeath_Value.Name = "lblLifeTimeStat_KillDeath_Value";
            this.lblLifeTimeStat_KillDeath_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_KillDeath_Value.TabIndex = 1;
            this.lblLifeTimeStat_KillDeath_Value.Text = "Score";
            this.lblLifeTimeStat_KillDeath_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_MatchesPlayed_Value
            // 
            this.lblLifeTimeStat_MatchesPlayed_Value.Location = new System.Drawing.Point(670, 396);
            this.lblLifeTimeStat_MatchesPlayed_Value.Name = "lblLifeTimeStat_MatchesPlayed_Value";
            this.lblLifeTimeStat_MatchesPlayed_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_MatchesPlayed_Value.TabIndex = 1;
            this.lblLifeTimeStat_MatchesPlayed_Value.Text = "Score";
            this.lblLifeTimeStat_MatchesPlayed_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_Wins_Value
            // 
            this.lblLifeTimeStat_Wins_Value.Location = new System.Drawing.Point(670, 428);
            this.lblLifeTimeStat_Wins_Value.Name = "lblLifeTimeStat_Wins_Value";
            this.lblLifeTimeStat_Wins_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Wins_Value.TabIndex = 1;
            this.lblLifeTimeStat_Wins_Value.Text = "Score";
            this.lblLifeTimeStat_Wins_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblLifeTimeStat_Kills_Value
            // 
            this.lblLifeTimeStat_Kills_Value.Location = new System.Drawing.Point(670, 493);
            this.lblLifeTimeStat_Kills_Value.Name = "lblLifeTimeStat_Kills_Value";
            this.lblLifeTimeStat_Kills_Value.Size = new System.Drawing.Size(200, 32);
            this.lblLifeTimeStat_Kills_Value.TabIndex = 1;
            this.lblLifeTimeStat_Kills_Value.Text = "Score";
            this.lblLifeTimeStat_Kills_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picLoading
            // 
            this.picLoading.Image = global::Fornite_Tracker.Properties.Resources.load;
            this.picLoading.Location = new System.Drawing.Point(70, 3);
            this.picLoading.Name = "picLoading";
            this.picLoading.Size = new System.Drawing.Size(100, 100);
            this.picLoading.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picLoading.TabIndex = 10;
            this.picLoading.TabStop = false;
            // 
            // pnlLoading
            // 
            this.pnlLoading.Controls.Add(this.picLoading);
            this.pnlLoading.Location = new System.Drawing.Point(769, 349);
            this.pnlLoading.Name = "pnlLoading";
            this.pnlLoading.Size = new System.Drawing.Size(208, 108);
            this.pnlLoading.TabIndex = 11;
            // 
            // btnReset
            // 
            this.btnReset.BackgroundColor = null;
            this.btnReset.BackgroundColor_Hover = null;
            this.btnReset.FontColor = null;
            this.btnReset.Location = new System.Drawing.Point(129, 201);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(114, 34);
            this.btnReset.TabIndex = 2;
            this.btnReset.Text = "Réinitialiser";
            this.btnReset.UseVisualStyleBackColor = false;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // lblTimer_Value
            // 
            this.lblTimer_Value.Location = new System.Drawing.Point(806, 160);
            this.lblTimer_Value.Name = "lblTimer_Value";
            this.lblTimer_Value.Size = new System.Drawing.Size(60, 30);
            this.lblTimer_Value.TabIndex = 12;
            this.lblTimer_Value.Text = "label1";
            this.lblTimer_Value.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timerRefresh
            // 
            this.timerRefresh.Interval = 10;
            this.timerRefresh.Tick += new System.EventHandler(this.timerRefresh_Tick);
            // 
            // pnlLine
            // 
            this.pnlLine.Location = new System.Drawing.Point(444, 322);
            this.pnlLine.Name = "pnlLine";
            this.pnlLine.Size = new System.Drawing.Size(2, 299);
            this.pnlLine.TabIndex = 13;
            // 
            // lblTimer_Text
            // 
            this.lblTimer_Text.Location = new System.Drawing.Point(676, 160);
            this.lblTimer_Text.Name = "lblTimer_Text";
            this.lblTimer_Text.Size = new System.Drawing.Size(124, 30);
            this.lblTimer_Text.TabIndex = 12;
            this.lblTimer_Text.Text = "Maj dans :";
            this.lblTimer_Text.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOption
            // 
            this.btnOption.BackgroundColor = null;
            this.btnOption.BackgroundColor_Hover = null;
            this.btnOption.FontColor = null;
            this.btnOption.Location = new System.Drawing.Point(22, 699);
            this.btnOption.Name = "btnOption";
            this.btnOption.Size = new System.Drawing.Size(152, 51);
            this.btnOption.TabIndex = 14;
            this.btnOption.Text = "Options";
            this.btnOption.UseVisualStyleBackColor = false;
            this.btnOption.Click += new System.EventHandler(this.btnOption_Click);
            // 
            // lblPlayerName
            // 
            this.lblPlayerName.Location = new System.Drawing.Point(22, 212);
            this.lblPlayerName.Name = "lblPlayerName";
            this.lblPlayerName.Size = new System.Drawing.Size(857, 48);
            this.lblPlayerName.TabIndex = 15;
            this.lblPlayerName.Text = "label1";
            this.lblPlayerName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnHistoric
            // 
            this.btnHistoric.BackgroundColor = null;
            this.btnHistoric.BackgroundColor_Hover = null;
            this.btnHistoric.FontColor = null;
            this.btnHistoric.Location = new System.Drawing.Point(727, 699);
            this.btnHistoric.Name = "btnHistoric";
            this.btnHistoric.Size = new System.Drawing.Size(152, 51);
            this.btnHistoric.TabIndex = 14;
            this.btnHistoric.Text = "Historics";
            this.btnHistoric.UseVisualStyleBackColor = false;
            this.btnHistoric.Click += new System.EventHandler(this.btnHistoric_Click);
            // 
            // taskBar
            // 
            this.taskBar.Text = "Fortnite Tracker";
            this.taskBar.Visible = true;
            this.taskBar.Click += new System.EventHandler(this.notifyIcon1_Click);
            // 
            // FormStat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(891, 762);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTimer_Text);
            this.Controls.Add(this.lblTimer_Value);
            this.Controls.Add(this.lblPlayerName);
            this.Controls.Add(this.btnHistoric);
            this.Controls.Add(this.btnOption);
            this.Controls.Add(this.pnlLine);
            this.Controls.Add(this.pnlLoading);
            this.Controls.Add(this.lblStat_Score);
            this.Controls.Add(this.lblStat_Matches);
            this.Controls.Add(this.lblStat_TimePlayed_Value);
            this.Controls.Add(this.lblStat_Top1);
            this.Controls.Add(this.lblLifeTimeStat_TimePlayed_Value);
            this.Controls.Add(this.lblStat_Kill);
            this.Controls.Add(this.lblStat_Score_Value);
            this.Controls.Add(this.lblStat_Top25);
            this.Controls.Add(this.lblStat_KillGame_Value);
            this.Controls.Add(this.lblStat_WinRatio);
            this.Controls.Add(this.lblStat_Title);
            this.Controls.Add(this.lblStat_KillMinute);
            this.Controls.Add(this.lblStat_Top10_Value);
            this.Controls.Add(this.lblStat_KillDeath);
            this.Controls.Add(this.lblLifeTimeStat_Score);
            this.Controls.Add(this.lblStat_TimePlayed);
            this.Controls.Add(this.lblStat_KillMinute_Value);
            this.Controls.Add(this.lblStat_KillGame);
            this.Controls.Add(this.lblLifeTimeStat_Score_Value);
            this.Controls.Add(this.lblStat_Top10);
            this.Controls.Add(this.lblStat_Matches_Value);
            this.Controls.Add(this.lblLifeTimeStat_KillMinute_Value);
            this.Controls.Add(this.lblStat_KillDeath_Value);
            this.Controls.Add(this.lblLifeTimeStat_WinsPercentage);
            this.Controls.Add(this.lblStat_Top25_Value);
            this.Controls.Add(this.lblLifeTimeStat_WinsPercentage_Value);
            this.Controls.Add(this.lblStat_Kill_Value);
            this.Controls.Add(this.lblTitle_LifeTimeStat);
            this.Controls.Add(this.lblStat_Top1_Value);
            this.Controls.Add(this.lblLifeTimeStat_KillDeath_Value);
            this.Controls.Add(this.lblStat_WinRatio_Value);
            this.Controls.Add(this.lblLifeTimeStat_TimePlayed);
            this.Controls.Add(this.lblLifeTimeStat_MatchesPlayed_Value);
            this.Controls.Add(this.lblLifeTimeStat_Wins_Value);
            this.Controls.Add(this.lblLifeTimeStat_KillMinute);
            this.Controls.Add(this.lblLifeTimeStat_Kills_Value);
            this.Controls.Add(this.lblLifeTimeStat_MatchesPlayed);
            this.Controls.Add(this.txtPlayerName);
            this.Controls.Add(this.lblLifeTimeStat_KillDeath);
            this.Controls.Add(this.cmbPlayer_Platform);
            this.Controls.Add(this.lblLifeTimeStat_Wins);
            this.Controls.Add(this.lblLifeTimeStat_Kills);
            this.Controls.Add(this.btnSquad);
            this.Controls.Add(this.btnDuo);
            this.Controls.Add(this.btnSolo);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormStat";
            this.Text = "Fornite Tracker : Stats";
            this.Shown += new System.EventHandler(this.FormStat_Shown);
            this.Resize += new System.EventHandler(this.FormStat_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picLoading)).EndInit();
            this.pnlLoading.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Custom_Button._Button btnSolo;
        private Custom_Button._Button btnDuo;
        private Custom_Button._Button btnSquad;
        private Custom_Button._Button btnSearch;
        private Alex.Controls._ComboBox cmbPlayer_Platform;
        private Alex.Controls._TextBox txtPlayerName;
        private System.Windows.Forms.Label lblStat_KillDeath_Value;
        private System.Windows.Forms.Label lblStat_Title;
        private System.Windows.Forms.Label lblStat_Kill_Value;
        private System.Windows.Forms.Label lblStat_Score;
        private System.Windows.Forms.Label lblStat_WinRatio_Value;
        private System.Windows.Forms.Label lblStat_Top25;
        private System.Windows.Forms.Label lblStat_Top1_Value;
        private System.Windows.Forms.Label lblStat_Top1;
        private System.Windows.Forms.Label lblStat_Top25_Value;
        private System.Windows.Forms.Label lblStat_KillDeath;
        private System.Windows.Forms.Label lblStat_Matches_Value;
        private System.Windows.Forms.Label lblStat_Top10;
        private System.Windows.Forms.Label lblStat_Top10_Value;
        private System.Windows.Forms.Label lblStat_WinRatio;
        private System.Windows.Forms.Label lblStat_Score_Value;
        private System.Windows.Forms.Label lblStat_Matches;
        private System.Windows.Forms.Label lblStat_Kill;
        private System.Windows.Forms.Label lblLifeTimeStat_TimePlayed_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_KillMinute_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_KillDeath_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_Wins_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_Kills_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_MatchesPlayed_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_WinsPercentage_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_Score_Value;
        private System.Windows.Forms.Label lblLifeTimeStat_TimePlayed;
        private System.Windows.Forms.Label lblLifeTimeStat_KillMinute;
        private System.Windows.Forms.Label lblLifeTimeStat_KillDeath;
        private System.Windows.Forms.Label lblLifeTimeStat_Wins;
        private System.Windows.Forms.Label lblLifeTimeStat_Kills;
        private System.Windows.Forms.Label lblLifeTimeStat_MatchesPlayed;
        private System.Windows.Forms.Label lblLifeTimeStat_WinsPercentage;
        private System.Windows.Forms.Label lblLifeTimeStat_Score;
        private System.Windows.Forms.Label lblTitle_LifeTimeStat;
        private System.Windows.Forms.Label lblStat_TimePlayed_Value;
        private System.Windows.Forms.Label lblStat_KillGame_Value;
        private System.Windows.Forms.Label lblStat_KillMinute_Value;
        private System.Windows.Forms.Label lblStat_KillGame;
        private System.Windows.Forms.Label lblStat_KillMinute;
        private System.Windows.Forms.Label lblStat_TimePlayed;
        private System.Windows.Forms.PictureBox picLoading;
        private System.Windows.Forms.Panel pnlLoading;
        private Custom_Button._Button btnReset;
        private System.Windows.Forms.Label lblTimer_Value;
        private System.Windows.Forms.Timer timerRefresh;
        private System.Windows.Forms.Panel pnlLine;
        private System.Windows.Forms.Label lblTimer_Text;
        private Custom_Button._Button btnOption;
        private System.Windows.Forms.Label lblPlayerName;
        private Custom_Button._Button btnHistoric;
        private System.Windows.Forms.NotifyIcon taskBar;
    }
}