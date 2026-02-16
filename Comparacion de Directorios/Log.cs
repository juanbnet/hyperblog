using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Comparacion_de_Directorios
{
    class Log
    {
        static string TxtFile { get; set; }
        public Log()
        {
            //Read paths in appsetting.json file
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            var Configuration = builder.Build();

            string pathTxtFile = Configuration["Paths:TxtFile"];

            //Add DateTime to flat file name in order to make different from another
            FileInfo file = new FileInfo(pathTxtFile);
            var fileName = file.Name.Replace(file.Extension, "") + DateTime.Now.ToString("yyyyMMddhhmm") + file.Extension;
            TxtFile = file.DirectoryName + @"\" + fileName;
        }



        public static void WriteResultSearchedFile(string line)
        {          
            
            using (StreamWriter writer = new StreamWriter(TxtFile, true))
            {
                writer.WriteLine(line);
            }
        }
    }
}
