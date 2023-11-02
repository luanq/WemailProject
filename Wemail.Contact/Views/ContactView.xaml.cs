using System.Windows.Controls;
using Wemail.Contact.ViewModels;
using Wemail.Common.MVVM;

namespace Wemail.Contact.Views
{
    /// <summary>
    /// Interaction logic for ContactView
    /// </summary>
    public partial class ContactView : UserControl,IView
    {
        public ContactView()
        {
            InitializeComponent();
            (DataContext as ContactViewModel).View = this;
        }

        public bool Launch()
        {
            var view = new NewContactView();
            view.ShowDialog();
            return true;
        }

        public bool Shutdown()
        {
            return true;
        }
    }
}

