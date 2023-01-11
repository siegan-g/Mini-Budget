using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace PROG_POE_Final
{
    //Class provides txt file read/write functionality>>
    public enum Directory
    {
        Expenses,
        Income
    }

    class FileIO
    {
        public void FileWrite(Directory directory, string name,string value)
        {
            string filename = String.Format("{0:MMMM}__{1}.txt", DateTime.Now,name);
            string path = Path.Combine(directory.ToString(), filename);

            try
            {
                using
                    StreamWriter s = new StreamWriter(path);
                {
                    s.WriteLine(value);                    
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Whoops something went wrong: could not write");
            }
        }      
        
        public string FileRead(Directory directory, string name)
        {
            string filename = String.Format("{0:MMMM}__{1}.txt", DateTime.Now, name);
            string path = Path.Combine(directory.ToString(), filename);
            string textbDetails = "🤷‍♂️";         
            List<string> textList = new List<string>();
            string line = "";
            try
            {
                using
                    StreamReader r = new StreamReader(path);
                {
                    
                    while ((line = r.ReadLine()) != null)
                    {
                        textList.Add(line);
                    }
                }
            }
            catch (FileNotFoundException) 
            {
              //  MessageBox.Show("File not found for this month...creating now","Press OK to continue",MessageBoxButton.OK,MessageBoxImage.Information);                
            }
            textbDetails=string.Join(",", textList);
            return textbDetails;

        }

        public void DestroyFile(Directory directory,string name)
        {
            string filename = String.Format("{0:MMMM}__{1}.txt", DateTime.Now, name);
            string path = Path.Combine(directory.ToString(), filename);
            File.Delete(path);
        }
    }
}
