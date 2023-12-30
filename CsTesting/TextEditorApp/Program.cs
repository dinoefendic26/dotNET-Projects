using System;
using System.Drawing;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace TextEditorApp
{
    public partial class MainForm : Form
    {
        private RichTextBox richTextBox;
        private bool isDarkMode = false;

        public MainForm()
        {
            //InitializeComponent();
            InitializeTextEditor();
        }

        private void InitializeTextEditor()
        {
            richTextBox = new RichTextBox();
            richTextBox.Dock = DockStyle.Fill;
            richTextBox.Font = new Font("Consolas", 12f);
            richTextBox.TextChanged += RichTextBox_TextChanged;

            Controls.Add(richTextBox);

            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("File");
            ToolStripMenuItem openMenuItem = new ToolStripMenuItem("Open");
            openMenuItem.Click += OpenMenuItem_Click;
            fileMenu.DropDownItems.Add(openMenuItem);

            ToolStripMenuItem saveAsMenuItem = new ToolStripMenuItem("Save As");
            saveAsMenuItem.Click += SaveAsMenuItem_Click;
            fileMenu.DropDownItems.Add(saveAsMenuItem);

            ToolStripMenuItem darkModeMenuItem = new ToolStripMenuItem("Dark Mode");
            darkModeMenuItem.Click += DarkModeMenuItem_Click;
            fileMenu.DropDownItems.Add(darkModeMenuItem);

            menuStrip.Items.Add(fileMenu);

            Controls.Add(menuStrip);
        }

        private void RichTextBox_TextChanged(object sender, EventArgs e)
        {
            // Call syntax highlighting method here
            HighlightSyntax();
        }

        private void HighlightSyntax()
        {
            // Syntax highlighting code remains the same
            // ...

            // Example of setting background and text color based on dark mode
            if (isDarkMode)
            {
                richTextBox.BackColor = Color.Black;
                richTextBox.ForeColor = Color.White;
            }
            else
            {
                richTextBox.BackColor = SystemColors.Window;
                richTextBox.ForeColor = SystemColors.WindowText;
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            // File open code remains the same
            // ...
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            // File save code remains the same
            // ...
        }

        private void DarkModeMenuItem_Click(object sender, EventArgs e)
        {
            // Toggle dark mode
            isDarkMode = !isDarkMode;
            HighlightSyntax(); // Refresh syntax highlighting after changing mode
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

