using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Drawing;

namespace ffxiv.act.hwbotd
{
    public partial class UX : Form
    {
        

        public UX()
        {
            InitializeComponent();
        }
        /*
        protected override void OnPaintBackground(PaintEventArgs e)
        {
            using (System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(this.ClientRectangle,
                                                                       Color.Black,
                                                                       Color.Blue,
                                                                       90F))
            {
                e.Graphics.FillRectangle(brush, this.ClientRectangle);
                
            }
        }
        */
        //Set the overlay image.
        //imageFile is a string leading to the filepath of the image.
        //transparentColor is a Color enum value to use as a "green-screen" transparency color.
        //Values for Color can be found here.  https://msdn.microsoft.com/en-us/library/system.drawing.color%28v=vs.110%29.aspx
        public void SetImage(string imageFile, Color transparentColor)
        {

            //Make the image and set it to the form's image object, pb.
            Image i = Image.FromFile(imageFile);
            this.BackgroundImage = i;
            this.TransparencyKey = transparentColor;
            this.BackColor = transparentColor;

            //Set the heights and widths for the image object and form.
        }

        //Code for making the form click-through
        //Credit to Joey in this thread.  http://stackoverflow.com/questions/1524035/topmost-form-clicking-through-possible
        //-----------------------------------------------------------------------------------------------------------------
        public enum GWL
        {
            ExStyle = -20
        }
        

        [DllImport("user32.dll", EntryPoint = "GetWindowLong")]
        public static extern int GetWindowLong(IntPtr hWnd, GWL nIndex);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong")]
        public static extern int SetWindowLong(IntPtr hWnd, GWL nIndex, int dwNewLong);

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            int wl = GetWindowLong(this.Handle, GWL.ExStyle);
            wl = wl | 0x80000 | 0x20;
            SetWindowLong(this.Handle, GWL.ExStyle, wl);
        }

        private void UX_Load(object sender, EventArgs e)
        {
            SetImage("botd\\up.png", Color.White);
            this.Opacity = 0.6;
        }
        //-----------------------------------------------------------------------------------------------------------------
    }
}
