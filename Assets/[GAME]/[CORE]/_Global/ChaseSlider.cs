using UnityEngine.UI;
using UnityEngine;

public class ChaseSlider
{
    private readonly Image slider;
    private readonly GameObject root;
    private readonly float maxVal;

    public ChaseSlider(Image slider, float _maxVal, GameObject _root)
    {
        this.slider = slider;
        maxVal = _maxVal;
        root = _root;
    }

    public float GetValue(float val)
    {
        return val / maxVal;
    }

    public void SetValue(float val)
    {
        if (GetValue(val) <= maxVal)
        {
            slider.fillAmount = GetValue(val);
        }
    }

    public void UpdateSlider()
    {
        SetActiveSlider(slider.fillAmount < 1);
    }

    private void SetActiveSlider(bool val)
    {
        root.SetActive(val);
    }
}
