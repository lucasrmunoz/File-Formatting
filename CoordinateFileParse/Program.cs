using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoordinateFileParse
{
    class Program
    {
        static void Main(string[] args)
        {
            string sData;
            string[] sSplitData;
            try
            {
                sData = File.ReadAllText("data.txt");
                sData = sData.Replace(" ", Environment.NewLine).Replace(Environment.NewLine, "|"); // works on all OS i.e. windows it adds \\n

                sSplitData = sData.Split('|');

                StringBuilder sb = new StringBuilder();

                for(int i = 0, j = 0; i < sSplitData.Count(); i++, j++)
                {
                    if (j == 5)
                    {
                        sb.AppendLine();
                        j = 0;
                    }
                    sb.Append("[").Append(sSplitData[i]).Append("], ");
                }

                File.WriteAllText("NewData.txt", sb.ToString().Substring(0, sb.ToString().Length-2));
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }

            Console.WriteLine("Complete");
            Console.ReadLine();
        }
    }
}
