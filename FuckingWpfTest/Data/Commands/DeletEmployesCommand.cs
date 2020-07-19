using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FuckingWpfTest
{
    public class DeletEmployesCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Action<List<Employe>> _deletEmployes;

        public DeletEmployesCommand(Action<List<Employe>> action)
        {
            _deletEmployes = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            IList objectList = parameter as IList;
            
            _deletEmployes.Invoke(objectList.Cast<Employe>().ToList());
        }
    }
}
