using Leap.Unity.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideGate : MonoBehaviour
{
    public float maxX;
    public float minX;

    public GameObject sliderObject;

    public InteractionSlider slider;

    private void Update()
    {
        float xPos = Mathf.Lerp(maxX, minX, slider.VerticalSliderValue);
        sliderObject.transform.localPosition = new Vector3(xPos, 0, 0);
    }
}
