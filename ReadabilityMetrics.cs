using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Drawing;
using PluginContracts;
using OutputHelperLib;


namespace ReadabilityMetrics
{
    public class ReadabilityMetrics : Plugin
    {


        public string[] InputType { get; } = { "String" };
        public string OutputType { get; } = "OutputArray";

        public Dictionary<int, string> OutputHeaderData { get; set; } = new Dictionary<int, string>() {{0, "LetterCount"},
                                                                                                        {1, "WordCount"},
                                                                                                        {2, "AverageSyllablesPerWord"},
                                                                                                        {3, "SentenceCount"},
                                                                                                        {4, "AverageWordsPerSentence"},
                                                                                                        {5, "ReadingTime"},
                                                                                                        {6, "SpeakingTime"},
                                                                                                        {7, "FleschKincaidReadingEase"},
                                                                                                        {8, "FleschKincaidGradeLevel"},
                                                                                                        {9, "GunningFogScore"},
                                                                                                        {10, "ColemanLiauIndex"},
                                                                                                        {11, "SMOGIndex"},
                                                                                                        {12, "AutomatedReadabilityIndex"} };
        public bool InheritHeader { get; } = false;

        #region Plugin Details and Info

        public string PluginName { get; } = "Readability Metrics";
        public string PluginType { get; } = "Language Analysis";
        public string PluginVersion { get; } = "1.0.2";
        public string PluginAuthor { get; } = "Ryan L. Boyd (ryan@ryanboyd.io)";
        public string PluginDescription { get; } = "Generate information about text including syllable counts and Flesch-Kincaid, Gunning-Fog, Coleman-Liau, SMOG and Automated Readability scores.";
        public bool TopLevel { get; } = false;
        public string PluginTutorial { get; } = "https://youtu.be/LrgelPznPhA";

        public Icon GetPluginIcon
        {
            get
            {
                return Properties.Resources.icon;
            }
        }

        #endregion



        public void ChangeSettings()
        {

            MessageBox.Show("This plugin does not have any settings to change.",
                    "No Settings", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

        }





        public Payload RunPlugin(Payload Input)
        {



            Payload pData = new Payload();
            pData.FileID = Input.FileID;
            pData.SegmentID = Input.SegmentID;

            for (int i = 0; i < Input.StringList.Count; i++)
            {

                TextStatistics Readability = TextStatistics.Parse(Input.StringList[i]);

                string[] Output_String = new string[13];
                if (Readability.LetterCount > 0)
                {
                    Output_String = new string[13] {
                                                            Readability.LetterCount.ToString(),
                                                            Readability.WordCount.ToString(),
                                                            Readability.AverageSyllablesPerWord.ToString(),
                                                            Readability.SentenceCount.ToString(),
                                                            Readability.AverageWordsPerSentence.ToString(),
                                                            Readability.ReadingTime().ToString(),
                                                            Readability.SpeakingTime().ToString(),
                                                            Readability.FleschKincaidReadingEase().ToString(),
                                                            Readability.FleschKincaidGradeLevel().ToString(),
                                                            Readability.GunningFogScore().ToString(),
                                                            Readability.ColemanLiauIndex().ToString(),
                                                            Readability.SMOGIndex().ToString(),
                                                            Readability.AutomatedReadabilityIndex().ToString()
                                                        };
                }
                else
                {
                    Output_String = new string[13] {
                                                            //we'll just show that there are zero letters and zero words, and 
                                                            //everything else can just be blank if there aren't any letters here.
                                                            Readability.LetterCount.ToString(),
                                                            "0", "","","","","","","","","","",""
                                                        };
                }


                pData.SegmentNumber.Add(Input.SegmentNumber[i]);
                pData.StringArrayList.Add(Output_String);


            }

            return (pData);



        }

        public bool InspectSettings()
        {
            return true;
        }



        public void Initialize() { }

        public Payload FinishUp(Payload Input)
        {
            return (Input);
        }



        #region Import/Export Settings
        public void ImportSettings(Dictionary<string, string> SettingsDict)
        {

        }

        public Dictionary<string, string> ExportSettings(bool suppressWarnings)
        {
            Dictionary<string, string> SettingsDict = new Dictionary<string, string>();
            return (SettingsDict);
        }
        #endregion

    }
}
