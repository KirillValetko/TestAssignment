using System.Windows;
using System.Windows.Controls;

namespace TestAssignment.WPF.Controls
{
    public class CustomBtn : RadioButton
    {
        static CustomBtn()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(CustomBtn), 
                new FrameworkPropertyMetadata(typeof(CustomBtn)));
        }
    }
}
