using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceMath : MonoBehaviour
{
    public Text point1;
    public Text point2;
    public float x1;
    public float y1;
    public float x2;
    public float y2;
    float answer;
    float firstNum;
    public string stringanswer;
    

    private void Awake()
    {
        firstNum = 1; 
        x1 = Random.Range(-99, 99);
        y1 = Random.Range(-99, 99);
        x2 = Random.Range(-99, 99);
        y2 = Random.Range(-99, 99);
        point1.text = "(" + x1.ToString() + "," + y1.ToString() + ")";
        point2.text = "(" + x2.ToString() + "," + y2.ToString() + ")";

        answer = ((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1));
        firstNumber();
        final();
        print(stringanswer);
    }

    void firstNumber()
    {
        for (float i=281; i>=1; i--)//281 becuase the max value for the distance
            //is 78408 and 281 x 281 is 78941 or something
        {
         float temp =   Mathf.Pow(i, 2);
         if(answer % temp == 0)
            {
                firstNum = i;
                break;
            }
        }
    }
    void final()
    {
        float temp = answer / (firstNum * firstNum);
        if (firstNum == 1)
        {
            stringanswer = "√" + answer.ToString();
        }
        else
        {
            stringanswer = firstNum.ToString() + "√" + temp.ToString();
        }
    }

  
}
