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
    public class EditStopTypeWindowViewModel : ViewModelBase
    {
        private StopType stopType;

        public StopType StopType
        {
            get { return stopType; }
            set { stopType = value; }
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<Window> EditStopTypeCommand
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
                    IProvider<StopType> provider = new StopTypeProvider();
                    var count = provider.Update(StopType);
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
