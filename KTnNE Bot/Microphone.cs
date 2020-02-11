using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KTnNE_Bot
{
    class Microphone
    {
        WaveInEvent waveIn;

        public Microphone()
        {
            waveIn = new WaveInEvent();
            waveIn.DeviceNumber = 0;
            waveIn.WaveFormat = new WaveFormat(16000, 1);

            waveIn.DataAvailable += (s, a) => WaveInDataAv(s, a);
        }

        public void StartRecording()
        {
            waveIn.StartRecording();
        }

        public void StopRecording()
        {
            waveIn.StopRecording();
        }

        private void WaveInDataAv(object s, WaveInEventArgs a)
        {
            Recognizer.longerAudioList.AddRange(a.Buffer);
        }

        public void Close()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
        }
    }
}
