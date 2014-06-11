using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WallyV1
{
    public partial class WriteCostPage : PhoneApplicationPage
    {
        bool isOpenNavDraw;
        double marginLeft;
        public WriteCostPage()
        {
            InitializeComponent();
           
           
        }


        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (isOpenNavDraw)
            {
                NavDrawer.Margin = new Thickness(0, 0, 0, 0);
                isOpenNavDraw = false;
            }

            double temp = marginLeft + e.HorizontalChange;
            if (temp <= 0 && temp >= -400)
            {
                marginLeft += e.HorizontalChange;
                NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
            }
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (marginLeft >= -200)
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft < 0)
                    {
                        marginLeft++;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
            else
            {
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (marginLeft > -400)
                    {
                        marginLeft--;

                        NavDrawer.Margin = new Thickness(marginLeft, 0, 0, 0);
                    }
                });
            }
        }

        private void Navigate_sidebar(object sender, System.Windows.Input.GestureEventArgs e)
        {

            NavDrawer.SlideNavBarOpen.Begin();
            marginLeft = 0;
            NavDrawer.Margin = new Thickness(0, 0, 0, 0);
            isOpenNavDraw = true;
        }

       
    }
}