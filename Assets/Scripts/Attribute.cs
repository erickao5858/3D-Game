using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Attribute : MonoBehaviour
{
    public bool isReplenishing, isFading;
    public float replenishingSpeed = 0.1f, fadingSpeed = 0.1f;
    public float max = 100, current = 100;
    public string Name;
    public Slider attachedHUDSlider;
    public bool Consume(float amount)
    {
        if (attachedHUDSlider == null) return false;
        if (current < amount) return false;
        current -= amount;
        SetSliderValue();
        return true;
    }
    public void Recover(float amount)
    {
        if (attachedHUDSlider == null) return;
        if (current + amount > max) current = max;
        else current += amount;
        SetSliderValue();
    }
    void FixedUpdate()
    {
        if (isReplenishing) Recover(replenishingSpeed);
        if (isFading) Consume(fadingSpeed);
    }
    void SetSliderValue()
    {
        attachedHUDSlider.value = current / max * 100f;
    }
}
