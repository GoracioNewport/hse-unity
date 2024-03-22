using TMPro;
using UnityEngine;

namespace _Source.Game
{
  public class CardView : MonoBehaviour
  {
    private CardInstance _cardInstance;
    private bool _rotatedUp;
    [SerializeField] private Sprite _cardBack;
    [SerializeField] private SpriteRenderer _spriteRenderer;
    [SerializeField] private TextMeshProUGUI _displayText;
    
    public void Init(CardInstance cardInstance)
    {
      _cardInstance = cardInstance;

      Rotate(false);
    }

    public void Rotate(bool up)
    {
      _rotatedUp = up;

      if (up)
      {
        _spriteRenderer.sprite = _cardBack;
        _spriteRenderer.color = Color.white;
        _displayText.text = "";
      }

      else
      {
        _spriteRenderer.sprite = _cardInstance.CardAsset.Image;
        _spriteRenderer.color = _cardInstance.CardAsset.Color;
        _displayText.text = _cardInstance.CardAsset.DisplayName;
      }
    }

    public void PlayCard()
    {
      _cardInstance.MoveToLayout(_cardInstance.CardGame._commonFieldLayoutId);
    }
  }
}