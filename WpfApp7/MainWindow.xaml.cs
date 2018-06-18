using System;
using System.IO;
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
using Microsoft.Win32;

namespace WpfApp7
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Image image = null;
        BitmapImage btimage = null;
        Button buttonn = null;
        List<String> paths = new List<String>();
        System.Windows.Forms.FolderBrowserDialog dialog = new System.Windows.Forms.FolderBrowserDialog();
        //OpenFileDialog dialog = new OpenFileDialog();
    
       
        public MainWindow()
        {
            InitializeComponent();
        }

        private void expander1_Expanded(object sender, RoutedEventArgs e)
        {
            expander1.Content = mainImage.Source.ToString();
        }
        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            image.Source = ((sender as Button).Content as Image).Source;

        }
        private void Button_open_Click(object sender, RoutedEventArgs e)
        {
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                paths.AddRange(Directory.GetFiles(dialog.SelectedPath));

                foreach (var item in paths)
                {
                    btimage = new BitmapImage();
                    buttonn = new Button();
                    image = new Image();
                    btimage.BeginInit();
                    btimage.UriSource = new Uri(item, UriKind.Absolute);
                    btimage.EndInit();
                    image.Source = btimage;
                    stack_panel1.Children.Add(buttonn);
                    buttonn.Content = image;
                    buttonn.Click += Btn_Click;
                }

            }
        }

        private void expander1_Collapsed(object sender, RoutedEventArgs e)
        {

        }

        private void Button_close_Click_(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
