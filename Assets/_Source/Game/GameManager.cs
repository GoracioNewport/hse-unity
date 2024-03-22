using _Source.Core;
using UnityEngine;

namespace _Source.Game
{
  public class GameManager : MonoBehaviour
  {
    private readonly ResourceBank _resourceBank = new();
    private void Awake()
    {
      _resourceBank.AddResource(GameResourceType.Humans, 10, 0);
      _resourceBank.AddResource(GameResourceType.Food, 5, 0);
      _resourceBank.AddResource(GameResourceType.Wood, 5, 0);
    }
    
    public GameResource GetResource(GameResourceType resource)
    {
      return _resourceBank.GetResource(resource);
    }
    
    public void AddResourceAmount(GameResourceType resource, int amount)
    {
      _resourceBank.AddResource(resource, amount, 0);
    }

    public void AddResourceLevel(GameResourceType resource, int level)
    {
      _resourceBank.AddResource(resource, 0, level);
    }
  }
}