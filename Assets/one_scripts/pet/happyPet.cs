using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class happyPet : MonoBehaviour {
    public AudioSource audio;

    

    public AudioClip describeZona;

    public AudioClip enterZona;



    public Text txt;

   

    public string tx;

    //public GameObject cube;



    void Start()
    {

       

        audio = GetComponent<AudioSource>();
        //		bool change = true;
        tx = "  ";

        txt.text = " ";

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
     



        yield return new WaitForSeconds(2f);
        ask(describeZona);


        yield return new WaitForSeconds(16f);

       

        ask(enterZona);

        txt.text = "YOU WILL LEAVE THE PORT AND ENTER ZONA SHORTLY";

        yield return new WaitForSeconds(8f);
        Application.LoadLevel("act II");
        


    }

   


    void ask(AudioClip aud)
    {

        audio.PlayOneShot(aud);
        //GetComponent<AudioSource> ().PlayOneShot (aud);

    }




}
