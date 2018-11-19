using System;
using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using AssemblyBrowser.Annotations;
using MessageBox = System.Windows.MessageBox;

namespace AssemblyBrowser
{
    public class AssemblyBrowserViewModel:INotifyPropertyChanged

    {
        private AssemblyResult _assemblyResult;
        private AssemblyReader _assemblyReader;
        private RelayCommand _openCommand;
      
        public AssemblyBrowserViewModel()
        {
            _assemblyReader = new AssemblyReader();
        }

        public AssemblyResult assemblyResult
        {
            get { return _assemblyResult; }
            set
            {
                _assemblyResult = value;
                OnPropertyChanged();
            }
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        
        public RelayCommand OpenCommand
        {
            get
            {
                return _openCommand ??
                       (_openCommand = new RelayCommand(obj =>
                       {
                           try
                           {
                               OpenFileDialog openFileDialog = new OpenFileDialog();
                               if (openFileDialog.ShowDialog() == DialogResult.OK)
                               {
                                   assemblyResult = _assemblyReader.reader(openFileDialog.FileName);
                               }
                           }
                           catch (Exception ex)
                           {
                               MessageBox.Show(ex.ToString());
                           }
                       }));
            }
        }
    }
}