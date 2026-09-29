namespace MAUI.Services
{
    public static class Alerts
    {
        private static Page Page => Application.Current!.Windows[0].Page!;

        public static Task Show(string title, string message, string cancel = "OK")
            => Page.DisplayAlertAsync(title, message, cancel);

        internal static async Task Show(object value1, string message, object value2)
        {
            throw new NotImplementedException();
        }

    }
}