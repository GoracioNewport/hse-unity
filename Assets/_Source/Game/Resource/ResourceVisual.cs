using System;
using _Source.Core;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace _Source.Game.Resource 
{
  public class ResourceVisual : MonoBehaviour
  {
    public GameManager _gameManager;
    public ResourceProductionBuilding _resourceProductionBuilding;
    public GameResourceType _gameResourceType;
    public TextMeshProUGUI _text;
    public Button _produceButton;
    public Button _upgradeButton;
    public ResourceSlider _resourceSlider;
    private void Start()
    {
      _gameManager.GetResource(_gameResourceType).Amount.OnValueChanged += UpdateText;
      UpdateText(_gameManager.GetResource(_gameResourceType).Amount.Value);
    }

    private void UpdateText(int value)
    {
      _text.SetText(Enum.GetName(typeof(GameResourceType), _gameResourceType) + ": " + value + ", (Rate: " + (1 / _resourceProductionBuilding.GetProductionTime()).ToString("n2") + " unit/s)");
    }
    
    public void ProcessProduceButtonPressed() 
    {
      _resourceProductionBuilding.Buy();
    }

    public void ProcessUpgradeButtonPressed()
    {
      _gameManager.AddResourceLevel(_gameResourceType, 1);
    }
  }
}