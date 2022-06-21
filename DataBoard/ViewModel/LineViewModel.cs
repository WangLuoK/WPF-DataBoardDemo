using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBoard.Models;
using DataBoard.Models.Provider;

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

    }
}
