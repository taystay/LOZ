using System;
using System.IO;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;

namespace LOZ.MapIO
{
    internal class ParseToEnemy
    {
        internal static void ParseEnemy(List<IGameObjects> obj, StreamReader reader) {
            string lineRead = reader.ReadLine();
            int lastParenthesis = lineRead.LastIndexOf(')');
            lineRead = lineRead.Remove(lastParenthesis + 1);
            int i = 0, commaPosition = 0;

            while (i < lineRead.Length) {
                commaPosition = lineRead.IndexOf(')') +1;
                string subStr = lineRead.Substring(i, commaPosition + 1);
                int parenthesis = subStr.IndexOf('(');

                int xCord = Convert.ToInt32(subStr.Substring(parenthesis, 1));
                int yCord = Convert.ToInt32(subStr.Substring(parenthesis+2, 1));

                int indexElement = yCord * 14 + xCord;
                IEnvironment block = (IEnvironment) obj[indexElement];
                Point spawnLocation = block.GetPosition();

               IGameObjects enemy = ConvertEnemy(subStr.Substring(i, parenthesis), spawnLocation);
                obj.Add(enemy);
                i += subStr.Length;
            }
        }

        private static IGameObjects ConvertEnemy(string s, Point location) {
            IGameObjects returnVal;
            switch (s) {
                case "skeleton":
                    returnVal = new Skeleton(location);
                    break;
                case "jelly":
                    returnVal = new Jelly(location);
                    break;
                case "bat":
                    returnVal = new Bat(location);
                    break;
                case "spikeTrap":
                    returnVal = new SpikeTrap(location);
                    break;
                case "dragon":
                    returnVal = new Dragon (location);
                    break;
                default:
                    returnVal = null;
                    break;
            }

            return returnVal;

        }





    }
}
