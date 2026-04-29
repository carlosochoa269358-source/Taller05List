namespace Shared;

public interface ILinkedList<T>
{
    void Add(T data);

    void ShowForward();

    void ShowReverse();

    void Sort();

    List<T> GetModes();

    void ShowChart();

    bool Exists(T data);

    void RemoveFirst(T data);

    void RemoveAll(T data);
}