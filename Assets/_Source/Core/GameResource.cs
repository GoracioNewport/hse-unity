namespace _Source.Core
{
  public class GameResource
  {
    public GameResourceType Type;
    public ObservableInt Amount;
    public int Level;
    
    public GameResource(GameResourceType type, int amount, int level)
    {
      Type = type;
      Amount = new ObservableInt(amount);
      Level = level;
    }
  }
}