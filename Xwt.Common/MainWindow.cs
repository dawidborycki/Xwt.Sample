#region Using

using Xwt;

#endregion

public class MainWindow
{
    #region Fields

    private Window window;

    private Frame box;
    private HSlider horizontalShiftSlider;
    private HSlider verticalShiftSlider;

    private int boxSize = 50;

    #endregion

    #region Enums

    private enum Orientation
    {
        Horizontal, Vertical
    }

    #endregion

    #region Constructor

    public MainWindow()
    {
        // Window
        window = new Window()
        {
            Title = "Hello, Xwt!",
            Width = 500,
            Height = 500
        };

        window.Closed += (sender, e) =>
        {
            Application.Exit();
            window.Dispose();
        };

        // Layout
        var tableLayout = new Table();
        window.Content = tableLayout;

        // Button
        tableLayout.Add(CreateButton(), 0, 0, colspan: 2, hexpand: true);

        // Button
        tableLayout.Add(CreateButton(), 0, 0, colspan: 2, hexpand: true);

        // Horizontal slider
        horizontalShiftSlider = CreateSlider(Orientation.Horizontal);
        tableLayout.Add(horizontalShiftSlider, 0, 1, hexpand: true);

        // Vertical slider
        verticalShiftSlider = CreateSlider(Orientation.Vertical);
        tableLayout.Add(verticalShiftSlider, 1, 1, hexpand: true);

        // Box
        box = CreateBox();
        tableLayout.Add(box, 0, 2, colspan: 2, vexpand: true,
            vpos: WidgetPlacement.Center, hpos: WidgetPlacement.Center);

        // Show window
        window.Show();

        // Update sliders
        UpdateSliderRanges();
    }

    #endregion

    #region Helpers

    private Button CreateButton()
    {
        var button = new Button("Hello, world!")
        {
            Margin = new WidgetSpacing(10, 5, 10, 5)
        };

        button.Clicked += (sender, e) =>
        {
            MessageDialog.ShowMessage("Hello, Xwt!");
        };

        return button;
    }

    private HSlider CreateSlider(Orientation orientation)
    {
        var hSlider = new HSlider();

        hSlider.ValueChanged += (sender, e) =>
        {
            var slider = sender as Slider;

            if (orientation == Orientation.Horizontal)
            {
                box.MarginLeft = slider.Value;
            }
            else
            {
                box.MarginTop = slider.Value;
            }
        };

        return hSlider;
    }

    private Frame CreateBox()
    {
        return new Frame()
        {
            BackgroundColor = Xwt.Drawing.Color.FromBytes(255, 0, 0),
            HeightRequest = boxSize,
            WidthRequest = boxSize,
            BorderWidth = 0
        };
    }

    private void UpdateSliderRanges()
    {
        var horizontalRange = window.Content.WindowBounds.Right
            - window.Content.WindowBounds.Left - 2 * boxSize;

        var verticalRange = window.Content.WindowBounds.Bottom
            - verticalShiftSlider.WindowBounds.Bottom - 2 * boxSize;

        verticalShiftSlider.MinimumValue = -verticalRange;
        verticalShiftSlider.MaximumValue = verticalRange;

        horizontalShiftSlider.MinimumValue = -horizontalRange;
        horizontalShiftSlider.MaximumValue = horizontalRange;
    }

    #endregion
}

