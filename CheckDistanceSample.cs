using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDistanceSample : MonoBehaviour
{
    public InputField answer;
    public string myText;
    public GameObject Main;
    public Text correct;
    public GameObject hintscreen;
    public Text hint1;
    public Text hint2;
    public Text hint3;
    public Text hint4;
    public Text error;
    public GameObject HintReturn;
    public Image distance;
    public GameObject finalReturn;

    int counter; 
    public void checkAnswer()
    {
        myText = answer.text;
        if (myText == "√61")
        { 
            Main.SetActive(false);
            hintscreen.SetActive(true);
            hint1.enabled = true;
            hint2.enabled = true;
            hint3.enabled = true;
            hint4.enabled = true;
            correct.enabled = true;
            distance.enabled = true;
            finalReturn.SetActive(true);


        }
        else
        {
            error.enabled = true;
            Main.SetActive(false);
            hintscreen.SetActive(true);
            hint1.enabled = true;
            hint2.enabled = true;
            hint3.enabled = true;
            hint4.enabled = true;
            
            distance.enabled = true;
            finalReturn.SetActive(true);
        }
    }
    public void hints()
    {
        HintReturn.SetActive(true);
        hintscreen.SetActive(true);
        Main.SetActive(false);
        counter += 1;
        if(counter == 1)
        {
            hint1.enabled = true;
        }
        if (counter == 2)
        {
            hint2.enabled = true;
            distance.enabled = true;
        }
        if (counter == 3)
        {
            hint3.enabled = true;
        }
        if (counter == 4)
        {
            hint4.enabled = true;
        }

    }
    public void back()
    {
        HintReturn.SetActive(false);
        hintscreen.SetActive(false);
        Main.SetActive(true);
    }
}
