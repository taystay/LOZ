namespace LOZ.Room
{
    public struct Point3D
    {
        public int X;
        public int Y;
        public int Z;

        public Point3D(int x, int y, int z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(int x, int y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public void changeBy(int dx, int dy, int dz)
        {
            X += dx;
            Y += dy;
            Z += dz;
        }

        public static Point3D operator +(Point3D s1, Point3D s2) =>
            new Point3D(s1.X + s2.X, s1.Y + s2.Y, s1.Z + s2.Z);           
    }
}
