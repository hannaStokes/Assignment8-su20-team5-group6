using DIKUArcade.Entities;
using System.Text.RegularExpressions;
using System;
using DIKUArcade.Math;
using DIKUArcade.Graphics;

namespace Library.LevelLoading {
    public class LevelCreator {
        // add fields as you see fit
        private Reader reader;

        private EntityContainer LevelBlocks;

        public LevelCreator() {
            reader = new Reader();
        }
        
        public Level CreateLevel(string levelname) {
            Level level = new Level();
            reader.ReadFile(levelname);

            float mapX = 0.0f;
            float mapY = 1.0f;
            Regex whiteSpaceRegex = new Regex(@"\w");

            //the position x and y for the placement of the pictures/entities change each iteration
            foreach (char elm in reader.MapData) {
                if ( mapX < 0.975f ) {
                        mapX += 0.025f;
                    } else {
                        mapX = 0.0f;
                        mapY -= 0.04347826f;
                    
                    }
                //if the character is not a whitespace then an Entity is added to the EntityContainer
                if (!(whiteSpaceRegex.IsMatch(Char.ToString(elm)))) {
                    int index = (reader.LetterData).IndexOf(Char.ToString(elm));
                    StationaryShape buildingBlock = new StationaryShape(new Vec2F(0.04347826f, 0.025f), new Vec2F(mapX, mapY));
                    Image image = new Image(reader.PictureData[index]);
                    LevelBlocks.AddStationaryEntity(buildingBlock, image);
                }
            }

            return level;
        }
    }
}