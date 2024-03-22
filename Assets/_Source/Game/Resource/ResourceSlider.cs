using UnityEngine;
using UnityEngine.UI;

namespace _Source.Game.Resource
{
  public class ResourceSlider : MonoBehaviour
  {
    [SerializeField] private Slider _slider;
    
    public void UpdateSlider(float value)
    {
      _slider.value = value;
    }
  }
}