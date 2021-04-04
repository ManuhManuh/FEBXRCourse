using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderControlledBrightness : MonoBehaviour
{
    public Light pointLight;
    public float minIntensity;
    public float maxIntensity;
    public SliderObject slider;

    public void OnSliderValueChanged()
    {
        pointLight.intensity = Mathf.Lerp(minIntensity, maxIntensity, slider.value);
    }
}
