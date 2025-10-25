using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
///
/// Program: Doctors and Companions sort
/// 
///
namespace Lab5b
{
    /// <summary>
    /// This the class the runs the window form
    /// </summary>
    public partial class Form1 : Form
    {

        /*
         * These are three global objects to store the doctors, companions, and episodes
         */
        List<Doctor> ListOfDoctor = new List<Doctor>();
        List<Companion> ListOfCompanion = new List<Companion>();
        List<Episode> ListOfEpisode = new List<Episode>();

        
        
        List<Image> pics = new List<Image>();
        /// <summary>
        /// This is the main constructor of the program.
        /// It extracts data from the sql database.
        /// </summary>
        public Form1()
        {
            InitializeComponent();            

            /*
             * These are three connections for three command actions
             */
            SqlConnection Connection1;
            SqlConnection Connection2;
            SqlConnection Connection3;
            /*
             * This is the connections 
             * string. 
             */
            string connectionString = @"Data Source=.\SQLEXPRESS;Initial Catalog=COMP10204_Lab5;Integrated Security=True";
            /*
             * Try and catch statement meant to locate any errors in the sql database or code.
             */
            try
            {
                Connection1 = new SqlConnection();
                Connection1.ConnectionString = connectionString;
                Connection1.Open();

                Connection2 = new SqlConnection();
                Connection2.ConnectionString = connectionString;
                Connection2.Open();

                Connection3 = new SqlConnection();
                Connection3.ConnectionString = connectionString;
                Connection3.Open();
            }
            catch (Exception ex)
            {
                message.Text = ex.Message;
                return;
            }

            message.Text = "Connected Successfully!";

            /*
             * These are commands to retrieve values within the database.
             */

            SqlCommand sqlcommandCOM = new SqlCommand("SELECT  [NAME],[ACTOR],[DOCTORID],[STORYID] FROM[COMP10204_LAB5].[dbo].[COMPANION]", Connection1);
            SqlCommand sqlcommandEP = new SqlCommand("SELECT  [STORYID],[SEASON],[SEASONYEAR],[TITLE] FROM[COMP10204_LAB5].[dbo].[EPISODE]", Connection2);
            SqlCommand sqlcommandDOC = new SqlCommand("SELECT [DOCTORID],[ACTOR],[SERIES],[AGE],[DEBUT],[PICTURE] FROM[COMP10204_LAB5].[dbo].[DOCTOR]", Connection3);
            /*
             * A try and catch statment meant to detect and error while reading the code
             */
            try
            
            {
                /*
                 * All Read lines being instantiated 
                 * to read the command lines above.
                 */
                SqlDataReader reader1 = sqlcommandCOM.ExecuteReader();
                SqlDataReader reader2 = sqlcommandEP.ExecuteReader();
                SqlDataReader reader3 = sqlcommandDOC.ExecuteReader();
                /*
                 * While loop that reads the sql database
                 */
                while (reader1.Read())
                {
                    string result = "";


                    for (int i = 0; i < reader1.FieldCount; i++)
                    {
                        var field = reader1[i]; //This stores object
                        result = result + field.ToString() + ",";

                    }
                    string[] line = result.Split(','); //Split string in order to save them individually in the companion, episode, and doctor objects.
                    byte[] img = null;

                    Companion thiscompanion = new Companion(line[0], line[1], line[2], line[3]); // Saves string in objects
                    
                    ListOfCompanion.Add(thiscompanion); //saves object in list

                }
                reader1.Close(); //closes reader

                /*
                * While loop that reads the sql database
                */
                while (reader2.Read())
                {
                    string result = "";


                    for (int i = 0; i < reader2.FieldCount; i++)
                    {
                        var field = reader2[i]; //This stores object
                        result = result + field.ToString() + ",";

                    }
                    string[] line = result.Split(','); //Split string in order to save them individually in the companion, episode, and doctor objects.

                    Episode thisepisode = new Episode(line[0], line[1], line[2], line[3]); // Saves string in objects

                    ListOfEpisode.Add(thisepisode); //saves object in list

                }
                reader2.Close(); //closes reader

                while (reader3.Read())
                {
                    string result = "";


                    for (int i = 0; i < reader3.FieldCount-1; i++)
                    {
                        var field = reader3[i]; //This stores object
                        result = result + field.ToString() + ",";                        
                    }
                    byte[]img= (byte[])(reader3[5]);
                    string[] line = result.Split(','); //Split string in order to save them individually in the companion, episode, and doctor objects.

                    Doctor thisdoctor = new Doctor(line[0], line[1], line[2], line[3], line[4], img);
                    
                    ListOfDoctor.Add(thisdoctor); //saves object in list

                }
                reader3.Close(); //closes reader
            }
            /*
             * Catch statments to catch errors
             */
            catch (SqlException ex)
            {
                message.Text = ex.Message;

            }
            catch (Exception ex)
            {
                message.Text = ex.Message;

            }
            /*
             * Close connection to sql statements
             */
             
            Connection1.Close(); 
            Connection2.Close();
            Connection3.Close();

            for (int i = 0; i < ListOfDoctor.Count; i++)
            {
                DoctorSelection.Items.Add(ListOfDoctor[i].id); //Loop to add docter id to listbox 
            }



        }
        private byte[]ConvertImageToBinary(Image img)
        {
            using(MemoryStream ms = new MemoryStream())
            {
                return ms.ToArray();
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void companions_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method instantiates graphics used to plant picture on window form
        /// Returns nothing
        /// </summary>
        private void image_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = image.CreateGraphics(); //Uses graphics on image
            Phoneroom.Draw(g, new Point(30, 40), 0); //Plants image on window form 

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            

        }
        

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void Quit_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void message_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Method changes display of window form as user choices doctor id
        /// Searches through List of objects (companion, episode, and doctor) to display relevant information in combobox
        /// Uses switch statement and returns nothing
        /// </summary>
        private void DoctorSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            string ind; // checks and compares correct index in doctor objects
            string storyid=""; //Used to find appropriate story id to match
            string actor = ""; // Used to compare actor and store value in combobox
            string name = ""; // Used to store value of name combobox
            int lowyear = 0; // used for lowest year for each doctor
            fullep.Clear(); //clears textbox
            yea.Clear();//clears textbox
            played.Clear();//clears textbox
            Companion.Items.Clear();//clears combobox
            seriesbox.Clear();//clears textbox
            age.Clear();//clears textbox
            
            /*
             * Switch statement made to change display 
             * depending on users choice in dropdown selection.
             */
            switch (DoctorSelection.SelectedItem.ToString())
            {                
                case "1":
                    ind = "1";
                    /*
                     * Sets textboxes to relevant 
                     * information depending on index
                     */
                    played.Text = ListOfDoctor[0].actor;
                    seriesbox.Text = ListOfDoctor[0].series;
                    age.Text = ListOfDoctor[0].age;
                    
                    /*
                     * list of titles and years to find first full episode
                     */
                    List<String> ListOfTitles = new List<String>();
                    List<int> ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                            /*
                             * loops through to find matching story id 
                            */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    int lowest = ListOfYears[0];
                    string nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms = new MemoryStream(ListOfDoctor[0].picture);
                    docpics.Image = Image.FromStream(ms);
                    break;
                case "2":
                    ind = "2";

                    played.Text = ListOfDoctor[1].actor;
                    seriesbox.Text = ListOfDoctor[1].series;
                    age.Text = ListOfDoctor[1].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms2 = new MemoryStream(ListOfDoctor[1].picture);
                    docpics.Image = Image.FromStream(ms2);
                    break;
                case "3":
                    ind = "3";

                    played.Text = ListOfDoctor[2].actor;
                    seriesbox.Text = ListOfDoctor[2].series;
                    age.Text = ListOfDoctor[2].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms3 = new MemoryStream(ListOfDoctor[2].picture);
                    docpics.Image = Image.FromStream(ms3);
                    break;
                case "4":
                    ind = "4";

                    played.Text = ListOfDoctor[3].actor;
                    seriesbox.Text = ListOfDoctor[3].series;
                    age.Text = ListOfDoctor[3].age;

                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }

                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString();
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest;
                    MemoryStream ms4 = new MemoryStream(ListOfDoctor[3].picture);
                    docpics.Image = Image.FromStream(ms4);
                    break;
                case "5":
                    ind = "5";
                    played.Text = ListOfDoctor[4].actor;
                    seriesbox.Text = ListOfDoctor[4].series;
                    age.Text = ListOfDoctor[4].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms5 = new MemoryStream(ListOfDoctor[4].picture);
                    docpics.Image = Image.FromStream(ms5);
                    break;
                case "6":
                    ind = "6";

                    played.Text = ListOfDoctor[5].actor;
                    seriesbox.Text = ListOfDoctor[5].series;
                    age.Text = ListOfDoctor[5].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms6 = new MemoryStream(ListOfDoctor[5].picture);
                    docpics.Image = Image.FromStream(ms6);
                    break;
                case "7":
                    ind = "7";

                    played.Text = ListOfDoctor[6].actor;
                    seriesbox.Text = ListOfDoctor[6].series;
                    age.Text = ListOfDoctor[6].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[ListOfTitles.Count-1];
                    nameoflowest = ListOfTitles[ListOfTitles.Count-1];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms7 = new MemoryStream(ListOfDoctor[6].picture);
                    docpics.Image = Image.FromStream(ms7);
                    break;
                case "8":
                    ind = "8";

                    played.Text = ListOfDoctor[7].actor;
                    seriesbox.Text = ListOfDoctor[7].series;
                    age.Text = ListOfDoctor[7].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms8 = new MemoryStream(ListOfDoctor[7].picture);
                    docpics.Image = Image.FromStream(ms8);
                    break;
                case "9":
                    ind = "9";

                    played.Text = ListOfDoctor[8].actor;
                    seriesbox.Text = ListOfDoctor[8].series;
                    age.Text = ListOfDoctor[8].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms9 = new MemoryStream(ListOfDoctor[8].picture);
                    docpics.Image = Image.FromStream(ms9);
                    break;
                case "10":
                    ind = "10";

                    played.Text = ListOfDoctor[9].actor;
                    seriesbox.Text = ListOfDoctor[9].series;
                    age.Text = ListOfDoctor[9].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms10 = new MemoryStream(ListOfDoctor[9].picture);
                    docpics.Image = Image.FromStream(ms10);
                    break;
                case "11":
                    ind = "11";

                    played.Text = ListOfDoctor[10].actor;
                    seriesbox.Text = ListOfDoctor[10].series;
                    age.Text = ListOfDoctor[10].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = ListOfTitles.Count-1; k >-1 ; k--)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms11 = new MemoryStream(ListOfDoctor[10].picture);
                    docpics.Image = Image.FromStream(ms11);
                    break;
                case "12":
                    ind = "12";

