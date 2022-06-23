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
    public class SubLineViewModel : ViewModelBase
    {
        private readonly IProvider<SubLine> subLineProvider = new SubLineProvider();
        private List<SubLine> subLines;

        public SubLineViewModel()
        {
            SubLines = subLineProvider.Select();
        }

        public List<SubLine> SubLines
        {
            get { return subLines; }
            set { subLines = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加框
        /// </summary>
        public RelayCommand OpenAddSubLineWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("AddSubLineWindow", "提示");
                    SubLines = subLineProvider.Select();
                });
            }
        }

        /// <summary>
        /// 修改框
        /// </summary>
        public RelayCommand<SubLine> OPenEditSubLineWindoeCommand
        {
            get
            {
                return new RelayCommand<SubLine>((model) =>
                {
                    var result = ServiceLocator.Current.GetInstance<EditSubLineWindowViewModel>();
                    if (result != null) result.SubLine = model;
                    else return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("EditSubLineWindow", "提示");
                    SubLines = subLineProvider.Select();
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<SubLine> DeleteSubLineCommand
        {
            get
            {
                return new RelayCommand<SubLine>((model) =>
                {
                    if (model == null) return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    var task = dialog.ShowMessage("确认要删除吗？", "提示", "", () => {
                        var count = subLineProvider.Delete(model);
                        if (count > 0)
                        {
                            dialog.ShowMessageBox("删除成功", "提示");
                            SubLines = subLineProvider.Select();
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
