using System.ComponentModel;
using System.Reflection;
using System.Runtime.CompilerServices;
using AssemblyBrowser.Annotations;

namespace AssemblyBrowser
{
    public class AssemblyBrowserViewModel:INotifyPropertyChanged

    {
        public AssemblyBrowserViewModel()
        {
            AssemblyReader assemblyReader = new AssemblyReader();
            assemblyReader.reader("C:\\Users\\vital\\RiderProjects\\ConsoleApp1\\ConsoleApp1.sln");
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}