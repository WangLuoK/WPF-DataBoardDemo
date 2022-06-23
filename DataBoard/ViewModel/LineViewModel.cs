using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBoard.Models;
using DataBoard.Models.Provider;
using GalaSoft.MvvmLight.Command;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Views;

namespace DataBoard.ViewModel
{
    public class LineViewModel : ViewModelBase
    {

        private LineProvider lineProvider = new LineProvider();
        private List<Line> lines;

        public LineViewModel()
        {
            Lines = lineProvider.Select();
        }

        public List<Line> Lines
        {
            get { return lines; }
            set { lines = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加框
        /// </summary>
        public RelayCommand OpenAddLineWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("AddLineWindow", "提示");
                    Lines = lineProvider.Select();
                });
            }
        }

        /// <summary>
        /// 修改框
        /// </summary>
        public RelayCommand<Line> OPenEditLineWindoeCommand
        {
            get 
            {
                return new RelayCommand<Line>((model) =>
                {
                    var result = ServiceLocator.Current.GetInstance<EditLineWindowViewModel>();
                    if (result != null) result.Line = model;
                    else return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("EditLineWindow", "提示");
                    Lines = lineProvider.Select();
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<Line> DeleteCommand
        {
            get
            {
                return new RelayCommand<Line>((model) =>
                {
                    if(model== null) return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    var task = dialog.ShowMessage("确认要删除吗？", "提示", "", () => {
                        var count = lineProvider.Delete(model);
                        if (count>0)
                        {
                            dialog.ShowMessageBox("删除成功", "提示");
                            Lines = lineProvider.Select();
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
