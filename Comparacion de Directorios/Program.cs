using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Newtonsoft.Json;

namespace Comparacion_de_Directorios
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {
                //Read paths in appsetting.json file
                var builder = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                var Configuration = builder.Build();

                string pathSource = Configuration["Paths:DirPathSource"];
                string pathTarget = Configuration["Paths:DirPathTarget"];
                //string pathTxtFile = Configuration["Paths:TxtFile"];
                string strStartDate = Configuration["Paths:StartDate"];
                string strEndDateString = Configuration["Paths:EndDate"];

                DateTime startDate = DateTime.Parse(strStartDate);
                DateTime endDate = DateTime.Parse(strEndDateString);

                ////Add DateTime to flat file name in order to make different from another
                //FileInfo file = new FileInfo(pathTxtFile);
                //var fileName = file.Name.Replace(file.Extension, "") + DateTime.Now.ToString("yyyyMMddhhmm") + file.Extension;
                //var pathTxtFileDate = file.DirectoryName + @"\" + fileName;

                //Instatiate the class with responsability to read the directory
                DirectoryReader directoryReader = new DirectoryReader(pathSource, pathTarget, startDate, endDate);

                //directoryReader.ReadSourceDirectory(); 

                directoryReader.ReadSourceDirectoryWithLinq();
                Log.WriteResultSearchedFile("<<<--- Proceso Ejecutado Exitosamente--->>>");
            }
            catch (Exception ex)
            {

                Log.WriteResultSearchedFile(ex.Message);
            }

            


        }
    }
 

}
