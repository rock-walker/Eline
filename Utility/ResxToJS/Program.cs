using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Resources;
using System.IO;
using System.Globalization;
using System.Collections;
using Newtonsoft.Json;
using System.Configuration;

namespace resourcesTest
{
    class Program
    {
        private static readonly string DefaultNameSpace = "jsres";
        private static string LogFile ="";
        static void Main(string[] args)
        {
            try
            {
                string dir = Directory.GetParent(args[0]).Parent.FullName;
                LogFile = Path.Combine(dir, ConfigurationManager.AppSettings["LogFile"]);
                if (File.Exists(LogFile))
                    File.Delete(LogFile);
                WriteLog(string.Format("[Convert] [Start] [Time: {0}]", DateTime.Now));
                string outFileName = ConfigurationManager.AppSettings["outputFileName"];
                string outDirectory = Path.Combine(dir, ConfigurationManager.AppSettings["directoryPath"], outFileName);
                File.WriteAllText(outDirectory, "if (typeof (elapp) == 'undefined') elapp = {};" + Environment.NewLine);
                Dictionary<string, List<string>> namspaces = new Dictionary<string, List<string>>();
                string[] resources = ConfigurationManager.AppSettings["inputFiles"].Split(';');
                foreach (var x in resources)
                {
                    string[] array = x.Split(':');
                    string key = string.Empty;
                    string val = string.Empty;
                    if (array.Length < 2 || string.IsNullOrEmpty(array[0]))
                    {
                        key = DefaultNameSpace;
                        val = array[0].Trim();
                    }
                    else
                    {
                        key = array[0].Trim();
                        val = array[1].Trim();
                    }
                    if (!namspaces.ContainsKey(key))
                    {
                        var l = new List<string>();
                        namspaces.Add(key, l);
                    }
                    foreach (var y in val.Split(','))
                    {
                        namspaces[key].Add(Path.Combine(args[0], y));
                    }

                }
                ConverResources(namspaces, outDirectory);
                WriteLog(string.Format("[Convert] [End] [Time: {0}]", DateTime.Now));
            }
            catch (Exception e)
            {
                WriteLog(string.Format("[Convert] [Exception] [Time: {0}]", e.Message));
                WriteLog(string.Format("[Convert] [StackTrace] [Time: {0}]", e.StackTrace));
            }
        }
        static void WriteLog(string msg)
        {
            File.AppendAllText(LogFile,msg + Environment.NewLine);
        }
        static void ConverResources(Dictionary<string, List<string>> namspaces, string dir)
        {
            foreach (var x in namspaces)
            {
                List<ResXResourceReader> lReader = new List<ResXResourceReader>();
                x.Value.ForEach(_ => lReader.Add(new ResXResourceReader(_)));
                Dictionary<string, string> content = ToDictionary(lReader);
                WriteToJS(dir, content, x.Key);
            }
        }
        public static Dictionary<string, string> ToDictionary(List<ResXResourceReader> resFiles)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (var resFile in resFiles)
            {
                IDictionaryEnumerator dict = resFile.GetEnumerator();
                while (dict.MoveNext())
                {
                    var key = dict.Key.ToString();
                    if (result.ContainsKey(key))
                    {
                        System.Console.WriteLine("DUPLICATE: ID \"{0}\" already defined before.", key);
                    }
                    result[dict.Key.ToString()] = dict.Value.ToString();
                }
            }
            return result;
        }
        public static void WriteToJS(string path, Dictionary<string, string> content, string name)
        {
            WriteLog(string.Format("[WriteToJS] [Statr] [Namespace: {0}]", name));
            string json = JsonConvert.SerializeObject(content, Formatting.Indented);
            string toWrite = "elapp." + name + "= " + json.ToString() + ";" + Environment.NewLine;
            File.AppendAllText(path, toWrite);
            WriteLog(string.Format("[WriteToJS] [End] [Namespace: {0}]", name));
        }
    }
}
