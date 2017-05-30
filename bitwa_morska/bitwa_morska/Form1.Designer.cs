namespace bitwa_morska
{
    partial class mainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            this.helpPanel = new System.Windows.Forms.Panel();
            this.helpImage = new System.Windows.Forms.PictureBox();
            this.helpHeaderLabel = new System.Windows.Forms.Label();
            this.infoPanel = new System.Windows.Forms.Panel();
            this.txtDeathsValue = new System.Windows.Forms.Label();
            this.txtKillsValue = new System.Windows.Forms.Label();
            this.txtPointsValue = new System.Windows.Forms.Label();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.infoLabel2 = new System.Windows.Forms.Label();
            this.playerShipImage = new System.Windows.Forms.PictureBox();
            this.statsPanel = new System.Windows.Forms.Panel();
            this.txtYellowPoints = new System.Windows.Forms.Label();
            this.txtVioletPoints = new System.Windows.Forms.Label();
            this.txtGreenPoints = new System.Windows.Forms.Label();
            this.txtRedPoints = new System.Windows.Forms.Label();
            this.txtYellowDeaths = new System.Windows.Forms.Label();
            this.txtVioletDeaths = new System.Windows.Forms.Label();
            this.txtGreenDeaths = new System.Windows.Forms.Label();
            this.txtRedDeaths = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtYellowKills = new System.Windows.Forms.Label();
            this.txtVioletKills = new System.Windows.Forms.Label();
            this.txtGreenKills = new System.Windows.Forms.Label();
            this.txtRedKills = new System.Windows.Forms.Label();
            this.statsHeaderLabel = new System.Windows.Forms.Label();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.menuExitButton = new System.Windows.Forms.Button();
            this.menuCreditsButton = new System.Windows.Forms.Button();
            this.menuHelpButton = new System.Windows.Forms.Button();
            this.menuSingleplayerButton = new System.Windows.Forms.Button();
            this.menuMultiplayerButton = new System.Windows.Forms.Button();
            this.nameOfGameImage = new System.Windows.Forms.PictureBox();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.howToPlayPanel = new System.Windows.Forms.Panel();
            this.htp2menuButton = new System.Windows.Forms.Button();
            this.howToPlayImage = new System.Windows.Forms.PictureBox();
            this.aboutAuthorPanel = new System.Windows.Forms.Panel();
            this.aa2menuButton = new System.Windows.Forms.Button();
            this.aboutAuthorImage = new System.Windows.Forms.PictureBox();
            this.ReceivingThread = new System.ComponentModel.BackgroundWorker();
            this.tbIpAddress = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.helpPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpImage)).BeginInit();
            this.infoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerShipImage)).BeginInit();
            this.statsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameOfGameImage)).BeginInit();
            this.gamePanel.SuspendLayout();
            this.howToPlayPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.howToPlayImage)).BeginInit();
            this.aboutAuthorPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.aboutAuthorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // helpPanel
            // 
            this.helpPanel.BackColor = System.Drawing.Color.Silver;
            this.helpPanel.Controls.Add(this.helpImage);
            this.helpPanel.Controls.Add(this.helpHeaderLabel);
            this.helpPanel.Location = new System.Drawing.Point(0, 446);
            this.helpPanel.Name = "helpPanel";
            this.helpPanel.Size = new System.Drawing.Size(294, 153);
            this.helpPanel.TabIndex = 1;
            // 
            // helpImage
            // 
            this.helpImage.Image = global::bitwa_morska.Properties.Resources.help_img;
            this.helpImage.Location = new System.Drawing.Point(40, 39);
            this.helpImage.Name = "helpImage";
            this.helpImage.Size = new System.Drawing.Size(217, 102);
            this.helpImage.TabIndex = 1;
            this.helpImage.TabStop = false;
            // 
            // helpHeaderLabel
            // 
            this.helpHeaderLabel.AutoSize = true;
            this.helpHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.helpHeaderLabel.Location = new System.Drawing.Point(100, 9);
            this.helpHeaderLabel.Margin = new System.Windows.Forms.Padding(100, 0, 100, 0);
            this.helpHeaderLabel.Name = "helpHeaderLabel";
            this.helpHeaderLabel.Size = new System.Drawing.Size(72, 20);
            this.helpHeaderLabel.TabIndex = 2;
            this.helpHeaderLabel.Text = "POMOC";
            // 
            // infoPanel
            // 
            this.infoPanel.BackColor = System.Drawing.Color.Gray;
            this.infoPanel.Controls.Add(this.txtDeathsValue);
            this.infoPanel.Controls.Add(this.txtKillsValue);
            this.infoPanel.Controls.Add(this.txtPointsValue);
            this.infoPanel.Controls.Add(this.infoLabel1);
            this.infoPanel.Controls.Add(this.infoLabel2);
            this.infoPanel.Controls.Add(this.playerShipImage);
            this.infoPanel.Location = new System.Drawing.Point(300, 446);
            this.infoPanel.Name = "infoPanel";
            this.infoPanel.Size = new System.Drawing.Size(400, 153);
            this.infoPanel.TabIndex = 2;
            // 
            // txtDeathsValue
            // 
            this.txtDeathsValue.AutoSize = true;
            this.txtDeathsValue.Location = new System.Drawing.Point(331, 110);
            this.txtDeathsValue.Name = "txtDeathsValue";
            this.txtDeathsValue.Size = new System.Drawing.Size(13, 13);
            this.txtDeathsValue.TabIndex = 5;
            this.txtDeathsValue.Text = "0";
            // 
            // txtKillsValue
            // 
            this.txtKillsValue.AutoSize = true;
            this.txtKillsValue.Location = new System.Drawing.Point(321, 84);
            this.txtKillsValue.Name = "txtKillsValue";
            this.txtKillsValue.Size = new System.Drawing.Size(13, 13);
            this.txtKillsValue.TabIndex = 4;
            this.txtKillsValue.Text = "0";
            // 
            // txtPointsValue
            // 
            this.txtPointsValue.AutoSize = true;
            this.txtPointsValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtPointsValue.Location = new System.Drawing.Point(143, 94);
            this.txtPointsValue.Name = "txtPointsValue";
            this.txtPointsValue.Size = new System.Drawing.Size(18, 20);
            this.txtPointsValue.TabIndex = 3;
            this.txtPointsValue.Text = "0";
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.infoLabel1.Location = new System.Drawing.Point(73, 94);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(64, 20);
            this.infoLabel1.TabIndex = 2;
            this.infoLabel1.Text = "Punkty:";
            // 
            // infoLabel2
            // 
            this.infoLabel2.AutoSize = true;
            this.infoLabel2.Location = new System.Drawing.Point(227, 84);
            this.infoLabel2.Name = "infoLabel2";
            this.infoLabel2.Size = new System.Drawing.Size(98, 39);
            this.infoLabel2.TabIndex = 1;
            this.infoLabel2.Text = "Zatopione okręty:\r\n\r\nStracone jednostki:";
            // 
            // playerShipImage
            // 
            this.playerShipImage.Image = ((System.Drawing.Image)(resources.GetObject("playerShipImage.Image")));
            this.playerShipImage.Location = new System.Drawing.Point(112, 9);
            this.playerShipImage.Name = "playerShipImage";
            this.playerShipImage.Size = new System.Drawing.Size(180, 50);
            this.playerShipImage.TabIndex = 0;
            this.playerShipImage.TabStop = false;
            // 
            // statsPanel
            // 
            this.statsPanel.BackColor = System.Drawing.Color.Silver;
            this.statsPanel.Controls.Add(this.txtYellowPoints);
            this.statsPanel.Controls.Add(this.txtVioletPoints);
            this.statsPanel.Controls.Add(this.txtGreenPoints);
            this.statsPanel.Controls.Add(this.txtRedPoints);
            this.statsPanel.Controls.Add(this.txtYellowDeaths);
            this.statsPanel.Controls.Add(this.txtVioletDeaths);
            this.statsPanel.Controls.Add(this.txtGreenDeaths);
            this.statsPanel.Controls.Add(this.txtRedDeaths);
            this.statsPanel.Controls.Add(this.pictureBox4);
            this.statsPanel.Controls.Add(this.pictureBox3);
            this.statsPanel.Controls.Add(this.pictureBox2);
            this.statsPanel.Controls.Add(this.pictureBox1);
            this.statsPanel.Controls.Add(this.txtYellowKills);
            this.statsPanel.Controls.Add(this.txtVioletKills);
            this.statsPanel.Controls.Add(this.txtGreenKills);
            this.statsPanel.Controls.Add(this.txtRedKills);
            this.statsPanel.Controls.Add(this.statsHeaderLabel);
            this.statsPanel.Location = new System.Drawing.Point(706, 446);
            this.statsPanel.Name = "statsPanel";
            this.statsPanel.Size = new System.Drawing.Size(294, 153);
            this.statsPanel.TabIndex = 3;
            // 
            // txtYellowPoints
            // 
            this.txtYellowPoints.AutoSize = true;
            this.txtYellowPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtYellowPoints.Location = new System.Drawing.Point(232, 121);
            this.txtYellowPoints.Name = "txtYellowPoints";
            this.txtYellowPoints.Size = new System.Drawing.Size(11, 13);
            this.txtYellowPoints.TabIndex = 16;
            this.txtYellowPoints.Text = "-";
            // 
            // txtVioletPoints
            // 
            this.txtVioletPoints.AutoSize = true;
            this.txtVioletPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtVioletPoints.Location = new System.Drawing.Point(232, 91);
            this.txtVioletPoints.Name = "txtVioletPoints";
            this.txtVioletPoints.Size = new System.Drawing.Size(11, 13);
            this.txtVioletPoints.TabIndex = 15;
            this.txtVioletPoints.Text = "-";
            // 
            // txtGreenPoints
            // 
            this.txtGreenPoints.AutoSize = true;
            this.txtGreenPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtGreenPoints.Location = new System.Drawing.Point(232, 65);
            this.txtGreenPoints.Name = "txtGreenPoints";
            this.txtGreenPoints.Size = new System.Drawing.Size(11, 13);
            this.txtGreenPoints.TabIndex = 14;
            this.txtGreenPoints.Text = "-";
            // 
            // txtRedPoints
            // 
            this.txtRedPoints.AutoSize = true;
            this.txtRedPoints.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRedPoints.Location = new System.Drawing.Point(232, 39);
            this.txtRedPoints.Name = "txtRedPoints";
            this.txtRedPoints.Size = new System.Drawing.Size(11, 13);
            this.txtRedPoints.TabIndex = 13;
            this.txtRedPoints.Text = "-";
            // 
            // txtYellowDeaths
            // 
            this.txtYellowDeaths.AutoSize = true;
            this.txtYellowDeaths.Location = new System.Drawing.Point(173, 121);
            this.txtYellowDeaths.Name = "txtYellowDeaths";
            this.txtYellowDeaths.Size = new System.Drawing.Size(10, 13);
            this.txtYellowDeaths.TabIndex = 12;
            this.txtYellowDeaths.Text = "-";
            // 
            // txtVioletDeaths
            // 
            this.txtVioletDeaths.AutoSize = true;
            this.txtVioletDeaths.Location = new System.Drawing.Point(173, 91);
            this.txtVioletDeaths.Name = "txtVioletDeaths";
            this.txtVioletDeaths.Size = new System.Drawing.Size(10, 13);
            this.txtVioletDeaths.TabIndex = 11;
            this.txtVioletDeaths.Text = "-";
            // 
            // txtGreenDeaths
            // 
            this.txtGreenDeaths.AutoSize = true;
            this.txtGreenDeaths.Location = new System.Drawing.Point(173, 65);
            this.txtGreenDeaths.Name = "txtGreenDeaths";
            this.txtGreenDeaths.Size = new System.Drawing.Size(10, 13);
            this.txtGreenDeaths.TabIndex = 10;
            this.txtGreenDeaths.Text = "-";
            // 
            // txtRedDeaths
            // 
            this.txtRedDeaths.AutoSize = true;
            this.txtRedDeaths.Location = new System.Drawing.Point(173, 39);
            this.txtRedDeaths.Name = "txtRedDeaths";
            this.txtRedDeaths.Size = new System.Drawing.Size(10, 13);
            this.txtRedDeaths.TabIndex = 9;
            this.txtRedDeaths.Text = "-";
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = global::bitwa_morska.Properties.Resources.yellow_small;
            this.pictureBox4.Location = new System.Drawing.Point(17, 114);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(72, 20);
            this.pictureBox4.TabIndex = 8;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::bitwa_morska.Properties.Resources.violet_small;
            this.pictureBox3.Location = new System.Drawing.Point(17, 84);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 20);
            this.pictureBox3.TabIndex = 7;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::bitwa_morska.Properties.Resources.green_small;
            this.pictureBox2.Location = new System.Drawing.Point(17, 58);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(72, 20);
            this.pictureBox2.TabIndex = 6;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::bitwa_morska.Properties.Resources.red_small;
            this.pictureBox1.Location = new System.Drawing.Point(17, 32);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 20);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // txtYellowKills
            // 
            this.txtYellowKills.AutoSize = true;
            this.txtYellowKills.Location = new System.Drawing.Point(115, 121);
            this.txtYellowKills.Name = "txtYellowKills";
            this.txtYellowKills.Size = new System.Drawing.Size(10, 13);
            this.txtYellowKills.TabIndex = 4;
            this.txtYellowKills.Text = "-";
            // 
            // txtVioletKills
            // 
            this.txtVioletKills.AutoSize = true;
            this.txtVioletKills.Location = new System.Drawing.Point(115, 91);
            this.txtVioletKills.Name = "txtVioletKills";
            this.txtVioletKills.Size = new System.Drawing.Size(10, 13);
            this.txtVioletKills.TabIndex = 3;
            this.txtVioletKills.Text = "-";
            // 
            // txtGreenKills
            // 
            this.txtGreenKills.AutoSize = true;
            this.txtGreenKills.Location = new System.Drawing.Point(115, 65);
            this.txtGreenKills.Name = "txtGreenKills";
            this.txtGreenKills.Size = new System.Drawing.Size(10, 13);
            this.txtGreenKills.TabIndex = 2;
            this.txtGreenKills.Text = "-";
            // 
            // txtRedKills
            // 
            this.txtRedKills.AutoSize = true;
            this.txtRedKills.Location = new System.Drawing.Point(115, 39);
            this.txtRedKills.Name = "txtRedKills";
            this.txtRedKills.Size = new System.Drawing.Size(10, 13);
            this.txtRedKills.TabIndex = 1;
            this.txtRedKills.Text = "-";
            // 
            // statsHeaderLabel
            // 
            this.statsHeaderLabel.AutoSize = true;
            this.statsHeaderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statsHeaderLabel.Location = new System.Drawing.Point(85, 9);
            this.statsHeaderLabel.Name = "statsHeaderLabel";
            this.statsHeaderLabel.Size = new System.Drawing.Size(116, 20);
            this.statsHeaderLabel.TabIndex = 0;
            this.statsHeaderLabel.Text = "STATYSTYKI";
            // 
            // menuPanel
            // 
            this.menuPanel.BackColor = System.Drawing.Color.Transparent;
            this.menuPanel.Controls.Add(this.label1);
            this.menuPanel.Controls.Add(this.tbIpAddress);
            this.menuPanel.Controls.Add(this.menuExitButton);
            this.menuPanel.Controls.Add(this.menuCreditsButton);
            this.menuPanel.Controls.Add(this.menuHelpButton);
            this.menuPanel.Controls.Add(this.menuSingleplayerButton);
            this.menuPanel.Controls.Add(this.menuMultiplayerButton);
            this.menuPanel.Controls.Add(this.nameOfGameImage);
            this.menuPanel.Location = new System.Drawing.Point(250, 20);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(500, 560);
            this.menuPanel.TabIndex = 1;
            // 
            // menuExitButton
            // 
            this.menuExitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuExitButton.Location = new System.Drawing.Point(142, 410);
            this.menuExitButton.Name = "menuExitButton";
            this.menuExitButton.Size = new System.Drawing.Size(200, 40);
            this.menuExitButton.TabIndex = 4;
            this.menuExitButton.Text = "Wyjście";
            this.menuExitButton.UseVisualStyleBackColor = true;
            this.menuExitButton.Click += new System.EventHandler(this.menuExitButton_Click);
            // 
            // menuCreditsButton
            // 
            this.menuCreditsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuCreditsButton.Location = new System.Drawing.Point(142, 350);
            this.menuCreditsButton.Name = "menuCreditsButton";
            this.menuCreditsButton.Size = new System.Drawing.Size(200, 40);
            this.menuCreditsButton.TabIndex = 3;
            this.menuCreditsButton.Text = "O autorach";
            this.menuCreditsButton.UseVisualStyleBackColor = true;
            this.menuCreditsButton.Click += new System.EventHandler(this.menuCreditsButton_Click);
            // 
            // menuHelpButton
            // 
            this.menuHelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuHelpButton.Location = new System.Drawing.Point(142, 290);
            this.menuHelpButton.Name = "menuHelpButton";
            this.menuHelpButton.Size = new System.Drawing.Size(200, 40);
            this.menuHelpButton.TabIndex = 2;
            this.menuHelpButton.Text = "Jak grać?";
            this.menuHelpButton.UseVisualStyleBackColor = true;
            this.menuHelpButton.Click += new System.EventHandler(this.menuHelpButton_Click);
            // 
            // menuSingleplayerButton
            // 
            this.menuSingleplayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuSingleplayerButton.Location = new System.Drawing.Point(142, 230);
            this.menuSingleplayerButton.Name = "menuSingleplayerButton";
            this.menuSingleplayerButton.Size = new System.Drawing.Size(200, 40);
            this.menuSingleplayerButton.TabIndex = 1;
            this.menuSingleplayerButton.Text = "Gra jednoosobowa";
            this.menuSingleplayerButton.UseVisualStyleBackColor = true;
            this.menuSingleplayerButton.Click += new System.EventHandler(this.menuSingleplayerButton_Click);
            // 
            // menuMultiplayerButton
            // 
            this.menuMultiplayerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuMultiplayerButton.Location = new System.Drawing.Point(142, 170);
            this.menuMultiplayerButton.Name = "menuMultiplayerButton";
            this.menuMultiplayerButton.Size = new System.Drawing.Size(200, 40);
            this.menuMultiplayerButton.TabIndex = 0;
            this.menuMultiplayerButton.Text = "Gra wieloosobowa";
            this.menuMultiplayerButton.UseVisualStyleBackColor = true;
            this.menuMultiplayerButton.Click += new System.EventHandler(this.menuMultiplayerButton_Click);
            // 
            // nameOfGameImage
            // 
            this.nameOfGameImage.Image = global::bitwa_morska.Properties.Resources.name_of_game;
            this.nameOfGameImage.Location = new System.Drawing.Point(0, 0);
            this.nameOfGameImage.Name = "nameOfGameImage";
            this.nameOfGameImage.Size = new System.Drawing.Size(500, 125);
            this.nameOfGameImage.TabIndex = 6;
            this.nameOfGameImage.TabStop = false;
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.Highlight;
            this.mapPanel.Location = new System.Drawing.Point(0, 0);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(1000, 440);
            this.mapPanel.TabIndex = 0;
            // 
            // gamePanel
            // 
            this.gamePanel.BackColor = System.Drawing.Color.White;
            this.gamePanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gamePanel.BackgroundImage")));
            this.gamePanel.Controls.Add(this.helpPanel);
            this.gamePanel.Controls.Add(this.infoPanel);
            this.gamePanel.Controls.Add(this.statsPanel);
            this.gamePanel.Controls.Add(this.mapPanel);
            this.gamePanel.Enabled = false;
            this.gamePanel.Location = new System.Drawing.Point(0, 0);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(1000, 600);
            this.gamePanel.TabIndex = 2;
            this.gamePanel.Visible = false;
            // 
            // howToPlayPanel
            // 
            this.howToPlayPanel.BackColor = System.Drawing.Color.Transparent;
            this.howToPlayPanel.Controls.Add(this.htp2menuButton);
            this.howToPlayPanel.Controls.Add(this.howToPlayImage);
            this.howToPlayPanel.Enabled = false;
            this.howToPlayPanel.Location = new System.Drawing.Point(150, 10);
            this.howToPlayPanel.Name = "howToPlayPanel";
            this.howToPlayPanel.Size = new System.Drawing.Size(700, 580);
            this.howToPlayPanel.TabIndex = 0;
            this.howToPlayPanel.Visible = false;
            // 
            // htp2menuButton
            // 
            this.htp2menuButton.BackColor = System.Drawing.Color.Gold;
            this.htp2menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.htp2menuButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.htp2menuButton.Location = new System.Drawing.Point(225, 490);
            this.htp2menuButton.Name = "htp2menuButton";
            this.htp2menuButton.Size = new System.Drawing.Size(250, 50);
            this.htp2menuButton.TabIndex = 1;
            this.htp2menuButton.Text = "Powrót do menu";
            this.htp2menuButton.UseVisualStyleBackColor = false;
            this.htp2menuButton.Click += new System.EventHandler(this.htp2menuButton_Click);
            // 
            // howToPlayImage
            // 
            this.howToPlayImage.Image = global::bitwa_morska.Properties.Resources.how_to_play;
            this.howToPlayImage.Location = new System.Drawing.Point(0, 0);
            this.howToPlayImage.Name = "howToPlayImage";
            this.howToPlayImage.Size = new System.Drawing.Size(700, 500);
            this.howToPlayImage.TabIndex = 0;
            this.howToPlayImage.TabStop = false;
            // 
            // aboutAuthorPanel
            // 
            this.aboutAuthorPanel.BackColor = System.Drawing.Color.Transparent;
            this.aboutAuthorPanel.Controls.Add(this.aa2menuButton);
            this.aboutAuthorPanel.Controls.Add(this.aboutAuthorImage);
            this.aboutAuthorPanel.Enabled = false;
            this.aboutAuthorPanel.Location = new System.Drawing.Point(150, 10);
            this.aboutAuthorPanel.Name = "aboutAuthorPanel";
            this.aboutAuthorPanel.Size = new System.Drawing.Size(700, 580);
            this.aboutAuthorPanel.TabIndex = 2;
            this.aboutAuthorPanel.Visible = false;
            // 
            // aa2menuButton
            // 
            this.aa2menuButton.BackColor = System.Drawing.Color.Gold;
            this.aa2menuButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.aa2menuButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.aa2menuButton.Location = new System.Drawing.Point(225, 490);
            this.aa2menuButton.Name = "aa2menuButton";
            this.aa2menuButton.Size = new System.Drawing.Size(250, 50);
            this.aa2menuButton.TabIndex = 2;
            this.aa2menuButton.Text = "Powrót do menu";
            this.aa2menuButton.UseVisualStyleBackColor = false;
            this.aa2menuButton.Click += new System.EventHandler(this.aa2menuButton_Click);
            // 
            // aboutAuthorImage
            // 
            this.aboutAuthorImage.Image = global::bitwa_morska.Properties.Resources.about_author;
            this.aboutAuthorImage.Location = new System.Drawing.Point(0, 0);
            this.aboutAuthorImage.Name = "aboutAuthorImage";
            this.aboutAuthorImage.Size = new System.Drawing.Size(700, 500);
            this.aboutAuthorImage.TabIndex = 0;
            this.aboutAuthorImage.TabStop = false;
            // 
            // ReceivingThread
            // 
            this.ReceivingThread.WorkerSupportsCancellation = true;
            this.ReceivingThread.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ReceivingThread_DoWork);
            // 
            // tbIpAddress
            // 
            this.tbIpAddress.Location = new System.Drawing.Point(142, 497);
            this.tbIpAddress.Name = "tbIpAddress";
            this.tbIpAddress.Size = new System.Drawing.Size(200, 20);
            this.tbIpAddress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(204, 467);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Adres IP:";
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.menuPanel);
            this.Controls.Add(this.gamePanel);
            this.Controls.Add(this.aboutAuthorPanel);
            this.Controls.Add(this.howToPlayPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "mainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.mainForm_FormClosed);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.mainForm_KeyUp);
            this.helpPanel.ResumeLayout(false);
            this.helpPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.helpImage)).EndInit();
            this.infoPanel.ResumeLayout(false);
            this.infoPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerShipImage)).EndInit();
            this.statsPanel.ResumeLayout(false);
            this.statsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuPanel.ResumeLayout(false);
            this.menuPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nameOfGameImage)).EndInit();
            this.gamePanel.ResumeLayout(false);
            this.howToPlayPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.howToPlayImage)).EndInit();
            this.aboutAuthorPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.aboutAuthorImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel helpPanel;
        private System.Windows.Forms.Label helpHeaderLabel;
        private System.Windows.Forms.Panel infoPanel;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Label statsHeaderLabel;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Button menuExitButton;
        private System.Windows.Forms.Button menuCreditsButton;
        private System.Windows.Forms.Button menuHelpButton;
        private System.Windows.Forms.Button menuSingleplayerButton;
        private System.Windows.Forms.Button menuMultiplayerButton;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.PictureBox playerShipImage;

        public System.Windows.Forms.Panel getMap()
        {
            return this.mapPanel;
        }

        private System.Windows.Forms.Panel howToPlayPanel;
        private System.Windows.Forms.PictureBox howToPlayImage;
        private System.Windows.Forms.Button htp2menuButton;
        private System.Windows.Forms.Panel aboutAuthorPanel;
        private System.Windows.Forms.PictureBox aboutAuthorImage;
        private System.Windows.Forms.Button aa2menuButton;
        private System.Windows.Forms.PictureBox nameOfGameImage;
        private System.Windows.Forms.PictureBox helpImage;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.Label infoLabel2;
        private System.ComponentModel.BackgroundWorker ReceivingThread;
        public System.Windows.Forms.Label txtKillsValue;
        public System.Windows.Forms.Label txtDeathsValue;
        public System.Windows.Forms.Label txtPointsValue;
        private System.Windows.Forms.Label txtYellowKills;
        private System.Windows.Forms.Label txtVioletKills;
        private System.Windows.Forms.Label txtGreenKills;
        private System.Windows.Forms.Label txtRedKills;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label txtYellowPoints;
        private System.Windows.Forms.Label txtVioletPoints;
        private System.Windows.Forms.Label txtGreenPoints;
        private System.Windows.Forms.Label txtRedPoints;
        private System.Windows.Forms.Label txtYellowDeaths;
        private System.Windows.Forms.Label txtVioletDeaths;
        private System.Windows.Forms.Label txtGreenDeaths;
        private System.Windows.Forms.Label txtRedDeaths;
        private System.Windows.Forms.TextBox tbIpAddress;
        private System.Windows.Forms.Label label1;
    }
}

