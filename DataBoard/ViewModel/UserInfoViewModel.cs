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
namespace DataBoard.ViewModel
{
    public class UserInfoViewModel : ViewModelBase
    {
        private readonly IProvider<UserInfo> provider = new UserInfoProvider();
        private List<UserInfo> userInfos;

        public UserInfoViewModel()
        {
            UserInfos = provider.Select();
        }

        public List<UserInfo> UserInfos
        {
            get { return userInfos; }
            set { userInfos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加框
        /// </summary>
        public RelayCommand OpenAddUserInfoWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("AddUserInfoWindow", "提示");
                    UserInfos = provider.Select();
                });
            }
        }

        /// <summary>
        /// 修改框
        /// </summary>
        public RelayCommand<UserInfo> OPenEditUserInfoWindoeCommand
        {
            get
            {
                return new RelayCommand<UserInfo>((model) =>
                {
                    var result = ServiceLocator.Current.GetInstance<EditUserInfoWindowViewModel>();
                    if (result != null) result.UserInfo = model;
                    else return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("EditUserInfoWindoe", "提示");
                    UserInfos = provider.Select();
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<UserInfo> DeleteUserInfoCommand
        {
            get
            {
                return new RelayCommand<UserInfo>((model) =>
                {
                    if (model == null) return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    var task = dialog.ShowMessage("确认要删除吗？", "提示", "", () => {
                        var count = provider.Delete(model);
                        if (count > 0)
                        {
                            dialog.ShowMessageBox("删除成功", "提示");
                            UserInfos = provider.Select();
                        }
                        else
                        {
                            dialog.ShowMessageBox("删除失败", "提示");

                        }
                    });
                    task.Start();

                });
            }
        }
    }
}
