using System.Collections.Generic;

namespace _Source.Core
{
  public class ResourceBank
  {
    private readonly Dictionary<GameResourceType, GameResource> _gameResources = new();
    
    public void AddResource(GameResourceType resource, int amount, int level)
    {
      TouchResource(resource);
      _gameResources[resource].Amount.Value += amount;
      _gameResources[resource].Level += level;
    }
    
    public GameResource GetResource(GameResourceType resource)
    {
      TouchResource(resource);
      return _gameResources[resource];
    }
    
    private void TouchResource(GameResourceType resource)
    {
      if (!_gameResources.ContainsKey(resource))
      {
        _gameResources.Add(resource, new GameResource(resource, 0, 0));
      }
    }
  }
}