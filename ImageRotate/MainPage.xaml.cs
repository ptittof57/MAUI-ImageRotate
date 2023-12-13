using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace ImageRotate
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        double value = 0;
        public event PropertyChangedEventHandler PropertyChanged;

        public MainPage()
        {
            this.InitializeComponent();
            this.BindingContext = this;

            Task.Run(this.Test);
        }

        public double Value
        {
            get { return this.value; }
            set
            {
                this.value = value;
                this.OnPropertyChanged();
            }
        }

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        private async Task Test()
        {
            while(true)
            {
                if(this.value >= 360)
                {
                    this.Value = 0;
                }

                this.Value++;

                await Task.Delay(200);
            }
        }
    }
}
