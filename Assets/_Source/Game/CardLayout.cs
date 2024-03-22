using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Source.Game
{
  public class CardLayout : MonoBehaviour
  {
    public int LayoutId;
    public Vector2 CardOffset;
    [SerializeField] private CardGame _cardGame;
    [SerializeField] private bool _faceUp;


    private void Update()
    {
      foreach (CardInstance card in _cardGame.GetCardsInLayout(LayoutId)) {
        var cardView = _cardGame.CardInstanceToView[card];
        cardView.transform.SetParent(transform);
        
        cardView.transform.localPosition = new Vector3(
          CardOffset.x * card.LayoutPosition, 
          CardOffset.y * card.LayoutPosition, 
          -card.LayoutPosition
        );
        
        cardView.Rotate(_faceUp);
      }
    }

    public void ShuffleLayout()
    {
      List<CardInstance> cards = ShuffleList(_cardGame.GetCardsInLayout(LayoutId));
      for (int i = 0; i < cards.Count; i++)
      {
        cards[i].LayoutPosition = i;
      }
    }
    
    private List<CardInstance> ShuffleList(List <CardInstance> list)
    {
      for (int i = list.Count - 1; i > 0; i--)
      {
        int j = UnityEngine.Random.Range(0, i + 1);
        (list[i], list[j]) = (list[j], list[i]);
      }
      return list;
    }
  }
  
}