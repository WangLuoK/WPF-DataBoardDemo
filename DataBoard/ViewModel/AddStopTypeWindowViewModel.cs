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
    public class AddStopTypeWindowViewModel : ViewModelBase
    {
        private StopType stopType = new StopType();

        public StopType StopType
        {
            get { return stopType; }
            set { stopType = value; }
        }

        /// <summary>
        /// 添加命令
        /// </summary>
        public RelayCommand<Window> AddStopTypeCommand
        {
            get
            {
                return new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(StopType.Name))
                    {
                        return;
                    }
                    if (StopType.Name.Length > 50) return;
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    StopType.UserInfoId = appData.CurrentUser.Id;
                    StopType.InsertDate = DateTime.Now;
                    StopTypeProvider stopTypeProvider = new StopTypeProvider();
                    var count = stopTypeProvider.Insert(StopType);
                    if (count > 0)
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("添加成功", "提示");
                        window.Close();
                        StopType = new StopType();
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
