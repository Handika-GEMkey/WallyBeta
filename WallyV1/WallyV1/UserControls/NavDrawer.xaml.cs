using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WallyV1.Helper;

namespace WallyV1.UserControl
{
    public partial class NavDrawer
    {

        public NavDrawer()
        {
            InitializeComponent();
            NavDrawMargin.left = 0;
        }

        private void GestureListener_DragDelta(object sender, DragDeltaGestureEventArgs e)
        {
            if (NavDrawMargin.left <= 400)
            {
                NavDrawMargin.left += e.HorizontalChange;
                LayoutRoot.Margin = new Thickness(NavDrawMargin.left, 0, 0, 0);
            }
        }

        private void GestureListener_DragCompleted(object sender, DragCompletedGestureEventArgs e)
        {
            if (LayoutRoot.Margin.Left >= 200)
            {
                NavDrawMargin.left = 0;
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (LayoutRoot.Margin.Left < 400)
                    {
                        NavDrawMargin.left = LayoutRoot.Margin.Left + 1;
                        LayoutRoot.Margin = new Thickness(NavDrawMargin.left, 0, 0, 0);
                    }
                });
            }
            else
            {
                NavDrawMargin.left = 0;
                Deployment.Current.Dispatcher.BeginInvoke(delegate
                {
                    while (LayoutRoot.Margin.Left > 0)
                    {
                        NavDrawMargin.left = LayoutRoot.Margin.Left - 1;
                        LayoutRoot.Margin = new Thickness(NavDrawMargin.left, 0, 0, 0);
                    }
                });
            }
        }

        private void NavigateToPage(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Grid grid = (Grid)sender;

            var frame = App.Current.RootVisual as PhoneApplicationFrame;
            frame.Navigate(new Uri("/Views/" + grid.Tag.ToString() + ".xaml", UriKind.Relative));
        }
    }
}
