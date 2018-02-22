using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

/*
 * Originated from https://stackoverflow.com/questions/741956/pan-zoom-image
 * Author: Ian Oakes
 */
namespace AirlinesManagerGame.Views.WorldMap
{
    public class ZoomBorder : Border
    {
        private UIElement mapImage = null;
        private Point origin;
        private Point start;

        private TranslateTransform GetTranslateTransform(UIElement element)
        {
            return (TranslateTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is TranslateTransform);
        }

        private ScaleTransform GetScaleTransform(UIElement element)
        {
            return (ScaleTransform)((TransformGroup)element.RenderTransform)
              .Children.First(tr => tr is ScaleTransform);
        }

        public override UIElement Child
        {
            get { return base.Child; }
            set
            {
                if (value != null && value != this.Child)
                    this.Initialize(value);
                base.Child = value;
            }
        }

        public void Initialize(UIElement element)
        {
            this.mapImage = element;
            if (mapImage != null)
            {
                TransformGroup group = new TransformGroup();
                ScaleTransform st = new ScaleTransform();
                group.Children.Add(st);
                TranslateTransform tt = new TranslateTransform();
                group.Children.Add(tt);
                mapImage.RenderTransform = group;
                mapImage.RenderTransformOrigin = new Point(0.0, 0.0);
                this.MouseWheel += MapImage_MouseWheel;
                this.MouseLeftButtonDown += MapImage_MouseLeftButtonDown;
                this.MouseLeftButtonUp += MapImage_MouseLeftButtonUp;
                this.MouseMove += MapImage_MouseMove;
                this.PreviewMouseRightButtonDown += new MouseButtonEventHandler(
                  MapImage_PreviewMouseRightButtonDown);
            }
        }

        public void Reset()
        {
            if (mapImage != null)
            {
                // reset zoom
                var st = GetScaleTransform(mapImage);
                st.ScaleX = 1.0;
                st.ScaleY = 1.0;

                // reset pan
                var tt = GetTranslateTransform(mapImage);
                tt.X = 0.0;
                tt.Y = 0.0;
            }
        }

        private void MapImage_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (mapImage != null)
            {
                var st = GetScaleTransform(mapImage);
                var tt = GetTranslateTransform(mapImage);

                if (!(e.Delta > 0) && (st.ScaleX < .4 || st.ScaleY < .4))
                    return;

                Point relative = e.GetPosition(mapImage);
                double abosuluteX;
                double abosuluteY;

                abosuluteX = relative.X * st.ScaleX + tt.X;
                abosuluteY = relative.Y * st.ScaleY + tt.Y;


                double zoom = 0;
                if(e.Delta > 0 && st.ScaleX < 6 && st.ScaleY < 6) { zoom = .2; } //prevents zooming in too much
                else if(e.Delta < 0 && st.ScaleX > 1 && st.ScaleY > 1) { zoom = -.2; } //prevents zooming out too much

                st.ScaleX += zoom;
                st.ScaleY += zoom;

                if (st.ScaleX == 1 || st.ScaleY == 1)
                {
                    Reset();
                }
                else
                {
                    tt.X = abosuluteX - relative.X * st.ScaleX;
                    tt.Y = abosuluteY - relative.Y * st.ScaleY;
                }
            }
        }

        private void MapImage_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (mapImage != null)
            {
                var tt = GetTranslateTransform(mapImage);
                start = e.GetPosition(this);
                origin = new Point(tt.X, tt.Y);
                this.Cursor = Cursors.Hand;
                mapImage.CaptureMouse();
            }
        }

        private void MapImage_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (mapImage != null)
            {
                mapImage.ReleaseMouseCapture();
                this.Cursor = Cursors.Arrow;
            }
        }

        void MapImage_PreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.Reset();
        }

        private void MapImage_MouseMove(object sender, MouseEventArgs e)
        {
            if (mapImage != null)
            {
                var st = GetScaleTransform(mapImage);

                if (mapImage.IsMouseCaptured && st.ScaleX > 1)

                {
                    var windowBorder = new Rect(mapImage.RenderSize);
                    var imageBorder = mapImage.TransformToAncestor(this).TransformBounds(windowBorder);

                    var tt = GetTranslateTransform(mapImage);
                    Vector v = start - e.GetPosition(this);

                    //Horizontal movement and constraining
                    double next_tt_X = origin.X - v.X;
                    double scaledImageBorder_Left = imageBorder.Left * st.ScaleX;
                    double scaledImageBorder_Right = imageBorder.Right * st.ScaleX;

                    if ((scaledImageBorder_Left + next_tt_X) < windowBorder.Left && (scaledImageBorder_Right + next_tt_X) > windowBorder.Right)
                    {
                        tt.X = origin.X - v.X;
                    }

                    //Vertical movement and constraining
                    double nextTTY = origin.Y - v.Y;
                    double scaledImageBorder_Top = imageBorder.Top * st.ScaleY;
                    double scaledImageBorder_Bottom = imageBorder.Bottom * st.ScaleY;

                    if ((scaledImageBorder_Top + nextTTY) < windowBorder.Top && (scaledImageBorder_Bottom + nextTTY) > windowBorder.Bottom)
                    {
                        tt.Y = origin.Y - v.Y;
                    }
                }
            }
        }
    }
}
