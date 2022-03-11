using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using LOZ.Collision;

namespace LOZ.EnvironmentalClasses
{
    public interface IEnvironment :IGameObjects
    {
        public Point Position { get; set; }
        public bool Pushable { get; set; }
        public Point GetPosition();
    }
}
