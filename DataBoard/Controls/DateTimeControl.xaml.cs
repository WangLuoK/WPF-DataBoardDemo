using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataBoard.Controls
{
    /// <summary>
    /// DateTimeControl.xaml 的交互逻辑
    /// </summary>
    public partial class DateTimeControl : UserControl
    {
        public DateTimeControl()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                //初始化年
                for (int i = 1949; i < DateTime.Now.Year + 20; i++)
                {
                    comboBoxYear.Items.Add(i);
                }
                //初始化月
                for (int i = 1; i < 13; i++)
                {
                    comboBoxMonth.Items.Add(i);
                }
                //初始化日
                for (int i = 1; i < 32; i++)
                {
                    comboBoxDay.Items.Add(i);
                }
                //初始化时
                for (int i = 0; i < 24; i++)
                {
                    comboBoxHour.Items.Add(i);
                }
                //初始化分
                for (int i = 0; i < 60; i++)
                {
                    comboBoxMinute.Items.Add(i);
                }
                //初始化秒
                for (int i = 0; i < 60; i++)
                {
                    comboBoxSecond.Items.Add(i);
                }
            };
        }



        public DateTime NowDateTime
        {
            get { return (DateTime)GetValue(NowDateTimeProperty); }
            set { SetValue(NowDateTimeProperty, value); }
        }

        public static readonly DependencyProperty NowDateTimeProperty =
    DependencyProperty.Register("NowDateTime", typeof(DateTime), typeof(DateTimeControl), new PropertyMetadata(DateTime.Now
        , new PropertyChangedCallback(OnNowTimePropertyChangedCallback)));

        private static void OnNowTimePropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (!(d is DateTimeControl dateTimeControl)) return;
            if (!(e.NewValue is DateTime dateTime)) return;
            int year, month, day, hour, minute, second;
            year = dateTime.Year;
            month = dateTime.Month;
            day = dateTime.Day;
            hour = dateTime.Hour;
            minute = dateTime.Minute;
            second = dateTime.Second;
            dateTimeControl.comboBoxYear.Text = year.ToString();
            dateTimeControl.comboBoxMonth.Text = month.ToString();
            dateTimeControl.comboBoxDay.Text = day.ToString();
            dateTimeControl.comboBoxHour.Text = hour.ToString();
            dateTimeControl.comboBoxMinute.Text = minute.ToString();
            dateTimeControl.comboBoxSecond.Text = second.ToString();


        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var year = comboBoxYear.Text;
            var month = comboBoxMonth.Text;
            var day = comboBoxDay.Text;
            var hour = comboBoxHour.Text;
            var minute = comboBoxMinute.Text;
            var second = comboBoxSecond.Text;
            var dateTime = $"{year}/{month}/{day}  {hour}:{minute}:{second}";
            if (DateTime.TryParse(dateTime, out DateTime result))
            {
                this.NowDateTime = result;
            }
        }
    }
}
