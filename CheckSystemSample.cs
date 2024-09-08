using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckSystemSample : MonoBehaviour
{
    public InputField answerX;
    public InputField answerY;
    public string myTextX;
    public string myTextY;
    public GameObject Main;
    public Text correct;
    public GameObject hintscreen1;
    public GameObject hintscreen2;
    public Text hint1;
    public Text hint2;
    public Text hint3;
    public Text hint4;
    public Text hint5;
    public Text error;
    public GameObject HintReturn;
    public GameObject next;

    public GameObject finalReturn;
    
    int counter;

    public void checkAnswer()
    {
        myTextX = answerX.text;
        myTextY = answerY.text;
        error.enabled = false;
        correct.enabled = false;
        if (myTextX == "2" && myTextY == "3")
        {
            Main.SetActive(false);
            hintscreen1.SetActive(true);
            hint1.enabled = true;
            hint2.enabled = true;
            correct.enabled = true;
            next.SetActive(true);
            HintReturn.SetActive(true);
        }
        else
        {
            error.enabled = true;
            Main.SetActive(false);
            hintscreen1.SetActive(true);
            hint1.enabled = true;
            hint2.enabled = true;
            next.SetActive(true);
            HintReturn.SetActive(true);
        }
        }
    public void hints()
    {
        error.enabled = false;
        correct.enabled = false;
        HintReturn.SetActive(true);
        Main.SetActive(false);
        counter += 1;
        if (counter == 1)
        {
            hintscreen1.SetActive(true);
            hint1.enabled = true;
        }
        if (counter == 2)
        {
            hint2.enabled = true;
            hintscreen1.SetActive(true);
        }
        if (counter == 3)
        {
            hintscreen1.SetActive(false);
            hintscreen2.SetActive(true);
            finalReturn.SetActive(true);
            hint3.enabled = true;
        }
        if (counter == 4)
        {
            hintscreen2.SetActive(true);
            finalReturn.SetActive(true);
            hint4.enabled = true;
        }
        if (counter == 5)
        {
            hintscreen2.SetActive(true);
            finalReturn.SetActive(true);
            hint5.enabled = true;
        }

    }
    public void back()
    {
        answerX.text = "";
        answerY.text = "";
        HintReturn.SetActive(false);
        hintscreen1.SetActive(false);
        hintscreen2.SetActive(false);
        Main.SetActive(true);
    }

    public void nextButton()
    {
        hintscreen1.SetActive(false);
        hintscreen2.SetActive(true);
        hint1.enabled = false;
        hint2.enabled = false;
        hint3.enabled = true;
        hint4.enabled = true;
        hint5.enabled = true;
        finalReturn.SetActive(true);
    }
}
