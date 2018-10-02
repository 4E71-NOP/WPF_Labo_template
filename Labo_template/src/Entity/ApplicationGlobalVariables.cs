using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labo_template.Entity
{
    public class ApplicationGlobalVariables : INotifyPropertyChanged
    {
        private static ApplicationGlobalVariables Instance = null;
        private string StrPsbLabelMessage = "";

        public static ApplicationGlobalVariables GetInstance { get { return Instance ?? (Instance = new ApplicationGlobalVariables()); } }

        //private static ApplicationGlobalVariables GetInstance()
        //{
        //    if (Instance == null) { Instance = new ApplicationGlobalVariables(); }
        //    return Instance;
        //}

        // https://www.codeproject.com/Articles/1237457/WPF-MVVM-View-Binding-to-a-Singleton-and-WeakRefer
        public string PsbLabelMessage {
            get => StrPsbLabelMessage ;
            set {
                StrPsbLabelMessage = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PsbLabelMessage)));
            } }
        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString() { return base.ToString(); }
    }
}
