using System;
using Gtk;

class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        //Create a new window
        var window = new Window("Application");
        window.SetDefaultSize(800, 600);

        //Create a grid to hold the elements
        var grid = new Grid();
        grid.ColumnSpacing = 6;

        //Create a text field
        var textField = new Entry();
        textField.Text = "";
        textField.Hexpand = true; 
        grid.Attach(textField, 0,0,1,1);

        //Create a button
        var button = new Button("Submit text");
        button.Clicked += (sender, e) => { Console.WriteLine($"{textField.Text}" ); };
        SetButtonColor(button, "#3498db");
        grid.Attach(button, 0,1,1,1);

        //Add the box to the window
        window.Add(grid);

        //Center the window
        window.SetPosition(WindowPosition.Center);
        
        //Connect the delete event to handle app closing 
        window.DeleteEvent += (o, args) => 
        { 
            Console.WriteLine("Closing application...");
            Application.Quit(); 
        };

        //Show all elements in the window
        window.ShowAll();

        //Run the application
        Application.Run();

    }

    static void SetButtonColor(Button button, string color)
    {
        var cssProvider = new CssProvider();
        cssProvider.LoadFromData($"button {{ background-color: {color}; }}");

        var styleContext = button.StyleContext;
        styleContext.AddProvider(cssProvider, 800);

        //Ensure the style is applied immidiately
        button.QueueDraw();
    }
}