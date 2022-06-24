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
    public class AddHistoryWindowViewModel : ViewModelBase
    {
        private History history;

        public History History
        {
            get { return history; }
            set { history = value; }
        }


        public AddHistoryWindowViewModel()
        {
            
        }

        public RelayCommand<Window> AddUserInfoCommand
        {
            get
            {
                return new RelayCommand<Window>((window) => {
                    var appData = ServiceLocator.Current.GetInstance<AppData>();
                    
                    IProvider<History> provider = new HistoryProvider();
                    var count = provider.Insert(History);
                    if (count > 0)
                    {
                        var dialog = ServiceLocator.Current.GetInstance<IDialogService>();
                        dialog.ShowMessageBox("添加成功", "提示");
                        window.Close();
                        this.History = new History();
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
