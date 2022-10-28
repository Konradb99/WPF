using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Movies.ViewModels
{
    public class MoviesListViewModel: BindableBase
    {
        private string _message;
        public string Message
        {
            get
            {
                return _message;
            }
            set
            {
                SetProperty(ref _message, value);
            }
        }

        private string _genre;
        public string Genre
        {
            get
            {
                return _genre;
            }
            set
            {
                SetProperty(ref _genre, value);
            }
        }

        public MoviesListViewModel()
        {
            Message = "Hello from Movies View Model";
            Genre = "Your selected genre is: ";
        }
    }
}
