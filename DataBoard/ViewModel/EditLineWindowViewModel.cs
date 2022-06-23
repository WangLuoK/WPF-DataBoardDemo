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
    public class EditLineWindowViewModel : ViewModelBase
    {
        private Line line;

        public Line Line
        {
            get { return line; }
            set { line = value; }
        }

        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<Window> EditLineCommand
        {
            get
            {
                return new RelayCommand<Window>((window) =>
                {
                    if (string.IsNullOrEmpty(Line.Name))
                    {
                        return;
                    }
                    if (Line.Name.Length > 50) return;
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    Line.UserInfoId = appData.CurrentUser.Id;
                    Line.InsertDate = DateTime.Now;
                    LineProvider lineProvider = new LineProvider();
                    var count = lineProvider.Update(Line);
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
