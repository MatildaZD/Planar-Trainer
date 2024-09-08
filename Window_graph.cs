using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class Window_graph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;
    private RectTransform labelTemplateX;
    private RectTransform labelTemplateY;
    private RectTransform dashTemplateX;
    private RectTransform dashTemplateY;



    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        labelTemplateX = graphContainer.Find("labelTemplateX").GetComponent<RectTransform>();
        labelTemplateY = graphContainer.Find("labelTemplateY").GetComponent<RectTransform>();
        dashTemplateX = graphContainer.Find("dashTemplateX").GetComponent<RectTransform>();
        dashTemplateY = graphContainer.Find("dashTemplateY").GetComponent<RectTransform>(); 
        List<int> valueList = new List<int>() {5,10};
        //these numbers are how high they will be
        //to make two of these just make a new value list, these will have to be randomized
        //according to eachother so that they create a line
        ShowGraph(valueList);
    }


    private GameObject createCircle(Vector2 anchoredPosition)
    {
        GameObject gameObject = new GameObject("circle", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPosition;
        rectTransform.sizeDelta = new Vector2(20, 20);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<int> valueList)
    {   //these will be what is randomized to show the line
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 10f;
        float xSize = 30f; //xscale

        GameObject lastCircleGameObject = null;
        for(int i = 0; i < valueList.Count; i++)
        {
            float xPosition = xSize + i * xSize;
            float yPosition = (valueList[i] / yMaximum) * graphHeight;
            print(xPosition-10 + ", " + yPosition);
            GameObject circleGameObject = createCircle(new Vector2(xPosition, yPosition+10));
            if (lastCircleGameObject != null)
            {
                CreateDotConnection(lastCircleGameObject.GetComponent<RectTransform>().anchoredPosition, circleGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastCircleGameObject = circleGameObject;

            RectTransform labelX = Instantiate(labelTemplateX);
            labelX.SetParent(graphContainer);
            labelX.gameObject.SetActive(true);
            labelX.anchoredPosition = new Vector2(xPosition, 10f);
            labelX.GetComponent<Text>().text = i.ToString();

            RectTransform dashX = Instantiate(dashTemplateX);
            dashX.SetParent(graphContainer);
            dashX.gameObject.SetActive(true);
            dashX.anchoredPosition = new Vector2(xPosition, 175f);
           
        }
        int separatorCount = 10; //amount of points 
        for (int i = 0; i <= separatorCount; i++)
        {
            RectTransform labelY = Instantiate(labelTemplateY);
            labelY.SetParent(graphContainer);
            labelY.gameObject.SetActive(true);
            float normalizedValue = i * 3f / separatorCount;
            labelY.anchoredPosition = new Vector2(-7f, (normalizedValue * graphHeight+20));
            labelY.GetComponent<Text>().text = Mathf.RoundToInt(normalizedValue/3 * yMaximum).ToString();

            RectTransform dashY = Instantiate(dashTemplateY);
            dashY.SetParent(graphContainer);
            dashY.gameObject.SetActive(true);
            dashY.anchoredPosition = new Vector2(235f, (normalizedValue * graphHeight + 20));
            
        }


    }

    private void CreateDotConnection(Vector2 dotPositionA, Vector2 dotPositionB)
    {
        GameObject gameObject = new GameObject("dotConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(0,0,0);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (dotPositionB - dotPositionA).normalized;
        float distance = Vector2.Distance(dotPositionA, dotPositionB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = dotPositionA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
        //code inside of getanglesfromvectorfloat
        ///
        //dir = dir.normalized;
        //float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        //if (n < 0) n += 360;

       // return n;
       

    }
}
