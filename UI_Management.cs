using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI_Management : MonoBehaviour
{
    public Button yourButton;
   
    public void expandPlay()
    {
       yourButton.image.rectTransform.sizeDelta = new Vector2(20, 20);
    }
    public void expandOther()
    {
        yourButton.image.rectTransform.sizeDelta = new Vector2(10, 10);
    }
    public void leave()
    {
        yourButton.image.rectTransform.sizeDelta = new Vector2(1, 1);
    }

   
    public void Play()
    {
        SceneManager.LoadScene("Choose Type");
    }
    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }
    public void About()
    {
        SceneManager.LoadScene("About Page");
    }
    public void LinearPicker()
    {
        SceneManager.LoadScene("Linear Pick Screen");
    }
    public void Home()
    {
        SceneManager.LoadScene("Startup Scene");
    }
    public void QuadraticPicker()
    {
        SceneManager.LoadScene("Quadratics Pick Screen");
    }
    public void SystemofEQPicker()
    {
        SceneManager.LoadScene("System of Equations");
    }
    public void SystemofEQSamplePicker()
    {
        SceneManager.LoadScene("System of Equations Sample");
    }

    public void distanceSample()
    {
        SceneManager.LoadScene("Distance Sample");
    }
    public void distance()
    {
        SceneManager.LoadScene("Distance");
    }

    public void QuadraticForumula()
    {
        SceneManager.LoadScene("Quadratic Formula");
    }
}
