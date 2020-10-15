using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectableButton : MonoBehaviour
{
    public void Start()
    {
        GetComponent<Selectable>().Select();
    }

    
}
