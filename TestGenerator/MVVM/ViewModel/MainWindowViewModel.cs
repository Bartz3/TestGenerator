using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestGenerator.Core;
using TestGenerator.Services;

namespace TestGenerator.MVVM.ViewModel
{
    public class MainWindowViewModel : Core.ViewModel
    {
        private INavigationService _navigation;
        public INavigationService Navigation {
            get => _navigation;
            set
            {
                _navigation = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand NavigateToQuestionCommand { get; set; }
        public RelayCommand NavigateToGenerateCommand { get; set; }

        public MainWindowViewModel(INavigationService navService)
        {
            Navigation = navService;
            NavigateToQuestionCommand = new RelayCommand(o => { Navigation.NavigateTo<QuestionViewModel>(); }, o => true);
            NavigateToGenerateCommand = new RelayCommand(o => { Navigation.NavigateTo<GenerateViewModel>(); }, o => true);

        }
    }
}
