using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
using System.Collections.Generic;
public class ViewGameManager : MonoBehaviour
{

    /// <summary>
    /// /camobjects
    /// </summary>
    /// 


        //this is a half-guided tour of nirgendheim. scroll through the text and press A to investigate

    //public Button[] prevbuttons;

    public GameObject[] canvases;

    //public Camera[] cameras;

    public GameObject player;

    public GameObject[] destinations;
    public int randomDestIndex;
    public int arraylength;
    public Transform finalDestsshard;


  //  public GameObject start;

//    public GameObject ScrollBar;

    public List<GameObject> cameras = new List<GameObject>();

    public navmesh targetscript;

    public UnityEngine.AI.NavMeshAgent playerAgent;

    public List<Transform> targets = new List<Transform>();



    /// <summary>
    /// audioobjects
    /// </summary>

    public AudioMixerSnapshot[] act3_sounscape1;


    public Text targetInst;
    public bool targetchange;

    public static bool shardReached;

    public bool canTeleport;

    void Start()
    {
        shardReached = false;
        canTeleport = true;

        targetscript = FindObjectOfType<navmesh>();
        //player.transform.position = start.transform.position;
        arraylength = destinations.Length - 1;


        // cameras.Add(new GameObject.Find("Camera_Shard")));

        //Turn all cameras off, except the first default one
        foreach (GameObject cam in cameras)
        {
            cam.gameObject.SetActive(false);
            
        }


        targetchange = false;

        //change destination to shard
        string s = string.Format("This is a half-guided tour of Nirgendheim. Scroll through the text and press <color=#00ff00ff>{0}</color> to investigate", GamepadController.instance.controlList.submitName);
        targetInst.text = s;

    }

    void Update()
    {
        // randomDestIndex = destinations.Length;
        //Random.Range(0, destinations.Length);
        if (arraylength > -1 && !shardReached && canTeleport && Input.GetKey(GamepadController.instance.controlList.submitControl))
        {
            Teleport();
        }

    }

   

    public void Teleport()
    {
        canTeleport = false;
        StartCoroutine(SetCanTeleport());
        Debug.Log("teleport");

        targetchange = !targetchange;
        //important change player pos dont delete


        Trans_to_snapshot(act3_sounscape1[Random.Range(0, act3_sounscape1.Length - 1)], 0.6f);

        randomDestIndex = Random.Range(0, arraylength);

        //    player.transform.position = destinations[randomDestIndex].transform.position;

        /////////////
        // player.GetComponent<NavMeshAgent>().enabled = false;
        // player.SetActive(false);

        // if (cameras.Length > 0)
        //{
        if (arraylength > -1)
        {
            cameras[randomDestIndex].SetActive(true);
            Debug.Log("Camera with name: " + cameras[randomDestIndex].GetComponent<Camera>().name + ", is now enabled");
            cameras[randomDestIndex].AddComponent<Rigidbody>();
            cameras.RemoveAt(randomDestIndex);


            targetscript.target = targets[randomDestIndex];
            targetInst.text = targetscript.target.gameObject.name;
            targets.RemoveAt(randomDestIndex);

            arraylength--;
        }

        else
        {
            targetscript.target = finalDestsshard;
        }
        /*for (int i = 0; i< destinations.Length-1; i++) {
            arraylength = i;
        Debug.Log(randomDestIndex);
        }*/
        //}

        foreach (GameObject canvas in canvases)
        {
            canvas.SetActive(false);
        }


        /*  if (destinations[randomDestIndex].gameObject.name == "finalShard");
          {
              Debug.Log("you arrived at the final resting place");
          }*/
    }

    public void disableOnClick()
    {


        /* for (i = 0; i < randomDestIndex, i++)
         {
             Destroy()
         }*/

        Debug.Log("disable me");
    }

    public void disableCanvasOnClick()
    {
        Debug.Log("disable me");
    }



  /*  public void ScrollBarOn()
    {
        ScrollBar.SetActive(true);

    }*/


    void Trans_to_snapshot(AudioMixerSnapshot snapshot, float time_to_transition)
    {

        snapshot.TransitionTo(time_to_transition);

    }

    public IEnumerator SetCanTeleport()
    {
        yield return new WaitForSeconds(10f);
        canTeleport = true;
    }
}
