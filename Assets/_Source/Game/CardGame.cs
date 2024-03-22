using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Source.Game
{
  public class CardGame : MonoBehaviour
  {
    public Dictionary<CardInstance, CardView> CardInstanceToView = new();
    [SerializeField] private List<CardAsset> _starterCards = new();
    [SerializeField] private GameObject _cardViewPrefab;
    public readonly int HandCapacity = 5;

    [SerializeField] private int _playerOneHandLayoutId = 0;
    [SerializeField] private int _playerOneDeckLayoutId = 1;
    [SerializeField] private int _playerTwoHandLayoutId = 2;
    [SerializeField] private int _playerTwoDeckLayoutId = 3;
    [SerializeField] public int _commonFieldLayoutId = 4;

    public void Start()
    {
      StartGame();
    }

    public void StartGame()
    {
      foreach (var cardAsset in _starterCards)
      {
        CreateCard(cardAsset, _playerOneDeckLayoutId);
        CreateCard(cardAsset, _playerTwoDeckLayoutId);
      }
      StartTurn();
    }

    public void StartTurn()
    {
      for (int i = 0; i < HandCapacity; i++)
      {
        DrawCard(_playerOneDeckLayoutId)?.MoveToLayout(_playerOneHandLayoutId);
        DrawCard(_playerTwoDeckLayoutId)?.MoveToLayout(_playerTwoHandLayoutId);
      }
    }

    private CardInstance DrawCard(int layoutId)
    {
      List<CardInstance> cards = GetCardsInLayout(layoutId);
      if (cards.Count == 0)
      {
        return null;
      }

      CardInstance card = cards[^1];
      cards.Remove(card);

      return card;
    }

    public void CreateCardView(CardInstance cardInstance)
    {
      GameObject cardObject = Instantiate(_cardViewPrefab);
      CardView cardView = cardObject.GetComponent<CardView>();
      cardView.Init(cardInstance);
      CardInstanceToView[cardInstance] = cardView;
    }

    public void CreateCard(CardAsset cardAsset, int layoutId)
    {
      CardInstance cardInstance = new(this, cardAsset);
      CreateCardView(cardInstance);
      cardInstance.MoveToLayout(layoutId);
    }

    public List<CardInstance> GetCardsInLayout(int layoutId)
    {
      return CardInstanceToView.Keys.Where(cardInstance => cardInstance.LayoutId == layoutId).ToList();
    }

    public void RecalculateLayout(int layoutId)
    {
      List<CardInstance> cards = GetCardsInLayout(layoutId);
      
      cards.Sort((a, b) => a.LayoutPosition.CompareTo(b.LayoutPosition));
      for (int i = 0; i < cards.Count; i++)
      {
        cards[i].LayoutPosition = i;
      }
    }

    public void ShuffleLayout(int layoutId)
    {
      List<CardInstance> cards = GetCardsInLayout(layoutId);
        
      
    }
  }
}