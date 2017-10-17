using N1EEZB.MessageBoxes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace N1EEZB.WpfControlLibrary
{
    public class WindowClass : Window
    {
        public WindowClass()
        {
            this.Closing += WindowClass_Closing;
            this.PreviewKeyDown += WindowClass_PreviewKeyDown;

            CreateKeyboardShortcuts();
        }

        private void WindowClass_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter && e.Source is TextBox)
            {
                (e.Source as TextBox).MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));

                e.Handled = true;
            }
        }

        private void WindowClass_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                if (WPFMessageBox.MsgYesNo("Are you sure you want to exit the program?") == MessageBoxResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void CloseWindow(object sender, ExecutedRoutedEventArgs e)
        {
            this.Close();
        }

        private void CreateKeyboardShortcuts()
        {
            RoutedCommand commandCloseWindow = new RoutedCommand();
            commandCloseWindow.InputGestures.Add(new KeyGesture(Key.X, ModifierKeys.Alt));
            CommandBindings.Add(new CommandBinding(commandCloseWindow, this.CloseWindow));
        }
    }
}
