using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        [DllImport("winmm.dll")]
        private static extern int mciSendString(string MciComando, string MciRetorno, int MciRetornoLeng, int CallBack);
        string musica = "";
        string music1 = "";
        

        public Form1()
        {
            InitializeComponent();
            button1.Enabled = false;
            button2.Enabled = false;
            button3.Enabled = false;
        }
        


        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog instru = new OpenFileDialog();
            instru.Filter = "MP3|*.mp3";
            if (instru.ShowDialog() == DialogResult.OK)
            {
                music1 = instru.FileName;
            }
            button4.Enabled = false;
            button1.Enabled = true;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            mciSendString("play " + music1, null, 0, 0);
            mciSendString("open new type waveaudio alias Som", null, 0, 0);
            mciSendString("record Som", null, 0, 0);
            button1.Enabled = false;
            button2.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mciSendString("stop " + music1, null, 0, 0);
            mciSendString("pause Som", null, 0, 0);
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "wave|*.wav";
            if (save.ShowDialog() == DialogResult.OK)
            {
                mciSendString("save Som " + save.FileName, null, 0, 0);
                mciSendString("close Som", null, 0, 0);
            }
            button2.Enabled = false;
            button3.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            if (musica == "")
            {
                OpenFileDialog open = new OpenFileDialog();
                open.Filter = "Wave|*.wav";
                if (open.ShowDialog() == DialogResult.OK) {
                    musica = open.FileName;
                }
            }
            mciSendString("play " + musica, null, 0, 0);
        }

        
    }
}
