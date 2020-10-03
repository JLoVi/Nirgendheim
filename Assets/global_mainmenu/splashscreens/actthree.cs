using UnityEngine;
using System.Collections;

public class actthree : MonoBehaviour {

    void Start()
    {

        StartCoroutine("MyEvent");
    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator MyEvent()
    {



        yield return new WaitForSeconds(4f);


        Application.LoadLevel("witliftanim");


    }
}
