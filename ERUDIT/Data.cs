using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ERUDIT
{
    static class Data
    {
        public static List<Point> RedPoints = new List<Point> {
            new Point(0,0), new Point(0,7), new Point(0,14),
            new Point(7,0), new Point(7,7), new Point(7,14),
            new Point(14,0), new Point(14,7), new Point(14,14)
        };
        public static List<Point> GreenPoints = new List<Point> {
            new Point(0,3), new Point(0,11),
            new Point(2,6), new Point(2,8),
            new Point(3,0), new Point(3,7), new Point(3,14),
            new Point(6,2), new Point(6,6), new Point(6,8), new Point(6,12),
            new Point(7,3), new Point(7,11),
            new Point(8,2), new Point(8,6), new Point(8,8), new Point(8,12),
            new Point(11,0), new Point(11,7), new Point(11,14),
            new Point(12,6), new Point(12,8),
            new Point(14,3), new Point(14,11),
        };
        public static List<Point> YellowPoints = new List<Point>
        {
            new Point(1,5), new Point(1,9),
            new Point(5,1), new Point(5,13),
            new Point(9,1), new Point(9,13),
            new Point(13,5), new Point(13,9),
        };
        public static List<Point> BluePoints = new List<Point> {
            new Point(1,1), new Point(2,2), new Point(3,3), new Point(4,4), 
            new Point(1,13), new Point(2,12), new Point(3,11), new Point(4,10),
            new Point(13,1), new Point(12,2), new Point(11,3), new Point(10,4),
            new Point(13,13), new Point(12,12), new Point(11,11), new Point(10,10)
        };

        public static Dictionary<char, int> litterCost = new Dictionary<char, int>();
        public static Dictionary<char, int> litterCount = new Dictionary<char, int>();
        public static HashSet<string> PossibleWords = new HashSet<string>();

        public static bool isFirstWord = true;
        public static bool CenterInterconnected = false;
        public static bool interconnectedWithAnotherWord = false;
        public static Random rand = new Random(DateTime.Now.Millisecond);

        static Data()
        {
            StreamReader input = new StreamReader("litters.txt");
            for (int i = 0; i < 33; ++i)
            {
                string[] str = input.ReadLine().Trim().Split(' ');
                litterCost.Add(str[0][0], int.Parse(str[2]));
                litterCount.Add(str[0][0], int.Parse(str[1]));
            }
            input.Close();
            StreamReader anotherInput = new StreamReader("words.txt");
            while (!anotherInput.EndOfStream)
                try
                {
                    PossibleWords.Add(anotherInput.ReadLine());
                }
                catch { }
            anotherInput.Close();
        }
        public static int b = 131;
        public static char createRandomNumber()
        {
            int a = rand.Next() % b;
            int score = 0;

            foreach (var item in litterCount)
            {
                if (score <= a && a < (score + item.Value))
                {
                    litterCount[item.Key]--;
                    b--;
                    return item.Key;
                }
                score += item.Value;
            }
            return 'а';
        }
    }
}
