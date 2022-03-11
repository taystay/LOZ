using System;
using System.Collections.Generic;
using System.Text;

namespace LOZ.GameState
{
    public struct Point3D
    {
        public int X;
        public int Y;
        public int Z;

        public Point3D(int x, int y, int z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        public Point3D(int x, int y)
        {
            this.X = x;
            this.Y = y;
            this.Z = 0;
        }

        public void changeBy(int dx, int dy, int dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }
    }
}
