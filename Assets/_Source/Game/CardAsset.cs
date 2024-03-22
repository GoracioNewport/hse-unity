using UnityEngine;

namespace _Source.Game
{
  [CreateAssetMenu(fileName = "Card", menuName = "Card")]
  public class CardAsset : ScriptableObject
  {
    public string DisplayName;
    public Sprite Image;
    public Color Color;
  }
}