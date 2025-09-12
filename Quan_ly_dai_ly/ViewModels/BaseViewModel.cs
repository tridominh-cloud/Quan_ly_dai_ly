using CommunityToolkit.Mvvm.ComponentModel;


public partial class BaseViewModel : ObservableObject
{
    [ObservableProperty]
    private string title = "Danh Sách Đại Lý";

    [ObservableProperty]
    [NotifyPropertyChangedFor(nameof(IsNotLoading))]
    private bool isLoading = false;
    public bool IsNotLoading => !IsLoading;

}
