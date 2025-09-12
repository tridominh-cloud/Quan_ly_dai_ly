namespace Quan_ly_dai_ly.RepositoryInterfaces;

public interface IThamSoRepository 
{
    Task<string> GetThamSo(string key);
}