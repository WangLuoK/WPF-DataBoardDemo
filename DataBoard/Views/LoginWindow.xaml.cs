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
using System.Windows.Shapes;
using DataBoard.Windows;
using GalaSoft.MvvmLight.Messaging;
using GalaSoft.MvvmLight.Views;

namespace DataBoard.Views
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window, IDialogService
    {
        public LoginWindow()
        {
            InitializeComponent();
           
        }

        public Task ShowError(string message, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task ShowError(Exception error, string title, string buttonText, Action afterHideCallback)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 弹框-自定义窗体
        /// </summary>
        /// <param name="message">窗体名称</param>
        /// <param name="title"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Task ShowMessage(string message, string title)
        {
            switch (message)
            {
                case "AddLineWindow": new AddLineWindow().ShowDialog();break;
                case "EditLineWindow":new EditLineWindow().ShowDialog();break;
                case "AddStopTypeWindow": new AddStopTypeWindow().ShowDialog(); break;
                case "EditStopTypeWindow": new EditStopTypeWindow().ShowDialog(); break;
                case "AddSubLineWindow": new AddSubLineWindow().ShowDialog(); break;
                case "EditSubLineWindow": new EditSubLineWindow().ShowDialog(); break;

                default:
                    break;
            }
            return null;
        }

        public Task ShowMessage(string message, string title, string buttonText, Action afterHideCallback)
        {
          var result =  MessageBox.Show(message, title,MessageBoxButton.YesNo);
            if (result == MessageBoxResult.Yes)
            {
                return new Task(afterHideCallback);
            }
            else
            {
                return new Task(() => { });
            }
        }

        public Task<bool> ShowMessage(string message, string title, string buttonConfirmText, string buttonCancelText, Action<bool> afterHideCallback)
        {
            throw new NotImplementedException();
        }

        public Task ShowMessageBox(string message, string title)
        {
            MessageBox.Show(message,title);
            return null;
        }

        private void TextBlock_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
