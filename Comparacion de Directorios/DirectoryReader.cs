using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace Comparacion_de_Directorios
{
    class DirectoryReader
    {
        string DirPathSource { get; set; }
        string DirPathTarget { get; set; }      
        DateTime startDate { get; set; }
        DateTime endDate { get; set; }

        Log log = new Log();
        public DirectoryReader(string dirpathsource, string dirpathtarget, DateTime startdate, DateTime enddate)
        {
            this.DirPathSource = dirpathsource;
            this.DirPathTarget = dirpathtarget;   
            this.startDate = startdate;
            this.endDate = enddate;
        }
        public void ReadSourceDirectoryWithLinq()
        {
            //Get list of files

            try
            {

                if (Directory.Exists(DirPathSource))
                {

                    string line = "";

                    var query = from file in new DirectoryInfo(DirPathSource).GetFiles()
                                where file.CreationTime >= startDate && file.CreationTime <= endDate
                                orderby file.CreationTime descending
                                select file;

                    Log.WriteResultSearchedFile("FILE NAME,FOUND,CREATION TIME");

                    foreach (var file in query)
                    {
                        //Search file in target directory
                        line = $"{file.Name},{SearchFileInTargetDirectory(file.Name)},{file.CreationTime}";
                        Log.WriteResultSearchedFile(line);
                    }

                }
                else
                {
                    Log.WriteResultSearchedFile($"Directorio Fuente INVALIDO: {DirPathSource}");
                }
            }
            catch (Exception ex)
            {

                Log.WriteResultSearchedFile(ex.Message);
            }


        }

        public void ReadSourceDirectory()
        {
            //Get list of files

            if (Directory.Exists(DirPathSource))
            {
                string[] arrFiles = Directory.GetFiles(DirPathSource);

                string line = "";

                Log.WriteResultSearchedFile("File Name,Found");

                foreach (string f in arrFiles)
                {
                    FileInfo objFile = new FileInfo(f);

                    //Search file in target directory
                    line = $"{objFile.Name},{SearchFileInTargetDirectory(objFile.Name)}";
                    Log.WriteResultSearchedFile(line);
                }
            }
            else
            {
                Log.WriteResultSearchedFile($"Directorio Fuente INVALIDO: {DirPathSource}");
            }

        }

        public bool SearchFileInTargetDirectory(string fileToSerch)
        {
            bool searchedFile= true;

            if(Directory.Exists(DirPathTarget))
            {
                var res = Directory.GetFiles(DirPathTarget, fileToSerch);

                if (res == null || res.Length == 0)
                {
                    searchedFile = false;
                }                
            }
            else
            {
                Log.WriteResultSearchedFile($"Directorio Destino INVALIDO: {DirPathSource}");
            }

            return searchedFile;
        }
        
    }
}
