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
    public class EditHistoryWindowViewModel : ViewModelBase
    {
        private History history;

        public History History
        {
            get { return history; }
            set { history = value; }
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<Window> EditHistoryCommand
        {
            get
            {
                return new RelayCommand<Window>((window) =>
                {
                 
                   
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    History.UserInfoId = appData.CurrentUser.Id;
                    History.InsertDate = DateTime.Now;
                    IProvider<History> provider = new HistoryProvider();
                    var count = provider.Update(History);
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
