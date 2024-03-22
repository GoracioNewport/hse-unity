namespace _Source.Game
{
  public class CardInstance
  {
    public CardGame CardGame;
    public CardAsset CardAsset;
    public int LayoutId;
    public int LayoutPosition;
    
    public CardInstance(CardGame cardGame, CardAsset cardAsset)
    {
      CardGame = cardGame;
      CardAsset = cardAsset;
    }
    
    public void MoveToLayout(int layoutId)
    {
      int oldLayoutId = LayoutId;
      
      LayoutId = layoutId;
      LayoutPosition = 0;
      
      CardGame.RecalculateLayout(oldLayoutId);
      CardGame.RecalculateLayout(LayoutId);
    }
  }
}