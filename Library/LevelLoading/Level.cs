using DIKUArcade.Entities;

namespace Library.LevelLoading {
    public class Level {
        // Add fields as needed
        private EntityContainer obstacles;
        private Player player; // Make Player class

        public Level() { }

        public void UpdateLevelLogic() {
           // all update logic here
        }

        public void RenderLevelObjects() {
            // all rendering here
            // obstacles.RenderEntities()
        }
    }
}
