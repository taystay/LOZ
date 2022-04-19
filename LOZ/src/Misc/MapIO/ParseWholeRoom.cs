using System.IO;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.DungeonClasses;

namespace LOZ.MapIO
{
    internal class ParseWholeRoom
    {
        internal static void ParseOWDoc(List<IGameObjects> obj, StreamReader reader, int numlines)
        {
            List<string[]> lines = new List<string[]>();
            for (int i = 0; i < numlines; i++)
                lines.Add(reader.ReadLine().Split(','));

            Point start = Info.Inside.Location;
            
            start.X += Info.BlockWidth / 2;
            start.Y += Info.BlockWidth / 2;
            for (int i = 0; i < lines[0].Length - 12; i++)
                start.X -= Info.BlockWidth / 2;
            for (int i = 0; i < lines.Count - 7; i++)
                start.Y -= Info.BlockWidth / 2;
            int startX = start.X;

            foreach (string[] line in lines)
            {
                if (line == null) continue;
                foreach(string s in line)
                {
                    obj.Add(ConvertBlock.BlockConvert(s, start.X, start.Y));
                    start.X += Info.BlockWidth;
                }
                start.Y += Info.BlockWidth;
                start.X = startX;
            }
        }

        internal static void ParseWhole(List<IGameObjects> obj, StreamReader reader)
        {
            int xIndex = 0, yIndex = 0;
            Point location = Info.Map.Location;
            location.X += 24;
            location.Y += 24;
            int leftSide = location.X;
            string lineRead = reader.ReadLine();
            while (yIndex != 11) 
            {
                string[] words = lineRead.Split(',');
                for (int i = 0; i < words.Length; i++)
                {
                    obj.Add(ConvertBlock.BlockConvert(words[xIndex], location.X, location.Y));
                    location.X += 48;
                    xIndex++;

                    if (xIndex == words.Length)
                    {
                        location.Y += 48;
                        location.X = leftSide;
                    }
                }
                xIndex = 0;
                yIndex++;
                lineRead = reader.ReadLine();
            }
        }
    }
}
