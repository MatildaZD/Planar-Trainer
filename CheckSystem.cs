using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CheckSystem : MonoBehaviour
{

    public InputField answerx;
    public InputField answery;
    string myTextx;
    string myTexty;

    string equation1;
    string equation2;
    public Text eq1;
    public Text eq2;


    string mathMethod;
    float finalx;
    float finaly;
    public Text hint1;
    public Text hint2;
    public Text hint3;
    public Text hint4;
    public Text hint5;

    public GameObject maincanvas;
    public GameObject hintCanvas;


   int hintcounter;

    public Text hinttext;
    public Text correctT;
    public Text incorrectT;
 

    private void Start()
    {
        equation1 = FindObjectOfType<SystemMath>().equation1;
        equation2 = FindObjectOfType<SystemMath>().equation2;
        mathMethod = FindObjectOfType<SystemMath>().Mathmethod; 
        eq1.text = equation1.ToString();
        eq2.text = equation2.ToString();
        finalx = FindObjectOfType<SystemMath>().finalx;
        finaly = FindObjectOfType<SystemMath>().finaly;
        FindObjectOfType<SystemMath>().method();
       
        hint3.text = FindObjectOfType<SystemMath>().hint3;
        hint4.text = FindObjectOfType<SystemMath>().hint4;
        hint5.text = FindObjectOfType<SystemMath>().hint5;
        hint1.text = FindObjectOfType<SystemMath>().hint1;
        hint2.text = FindObjectOfType<SystemMath>().hint2;
      


    }

    public void checkAnswer()
    {
        char[] toTrim = { ' ', '0' };
        myTextx = answerx.text;
        myTextx = myTextx.Trim(toTrim);
        myTexty = answery.text;
        myTexty = myTexty.Trim(toTrim);

        //these lines make sure that if theres a lack of zero before the decimal that it
        //still accepts the answer 
        if (answerx.text == ""|| answery.text == "")
        {
            incorrect();
        }
        else if(answerx.text[0] == '-' && answerx.text[1] == '.')
        {
           myTextx= myTextx.Insert(1, "0");
        }
       else  if (answery.text[0] == '-' && answery.text[1] == '.')
        {
            myTexty = myTexty.Insert(1, "0");
        }
        
        //checks for both zeros in front and without
        if (myTextx == finalx.ToString().Trim(toTrim) && myTexty == finaly.ToString().Trim(toTrim))
        {
            correct();
        }
        else if (myTextx == finalx.ToString() && myTexty == finaly.ToString())
        {
            correct();
        }
        else
        {

            incorrect();
        }
    }
   
    public void hints()
    {
        correctT.enabled=false;
        incorrectT.enabled = false;
        hinttext.enabled = true;


        hint1.enabled = false;
        hint2.enabled = false;
        hint3.enabled = false;
        hint4.enabled = false;
        hint5.enabled = false;

        maincanvas.SetActive(false);
        hintCanvas.SetActive(true);
     
        hintcounter = 1;
       
        if(hintcounter == 1)
        {
            hint1.enabled = true;
        }
        
    }
    public void outofhints()
    {
        hintCanvas.SetActive(false);
        maincanvas.SetActive(true);

    }
    public void nextHints()
    {
  
        if (hint1.enabled == true)
        {
            hintcounter = 2;
            hint1.enabled = false;
            hint1.GetComponentInChildren<Text>().enabled = true;

        }
        if (hint2.enabled == true)
        {
            hintcounter = 3;
            hint2.enabled = false;
        }
        if (hint3.enabled == true)
        {
            hintcounter = 4;
            hint3.enabled = false;
        }
        if (hint4.enabled == true)
        {
            hintcounter = 5;
            hint1.enabled = false;

        }
        if (hint5.enabled == true)
        {
           
        }
        hint1.enabled = false;
        hint2.enabled = false;
        hint3.enabled = false;
        hint4.enabled = false;
        hint5.enabled = false;
       
        if (hintcounter == 1)
        {
            hint1.enabled = true;
        }
        if (hintcounter == 2)
        {
          
            hint2.enabled = true;
        }
        if (hintcounter == 3)
        {
         
            hint3.enabled = true;

        }
        if (hintcounter == 4)
        {
           
            hint4.enabled = true;

        }
        if (hintcounter >= 5)
        {
            
            hint5.enabled = true;
            hintcounter = 5;

        }
    }
    public void backhints()
    {
        if(hint1.enabled == true)
        {
            
        }
        if(hint2.enabled == true)
        {
            hint1.enabled = true;
            hint2.enabled = false; 
        }
        if(hint3.enabled == true)
        {
            hint2.enabled = true;
            hint3.enabled = false; 
        }
        if(hint4.enabled == true)
        {
            hint3.enabled = true;
            hint4.enabled = false;
        }
        if (hint5.enabled == true)
        {
            hint4.enabled = true;
            hint5.enabled = false;
        }
      
       
    }

    void correct()

    {
        hint1.enabled = false;
        hint2.enabled = false;
        hint3.enabled = false;
        hint4.enabled = false;
        hint5.enabled = false;
        hinttext.enabled = false;
        incorrectT.enabled = false;
        correctT.enabled = true;
        maincanvas.SetActive(false);
        hintCanvas.SetActive(true);

        hintcounter = 1;

        if (hintcounter == 1)
        {
            hint1.enabled = true;
        }
       
        
    }

    void incorrect()
    {
        hint1.enabled = false;
        hint2.enabled = false;
        hint3.enabled = false;
        hint4.enabled = false;
        hint5.enabled = false;
        hinttext.enabled = false;
        correctT.enabled = false;
        incorrectT.enabled = true;
        maincanvas.SetActive(false);
        hintCanvas.SetActive(true);

        hintcounter = 1;

        if (hintcounter == 1)
        {
            hint1.enabled = true;
        }
    
    }
}
