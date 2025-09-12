using System.Globalization;

namespace Quan_ly_dai_ly.Utils;

public static class AlertUtil
{
    public static async Task ShowErrorAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Lỗi", message, "OK");
        }
    }

    public static async Task ShowSuccessAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Thành công", message, "OK");
        }
    }

    public static async Task ShowInfoAlert(string message)
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            await mainPage.DisplayAlert("Thông báo", message, "OK");
        }
    }

    public static async Task<bool> ShowConfirmAlert(string title, string message, string accept = "Có", string cancel = "Không")
    {
        var mainPage = Application.Current?.MainPage;
        if (mainPage != null)
        {
            return await mainPage.DisplayAlert(title, message, accept, cancel);
        }
        return false;
    }
}
public class PlusOneConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is int index)
            return index + 1;
        return 0;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}

