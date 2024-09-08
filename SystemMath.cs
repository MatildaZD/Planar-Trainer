 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMath : MonoBehaviour
{
    float x1;
    float y1;
    float x2;
    float y2;
    float equals1;
    float equals2;
    public string equation1;
    public string equation2;
    string plusminus1;
    string plusminus2;
    float[,] values;
    float[,] answers;
    float[,] xandy;
    float[,] tempMatrix;
    float[,] invertedMatrix;
    float determinant;
    public float finalx;
    public float finaly;
    public string Mathmethod;


    //for the hints
    public string hint1;
    public string hint2;
    public string hint3;
    public string hint4;
    public string hint5;

    
    bool priority = false;
    bool secondary = false;
    bool third = false;
    bool fourth = false;

    private void Awake()
    {
        //SET UP THE EQUATIONS
        x1 = Random.Range(-25, 25);
        if (x1 == 0)
        {
            x1 = 1;
        }
        y1 = Random.Range(1, 25);
        x2 = Random.Range(-25, 25);
        if (x2 == 0)
        {
            x2 = 1;
        }
        y2 = Random.Range(1, 25);
        equals1 = Random.Range(-25, 25);
        equals2 = Random.Range(-25, 25);
        int temp = Random.Range(-5, 5);
        int temp2 = Random.Range(-5, 5);
        if (temp < 0)
        {
            plusminus1 = "+";
        }
        else
        {
            plusminus1 = "-";
           

        }
        if (temp2 < 0)
        {
            plusminus2 = "+";
        }
        else
        {
            plusminus2 = "-";
           

        }
        equation1 = x1 + "x" + plusminus1 + y1 + "y=" + equals1;
        equation2 = x2 + "x" + plusminus2 + y2 + "y=" + equals2;
        //NOW WE HAVE THE TWO EQUATIONS, NOW WE HAVE TO CALCULATE  

        if (plusminus1 == "-")
        {
            y1 = y1 * -1;
        }
        if (plusminus2 == "-"){
            y2 = y2 * -1;
        }
        calculate();
    }

    void calculate()
    {
        values = new float[2, 2] { { x1, y1 }, { x2, y2 } };
        //Create the matrix that holds the x and y values
        answers = new float[1, 2] { { equals1, equals2 } };
        //matrix for the answers
        //now we need to invert the values matrix and multiply it by the answers
        //matrix to get our two x and y values
        tempMatrix = new float[2, 2] { { y2, -1 * y1 }, { -1 * x2, x1 } };
        determinant = 1 / ((x1 * y2) - (y1 * x2));
        invertedMatrix = new float[2, 2] { { tempMatrix[0, 0] * determinant, tempMatrix[0, 1] * determinant }, { tempMatrix[1, 0] * determinant, tempMatrix[1, 1] * determinant } };
        //Now we have the inverted matrix, now we just multiply the inverse by the two answers

        //multiplication:
       

        xandy = new float[1, 2] { { (invertedMatrix[0, 0] * answers[0, 0]) + (invertedMatrix[0, 1] * answers[0, 1]), (invertedMatrix[1, 0] * answers[0, 0]) + (invertedMatrix[1, 1] * answers[0, 1]) } };
        //answers = inverted x1*a1+y1*a2 
        //                   x2*a1 +y2*a2

        
        finalx = (float)System.Math.Round(xandy[0, 0], 2);
        finaly = (float)System.Math.Round(xandy[0, 1], 2);
        print("X= " + finalx + ", Y=" + finaly);


    }

    public void method() //determining if the mothd will be elimination or substitutuion 
    {
      
 
        if(x1 % x2 == 0)
        {
            priority = true;
        }
        else if (y1 % y2 == 0)
        {
            secondary = true;
        }
       else if (x2 % x1 == 0)
        {
            third = true;
        }
       else  if (y2 % y1 == 0)
        {
            fourth = true;
        }
      else
        {
            Mathmethod = "substitution";
            substitution();
        }
        if(priority == true)
        {
            P_elimination();
        }
        if (secondary == true)
        {
            S_elimination();
        }
        if (third == true)
        {
            T_elimination();
        }
        if (fourth == true)
        {
            F_elimination();
        }
       
    }
  
    public void substitution()
    {
        print("substitution");
        hint1 = "There are 2 main ways to solve systems of equations" + "\n" +
            "1.Substitution" + "\n" + "2.Elimination" + "\n" + "In this case, it would probably be best to use" + "\n" 
            + "Substitution";

        hint2 = "The substitution method:\nStep 1: Solve one of the equations for either x = or y =" + " \n" + 
           "Step 2: Substitute the solution from step 1 into the second equation" + "\n" + 
           "Step 3: Solve this new equation.";
            
        //hint3
        string step1;
        string step2;
        string step3;
        string step4;
        string step5;
        string step6;
        string step7;
        if (plusminus1 == "-")
        {
            step1 = "x " + y1 + "/" + x1 + "y" + " = " + equals1 + "/" + x1;
        }
        else
        {
             step1 = "x " + plusminus1 + " " + y1 + "/" + x1 + "y" + " = " + equals1 + "/" + x1;
        }
        if (plusminus1 == "-") {
            step2 =  equals1 + "/" + x1 + " + " + y1 + "/" + x1 + "y";
                }
        else
        {
            step2 =  equals1 + "/" + x1 + " - " + y1 + "/" + x1 + "y";
        }
            hint3 = "Isolate x in the first equation. Do this by dividing the whole equation by " +
            x1 + " which would equal:\n " + step1 + "\n" + "Then moving everything but x to the other side of the equation: \n" + "x = "  + step2;
       
        //hint4
        if (plusminus2 == "-")
        {
            step3 = x2 + "(" + step2 + ")" +  y2 + "y = " + equals2;
        }
        else
        {
            step3 = x2 + "(" + step2 + ") " + plusminus2 + " "+ y2 + "y = " + equals2;
        }
        if (plusminus2 == "-")
        {
            step4 = (equals1 / x1) * x2 + " + " + ((y1 * -1) / x1) * x2 + "y " +  y2 + "y = " + equals2;
        }
        else
        {
            step4 = (equals1 / x1) * x2 + " + " + ((y1 * -1) / x1) * x2 + "y " + plusminus2 + y2 + "y = " + equals2;
        }
        step5 = ((((y1 * -1) / x1) * x2) + y2) + "y = " + (((((equals1*-1) / x1) * x2) * 1) + equals2);
        float temp = (((((equals1 * -1) / x1) * x2) * 1) + equals2) / ((((y1 * -1) / x1) * x2) + y2);
        float rounded = (float)System.Math.Round(temp, 2);
        step6 = "y = " + rounded.ToString(); 

        hint4 = "Plug in the equation for x in terms of y into the second equation: \n" + step3 
            + "\n" + " Then distribute: \n" + step4 + "\n" + " Combine like terms: \n" + step5 + "\n" + " Simplify: \n" + step6; 
       
        if (plusminus1 == "-")
        {
            step7 = x1 + "x" + y1 + "(" + finaly + ") = " + equals1;
        }
        else
        {
            step7 = x1 + "x" + plusminus1+ y1 + "(" + finaly + ") = " + equals1;
        }

        hint5 = "Now to find x, plug in the value found for y back into the equation: \n" + step7 + "\n" + " Solving for x leads to: \n x = " + finalx + "\n" + step6; ;
       
    }
    void P_elimination()
    {
        print("elimination");
        hint123method_(x2, x1);
    }
    void S_elimination()
    {
        print("elimination");
        hint123method_(y2, y1);
    }
    void T_elimination()
    {
        print("elimination");
        hint123method(x1, x2);
    }
    void F_elimination()
    {
        print("elimination");
        hint123method(y1, y2);
    }

    //method for third and fourth elimination methods
    void hint123method(float first, float second)
    {
        string step1;
        string step2;
        string step3;
        hint1 = "There are 2 main ways to solve systems of equations" + "\n" +
            "1.Substitution" + "\n" + "2.Elimination" + "\n" + "In this case, it would probably be best to use" + "\n"
            + "Elimination";

        hint2 = "In the elimination method you either add or subtract the equations to" +
            " get an equation in one variable. When the coefficients of one " +
            "variable are opposites you add the equations to eliminate a " +
            "variable and when the coefficients of one variable are equal you " +
            "subtract the equations to eliminate a variable.";
        //checks for which value the multiplier is going to based on the values 
        

            step1 = (-1 * (second / first)) + "(" + equation1 + ")";
        if ((first > 0 && second < 0) || (first < 0 && second > 0))
        {
            if (plusminus1 == "+")
            {
                step2 = ((-1 * (second / first)) * x1) + "x+" + ((-1 * (second / first)) * y1) + "y=" + (equals1 * (-1 * (second / first)));
            }
            else
            {
                step2 = ((-1 * (second / first)) * x1) + "x" + ((-1 * (second / first)) * y1) + "y=" + (equals1 * (-1 * (second / first)));
            }
        }
        else
        {
            if (plusminus1 == "-")
            {
                step2 = ((-1 * (second / first)) * x1) + "x+" + ((-1 * (second / first)) * y1) + "y=" + (equals1 * (-1 * (second / first)));
            }
            else
            {
                step2 = ((-1 * (second / first)) * x1) + "x" + ((-1 * (second / first)) * y1) + "y=" + (equals1 * (-1 * (second / first)));
            }
        }
            hint3 = "In this case the entire first equation be multiplied by " + -1 * (second / first) + " to create " +
            "the additive inverse of the first x value for that equation: \n" + step1 + "\n Which gives us this equation: \n" +
            step2;
            //simplifies the equations into x or y based on the addition
            if (third == true)
            {
                step3 = (((-1 * (second / first)) * y1) + y2) + "y=" + ((equals1 * (-1 * (second / first))) + equals2);
                hint4 = "Now that we have our altered equation, we can add the two equations together:\n" + step2 + "\n" + equation2
                    + "\n" + "------------\n" + step3 + "\nSimplify for y:\n" + "y=" + finaly;
            if (plusminus1 == "-")
            {
                hint5 = "Finally, plug in the value found for y back into one of the equations (It does not matter which, but we will use the first one):\n" +
                    x1 + "x" + y1 + "(" + finaly + ")=" + equals1 + "\n which gives us the final solution for x: \n x=" + finalx + "\n" +
                                    "y=" + finaly;
            }

            else
            {
                hint5 = "Finally, plug in the value found for y back into one of the equations (It does not matter which, but we will use the first one):\n" +
                     x1 + "x+" + y1 + "(" + finaly + ")=" + equals1 + "\n which gives us the final solution for x: \n x=" + finalx + "\n" +
                                     "y=" + finaly;
            }
        }
            else if(fourth == true)
            {
                step3 = (((-1 * (second / first)) * x1) + x2) + "x="+ ((equals1 * (-1 * (second / first))) + equals2);
                hint4 = "Now that we have our altered equation, we can add the two equations together:\n" + step2 + "\n" + equation2
                    + "\n" + "------------\n" + step3 + "\nSimplify for x:\n" + "x=" + finalx;
            if (plusminus1 == "-")
            {
                hint5 = "Finally, plug in the value found for x back into one of the equations (It does not matter which, but we will use the first one):\n" +
                                   x1 + "(" + finalx + ")" + y1 + "y=" + equals1 + "\n which gives us the final solution for y: \n y=" + finaly + "\n" +
                                   "x=" + finalx;
            }

            else
            {
                hint5 = "Finally, plug in the value found for x back into one of the equations (It does not matter which, but we will use the first one):\n" +
                                    x1 + "(" + finalx + ")+" + y1 + "y=" + equals1 + "\n which gives us the final solution for y: \n y=" + finaly + "\n" +
                                    "x=" + finalx;
            }
        }
        }

    
        


    

    //methods for outcomes for priority and secondary elimination
    void hint123method_(float first, float second)
    {
        string step1;
        string step2;
        string step3;
        hint1 = "There are 2 main ways to solve systems of equations" + "\n" +
            "1.Substitution" + "\n" + "2.Elimination" + "\n" + "In this case, it would probably be best to use" + "\n"
            + "Elimination";

        hint2 = "In the elimination method you either add or subtract the equations to" +
            " get an equation in one variable. When the coefficients of one " +
            "variable are opposites you add the equations to eliminate a " +
            "variable and when the coefficients of one variable are equal you " +
            "subtract the equations to eliminate a variable.";
      

            step1 = (-1 * (second / first)) + "(" + equation2 + ")";
        if ((first > 0 && second < 0) || (first < 0 && second > 0))
        {
            if (plusminus2 == "+")
            {
                step2 = ((-1 * (second / first)) * x2) + "x+" + ((-1 * (second / first)) * y2) + "y=" + (equals2 * (-1 * (second / first)));
            }
            else
            {
                step2 = ((-1 * (second / first)) * x2) + "x" + ((-1 * (second / first)) * y2) + "y=" + (equals2 * (-1 * (second / first)));
            }
        }
        else
        {
            if (plusminus2 == "-")
            {
                step2 = ((-1 * (second / first)) * x2) + "x+" + ((-1 * (second / first)) * y2) + "y=" + (equals2 * (-1 * (second / first)));
            }
            else
            {
                step2 = ((-1 * (second / first)) * x2) + "x" + ((-1 * (second / first)) * y2) + "y=" + (equals2 * (-1 * (second / first)));
            }
        }
            hint3 = "In this case the entire second equation be multiplied by " + -1 * (second / first) + " to create " +
            "the additive inverse of the first x value for that equation: \n" + step1 + "\n Which gives us this equation: \n" +
            step2;
        //x2,x1
        if (priority == true)
        {
            step3 = (((-1 * (second / first)) * y2) + y1) + "y=" + ((equals2 * (-1 * (second / first))) + equals1);
            hint4 = "Now that we have our altered equation, we can add the two equations together:\n" + step2 + "\n" + equation1
                + "\n" + "------------\n" + step3 + "\nSimplify for y:\n" + "y=" + finaly;

            if (plusminus1 == "-")
            {
                hint5 = "Finally, plug in the value found for y back into one of the equations (It does not matter which, but we will use the first one):\n" +
                    x1 + "x" + y1 + "(" + finaly + ")=" + equals1 + "\n which gives us the final solution for x: \n x=" + finalx + "\n" +
                                    "y=" + finaly;
            }

            else
            {
                hint5 = "Finally, plug in the value found for y back into one of the equations (It does not matter which, but we will use the first one):\n" +
                     x1 + "x+" + y1 + "(" + finaly + ")=" + equals1 + "\n which gives us the final solution for x: \n x=" + finalx + "\n" +
                                     "y=" + finaly;
            }
        }
        
        else if (secondary == true)
        {
            step3 = (((-1 * (second / first)) * x2) + x1) + "x=" + ((equals2 * (-1 * (second / first))) + equals1);
            hint4 = "Now that we have our altered equation, we can add the two equations together:\n" + step2 + "\n" + equation1
                + "\n" + "------------\n" + step3 + "\nSimplify for x:\n" + "x=" + finalx;
            if (plusminus1 == "-")
            {
                hint5 = "Finally, plug in the value found for x back into one of the equations (It does not matter which, but we will use the first one):\n" +
                                   x1 + "(" + finalx + ")" + y1 + "y=" + equals1 + "\n which gives us the final solution for y: \n y=" + finaly + "\n" +
                                   "x=" + finalx;
            }

            else
            {
                hint5 = "Finally, plug in the value found for x back into one of the equations (It does not matter which, but we will use the first one):\n" +
                                    x1 + "(" + finalx + ")+" + y1 + "y=" + equals1 + "\n which gives us the final solution for y: \n y=" + finaly + "\n" +
                                    "x=" + finalx;
            }
        }
           
        
            

      


    }
    

}
//TO DO:
//ANSWERS CAN BE INVALID OR INFINITE, DEAL WITH THOSE 
//WHEN ANSWERS CAN ALREADY BE SOLVED BY ELIMINATION WITHOUT MULTIPLYING THE EQ BY ANYTHING

