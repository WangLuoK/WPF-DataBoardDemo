/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:DataBoard"
                           x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"

  You can also use Blend to do all this with the tool's support.
  See http://www.galasoft.ch/mvvm
*/

using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using DataBoard.Views;

namespace DataBoard.ViewModel
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);
            SimpleIoc.Default.Register<MainViewModel>();
            SimpleIoc.Default.Register<LoginWindowViewModel>();
            SimpleIoc.Default.Register<AppData>();
            SimpleIoc.Default.Register<IDialogService, LoginWindow>();

            SimpleIoc.Default.Register<HistoryViewModel>();
            SimpleIoc.Default.Register<IndexViewModel>();
            SimpleIoc.Default.Register<LineViewModel>();
            SimpleIoc.Default.Register<StopTypeViewModel>();
            SimpleIoc.Default.Register<SubLineViewModel>();
            SimpleIoc.Default.Register<UserInfoViewModel>();

            SimpleIoc.Default.Register<HistoryView>();
            SimpleIoc.Default.Register<IndexView>();
            SimpleIoc.Default.Register<LineView>();
            SimpleIoc.Default.Register<StopTypeView>();
            SimpleIoc.Default.Register<SubLineView>();
            SimpleIoc.Default.Register<UserInfoView>();

        }

        public MainViewModel Main => ServiceLocator.Current.GetInstance<MainViewModel>();
        public HistoryViewModel History => ServiceLocator.Current.GetInstance<HistoryViewModel>();
        public IndexViewModel Index => ServiceLocator.Current.GetInstance<IndexViewModel>();    
        public LineViewModel Line => ServiceLocator.Current.GetInstance<LineViewModel>();   
        public StopTypeViewModel StopType => ServiceLocator.Current.GetInstance<StopTypeViewModel>();   
        public SubLineViewModel SubLine => ServiceLocator.Current.GetInstance<SubLineViewModel>();  
        public UserInfoViewModel UserInfo => ServiceLocator.Current.GetInstance<UserInfoViewModel>();   
        public LoginWindowViewModel LoginWindow
        {
            get
            {
                return ServiceLocator.Current.GetInstance<LoginWindowViewModel>();
            }
        }
        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}