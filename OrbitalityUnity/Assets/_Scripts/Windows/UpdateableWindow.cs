namespace Windows
{
    public abstract class UpdateableWindow : Window
    {
        public override void Show()
        {
            UpdateData();
            base.Show();
        }

        protected abstract void UpdateData();
    }
}