                    played.Text = ListOfDoctor[11].actor;
                    seriesbox.Text = ListOfDoctor[11].series;
                    age.Text = ListOfDoctor[11].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms12 = new MemoryStream(ListOfDoctor[11].picture);
                    docpics.Image = Image.FromStream(ms12);
                    break;
                
                case "13":
                    ind = "13";

                    played.Text = ListOfDoctor[12].actor;
                    seriesbox.Text = ListOfDoctor[12].series;
                    age.Text = ListOfDoctor[12].age;

                    /*
                     * list of titles and years to find first full episode
                     */
                    ListOfTitles = new List<String>();
                    ListOfYears = new List<int>();
                    /*
                     * Loop through companion objects to id matching to 
                     */
                    for (int i = 0; i < ListOfCompanion.Count; i++)
                    {
                        if (ListOfCompanion[i].doctorid == ind)
                        {
                            storyid = ListOfCompanion[i].storyid;
                            actor = ListOfCompanion[i].actor;
                            name = ListOfCompanion[i].name;
                            for (int j = 0; j < ListOfEpisode.Count; j++)
                            {
                                /*
                                 * loops through to find matching story id 
                                */
                                if (ListOfEpisode[j].storyid == storyid)
                                {
                                    /*
                                     * If statements to find earliest year
                                     */
                                    if (lowyear == 0)
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    if ((lowyear > Int32.Parse(ListOfEpisode[j].seasonyear)))
                                    {
                                        lowyear = Int32.Parse(ListOfEpisode[j].seasonyear);
                                    }
                                    /*
                                     * Adds items to combobox 
                                     */
                                    Companion.Items.Add(name + " " + "(" + actor + ")");
                                    Companion.Items.Add(ListOfEpisode[j].title + " (" + ListOfEpisode[j].seasonyear + ")");
                                    Companion.Items.Add(" ");
                                    /*
                                     * Adds  objects of title and years lists to compare
                                     */
                                    ListOfTitles.Add(ListOfEpisode[j].title);
                                    ListOfYears.Add(Int32.Parse(ListOfEpisode[j].seasonyear));

                                }
                            }

                        }
                    }
                    yea.Text = lowyear.ToString(); //sets year textbox to earliest year
                    /*
                     * Uses loop to find first episode
                     */
                    lowest = ListOfYears[0];
                    nameoflowest = ListOfTitles[0];
                    for (int k = 0; k < ListOfTitles.Count; k++)
                    {

                        if (lowest > ListOfYears[k])
                        {
                            lowest = ListOfYears[k];
                            nameoflowest = ListOfTitles[k];

                        }
                    }
                    fullep.Text = nameoflowest; //sets textbox as first episode
                    MemoryStream ms13 = new MemoryStream(ListOfDoctor[14].picture);
                    docpics.Image = Image.FromStream(ms13);
                    break;
            }
            
        }

        private void played_TextChanged(object sender, EventArgs e)
        {

        }

        private void docpics_Click(object sender, EventArgs e)
        {
            
        }
    }
}
