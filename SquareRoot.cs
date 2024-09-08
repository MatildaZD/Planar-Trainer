using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SquareRoot: MonoBehaviour
{
    public InputField answer;

    public void squareRoot()
    {
        answer.text += "√";
    }
}
