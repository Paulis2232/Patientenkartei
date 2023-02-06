//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

using System.Windows;
using System.IO; //Input/Output 
using System.Net.Sockets;
using System.Text;

namespace Patientenkartei1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string DIR_PATH = @"C:\Users\Yassine\Desktop\test\";
        public static string FILE_EXT = ".txt";
        public MainWindow()
        {
            InitializeComponent();

        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            string content = textBoxContent.Text;
            string filename = textBoxFilename.Text;
            //string dirPath = @"C:\Users\Yassine\Desktop\test\" + filename;
            using (FileStream fs = File.Create(DIR_PATH + filename + FILE_EXT))
            {
                ///<summary>
                ///
                ///</summary>

                byte[] contenConvertedToByte = Encoding.ASCII.GetBytes(content);
                fs.Write(contenConvertedToByte,0,contenConvertedToByte.Length);
            }
            MessageBox.Show("Datei wurde angelegt.");

            
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string filename = textBoxFilename.Text;
            using (FileStream fs = File.OpenRead(DIR_PATH + filename + FILE_EXT))
            {
                using(StreamReader sr = new StreamReader(fs))
                {
                    string content = sr.ReadToEnd();
                    textBoxContent.Text = content;
                }
                //die gleiche Methode wie man mit Hilfer der StreamWriter was schreiben...
                //using(StreamWriter sw = new StreamWriter(fs))
                //{
                //    string content = fs.Write(sw);

                //}
            }
        }
    }
}
