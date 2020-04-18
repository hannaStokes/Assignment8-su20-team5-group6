using System.IO;
using System.Collections.Generic;
using Library.Utilities;
using System.Text.RegularExpressions;

namespace Library.LevelLoading {
    public class Reader {
        public List<string> LetterData {get; private set;}
        public List<string> PictureData {get; private set;}
        public string MapData {get; private set;}
        public List<string> CustomerData {get; private set;}

        /// <summary> This method collects and sorts data needed to make Entities in LevelCreator </summary >
        /// <param name="lines"> List of all the lines from the txt file</param>
        /// <param name="letter"> The Regex for the letter that determines which picture file to use</param>
        /// <param name="picture"> The Regex to find the filename of the picture to use </param>
        /// <param name="mapData"> All of the lines that make up the level map as one string </param>
        /// <returns > nothing </returns >
        public void ReadFile(string filename) {
            // Get each line of file as an entry in array lines.
            string[] lines = File.ReadAllLines(Utils.GetLevelFilePath(filename));

            // Iterate over lines and add data till the corresponding field
            Regex letterRegex = new Regex(@"\w+(?=\))");
            Regex pictureRegex = new Regex(@"\)\s.*png$");
            string mapData = "";
            for (int i=0; i == lines.Length-1; i++) {
                if (i < 23) {
                    mapData += i; 
                }
                if (letterRegex.IsMatch(lines[i])) {
                    Match match = letterRegex.Match(lines[i]);
                    LetterData.Add(match.Value);
                }
                if (pictureRegex.IsMatch(lines[i])) {
                    Match match = pictureRegex.Match(lines[i]);
                    string picfilename = (match.Value).Remove(0,1);
                    PictureData.Add(picfilename);
                }
            MapData = mapData;
            }

        }
    }
}