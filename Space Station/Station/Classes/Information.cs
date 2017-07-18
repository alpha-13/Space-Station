using System;
using System.Windows.Controls;
using System.Data;

namespace Station.Classes
{
    internal sealed class Information
    {
        #region Galaxy Information

        public void GalaxyInformation(Grid Container, DataRow Information, Image Photo, params TextBox[] txtInfo)
        {
            Container.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                txtInfo[0].Text = Information["Name"].ToString();
                txtInfo[1].Text = Information["Age"].ToString();
                txtInfo[2].Text = Information["Type"].ToString();
                txtInfo[3].Text = Information["Diameter"].ToString();
                txtInfo[4].Text = Information["Stars"].ToString();
                txtInfo[5].Text = Information["Arms"].ToString();
                txtInfo[6].Text = Information["Mass"].ToString();
                txtInfo[7].Text = Information["Expansion"].ToString();
                txtInfo[8].Text = Information["Density"].ToString();
                if (Information["Image"] != DBNull.Value)
                    Photo.Source = Person.ByteToImage((byte[])Information["Image"]);
            }));
        }

        #endregion

        #region Planetary System Information

        public void PlanetarySystemInfo(Grid Container, DataRow Information, Image Photo, params TextBox[] txtInfo)
        {
            Container.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                txtInfo[0].Text = Information["Galaxy"].ToString();
                txtInfo[1].Text = Information["Name"].ToString();
                txtInfo[2].Text = Information["Plants"].ToString();
                txtInfo[3].Text = Information["Asteroids"].ToString();
                txtInfo[4].Text = Information["Location"].ToString();
                txtInfo[5].Text = Information["Speed"].ToString();
                if (Information["Image"] != DBNull.Value)
                    Photo.Source = Person.ByteToImage((byte[])Information["Image"]);
            }));
        }

        #endregion

        #region Plant Information

        public void PlantInformation(Grid Container, DataRow Information, Image Photo, params TextBox[] txtInfo)
        {
            Container.Dispatcher.Invoke(new System.Windows.Forms.MethodInvoker(delegate
            {
                txtInfo[0].Text = Information["Planetary_system"].ToString();
                txtInfo[1].Text = Information["Name"].ToString();
                txtInfo[2].Text = Information["Water"].ToString();
                txtInfo[3].Text = Information["Temperature"].ToString();
                txtInfo[4].Text = Information["Live"].ToString();
                txtInfo[5].Text = Information["Year"].ToString();
                txtInfo[6].Text = Information["Moons"].ToString();
                txtInfo[7].Text = Information["Oxygen"].ToString();
                txtInfo[8].Text = Information["Carbon_Dioxide"].ToString();
                txtInfo[9].Text = Information["Nitrogen"].ToString();
                if (Information["Image"] != DBNull.Value)
                    Photo.Source = Person.ByteToImage((byte[])Information["Image"]);
            }));
        }

        #endregion
    }
}
