using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuadraticEquationMath : MonoBehaviour
{



    float a;
    float b;
    float c;
    float discriminant;
    float firstNum;

    float first;
    float second;
    float third;


    string plusminus1;
    string plusminus2;
    

    public string fullequation;

    void Awake()
    {
        a = Random.Range(-9, 9);
        b = Random.Range(-55, 55);
        c = Random.Range(-75, 75);

        if (a == 0)
        {
            a = 1;
        }
        if (b == 0)
        {
            b = 1;
        }
        if (c == 0)
        {
            c = 1;
        }



        if (b < 0 && c < 0) {
            fullequation = a + "x" + b + "x" + c + "=0";
        }
       else if (b > 0 && c < 0)
        {
            fullequation = a + "x+" + b + "x" + c + "=0";
        }
        else if (b < 0 && c > 0)
        {
            fullequation = a + "x" + b + "x+" + c + "=0";
        }
        else
        {
            fullequation = a + "x+" + b + "x+" + c + "=0";
        }


        first = -1 * b;
        second = ((b * b) - (4 * a * c));
        third = 2 * a;


        firstNumber();
        finalnumber();

        //DISCRINANT = 0 = 1 solution
        //discriminant > 1 = 2 solution
        //discriminant < 1 = 0 solution 
    }

    void firstNumber()
    {
        float discrim = ((b * b) - (4 * a * c));
        for (float i = 200; i >= 1; i--)//281 becuase the max value for the distance
                                        //is 78408 and 281 x 281 is 78941 or something
        {
            float temp = Mathf.Pow(i, 2);
            if (discrim % temp == 0)
            {
                firstNum = i;
                break;
            }
        }
    }

   void finalnumber()
    {
        float discrim = ((b * b) - (4 * a * c));
        float temp = discrim / (firstNum * firstNum);

        if(firstNum != 1)
        {
            first = first * firstNum;
            second = temp;
        }

        print(first + "+-√" + second + "/" + third);



    }



}
