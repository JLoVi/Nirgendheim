using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollController : MonoBehaviour
{

    public ScrollRect m_ScrollRect;


    //  public Transform[] pages;
    public float transitionStep;


    private int input;

    private int previousValue;
    public AnimationCurve MoveCurve;

    public bool canScroll;
    // public ShowPhoto photoFader;

    //public GameEvent UpdateNarrativeEvent;
    //public GameEvent FadeOutPhotoEvent;

    public float currentPos;
    public float scrollTime;

    void Start()
    {
        //	canvasEndCorrectedPos = 1 - canvasEndCorrectedPos;
        input = 0;

        //	canScroll = true;

        //	currentPage = 0;

        //m_ScrollRect.horizontalNormalizedPosition = 0.5f;

        // StartCoroutine(ScrollToNormalisedPosition(3, 0.1f, 0.5f));
      // transitionStep = 0.05f;

    }

    // Update is called once per frame
    void Update()
    {


        currentPos = m_ScrollRect.horizontalNormalizedPosition;

        var x = Input.GetAxis("Horizontal");

        if (x > 0)
        {
            //  StartCoroutine(SetTOZeroAfterTime());
            input = 1;
            //  Debug.Log("1");

        }

        if (x < 0)
        {
            // StartCoroutine(SetTOZeroAfterTime());
            input = -1;
            // Debug.Log("-1");

        }

        if (x == 0)
        {
            input = 0;
            // Debug.Log("0");
        }

        //  Debug.Log(x);
        if (input == 1 && canScroll) // forward
        {

         //   canScroll = false;
            //  Debug.Log(input);
            ScrollRectForward();
            previousValue = input;

        }
        if (input == -1 && canScroll) // backwards
        {

         //   canScroll = false;
            //  Debug.Log(input);
            ScrollRectBack();
            previousValue = input;

        }


    }

    public void ScrollRectForward()
    {


        float targetPos;
        Debug.Log("forward");



        //   StartCoroutine(SetCanScroll());




        targetPos = currentPos - transitionStep;


            IEnumerator co;

         co = ScrollToNormalisedPosition(scrollTime, currentPos, targetPos);

             StopCoroutine(co); // stop it.


        StartCoroutine(ScrollToNormalisedPosition(scrollTime, currentPos, targetPos));

        //  }
        //   else { return; }

    }



    public void ScrollRectBack()
    {



        float targetPos;
        //   Debug.Log("back");
        //   StartCoroutine(SetCanScroll());




        targetPos = currentPos + transitionStep;


            IEnumerator co;
           co = ScrollToNormalisedPosition(scrollTime, currentPos, targetPos);
          StopCoroutine(co); // stop it.


        //StartCoroutine(ScrollToNormalisedPosition(scrollTime, startPos, startPos + transitionStep));
        StartCoroutine(ScrollToNormalisedPosition(scrollTime, currentPos, targetPos));

        //   }
        //   else { return; }

    }

    public IEnumerator ScrollToNormalisedPosition(float scrollT, float currentPos, float targetPos)
    {
        Debug.Log("enter coroutine");

        for (float t = 0.01f; t < scrollT; t += Time.deltaTime)
        {
            float value;
            value = Mathf.Lerp(currentPos, targetPos, MoveCurve.Evaluate(Mathf.Min(1, t / scrollT)));

            m_ScrollRect.horizontalNormalizedPosition = value;
             Debug.Log(value);
            yield return null;

        }


    }

    /*   public IEnumerator SetCanScroll()
       {

           yield return new WaitForSeconds(0.3f);
           input = 0;
           canScroll = true;
           // previousValue = 0;

       }*/


}