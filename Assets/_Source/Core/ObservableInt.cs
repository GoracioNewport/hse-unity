namespace _Source.Core
{
  public class ObservableInt
  {
    private int _value;

    public System.Action<int> OnValueChanged;

    public ObservableInt(int value)
    {
      _value = value;
    }

    public int Value
    {
      get => _value;

      set
      {
        _value = value;
        OnValueChanged?.Invoke(_value);
      }
    }
  }
}