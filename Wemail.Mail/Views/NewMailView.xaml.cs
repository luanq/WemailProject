using System.Windows;
using Wemail.Common.MVVM;
using Wemail.Mail.ViewModels;

namespace Wemail.Mail.Views
{
    /// <summary>
    /// Interaction logic for NewMailView.xaml
    /// </summary>
    public partial class NewMailView : Window,IView
    {
        public NewMailView()
        {
            InitializeComponent();
            (DataContext as NewMailViewModel).View = this;
        }

        public bool Launch()
        {
            return false;
        }

        public bool Shutdown()
        {
            Close();
            return true;
        }
    }
}
