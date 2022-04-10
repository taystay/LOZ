namespace LOZ.Inventory
{
    public struct itemCount
    {
        public int rupees;
        public int keys;
        public int bombs;

        public itemCount(int rupeeCount, int keyCount, int bombCount)
        {
            rupees = rupeeCount;
            keys = keyCount;
            bombs = bombCount;
        }
    }
}
