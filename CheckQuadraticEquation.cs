using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CheckQuadraticEquation : MonoBehaviour
{
    public InputField answerx1;
    public InputField answerx2;
    string myTextx1;
    string myTextx2;

    string equation;
    public Text fullEQ;

    public GameObject twosolutionsUI;
    public GameObject onesolutionUI;
    public GameObject noSolution;

    public GameObject button1;
    public GameObject button2;

    public GameObject backmethod;




    private void Start()
    {
        equation = FindObjectOfType<QuadraticEquationMath>().fullequation;
        fullEQ.text = equation.ToString();
    }

    public void noSol()
    {
        noSolution.SetActive(false);
        button2.SetActive(false);
        button1.SetActive(false);
        backmethod.SetActive(true);
    }

    public void onesol()
    {
        noSolution.SetActive(false);
        button2.SetActive(false);
        button1.SetActive(false);
        onesolutionUI.SetActive(true);
        twosolutionsUI.SetActive(false);
        backmethod.SetActive(true);
    }

    public void twosols()
    {
        noSolution.SetActive(false);
        button2.SetActive(false);
        button1.SetActive(false);
        onesolutionUI.SetActive(false);
        twosolutionsUI.SetActive(true);
        backmethod.SetActive(true);
    }

    public void backmethods()
    {
        noSolution.SetActive(true);
        button2.SetActive(true);
        button1.SetActive(true);
        onesolutionUI.SetActive(false);
        twosolutionsUI.SetActive(false);
        backmethod.SetActive(false);
    }
}
