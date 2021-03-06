﻿using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using Grpc.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Google.Cloud.Speech.V1.RecognitionConfig.Types;

namespace KTnNE_Bot
{
    class GoogleSpeech 
    {

        SpeechClient client;
        static RecognitionConfig config;
        static SpeechContext context;
        

        public GoogleSpeech()
        {
            var credential = GoogleCredential.FromFile("C:/GoogleCreds.json").CreateScoped(SpeechClient.DefaultScopes);
            var channel = new Grpc.Core.Channel(SpeechClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());
            client = SpeechClient.Create(channel);

            context = new SpeechContext();

            config = new RecognitionConfig
            {
                Encoding = AudioEncoding.Linear16,
                SampleRateHertz = 16000,
                LanguageCode = LanguageCodes.English.UnitedStates,
                Model = "command_and_search"
            };
            config.Metadata = new RecognitionMetadata();
            config.Metadata.InteractionType = RecognitionMetadata.Types.InteractionType.VoiceCommand;
            config.SpeechContexts.Add(context);
        }

        public static void SetContext(List<string> contexts)
        {
            context.Phrases.Clear();
            config.SpeechContexts.Clear();
            context.Phrases.AddRange(contexts);
            context.Phrases.Add("strike");
            context.Phrases.Add("stop");
            context.Phrases.Add("menu");
            config.SpeechContexts.Add(context);
        }

        public string Recognize()
        {
            if (Recognizer.longerAudioList.Count < 3200) return "ERROR";
            RecognitionAudio audio5 = RecognitionAudio.FromBytes(Recognizer.longerAudioList.ToArray());
            RecognizeResponse response = client.Recognize(config, audio5);
            Console.WriteLine(response);
            Recognizer.longerAudioList.Clear();

            try
            {
                return response.Results[0].Alternatives[0].Transcript;
            }
            catch (Exception ex)
            {
                return "ERROR";
            }
        }
    }
}
