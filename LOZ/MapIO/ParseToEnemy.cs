using System;
using System.IO;
using System.Collections.Generic;
using LOZ.Collision;
using Microsoft.Xna.Framework;
using LOZ.EnvironmentalClasses;
using LOZ.EnemyClass;
using System.Diagnostics;
using LOZ.DungeonClasses;


namespace LOZ.MapIO
{
    internal class ParseToEnemy
    {
        internal static void ParseEnemy(List<IGameObjects> obj, string lineRead) {

            //https://docs.microsoft.com/en-us/dotnet/api/system.string.trimend?view=net-6.0
            lineRead = lineRead.TrimEnd(',');

            //https://docs.microsoft.com/en-us/dotnet/api/system.string.replace?view=net-6.0
            lineRead = lineRead.Replace('\"', ' ');

            int countBefore = obj.Count - 1;
   
            while (lineRead.Length !=0) {
                int i = 0;

                //https://docs.microsoft.com/en-us/dotnet/api/system.string.substring?view=net-6.0
                //^substring method
                //https://docs.microsoft.com/en-us/dotnet/api/system.string.indexof?view=net-6.0
                //^indexOf 
                int closingParens = lineRead.IndexOf(')',i);
                string subStr = lineRead.Substring(i+1, closingParens);
                int openingParens = subStr.IndexOf('(', i);
                int commaPosition = subStr.IndexOf(',');

                //https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/types/how-to-convert-a-string-to-a-number
                //^ String to int
                int xCord = Int32.Parse(subStr.Substring(openingParens+1, commaPosition-openingParens-1));
                int yCord = Int32.Parse(subStr.Substring(commaPosition+1, closingParens-commaPosition-2));

                Debug.WriteLine("xCord: " + xCord + "\nyCord: " + yCord);
                int indexElement = ((yCord-1) * 12) + (xCord-1) + countBefore - 84 + 1;
                    
                Debug.WriteLine("indexElement: " + indexElement);
                IEnvironment block = (IEnvironment) obj[indexElement];
                Point spawnLocation = block.GetPosition();

                string enemyStr = subStr.Substring(i, openingParens);
                IGameObjects enemyType = ConvertEnemy(enemyStr, spawnLocation);
                obj.Add(enemyType);

                if (lineRead.Length > subStr.Length + 3)
                {
                    lineRead = lineRead.Substring(subStr.Length + 3);
                }
                else {
                    lineRead = lineRead.Substring(lineRead.Length);
                }
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
                case "spiketrap":
                    returnVal = new SpikeTrap(location);
                    break;
                case "dragon":
                    returnVal = new Dragon (location);
                    break;
                default:
                    returnVal = new Skeleton(location);
                    break;
            }

            return returnVal;

        }





    }
}
