using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Sprint2.ControllerClasses
{
    public interface IController
    {
        public void Update(GameTime gametime);
    }
}
