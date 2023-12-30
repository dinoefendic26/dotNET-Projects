using System;
using System.Drawing;
using System.Windows.Forms;

namespace AdvancedPaintApp
{
    public partial class PaintForm : Form
    {
        private Point? _previousPoint;
        private Color _currentColor = Color.Black; // Default color
        private ShapeType _currentShape = ShapeType.Line; // Default shape

        private enum ShapeType
        {
            Line,
            Rectangle,
            Ellipse
        }

        public PaintForm()
        {
            //InitializeComponent();

            Text = "Advanced Paint App";
            DoubleBuffered = true;
            ResizeRedraw = true;

            MouseDown += PaintForm_MouseDown;
            MouseMove += PaintForm_MouseMove;
            MouseUp += PaintForm_MouseUp;
            Paint += PaintForm_Paint;

            // Add a menu with options for shapes, colors, and save
            MenuStrip menuStrip = new MenuStrip();

            ToolStripMenuItem shapeMenu = new ToolStripMenuItem("Shapes");
            shapeMenu.DropDownItems.Add("Line", null, ShapeMenuItem_Click);
            shapeMenu.DropDownItems.Add("Rectangle", null, ShapeMenuItem_Click);
            shapeMenu.DropDownItems.Add("Ellipse", null, ShapeMenuItem_Click);

            ToolStripMenuItem colorMenuItem = new ToolStripMenuItem("Pick Color");
            colorMenuItem.Click += ColorMenuItem_Click;

            ToolStripMenuItem saveMenuItem = new ToolStripMenuItem("Save");
            saveMenuItem.Click += SaveMenuItem_Click;

            menuStrip.Items.Add(shapeMenu);
            menuStrip.Items.Add(colorMenuItem);
            menuStrip.Items.Add(saveMenuItem);

            Controls.Add(menuStrip);

            MainMenuStrip = menuStrip;
        }

        private void PaintForm_MouseDown(object sender, MouseEventArgs e)
        {
            _previousPoint = new Point(e.X, e.Y);
        }

        private void PaintForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (_previousPoint.HasValue)
            {
                using (Graphics g = CreateGraphics())
                {
                    Pen pen = new Pen(_currentColor);

                    switch (_currentShape)
                    {
                        case ShapeType.Line:
                            g.DrawLine(pen, _previousPoint.Value, new Point(e.X, e.Y));
                            break;
                        case ShapeType.Rectangle:
                            g.DrawRectangle(pen, GetRectangle(_previousPoint.Value, new Point(e.X, e.Y)));
                            break;
                        case ShapeType.Ellipse:
                            g.DrawEllipse(pen, GetRectangle(_previousPoint.Value, new Point(e.X, e.Y)));
                            break;
                    }
                }

                _previousPoint = new Point(e.X, e.Y);
            }
        }

        private void PaintForm_MouseUp(object sender, MouseEventArgs e)
        {
            _previousPoint = null;
        }

        private void PaintForm_Paint(object sender, PaintEventArgs e)
        {
            // You can add additional painting logic here if needed
        }

        private void ShapeMenuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;

            switch (menuItem.Text)
            {
                case "Line":
                    _currentShape = ShapeType.Line;
                    break;
                case "Rectangle":
                    _currentShape = ShapeType.Rectangle;
                    break;
                case "Ellipse":
                    _currentShape = ShapeType.Ellipse;
                    break;
            }
        }

        private void ColorMenuItem_Click(object sender, EventArgs e)
        {
            // Show color picker dialog
            ColorDialog colorDialog = new ColorDialog();
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _currentColor = colorDialog.Color;
            }
        }

        private void SaveMenuItem_Click(object sender, EventArgs e)
        {
            // Save the content to an image file
            using (Bitmap bitmap = new Bitmap(ClientSize.Width, ClientSize.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    DrawToBitmap(bitmap, ClientRectangle);
                }

                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "PNG files (*.png)|*.png|All files (*.*)|*.*";
                saveFileDialog.Title = "Save an Image File";
                saveFileDialog.ShowDialog();

                if (saveFileDialog.FileName != "")
                {
                    bitmap.Save(saveFileDialog.FileName);
                }
            }
        }

        private Rectangle GetRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y)
            );
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PaintForm());
        }
    }
}
