using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActISceneFive : MonoBehaviour
{
    /// <summary>
    /// act I scene 4 optional
    /// this is where you ask if you want to play a game
    /// </summary>
    public AudioSource audio;

    public AudioClip location;

    public AudioClip grouppeople;

    public AudioClip somethingwill;



    public Text txt;
    public Text infotxt;

    public GameObject yesno;

    public string tx;

    //public GameObject cube;

   
    
    void Start()
    {

        yesno.SetActive(false);

        audio = GetComponent<AudioSource>();
        //		bool change = true;
        tx = "  ";

        txt.text = " ";
        infotxt.text = " ";
        //steps = 1;

        StartCoroutine("MyEvent");
    }

    // Update is called once per frame
    void Update()
    {

       

    }

  


    private IEnumerator MyEvent()
    {

       

        yield return new WaitForSeconds(2f);
        ask(location);
        txt.text = "Location: The Ports  " + ActISceneFour.sceneDesc;

      


        yield return new WaitForSeconds(10f);
      
        txt.text = " ";


        yield return new WaitForSeconds(3f);
        ask(grouppeople);
        txt.text = "A group of people have been sitting here, playing a game to escape reality. Would you like to join?";

        yield return new WaitForSeconds(5f);

        yesno.SetActive(true);

        yield return new WaitForSeconds(4f);

        ask(somethingwill);

        infotxt.text = "YOUR ANSWER WILL CHANGE THE SCENE";
       

    }

    public void PlayYes()
    {
        //location will be Location:  Ports
        Application.LoadLevel("happy");


    }

    public void PlayNo()
    {
        //location will be Location:  Ports
        Application.LoadLevel("unhappy");
    }


    void ask(AudioClip aud)
    {

        audio.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }




}
