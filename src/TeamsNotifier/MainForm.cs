using System.Drawing;
using System.Windows.Forms;

namespace TeamsNotifier;

public class MainForm : Form
{
    public MainForm()
    {
        Text = "TeamsNotifier";

        Width = 600;
        Height = 400;

        StartPosition = FormStartPosition.CenterScreen;

        Controls.Add(new Label
        {
            Text = "TeamsNotifier запускается...",
            AutoSize = true,
            Font = new Font("Segoe UI", 16),
            Left = 40,
            Top = 40
        });
    }
}
