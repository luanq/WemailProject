using System.Windows;
using System.Windows.Controls;
using Wemail.Common.MVVM;
using Wemail.Contact.ViewModels;

namespace Wemail.Contact.Views
{
    /// <summary>
    /// Interaction logic for NewContactView.xaml
    /// </summary>
    public partial class NewContactView : Window,IView
    {
       
            //依赖倒置，把自己初始化的时机交给使用者
            public NewContactView()
            {
                InitializeComponent();
                (DataContext as NewContactViewModel).View = this;
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

            private void Window_Error(object sender, ValidationErrorEventArgs e)
            {

            }
        }
    }
