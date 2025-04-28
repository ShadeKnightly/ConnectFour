using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

public class CircularButton : Button
{
    protected override void OnPaint(PaintEventArgs pevent)
    {
        base.OnPaint(pevent);

        // Create a circular path for the button
        GraphicsPath path = new GraphicsPath();
        path.AddEllipse(0, 0, this.Width, this.Height);
        this.Region = new Region(path);

        //You can customize the border or background
        pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
        pevent.Graphics.FillEllipse(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
    }
}