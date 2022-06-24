using CommonServiceLocator;
using DataBoard.Models;
using DataBoard.Models.Provider;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DataBoard.ViewModel
{
    public class EditUserInfoWindowViewModel : ViewModelBase
    {
        private UserInfo userInfo = new UserInfo();
        private AppData appData;

        public EditUserInfoWindowViewModel()
        {
            AppData = ServiceLocator.Current.GetInstance<AppData>();
        }

        public UserInfo UserInfo
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        public AppData AppData
        {
            get { return appData; }
            set { appData = value; }
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<Window> EditUserInfoCommand
        {
            get
            {
                return new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(UserInfo.Name)) return;
                    if (string.IsNullOrEmpty(UserInfo.Password)) return;
                    if (UserInfo.Name.Length > 50) return;
                    if (UserInfo.Password.Length > 50) return;
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    UserInfo.Name = appData.CurrentUser.Name;
                    UserInfo.Role = appData.CurrentUser.Role;
                    UserInfo.Password = appData.CurrentUser.Password;
                    UserInfo.InsertDate = DateTime.Now;
                    IProvider<UserInfo> provider = new UserInfoProvider();
                    var count = provider.Update(UserInfo);
                    if (count > 0)
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("修改成功", "提示");
                        window.Close();
                    }
                    else
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("添加失败", "提示");
                    }
                });
            }
        }
    }
}
