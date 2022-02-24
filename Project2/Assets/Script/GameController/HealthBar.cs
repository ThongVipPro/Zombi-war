using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    Slider slider;

    // Start is called before the first frame update
    private void Start()
    {
        //EventManager.AddPlayerHitEventListener(SetHealth);
    }   

    /// <summary>
    /// Changes the health value of the bar
    /// </summary>
    /// <param name="health">current health value</param>
    public void SetHealth(int health)
    {
        slider.value = health;
        slider.wholeNumbers = true;
    }

    /// <summary>
    /// Gives the health bar a maximum value
    /// </summary>
    /// <param name="health">maximum health value</param>
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        slider.wholeNumbers = true;
    }
}
