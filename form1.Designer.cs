namespace Lab5b
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Doc = new System.Windows.Forms.GroupBox();
            this.docpics = new System.Windows.Forms.PictureBox();
            this.DoctorSelection = new System.Windows.Forms.ComboBox();
            this.Doctor = new System.Windows.Forms.Label();
            this.playedby = new System.Windows.Forms.Label();
            this.year = new System.Windows.Forms.Label();
            this.fullep = new System.Windows.Forms.TextBox();
            this.age = new System.Windows.Forms.TextBox();
            this.series = new System.Windows.Forms.Label();
            this.seriesbox = new System.Windows.Forms.TextBox();
            this.ageatstart = new System.Windows.Forms.Label();
            this.yea = new System.Windows.Forms.TextBox();
            this.Firstfull = new System.Windows.Forms.Label();
            this.played = new System.Windows.Forms.TextBox();
            this.linq = new System.Windows.Forms.RadioButton();
            this.sql = new System.Windows.Forms.RadioButton();
            this.Companion = new System.Windows.Forms.ListBox();
            this.companions = new System.Windows.Forms.GroupBox();
            this.image = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Phoneroom = new System.Windows.Forms.ImageList(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.message = new System.Windows.Forms.Label();
            this.Quit = new System.Windows.Forms.Button();
            this.docImages = new System.Windows.Forms.ImageList(this.components);
            this.Doc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docpics)).BeginInit();
            this.companions.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Doc
            // 
            this.Doc.Controls.Add(this.docpics);
            this.Doc.Controls.Add(this.DoctorSelection);
            this.Doc.Controls.Add(this.Doctor);
            this.Doc.Controls.Add(this.playedby);
            this.Doc.Controls.Add(this.year);
            this.Doc.Controls.Add(this.fullep);
            this.Doc.Controls.Add(this.age);
            this.Doc.Controls.Add(this.series);
            this.Doc.Controls.Add(this.seriesbox);
            this.Doc.Controls.Add(this.ageatstart);
            this.Doc.Controls.Add(this.yea);
            this.Doc.Controls.Add(this.Firstfull);
            this.Doc.Controls.Add(this.played);
            this.Doc.Location = new System.Drawing.Point(25, 38);
            this.Doc.Name = "Doc";
            this.Doc.Size = new System.Drawing.Size(301, 325);
            this.Doc.TabIndex = 0;
            this.Doc.TabStop = false;
            this.Doc.Text = "The Doctor";
            // 
            // docpics
            // 
            this.docpics.Location = new System.Drawing.Point(159, 171);
            this.docpics.Name = "docpics";
            this.docpics.Size = new System.Drawing.Size(126, 139);
            this.docpics.TabIndex = 14;
            this.docpics.TabStop = false;
            this.docpics.Click += new System.EventHandler(this.docpics_Click);
            // 
            // DoctorSelection
            // 
            this.DoctorSelection.FormattingEnabled = true;
            this.DoctorSelection.Location = new System.Drawing.Point(164, 23);
            this.DoctorSelection.Name = "DoctorSelection";
            this.DoctorSelection.Size = new System.Drawing.Size(121, 21);
            this.DoctorSelection.TabIndex = 13;
            this.DoctorSelection.SelectedIndexChanged += new System.EventHandler(this.DoctorSelection_SelectedIndexChanged);
            // 
            // Doctor
            // 
            this.Doctor.AutoSize = true;
            this.Doctor.Location = new System.Drawing.Point(15, 31);
            this.Doctor.Name = "Doctor";
            this.Doctor.Size = new System.Drawing.Size(42, 13);
            this.Doctor.TabIndex = 2;
            this.Doctor.Text = "Docter:";
            // 
            // playedby
            // 
            this.playedby.AutoSize = true;
            this.playedby.Location = new System.Drawing.Point(15, 57);
            this.playedby.Name = "playedby";
            this.playedby.Size = new System.Drawing.Size(56, 13);
            this.playedby.TabIndex = 1;
            this.playedby.Text = "Played by:";
            // 
            // year
            // 
            this.year.AutoSize = true;
            this.year.Location = new System.Drawing.Point(18, 83);
            this.year.Name = "year";
            this.year.Size = new System.Drawing.Size(32, 13);
            this.year.TabIndex = 3;
            this.year.Text = "Year:";
            // 
            // fullep
            // 
            this.fullep.Location = new System.Drawing.Point(6, 187);
            this.fullep.Name = "fullep";
            this.fullep.Size = new System.Drawing.Size(147, 20);
            this.fullep.TabIndex = 9;
            // 
            // age
            // 
            this.age.Location = new System.Drawing.Point(164, 128);
            this.age.Name = "age";
            this.age.Size = new System.Drawing.Size(100, 20);
            this.age.TabIndex = 12;
            // 
            // series
            // 
            this.series.AutoSize = true;
            this.series.Location = new System.Drawing.Point(18, 109);
            this.series.Name = "series";
            this.series.Size = new System.Drawing.Size(39, 13);
            this.series.TabIndex = 4;
            this.series.Text = "Series:";
            // 
            // seriesbox
            // 
            this.seriesbox.Location = new System.Drawing.Point(164, 102);
            this.seriesbox.Name = "seriesbox";
            this.seriesbox.Size = new System.Drawing.Size(100, 20);
            this.seriesbox.TabIndex = 11;
            // 
            // ageatstart
            // 
            this.ageatstart.AutoSize = true;
            this.ageatstart.Location = new System.Drawing.Point(18, 139);
            this.ageatstart.Name = "ageatstart";
            this.ageatstart.Size = new System.Drawing.Size(64, 13);
            this.ageatstart.TabIndex = 5;
            this.ageatstart.Text = "Age at start:";
            this.ageatstart.Click += new System.EventHandler(this.label5_Click);
            // 
            // yea
            // 
            this.yea.Location = new System.Drawing.Point(164, 76);
            this.yea.Name = "yea";
            this.yea.Size = new System.Drawing.Size(100, 20);
            this.yea.TabIndex = 10;
            // 
            // Firstfull
            // 
            this.Firstfull.AutoSize = true;
            this.Firstfull.Location = new System.Drawing.Point(18, 171);
            this.Firstfull.Name = "Firstfull";
            this.Firstfull.Size = new System.Drawing.Size(86, 13);
            this.Firstfull.TabIndex = 6;
            this.Firstfull.Text = "First Full Episode";
            // 
            // played
            // 
            this.played.Location = new System.Drawing.Point(165, 50);
            this.played.Name = "played";
            this.played.Size = new System.Drawing.Size(100, 20);
            this.played.TabIndex = 8;
            this.played.TextChanged += new System.EventHandler(this.played_TextChanged);
            // 
            // linq
            // 
            this.linq.AutoSize = true;
            this.linq.Location = new System.Drawing.Point(6, 52);
            this.linq.Name = "linq";
            this.linq.Size = new System.Drawing.Size(103, 17);
            this.linq.TabIndex = 13;
            this.linq.TabStop = true;
            this.linq.Text = "Solve using Linq";
            this.linq.UseVisualStyleBackColor = true;
            // 
            // sql
            // 
            this.sql.AutoSize = true;
            this.sql.Location = new System.Drawing.Point(6, 19);
            this.sql.Name = "sql";
            this.sql.Size = new System.Drawing.Size(104, 17);
            this.sql.TabIndex = 14;
            this.sql.TabStop = true;
            this.sql.Text = "Solve using SQL";
            this.sql.UseVisualStyleBackColor = true;
            // 
            // Companion
            // 
            this.Companion.FormattingEnabled = true;
            this.Companion.Location = new System.Drawing.Point(16, 40);
            this.Companion.Name = "Companion";
            this.Companion.Size = new System.Drawing.Size(206, 251);
            this.Companion.TabIndex = 15;
            // 
            // companions
            // 
            this.companions.Controls.Add(this.image);
            this.companions.Controls.Add(this.groupBox1);
            this.companions.Controls.Add(this.Companion);
            this.companions.Location = new System.Drawing.Point(359, 38);
            this.companions.Name = "companions";
            this.companions.Size = new System.Drawing.Size(388, 342);
            this.companions.TabIndex = 16;
            this.companions.TabStop = false;
            this.companions.Text = "Companions and their first episode with this Doctor:";
            this.companions.Enter += new System.EventHandler(this.companions_Enter);
            // 
            // image
            // 
            this.image.Location = new System.Drawing.Point(228, 40);
            this.image.Name = "image";
            this.image.Size = new System.Drawing.Size(145, 195);
            this.image.TabIndex = 18;
            this.image.Paint += new System.Windows.Forms.PaintEventHandler(this.image_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sql);
            this.groupBox1.Controls.Add(this.linq);
            this.groupBox1.Location = new System.Drawing.Point(264, 241);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(118, 84);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Query";
            // 
            // Phoneroom
            // 
            this.Phoneroom.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Phoneroom.ImageStream")));
            this.Phoneroom.TransparentColor = System.Drawing.Color.Transparent;
            this.Phoneroom.Images.SetKeyName(0, "tardis.png");
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // message
            // 
            this.message.AutoSize = true;
            this.message.Location = new System.Drawing.Point(38, 412);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(37, 13);
            this.message.TabIndex = 17;
            this.message.Text = "          ";
            this.message.Click += new System.EventHandler(this.message_Click);
            // 
            // Quit
            // 
            this.Quit.Location = new System.Drawing.Point(4, 9);
            this.Quit.Name = "Quit";
            this.Quit.Size = new System.Drawing.Size(75, 23);
            this.Quit.TabIndex = 18;
            this.Quit.Text = "Quit";
            this.Quit.UseVisualStyleBackColor = true;
            this.Quit.Click += new System.EventHandler(this.Quit_Click);
            // 
            // docImages
            // 
            this.docImages.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.docImages.ImageSize = new System.Drawing.Size(16, 16);
            this.docImages.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Quit);
            this.Controls.Add(this.message);
            this.Controls.Add(this.companions);
            this.Controls.Add(this.Doc);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Doc.ResumeLayout(false);
            this.Doc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.docpics)).EndInit();
            this.companions.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox Doc;
        private System.Windows.Forms.Label playedby;
        private System.Windows.Forms.Label Doctor;
        private System.Windows.Forms.Label year;
        private System.Windows.Forms.Label series;
        private System.Windows.Forms.Label ageatstart;
        private System.Windows.Forms.Label Firstfull;
        private System.Windows.Forms.TextBox played;
        private System.Windows.Forms.TextBox fullep;
        private System.Windows.Forms.TextBox yea;
        private System.Windows.Forms.TextBox seriesbox;
        private System.Windows.Forms.TextBox age;
        private System.Windows.Forms.RadioButton linq;
        private System.Windows.Forms.RadioButton sql;
        private System.Windows.Forms.ListBox Companion;
        private System.Windows.Forms.GroupBox companions;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel image;
        private System.Windows.Forms.ImageList Phoneroom;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button Quit;
        private System.Windows.Forms.ComboBox DoctorSelection;
        private System.Windows.Forms.PictureBox docpics;
        private System.Windows.Forms.ImageList docImages;
    }
}

