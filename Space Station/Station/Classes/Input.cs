using System.Windows.Input;
using System.Timers;
using System.Windows.Controls;

namespace Station.Classes
{
    internal sealed class Input
    {
        string Msg;
        Timer T = new Timer();
        TextBlock txt_Message;
        bool Reverse;

        public Input() { }

        public Input(TextBlock txt_Message)
        {
            this.txt_Message = txt_Message;
            T.Interval = 100;
            T.Elapsed += ShowMessage;
        }

        #region Accept Only Characters (a => z - A => Z)

        public void Chracters(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.A && e.Key <= Key.Z || e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right)
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion

        #region Accept Only Numbers (0 => 9)

        public void Numbers(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right)
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion

        #region Accept Characters And Numbers (a => z - A => Z - 0 => 9)

        public void NumbersCharcters(object sender, KeyEventArgs e)
        {
            if ((e.Key >= Key.A && e.Key <= Key.Z) || (e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9) || (e.Key >= Key.D0 && e.Key <= Key.D9) || e.Key == Key.Back || e.Key == Key.Tab || e.Key == Key.Left || e.Key == Key.Right)
                e.Handled = false;
            else
                e.Handled = true;
        }

        #endregion

        #region Toggle Message

        public void Message(string Message)
        {
            Msg = Message;
            T.Enabled = true;
        }

        private void ShowMessage(object sender, ElapsedEventArgs e)
        {
            txt_Message.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                txt_Message.Text = Msg;

                if (txt_Message.Opacity >= 1)
                    Reverse = true;

                if (Reverse)
                    txt_Message.Opacity -= 0.1;
                else
                    txt_Message.Opacity += 0.1;

                if (txt_Message.Opacity < 0)
                {
                    T.Enabled = false;
                    Reverse = false;
                }
            }));
        }

        #endregion
    }
}
