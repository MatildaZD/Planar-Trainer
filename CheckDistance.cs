using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckDistance : MonoBehaviour
{
    public InputField answer;
    public string myText;
    string answer_;
    public GameObject Main;
    public Text correct;
    public GameObject hintscreen;
    public Text hint1;
    public Text hint2;
    public GameObject hint3;
    public GameObject hint4;
    public Text error;
    public GameObject HintReturn;
    public Image distance;
    public GameObject finalReturn;
    float x1;
    float x2;
    float y1;
    float y2;

    public Text x1_;
    public Text x2_;
    public Text y1_;
    public Text y2_;

   

    int counter;
    private void Start()
    {
        
        answer_ = FindObjectOfType<DistanceMath>().stringanswer;
        x1 = FindObjectOfType<DistanceMath>().x1;
        y1 = FindObjectOfType<DistanceMath>().y1;
        x2 = FindObjectOfType<DistanceMath>().x2;
        y2 = FindObjectOfType<DistanceMath>().y2;

        x1_.text = x1.ToString();
        x2_.text = x2.ToString();
        y1_.text = y1.ToString();
        y2_.text = y2.ToString();


    }

    public void checkAnswer()
    {
        
        myText = answer.text;
        myText = myText.Trim();

        if (myText == answer_)
        { 
            Main.SetActive(false);
            hintscreen.SetActive(true);
            hint1.enabled = true;
            hint2.enabled = true;
            hint3.SetActive(true);
            hint4.SetActive(true);
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
            hint3.SetActive(true);
            hint4.SetActive(true);
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
            hint3.SetActive(true);
        }
        if (counter == 4)
        {
            hint4.SetActive(true);
        }

    }
    public void back()
    {
        HintReturn.SetActive(false);
        hintscreen.SetActive(false);
        Main.SetActive(true);
    }
}
