using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using System.Windows.Input;
using DataBoard.Models;
using DataBoard.Views;
using GalaSoft.MvvmLight.Views;

namespace DataBoard.ViewModel
{
    public class LoginWindowViewModel : ViewModelBase
    {
        public LoginWindowViewModel()
        {
            appData = ServiceLocator.Current.GetInstance<AppData>();
        }

        private AppData appData;

        public AppData AppData
        {
            get { return appData; }
            set { appData = value; }
        }

        public int MyProperty { get; set; }

        private RelayCommand<LoginWindow> checkUserLoginCommand;

        //public ICommand CheckUserLoginCommand
        //{
        //    get
        //    {
        //        if (checkUserLoginCommand == null)
        //        {
        //            checkUserLoginCommand = new RelayCommand(() =>
        //            {
        //                BoardDBEntities dBEntities = new BoardDBEntities();
        //                UserInfo model = dBEntities.UserInfo.ToList().FirstOrDefault(item => item.Name == AppData.CurrentUser.Name && item.Password == AppData.CurrentUser.Password);
        //                if (model == null)
        //                {
        //                    return;
        //                }
        //                AppData.CurrentUser = model;
        //                MainWindow mainWindow = new MainWindow();
        //                mainWindow.Show();
        //            });
        //        }

        //        return checkUserLoginCommand;
        //    }
        //}

        public RelayCommand<LoginWindow> CheckUserLoginCommand
        {
            get
            {
                if (checkUserLoginCommand == null)
                {
                    checkUserLoginCommand = new RelayCommand<LoginWindow>((loginWindow) =>
                    {
                        BoardDBEntities1 dBEntities = new BoardDBEntities1();
                        UserInfo model = dBEntities.UserInfo.ToList().FirstOrDefault(item => item.Name == AppData.CurrentUser.Name && item.Password == AppData.CurrentUser.Password);
                        if (model == null)
                        {
                            var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                            dialog.ShowMessageBox("用户名或密码错误","提示");
                            return;
                        }
                        AppData.CurrentUser = model;
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        loginWindow.Close();
                    });
                }

                return checkUserLoginCommand;
            }
        }




    }
}
