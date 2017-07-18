using System.Timers;
using System.Windows;
using System.Windows.Controls;

namespace Station.Classes
{
    class Options
    {
        bool Setting = false;

        ListView Option;
        Timer T = new Timer();

        public Options(ListView Option)
        {
            this.Option = Option;

            T.Elapsed += new ElapsedEventHandler(ShowOptions);
            T.Interval = 5;
        }

        #region Show Options

        private void ShowOptions(object source, ElapsedEventArgs e)
        {
            Option.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                if (Setting)
                    Option.Height -= 5;
                else
                {
                    Option.Height += 5;
                    Option.Visibility = Visibility.Visible;
                }

                if (Option.Height == 95)
                {
                    T.Enabled = false;
                    Setting = true;
                }
                else if (Option.Height == 0)
                {
                    Option.Visibility = Visibility.Hidden;
                    T.Enabled = false;
                    Setting = false;
                }
            }));
        }

        #endregion

        #region Show

        public void Show()
        {
            T.Enabled = true;
        }

        #endregion

        #region Close

        public void Close()
        {
            T.Enabled = false;
        }

        #endregion
    }
}
