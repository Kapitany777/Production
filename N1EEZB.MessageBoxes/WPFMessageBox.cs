using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace N1EEZB.MessageBoxes
{
    /// <summary>
    /// WPF Message Boxes
    /// </summary>
    public static class WPFMessageBox
    {
        /// <summary>
        /// Send an error message
        /// </summary>
        /// <param name="text">Error message</param>
        public static void MsgError(string text)
        {
            MessageBox.Show(text, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        /// <summary>
        /// Send an error message
        /// </summary>
        /// <param name="text1">Error message, first row</param>
        /// <param name="text2">Error message, second row</param>
        public static void MsgError(string text1, string text2)
        {
            MsgError(string.Format("{0}{1}{2}", text1, Environment.NewLine, text2));
        }

        /// <summary>
        /// Send an error message
        /// </summary>
        /// <param name="text">Error message</param>
        /// <param name="ex">An exception</param>
        public static void MsgError(string text, Exception ex)
        {
            MsgError(text, ex.Message);
        }

        /// <summary>
        /// Send a warning message
        /// </summary>
        /// <param name="text">Warning message</param>
        public static void MsgWarning(string text)
        {
            MessageBox.Show(text, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        /// <summary>
        /// Send a warning message
        /// </summary>
        /// <param name="text1">Warning message, first row</param>
        /// <param name="text2">Warning message, second row</param>
        public static void MsgWarning(string text1, string text2)
        {
            MsgWarning(string.Format("{0}{1}{2}", text1, Environment.NewLine, text2));
        }

        /// <summary>
        /// Send an information message
        /// </summary>
        /// <param name="text">Information message</param>
        public static void MsgInfo(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        /// <summary>
        /// Send an information message
        /// </summary>
        /// <param name="text1">Information message, first row</param>
        /// <param name="text2">Information message, second row</param>
        public static void MsgInfo(string text1, string text2)
        {
            MsgInfo(string.Format("{0}{1}{2}", text1, Environment.NewLine, text2));
        }

        /// <summary>
        /// Ask a yes / no question
        /// </summary>
        /// <param name="text">The question</param>
        /// <returns></returns>
        public static MessageBoxResult MsgYesNo(string text)
        {
            return MessageBox.Show(text, "Question", MessageBoxButton.YesNo, MessageBoxImage.Question);
        }
    }
}
