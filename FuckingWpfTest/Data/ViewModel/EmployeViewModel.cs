using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuckingWpfTest
{
    public class EmployeViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Employe> Employes { get; set; } = new ObservableCollection<Employe>();

        public string MyProperty { get; set; } = "Hello World!";
        public ICommand DeletEmployesCommand { get; private set; }

        public EmployeViewModel()
        {
            DeletEmployesCommand = new DeletEmployesCommand(DeletEmployes);


            Employes.Add(new Employe { Age = 20, Name = "Krisztian" });
            Employes.Add(new Employe { Age = 10, Name = "Bence" });
            Employes.Add(new Employe { Age = 30, Name = "Jozsi" });
        }

        private void DeletEmployes(List<Employe> employes)
        {
            foreach (var item in employes)
            {
                Employes.Remove(item);
            }


            // for perfomance Reason we update the list when we remove all value.
            OnPropertyChanged(nameof(Employes));

        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
