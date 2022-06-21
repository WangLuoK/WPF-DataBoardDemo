using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DataBoard.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            appData = ServiceLocator.Current.GetInstance<AppData>();
            Task.Run(() =>
            {
                while (true)
                {
                    SystemTime = DateTime.Now.ToString();
                    Thread.Sleep(1000);
                }
            });
        }
        private AppData appData;

        public AppData AppData
        {
            get { return appData; }
            set { appData = value; }
        }

        private string systemTime;

        public string SystemTime
        {
            get { return systemTime; }
            set { systemTime = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// ÍË³ö³ÌÐò
        /// </summary>
        public RelayCommand ExitCommand
        {

            get
            {
                return new RelayCommand(() =>
                {
                    Application.Current.Shutdown();
                });
            }
        }

        public RelayCommand<RadioButton> NavigationCommand
        {
            get
            {
                return new RelayCommand<RadioButton>((arg) =>
                {

                });
            }
        }
    }
}