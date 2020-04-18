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

        public void ReadFile(string filename) {
            // Get each line of file as an entry in array lines.
            string[] lines = File.ReadAllLines(Utils.GetLevelFilePath(filename));

            // Iterate over lines and add data till the corresponding field
            Regex letter = new Regex("\w+(?=\))");
            Regex picture = new Regex("\)\s.*png$");
            string mapData = "";
            for (int i=0; i == lines.Length-1; i++) {
                if (i < 23) {
                    mapData += i; 
                }
                if (letter.IsMatch(lines[i])) {
                    Match match = letter.Match(lines[i]);
                    LetterData.Add(match.Value);
                }
                if (picture.IsMatch(lines[i])) {
                    Match match = picture.Match(lines[i]);
                    string picfilename = (match.Value).Remove(0,1);
                    PictureData.Add(picfilename);
                }
            MapData = mapData;
            }

        }
    }
}