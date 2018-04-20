using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Forms;
using System.IO;

namespace ImageViewerWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> names;
        List<string> pathes;
        List<string> infoItems;
        public MainWindow()
        {
            InitializeComponent();
            names = new List<string>();
            pathes = new List<string>();
            infoItems = new List<string>();
        }

        private void open_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string path = fbd.SelectedPath;
                DirectoryInfo di = new DirectoryInfo(path);
                FileInfo[] files1 = di.GetFiles("*.jpg");
                FileInfo[] files2 = di.GetFiles("*.png");

                names.Clear();
                pathes.Clear();
                foreach (FileInfo f in files1)
                {
                    names.Add(f.Name);
                    pathes.Add(f.FullName);
                    infoItems.Add($"{f.Length} bytes; {f.LastWriteTime}");
                }

                foreach (FileInfo f in files2)
                {
                    names.Add(f.Name);
                    pathes.Add(f.FullName);
                    infoItems.Add($"{f.Length} bytes; {f.LastWriteTime}");
                }
                filesList.ItemsSource = names;
            }
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {
            //if(image!=null)
            //{
            //    BitmapImage img = new BitmapImage();
            //    img.UriSource = new Uri("\\Images\\logo.jpg");
            //    image.Source = img;
            //}
            //filesList.Items.Clear();
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void proga_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show("Здесь будет краткое описание о программе");
        }

        private void filesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int k = filesList.SelectedIndex;
            BitmapImage img = new BitmapImage();
            img.BeginInit();
            img.UriSource = new Uri(pathes[k]);
            img.EndInit();
            image.Source = img;

            progress.Maximum = filesList.Items.Count;
            progress.Value = k+1;
        }

        private void zoom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            double v = zoom.Value;
            Transformer t = (Transformer)this.Resources["transformerID"];
            t.Scale = v / 100;
        }

        private void next_Click(object sender, RoutedEventArgs e)
        {
            filesList.SelectedIndex++;

        }

        private void back_Click(object sender, RoutedEventArgs e)
        {
            if (filesList.SelectedIndex > 0)
                filesList.SelectedIndex--;

        }
    }
}
