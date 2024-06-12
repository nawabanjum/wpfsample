using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Controls;

namespace DataIntelligenceWpfApp.Helpers
{
    public class SuccessMessageToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var message = value as string;

            if (string.IsNullOrEmpty(message))
            {
                return Brushes.Transparent;
            }

            return message.Contains("successfully") ? Brushes.Green : Brushes.Red;  // Adjust condition as needed
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class BooleanToStringConverter : IValueConverter
    {
        public string TrueValue { get; set; }
        public string FalseValue { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return FalseValue;
            else
                return (bool)value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DateTimeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DateTime dateTime = (DateTime)value;

            if (parameter is string format)
            {
                string daySuffix = GetDaySuffix(dateTime.Day);
                return dateTime.ToString(format.Replace("dd", $"d'{daySuffix}'"), culture);
            }

            throw new InvalidOperationException("Invalid format string parameter.");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        private string GetDaySuffix(int day)
        {
            switch (day)
            {
                case 1:
                case 21:
                case 31:
                    return "st";
                case 2:
                case 22:
                    return "nd";
                case 3:
                case 23:
                    return "rd";
                default:
                    return "th";
            }
        }
    }

    public class BooleanNotConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return !booleanValue;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool booleanValue)
            {
                return !booleanValue;
            }
            return value;
        }
    }

    public class BoolToEnumConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum enumValue && parameter is Enum targetValue)
            {
                return enumValue.Equals(targetValue);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue && parameter is Enum targetValue)
            {
                return targetValue;
            }
            return Binding.DoNothing;
        }
    }

    public class EnumToBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Enum enumValue && parameter is Enum targetValue)
            {
                return enumValue.Equals(targetValue);
            }
            return false;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue && boolValue && parameter is Enum targetValue)
            {
                return targetValue;
            }
            return Binding.DoNothing;
        }
    }

    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return boolValue ? Visibility.Visible : Visibility.Collapsed;
            }

            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class DaysLeftToColourConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int daysLeft)
            {
                return daysLeft <= 7 ? "Red" : "Black";
            }
            return "Black";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    /// <summary>
    /// Ensure that rows in the DSAR Workbench are colour coded based on Status and DayLeft
    /// 
    /// Version History
    /// 
    /// 5-MAR-2024 - https://js-ig.atlassian.net/browse/SAV-444 - Consider both Status and Days Left
    /// </summary>
    public class DaysLeftAndStatusToColourConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values[0] is int daysLeft && values[1] is int statusId)
            {
                // Define your range of StatusIDs that should be considered for coloring
                var statusIdsToConsider = new HashSet<int> { 1,2,3,4,5,6,7,8,9,10,11,12,13 };

                if (daysLeft <= 7 && statusIdsToConsider.Contains(statusId))
                {
                    return Brushes.Red;
                }
            }

            return Brushes.Black;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class StringToFlowDocumentConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string content = value as string;
            if (content != null)
            {
                FlowDocument doc = new FlowDocument();
                doc.Blocks.Add(new Paragraph(new Run(content)));
                return doc;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            FlowDocument doc = value as FlowDocument;
            if (doc != null)
            {
                TextRange textRange = new TextRange(doc.ContentStart, doc.ContentEnd);
                return textRange.Text;
            }
            return string.Empty;
        }
    }

    public class RichTextBoxHelper : DependencyObject
    {
        public static readonly DependencyProperty DocumentProperty =
            DependencyProperty.RegisterAttached(
                "Document",
                typeof(FlowDocument),
                typeof(RichTextBoxHelper),
                new FrameworkPropertyMetadata(null, OnDocumentChanged)
            );

        public static FlowDocument GetDocument(DependencyObject obj)
        {
            return (FlowDocument)obj.GetValue(DocumentProperty);
        }

        public static void SetDocument(DependencyObject obj, FlowDocument value)
        {
            obj.SetValue(DocumentProperty, value);
        }

        private static void OnDocumentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is RichTextBox richTextBox)
            {
                // Check if e.NewValue is not null before setting it as the Document
                if (e.NewValue is FlowDocument newFlowDocument)
                {

                    try
                    {
                        richTextBox.Document = newFlowDocument;
                    }
                    catch (Exception ex)
                    {

                    }
                }
                else
                {
                    // Optionally, you can handle the case where e.NewValue is null or not a FlowDocument.
                    // For example, you could set a default FlowDocument or log an error.
                    // richTextBox.Document = new FlowDocument(); // Set a default FlowDocument
                    // Log an error or handle the situation as needed.
                }
            }
        }
    }


}
