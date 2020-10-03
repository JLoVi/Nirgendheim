using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class pickup : MonoBehaviour {

    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;

    void OnCollisionEnter(Collision collision)
    {
        foreach(Transform child in inventoryPanel.transform)
        {
            if(child.gameObject.tag == collision.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + tcount;
                return;
            }
        }

        GameObject i;
        if (collision.gameObject.tag == "info")
        {
            i = Instantiate(inventoryIcons[0]);
            i.transform.SetParent(inventoryPanel.transform);
        }
        else if(collision.gameObject.tag == "move")
        {
            i = Instantiate(inventoryIcons[1]);
            i.transform.SetParent(inventoryPanel.transform);
        }
    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
