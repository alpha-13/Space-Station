using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading;
using System.Windows.Controls;
using System.Windows;

namespace Station.Classes
{
    internal sealed class News
    {
        bool? flag = null;
        int counter = 0;

        Data.DataAccessLayer Data = new Data.DataAccessLayer();
        List<string> AllNews = new List<string>();
        List<string> PersonNews;
        Grid Slider;
        TextBox txtNews1, txtNews2;
        Thread t;

        public News(Grid Slider, TextBox txt_News1, TextBox txt_News2)
        {
            this.Slider = Slider;
            this.txtNews1 = txt_News1;
            this.txtNews2 = txt_News2;
        }

        #region Select News

        public void selectNews(string Author, int days)
        {
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[1] = new SqlParameter("@author", SqlDbType.NVarChar, 25);
            param[0].Value = -1;
            param[1].Value = Author;

            DataTable dt = Data.selectData("select_News", param);

            PersonNews = new List<string>();
            List<int> values = new List<int>();
            int Diffrent;
            int value;

            for (int i = 0; i < 3; i++)
            {
                TimeSpan Time = DateTime.Now - (DateTime)dt.Rows[i]["Date_of_post"];
                Diffrent = Time.Days;
                if (Diffrent > days - 1)
                {
                    Random R = new Random();
                    for (int j = 0; j < 3; j++)
                    {
                        value = R.Next(1, (int)dt.Rows[i][0]);
                        if (!values.Contains(value))
                        {
                            values.Add(value);
                            break;
                        }
                    }
                }
                else
                    PersonNews.Add(dt.Rows[i][1].ToString());
            }

            dt = new DataTable();

            for (int i = 0; i < values.Count; i++)
            {
                param = new SqlParameter[2];
                param[0] = new SqlParameter("@ID", SqlDbType.Int);
                param[1] = new SqlParameter("@author", SqlDbType.NVarChar, 25);
                param[0].Value = values[i];
                param[1].Value = Author;

                PersonNews.Add(Data.selectData("select_News", param).Rows[0]["News"].ToString());
            }
            AllNews.AddRange(PersonNews);
        }

        #endregion

        #region Get News

        public void GetNews(object sender, EventArgs e)
        {
            Random R = new Random();

            if (flag == true)
            {
                txtNews2.Text = AllNews[counter];
                t = new Thread(Repeat);
                t.Start();
                flag = false;
            }
            else if (flag == false)
            {
                txtNews1.Text = AllNews[counter];
                t = new Thread(Repeat);
                t.Start();
                flag = true;
            }
            else
            {
                txtNews1.Text = AllNews[counter];
                flag = true;
            }

            if (counter < AllNews.Count - 1)
                counter++;
            else
                counter = 0;
        }

        #endregion

        #region Repeat

        private void Repeat()
        {
            for (int i = 0; i < 25; i++)
            {
                Thread.Sleep(10);

                Slider.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
                {

                    Thickness margin = txtNews1.Margin;
                    Thickness margin2 = txtNews2.Margin;

                    if (flag == false)
                    {
                        margin.Bottom++;
                        margin2.Top--;
                    }
                    else
                    {
                        margin.Bottom--;
                        margin2.Top++;
                    }

                    txtNews1.Margin = margin;
                    txtNews2.Margin = margin2;
                }));
            }

        }

        #endregion
    }
}
