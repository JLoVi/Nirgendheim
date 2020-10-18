using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectSpecificButtoon : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Button>().Select();
        GetComponent<Button>().targetGraphic.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
