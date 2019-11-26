using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace KTnNE_Bot
{
    public partial class Form1 : Form
    {
        public static Form1 form;
        bool alreadyPressed = false;
        Microphone mic;
        TextSynthesizer syn;
        GoogleSpeech speech;
        Interpreter interpreter;

        public Form1()
        {
            InitializeComponent();
            form = this;
            mic = new Microphone();
            syn = new TextSynthesizer();
            speech = new GoogleSpeech();
            interpreter = new Interpreter();

            var keybaordHook = new KeyboardHook();
            keybaordHook.OnKeyPressed += HotKeyManager_HotKeyPressed;
            keybaordHook.OnKeyUnpressed += HotKeyManager_HotKeyReleased;
        }


        private void HotKeyManager_HotKeyPressed(object sender, Keys key)
        {
            if(key == Keys.X)
            {
                if (!alreadyPressed)
                {
                    alreadyPressed = true;
                    GoogleSpeech.longerAudioList = new List<byte>();
                    richTextBox1.Text += "Start ";
                    mic.StartRecording();
                    
                }
            }
        }

        private void HotKeyManager_HotKeyReleased(object sender, Keys key)
        {
            if (key == Keys.X)
            {
                mic.StopRecording();
                alreadyPressed = false;
                string response = speech.Recognize();
                richTextBox1.Text += response;
                interpreter.Interpret(response);
                richTextBox1.Text +=  " Stop\n";
                
            }
        }

        public void AddToText(string text)
        {
            form.Invoke(new EventHandler(delegate
            {
                richTextBox1.Text += text;
            }));
        }

        

        private void ButtonStart_Click(object sender, EventArgs e)
        {
            GoogleSpeech.longerAudioList = new List<byte>();
            mic.StartRecording();
            richTextBox1.Text += "Start";
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            
            mic.StopRecording();
            richTextBox1.Text += "Stop";
            GoogleSpeech.longerAudioList.Clear();
            GoogleSpeech.longerAudioList = null;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            syn.Close();
            mic.Close();
        }
    }
}
