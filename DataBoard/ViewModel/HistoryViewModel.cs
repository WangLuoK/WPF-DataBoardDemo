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
    public class HistoryViewModel : ViewModelBase
    {
        private readonly IProvider<History> provider = new HistoryProvider();
        private List<History> histories;

        public HistoryViewModel()
        {
            Histories = provider.Select();
        }

        public List<History> Histories
        {
            get { return histories; }
            set { histories = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加框
        /// </summary>
        public RelayCommand OpenAddHistoryWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("AddHistoryWindow", "提示");
                    Histories = provider.Select();
                });
            }
        }

        /// <summary>
        /// 修改框
        /// </summary>
        public RelayCommand<History> OPenEditHistoryWindoeCommand
        {
            get
            {
                return new RelayCommand<History>((model) =>
                {
                    var result = ServiceLocator.Current.GetInstance<EditHistoryWindowViewModel>();
                    if (result != null) result.History = model;
                    else return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("EditHistoryWindow", "提示");
                    Histories = provider.Select();
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<History> DeleteHistoryCommand
        {
            get
            {
                return new RelayCommand<History>((model) =>
                {
                    if (model == null) return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    var task = dialog.ShowMessage("确认要删除吗？", "提示", "", () => {
                        var count = provider.Delete(model);
                        if (count > 0)
                        {
                            dialog.ShowMessageBox("删除成功", "提示");
                            Histories = provider.Select();
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
