using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace AdServerInvalidAdControlKeys
{
    class Program
    {
        static void Main(string[] args)
        {
            String dirName = ConfigurationManager.AppSettings["DirName"];
            String outFileName = ConfigurationManager.AppSettings["OutFileName"];
            processFiles(dirName, outFileName);
        }

        static void processFiles(string filePath, string outFileName)
        {
            try {
                Dictionary<string,int> keyDictionary = new Dictionary<string,int>();
                string[] filesToRead = Directory.GetFiles(filePath);
                foreach (string file in filesToRead)
                {
                    using (StreamReader sr = new StreamReader(file))
                    {
                        while (sr.Peek() >= 0)
                        {
                            String line = sr.ReadLine();
                            char[] splitChars = { ','};
                            string[] stringList = line.Split(splitChars);
                            // comma separated line (need to pull out 4,6,7 tokens)
                            String keys = String.Format("{0}, {1}, {2}", stringList.ElementAt(3), stringList.ElementAt(5), stringList.ElementAt(6));
                            addKeyToDictionary(keyDictionary, keys);
                        }
                    }
                }
                printOutResults(keyDictionary, outFileName);
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
            }
        }

        static void addKeyToDictionary(Dictionary<string,int> theDictionary, string theKey)
        {
            int currentCount = 0;
            theDictionary.TryGetValue(theKey, out currentCount);
            theDictionary[theKey] = currentCount + 1;
        }

        static void printOutResults(Dictionary<string, int> theDictionary, string outFileName)
        {
            int total = theDictionary.Values.Sum();
            Console.WriteLine(total);

            using (StreamWriter sw = File.CreateText(outFileName))
            {
                sw.WriteLine("CampId,Creative Id,Placement Id,,Total");
                var list = theDictionary.Keys.ToList();
                list.Sort();
                foreach (var key in list)
                {
                    String fullLine = String.Format("{0}, ,{1}", key, theDictionary[key]);
                    sw.WriteLine(fullLine);
                }
            }	

        }

    }
}
