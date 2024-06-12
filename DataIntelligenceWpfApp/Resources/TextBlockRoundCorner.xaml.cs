using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

//namespace DataIntelligenceWpfApp.Resources
//{
//    /// <summary>
//    /// Interaction logic for TextBlockRoundCorner.xaml
//    /// </summary>
//    public partial class TextBlockRoundCorner : UserControl
//    {
//        public static readonly DependencyProperty TextProperty =
//        DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBlockRoundCorner), new PropertyMetadata(default(string)));

//        public string Text
//        {
//            get => (string)GetValue(TextProperty);
//            set => SetValue(TextProperty, value);
//        }

//        public TextBlockRoundCorner()
//        {
//            InitializeComponent();

//            // Bind the TextBlock's Text property to this control's Text property
//            ContentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text)) { Source = this });
//        }

//    }
//}

namespace DataIntelligenceWpfApp.Resources
{
    public partial class TextBlockRoundCorner : UserControl
    {
        public static readonly DependencyProperty TextProperty =
        DependencyProperty.Register(nameof(Text), typeof(string), typeof(TextBlockRoundCorner), new PropertyMetadata(default(string)));

        public string Text
        {
            get => (string)GetValue(TextProperty);
            set => SetValue(TextProperty, value);
        }

        public TextBlockRoundCorner()
        {
            InitializeComponent();
            ContentTextBlock.SetBinding(TextBlock.TextProperty, new Binding(nameof(Text)) { Source = this });
        }
    }
}
