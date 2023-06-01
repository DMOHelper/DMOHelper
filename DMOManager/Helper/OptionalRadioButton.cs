using System.Windows.Controls;
using System.Windows;

namespace DMOHelper.Helper
{
    public class OptionalRadioButton : RadioButton
    {
        #region bool IsOptional dependency property
        public static readonly DependencyProperty IsOptionalProperty =
            DependencyProperty.Register(
                "IsOptional",
                typeof(bool),
                typeof(OptionalRadioButton),
                new PropertyMetadata((bool)true,
                    (obj, args) =>
                    {
                        ((OptionalRadioButton)obj).OnIsOptionalChanged(args);
                    }));
        public bool IsOptional
        {
            get
            {
                return (bool)GetValue(IsOptionalProperty);
            }
            set
            {
                SetValue(IsOptionalProperty, value);
            }
        }
        private void OnIsOptionalChanged(DependencyPropertyChangedEventArgs args)
        {
        }
        #endregion

        protected override void OnClick()
        {
            bool? wasChecked = this.IsChecked;
            base.OnClick();
            if (this.IsOptional && wasChecked == true)
                this.IsChecked = false;
        }
    }
}
