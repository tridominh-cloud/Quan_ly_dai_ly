using System.Reflection;
using Quan_ly_dai_ly.Data;

namespace Quan_ly_dai_ly.Configs;

public class DataBaseConfig
{
    private readonly DataContext _dataContext;

    public DataBaseConfig(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public DataContext DataContext => _dataContext ?? throw new Exception("Database not initialized");

    //SQLite sẽ tạo ra 1 file.db
    //Làm sao để Entity FrameWork biết file db nằm ở đâu => GetResourcePath()
    public static string GetResourcePath()
    {
        //Assembly.GetExecutingAssembly().Location trả về path file dll đang chạy (để xác định chương trình của mình đang nằm ở đâu)
        //Nếu GetDirectionName trả về null lấy path folder chứa dll
        string appDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ??
                              AppDomain.CurrentDomain.BaseDirectory;

        string relativePath = Path.Combine(appDirectory, @"..\..\..\..\Resources\Database");

        string databaseDirectory = Path.GetFullPath(relativePath);
        Directory.CreateDirectory(databaseDirectory);
        return Path.Combine(databaseDirectory, $"QuanLyDaiLy.db");
    }
    //đôi khi database chưa được tạo mà đã khởi tạo app rồi -> lỗi => dùng await
    public async Task Initialize()
    {
        await _dataContext.Database.EnsureCreatedAsync();
    }
}