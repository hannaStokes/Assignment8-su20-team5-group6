using System.IO;
using DIKUArcade.EventBus;
using DIKUArcade.Graphics;
using DIKUArcade.Math;
using DIKUArcade.Entities;
using Library.Utilities;

namespace Library {
    public class Player : IGameEventProcessor<object> {
        public Entity Entity {get; private set;}

        public Player(DynamicShape shape, IBaseImage image) {
            Entity = new Entity(shape, image);
        }

        private void KeyPress(string key) {
            switch(key) {
                case "KEY_ESCAPE":
                    EventBus.GetBus().RegisterEvent(
                        GameEventFactory<object>.CreateGameEventForAllProcessors(
                            GameEventType.WindowEvent, this, "CLOSE_WINDOW", "", ""));
                    break;
                case "KEY_RIGHT":
                    Direction(new Vec2F(0.01f, 0.0f));
                    break;
                case "KEY_LEFT":
                    Direction(new Vec2F(-0.01f, 0.0f));
                    break;
                case "KEY_UP":
                    Direction(new Vec2F(0.00f, 0.1f));
                    break;
                case "KEY_DOWN":
                    Direction(new Vec2F(0.00f, -0.1f));
                    break;
            }
        }
            
        private void KeyRelease(string key) {
            switch(key) {
                case "KEY_RIGHT":
                case "KEY_LEFT":
                    Direction(new Vec2F(0.0f, 0.0f));;
                    break;
            }
        }

        public void ProcessEvent(GameEventType eventType, GameEvent<object> gameEvent) {
            switch (gameEvent.Parameter1) {
                case "KEY_PRESS":
                    KeyPress(gameEvent.Message);
                    break;
                case "KEY_RELEASE":
                    KeyRelease(gameEvent.Message);
                    break;    
            }
        }

        public void Direction(Vec2F vector) {
            DynamicShape dShape = Entity.Shape.AsDynamicShape();
            dShape.ChangeDirection(vector);
        }

        public void Move() {
            DynamicShape dShape = Entity.Shape.AsDynamicShape();
            if ((dShape.Position.X + dShape.Direction.X) > 0.0f && (dShape.Position.X + dShape.Direction.X) < 0.9f ) {
                dShape.Move();
            }
        }
    }
}