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
    public class AddUserInfoWindowViewModel : ViewModelBase
    {
        private UserInfo userInfo = new UserInfo();

        private AppData appData;

        public AddUserInfoWindowViewModel()
        {
            appData = ServiceLocator.Current.GetInstance<AppData>();
        }

        public AppData AppData
        {
            get { return appData; }
            set { appData = value; }
        }

        /// <summary>
        /// 当前用户
        /// </summary>
        public UserInfo CurrentUser
        {
            get { return userInfo; }
            set { userInfo = value; }
        }

        public RelayCommand<Window> AddUserInfoCommand
        {
            get
            {
                return new RelayCommand<Window>((window) => {

                    if (string.IsNullOrEmpty(CurrentUser.Name)) return;
                    if (string.IsNullOrEmpty(CurrentUser.Password)) return;
                    if (CurrentUser.Name.Length > 50) return;
                    if (CurrentUser.Password.Length > 50) return;

                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    this.CurrentUser.Role = this.CurrentUser.RoleModel.Id;
                    this.CurrentUser.InsertDate = DateTime.Now;
                    IProvider<UserInfo> provider = new UserInfoProvider();
                    var count = provider.Insert(CurrentUser);
                    if (count>0)
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("添加成功", "提示");
                        window.Close();
                        this.CurrentUser = new UserInfo();
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
