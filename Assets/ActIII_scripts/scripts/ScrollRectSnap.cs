﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScrollRectSnap : MonoBehaviour {


    public RectTransform panel;
    public Button[] bttn;
    public RectTransform center; //cneter to compare distance from each button


    private float[] distance; //all buttons distance to the center

    private bool dragging = false;
    private int bttnDistance; // will hold the distance between the buttons
    private int minButtonNum; // will hold the num of button with smallest distance;


	// Use this for initialization
	void Start () {
        int bttnLength = bttn.Length;
        distance = new float[bttnLength];

        //get distance between buttons
        bttnDistance = (int)Mathf.Abs(bttn[1].GetComponent<RectTransform>().anchoredPosition.x - bttn[0].GetComponent<RectTransform>().anchoredPosition.x);
     
            
            }
	
	// Update is called once per frame
	void Update () {
        for(int i = 0; i < bttn.Length; i++)
        {
            distance[i] = Mathf.Abs(center.transform.position.x - bttn[i].transform.position.x);
        }

        float minDistance = Mathf.Min(distance);
        
        for (int a = 0; a < bttn.Length; a++)
        {
            if (minDistance == distance[a])
            {
                minButtonNum = a;

            }
        }
        if (!dragging)
        {
            LerpToBttn(minButtonNum * -bttnDistance);
        }
	}
    void LerpToBttn (int position)
    {
        float newX = Mathf.Lerp(panel.anchoredPosition.x, position, Time.deltaTime * 10f);
        Vector2 newPosition = new Vector2(newX, panel.anchoredPosition.y);

        panel.anchoredPosition = newPosition;
    }

    public void StartDrag()
    {
        dragging = true;
    }

    public void EndDrag ()
    {
        dragging = false;
    }
}
