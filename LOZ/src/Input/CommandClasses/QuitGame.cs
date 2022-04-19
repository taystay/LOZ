

namespace LOZ.CommandClasses
{
    class QuitGame : ICommand
    {
        Game1 GameObj;
        public QuitGame(Game1 gameObj) =>
            GameObj = gameObj;
        public void execute() => GameObj.Exit();
    }
}
