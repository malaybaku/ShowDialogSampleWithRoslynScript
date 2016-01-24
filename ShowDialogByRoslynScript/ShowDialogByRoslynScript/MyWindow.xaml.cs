using System.Windows;

namespace DialogSample
{
    /// <summary>
    /// MyWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MyWindow : Window
    {
        public MyWindow()
        {
            InitializeComponent();
        }

        private void OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            PersonName = textBox.Text;
            IsMale = checkBox.IsChecked.GetValueOrDefault();
            DialogResult = true;
            Close();
        }

        public string PersonName { get; private set; }
        public bool IsMale { get; private set; }
    }
}
