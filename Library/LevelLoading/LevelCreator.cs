namespace Library.LevelLoading {
    public class LevelCreator {
        // add fields as you see fit
        private Reader reader;

        public LevelCreator() {
            reader = new Reader();
        }
        
        public Level CreateLevel(string levelname) {
            // Create the Level here
            Level level = new Level();

            // Gather all the information/objects the levels needs here.
            reader.ReadFile(levelname);

            return level;
        }
    }
}