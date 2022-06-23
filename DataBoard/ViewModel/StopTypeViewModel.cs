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
    public class StopTypeViewModel : ViewModelBase
    {
        private readonly IProvider<StopType> stopTypeProvider = new StopTypeProvider();
        private List<StopType> stopTypes;

        public StopTypeViewModel()
        {
            StopTypes = stopTypeProvider.Select();
        }

        public List<StopType> StopTypes
        {
            get { return stopTypes; }
            set { stopTypes = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 添加框
        /// </summary>
        public RelayCommand OpenAddStopTypeWindowCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("AddStopTypeWindow", "提示");
                    StopTypes = stopTypeProvider.Select();
                });
            }
        }

        /// <summary>
        /// 修改框
        /// </summary>
        public RelayCommand<StopType> OPenEditStopTypeWindoeCommand
        {
            get
            {
                return new RelayCommand<StopType>((model) =>
                {
                    var result = ServiceLocator.Current.GetInstance<EditStopTypeWindowViewModel>();
                    if (result != null) result.StopType = model;
                    else return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    dialog.ShowMessage("EditStopTypeWindow", "提示");
                    StopTypes = stopTypeProvider.Select();
                });
            }
        }

        /// <summary>
        /// 删除
        /// </summary>
        public RelayCommand<StopType> DeleteStopTypeCommand
        {
            get
            {
                return new RelayCommand<StopType>((model) =>
                {
                    if (model == null) return;
                    var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                    var task = dialog.ShowMessage("确认要删除吗？", "提示", "", () => {
                        var count = stopTypeProvider.Delete(model);
                        if (count > 0)
                        {
                            dialog.ShowMessageBox("删除成功", "提示");
                            StopTypes = stopTypeProvider.Select();
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
