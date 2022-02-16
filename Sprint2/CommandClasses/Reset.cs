using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class Reset : ICommand
    {
        Game1 gameObject;
        public Reset(Game1 gameObj) {
            gameObject = gameObj;
    
        }

        public void execute() {
            GameObjects.Blocks.SetToDefault();
            GameObjects.Enemies.SetToDefault();
            GameObjects.Items.SetToDefault();
        }
    }
}
