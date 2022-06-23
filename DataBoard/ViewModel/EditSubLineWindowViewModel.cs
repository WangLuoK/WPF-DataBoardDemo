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
    public class EditSubLineWindowViewModel : ViewModelBase
    {
        private SubLine subLine;

        public SubLine SubLine
        {
            get { return subLine; }
            set { subLine = value; }
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<Window> EditSubLIneCommand
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
                    IProvider<SubLine> provider = new SubLineProvider();
                    var count = provider.Update(SubLine);
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
