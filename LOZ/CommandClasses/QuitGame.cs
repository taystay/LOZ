using Sprint2.GameState;

namespace Sprint2.CommandClasses
{
    class QuitGame : ICommand
    {
        Game1 GameObj;
        public QuitGame(Game1 gameObj)
        {
            GameObj = gameObj;
        }
        public void execute()
        {
            GameObj.Exit();
        }
    }
}
