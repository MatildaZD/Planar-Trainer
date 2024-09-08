using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hint4Distance : MonoBehaviour
{
    float x1;
    float x2;
    float y1;
    float y2;

    public Text x1_;
    public Text x2_;
    public Text y1_;
    public Text y2_;
    public Text Subtracted1;
    public Text Subtracted2;
    public Text Square1;
    public Text Square2;
    public Text s1;
    public Text s2;
    public Text plus1;
    public Text plus2;
    public Text unsimplified;
    public Text simplified;

    private void Start()
    {
        simplified.text = FindObjectOfType<DistanceMath>().stringanswer;
        x1 = FindObjectOfType<DistanceMath>().x1;
        y1 = FindObjectOfType<DistanceMath>().y1;
        x2 = FindObjectOfType<DistanceMath>().x2;
        y2 = FindObjectOfType<DistanceMath>().y2;

        x1_.text = x1.ToString();
        x2_.text = x2.ToString();
        y1_.text = y1.ToString();
        y2_.text = y2.ToString();

        float temp1 = x2 - x1;
        float temp2 = y2 - y1;
        Subtracted1.text = temp1.ToString();
        Subtracted2.text = temp2.ToString();

        s1.text = temp1.ToString();
        s2.text = temp2.ToString();

        Square1.text = (temp1 * temp1).ToString();
        Square2.text = (temp2 * temp2).ToString();

        float temp3 = (temp1 * temp1) + (temp2 * temp2);

        plus1.text = (temp1 * temp1).ToString() + " +";
        plus2.text = (temp2 * temp2).ToString() + " =" ;

        unsimplified.text = "√" + temp3.ToString();

    }
}


