using System;
using System.Collections;
using UnityEngine;

namespace _Source.Game.Resource
{
  public class ResourceProductionBuilding : MonoBehaviour
  {
    [SerializeField] private float _baseProductionMultiplier;
    [SerializeField] private float _baseProductionTime;
    [SerializeField] private ResourceVisual _resourceVisual;

    public void Buy()
    {
      StartCoroutine(Coroutine());
    }

    public float GetProductionTime()
    {
      return _baseProductionTime * (float)Math.Pow(_baseProductionMultiplier, _resourceVisual._gameManager.GetResource(_resourceVisual._gameResourceType).Level);
    }

    private void Build()
    {
      _resourceVisual._gameManager.AddResourceAmount(_resourceVisual._gameResourceType, 1);
    }
    
    private IEnumerator Coroutine()
    {
      _resourceVisual._produceButton.enabled = false;
      float timeElapsed = 0;

      while (timeElapsed < GetProductionTime())
      {
        timeElapsed += Time.deltaTime;
        _resourceVisual._resourceSlider.UpdateSlider(timeElapsed / GetProductionTime());
        yield return null;
      }

      Build();
      _resourceVisual._resourceSlider.UpdateSlider(0);
      _resourceVisual._produceButton.enabled = true;
    }
  }
}