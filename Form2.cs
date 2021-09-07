using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StoryGenForm
{
    
    public partial class Form2 : Form
    {
        public static double temp;
        public static double storyLen;

        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
          
            if (trackBar1.Value == 0) temp = 0.05;
            if (trackBar1.Value == 1) temp = 0.1;
            if (trackBar1.Value == 2) temp = 0.2;
            if (trackBar1.Value == 3) temp = 0.3;
            if (trackBar1.Value == 4) temp = 0.4;
            if (trackBar1.Value == 5) temp = 0.5;
            if (trackBar1.Value == 6) temp = 0.6;
            if (trackBar1.Value == 7) temp = 0.7;
            if (trackBar1.Value == 8) temp = 0.8;
            if (trackBar1.Value == 9) temp = 0.9;
            if (trackBar1.Value == 10) temp = 1.0;
            Console.Write(temp + " ");
            
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            if (trackBar2.Value == 0) storyLen = 1000.0;
            if (trackBar2.Value == 1) storyLen = 2000.0;
            if (trackBar2.Value == 2) storyLen = 3000.0;
            if (trackBar2.Value == 3) storyLen = 4000.0;
            if (trackBar2.Value == 4) storyLen = 5000.0;
            if (trackBar2.Value == 5) storyLen = 6000.0;
            if (trackBar2.Value == 6) storyLen = 7000.0;
            if (trackBar2.Value == 7) storyLen = 8000.0;
            if (trackBar2.Value == 8) storyLen = 9000.0;
            if (trackBar2.Value == 9) storyLen = 10000.0;
            if (trackBar2.Value == 10) storyLen = 11000.0;
            Console.Write(storyLen);
        }
    }
}
