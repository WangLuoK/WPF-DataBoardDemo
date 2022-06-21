using GalaSoft.MvvmLight.Ioc;
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
using DataBoard.Views;

namespace DataBoard
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += (s, e) => {

                container.Content = SimpleIoc.Default.GetInstance<IndexView>();
            };
        }

        private void RadioButton_Click(object sender, RoutedEventArgs e)
        {
            if (!(sender is RadioButton radioButton)) return;
            string uid = radioButton.Uid;
            if (string.IsNullOrEmpty(uid))
            {
                return;
            }
            switch (uid)
            {
                case "IndexView": 
                    container.Content = SimpleIoc.Default.GetInstance<IndexView>();
                    break;
                case "HistoryView":
                    container.Content = SimpleIoc.Default.GetInstance<HistoryView>(); 
                    break;
                case "SubLineView": 
                    container.Content = SimpleIoc.Default.GetInstance<SubLineView>();
                    break;
                case "StopTypeView":
                    container.Content = SimpleIoc.Default.GetInstance<StopTypeView>();
                    break;
                case "UserInfoView": 
                    container.Content = SimpleIoc.Default.GetInstance<UserInfoView>();
                    break;
                case "LineView": 
                    container.Content = SimpleIoc.Default.GetInstance<LineView>();
                    break;

                default:
                    break;
            }
        }
    }
}
