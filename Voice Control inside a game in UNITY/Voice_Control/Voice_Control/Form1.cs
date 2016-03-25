using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Speech.Recognition;
using System.Globalization;
using System.IO;

namespace Voice_Control
{
    public partial class Form1 : Form
    {

        public int flag = 0;

        public Form1()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {

            try
            {
                // Create a new SpeechRecognitionEngine instance.
                SpeechRecognizer recognizer = new SpeechRecognizer();

                // Create a simple grammar that recognizes "red", "green", or "blue".
                Choices commands = new Choices();
                commands.Add(new string[] { "1", "b" });

                // Create a GrammarBuilder object and append the Choices object.
                GrammarBuilder gb = new GrammarBuilder();
                gb.Append(commands);

                // Create the Grammar instance and load it into the speech recognition engine.
                Grammar g = new Grammar(gb);
                recognizer.LoadGrammar(g);

                // Register a handler for the SpeechRecognized event.
                recognizer.SpeechRecognized +=
                  new EventHandler<SpeechRecognizedEventArgs>(sre_SpeechRecognized);
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Windows Speech Recognizer must be started before running Voice Recognition", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Windows Speech Recognizer must be started before running Voice Recognition", "Error", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                Application.Exit();
            }
            }

        void sre_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            //MessageBox.Show("Speech recognized: " + e.Result.Text);
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (e.Result.Text == "1")
            {
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\jump_voiceControl.tmp"))
                {
                }
            }
            if (e.Result.Text == "b")
            {
                using (StreamWriter outputFile = new StreamWriter(mydocpath + @"\fire_voiceControl.tmp"))
                { 
                }
            }
           
        }

        
    }
}


