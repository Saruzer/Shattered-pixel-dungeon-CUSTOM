using System.Windows;

namespace Shattered_pixel_dungeon_CUSTOM
{
    public partial class MainWindow : Window
    {
        public List<string> SomeText { get; set; }
        public MainWindow()
        {
            DataContext = this;
            SomeText = new List<string> { "1", "2", "3" };
            InitializeComponent();
        }

        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if(e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}