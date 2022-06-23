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
    public class AddSubLineWindowViewModel : ViewModelBase
    {
        private SubLine subLine = new SubLine();

        public SubLine SubLine
        {
            get { return subLine; }
            set { subLine = value; }
        }

        /// <summary>
        /// 添加命令
        /// </summary>
        public RelayCommand<Window> AddSubLineCommand
        {
            get
            {
                return new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(SubLine.Name))
                    {
                        return;
                    }
                    if (SubLine.Name.Length > 50) return;
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    SubLine.UserInfoId = appData.CurrentUser.Id;
                    SubLine.InsertDate = DateTime.Now;
                    SubLineProvider lineProvider = new SubLineProvider();
                    var count = lineProvider.Insert(SubLine);
                    if (count > 0)
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("添加成功", "提示");
                        window.Close();
                        SubLine = new SubLine();
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
