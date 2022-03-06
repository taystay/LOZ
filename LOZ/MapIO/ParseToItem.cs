using System;
using System.Collections.Generic;
using LOZ.Collision;
using LOZ.ItemsClasses;
using LOZ.EnvironmentalClasses;
using Microsoft.Xna.Framework;

namespace LOZ.MapIO
{
    internal class ParseToItem
    {
        internal static void ParseItem(List<IGameObjects> obj, string lineRead)
        {

            //https://docs.microsoft.com/en-us/dotnet/api/system.string.trimend?view=net-6.0
            lineRead = lineRead.TrimEnd(',');

            //https://docs.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-6.0
            lineRead = lineRead.Replace('\"', ' ');

            int countBefore = obj.Count - 1;

            while (lineRead.Length != 0)
            {
                int i = 0;

                int closingParens = lineRead.IndexOf(')', i);
                string subStr = lineRead.Substring(i + 1, closingParens);
                int openingParens = subStr.IndexOf('(', i);
                int commaPosition = subStr.IndexOf(',');

                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                //^ String to int
                int xCord = Int32.Parse(subStr.Substring(openingParens + 1, commaPosition - openingParens - 1));
                int yCord = Int32.Parse(subStr.Substring(commaPosition + 1, closingParens - commaPosition - 2));

                int indexElement = ((yCord - 1) * 12) + (xCord - 1) + countBefore - 84 + 1;

                IEnvironment block = (IEnvironment)obj[indexElement];
                Point spawnLocation = block.GetPosition();

                string enemyStr = subStr.Substring(i, openingParens);
                IGameObjects enemyType = ConvertItem(enemyStr, spawnLocation);
                obj.Add(enemyType);

                if (lineRead.Length > subStr.Length + 3)
                {
                    lineRead = lineRead.Substring(subStr.Length + 3);
                }
                else
                {
                    lineRead = lineRead.Substring(lineRead.Length);
                }
            }
        }

        private static IGameObjects ConvertItem(string s, Point location)
        {
            IGameObjects returnVal;
            switch (s)
            {
                case "bow":
                    returnVal = new Bow(location);
                    break;
                case "clock":
                    returnVal = new Clock(location);
                    break;
                case "compass":
                    returnVal = new Compass(location);
                    break;
                case "fireitem":
                    returnVal = new FireItem(location);
                    break;
                case "heart":
                    returnVal = new Heart(location);
                    break;
                case "heartcontainer":
                    returnVal = new HeartContainer(location);
                    break;
                case "key":
                    returnVal = new Key(location);
                    break;
                case "Map":
                    returnVal = new Map(location);
                    break;
                case "rupee":
                    returnVal = new Rupee(location);
                    break;
                case "triforce":
                    returnVal = new Triforce(location);
                    break;
                case "arrowitem":
                    returnVal = new ArrowItem(location);
                    break;
                default:
                    returnVal = new Triforce(location);
                    break;
            }

            return returnVal;

        }
    }
}
