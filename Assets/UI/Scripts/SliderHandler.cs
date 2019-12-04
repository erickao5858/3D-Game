using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderHandler : MonoBehaviour
{
    public bool IsReplenishing, IsFading;
    public float ReplenishingSpeed = 0.1f, FadingSpeed = 0.1f;
    public Slider Slider;
    private float maxAmount = 100, currentAmount;
    void Start()
    {
        if (Slider == null) return;
        currentAmount = maxAmount;
        SetSliderValue();
    }
    void Update()
    {
        if (Slider == null) return;
        if (IsReplenishing) Recover(ReplenishingSpeed);
        if (IsFading) Consume(FadingSpeed);
        SetSliderValue();
    }
    public bool Consume(float amount)
    {
        if (Slider == null) return false;
        if (currentAmount < amount) return false;
        currentAmount -= amount;
        SetSliderValue();
        return true;
    }
    public void Recover(float amount)
    {
        if (Slider == null) return;
        if (currentAmount + amount > maxAmount) currentAmount = maxAmount;
        else currentAmount += amount;
        SetSliderValue();
    }
    private void SetSliderValue() => Slider.value = (currentAmount / maxAmount) * 100f;
}
