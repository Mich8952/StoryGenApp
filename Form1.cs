using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace StoryGenForm
{
    public partial class Form1 : Form
    {
        string inputUser = "";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.FileName = @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python37_64\python.exe";
            var script = @"C:/Users/micha/source/repos/StoryGenForm/GenStory.py";
            var start_string = inputUser;
            psi.Arguments = $"\"{script}\" \"{start_string}\" \"{Form2.temp}\" \"{Form2.storyLen}\"";
            psi.UseShellExecute = false;
            psi.CreateNoWindow = true;
            psi.RedirectStandardOutput = true;
            psi.RedirectStandardError = true;

            var errors = "";
            var results = "";

            using (var process = System.Diagnostics.Process.Start(psi))
            {
                errors = process.StandardError.ReadToEnd();
                results = process.StandardOutput.ReadToEnd();
            }

            Console.WriteLine("ERRORS:");
            Console.WriteLine(errors);
            Console.WriteLine();
            Console.WriteLine("Results:");
            Console.WriteLine(results);

            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(@"C:/Users/micha/source/repos/StoryGenForm/sample.txt", FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();


            //string text = System.IO.File.ReadAllText(@"C:\Users\micha\source\repos\Covid-Predictor_VSC\sample.txt", Encoding.UTF8);
            //textBox2.Text = text;
            textBox2.Lines = lines;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            inputUser = text;
            Console.WriteLine(inputUser + " ");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            textBox2.ScrollBars = ScrollBars.Vertical;
        }

        private void settings_Click(object sender, EventArgs e)
        {
           
            Form2 frm = new Form2();
            frm.Show();
            //this.Close();
        }
    }
}
