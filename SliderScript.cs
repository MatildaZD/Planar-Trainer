using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderScript : MonoBehaviour
{

    public Slider yourSlider;
    public Text sliderText;
    float valueofslider;



    // Update is called once per frame
    private void Start()
    {
        valueofslider = PlayerPrefs.GetFloat("valueofslider");
        yourSlider.value = valueofslider;
    }

    
    void Update()
    { 
       
        sliderText.text = yourSlider.value.ToString();
        PlayerPrefs.SetFloat("valueofslider", valueofslider);

        PlayerPrefs.Save();
    }
   
}
   
