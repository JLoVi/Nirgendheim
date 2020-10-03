using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {
    
    public AudioSource audioSource;
   
    public float fadeSpeed = 5f;
    
    

    float time = 0f;

    // Use this for initialization
    void Start () {
        
        DontDestroyOnLoad(transform.gameObject);

       // if (Application.loadedLevelName == "ActIScene1")
       // {
            StartCoroutine("FadeInSound");
       // }
    }

    // Update is called once per frame
    void Update()
    {

        if (Application.loadedLevelName == "ActIScene3")
        {
            audioSource.volume = Mathf.Lerp(1f, 0f, time);
            time += Time.deltaTime / fadeSpeed;
            Debug.Log(Application.loadedLevelName);

            if (audioSource.volume == 0)
            {
                Destroy(gameObject);
            }
        }

        if (Application.loadedLevelName == "seconddialogue")
        {

            audioSource.volume = Mathf.Lerp(1f, 0f, time);
            time += Time.deltaTime / fadeSpeed;

            if (audioSource.volume == 0)
            {
                Destroy(gameObject);
            }
        }
        if (Application.loadedLevelName == "witliftanim")
        {

            audioSource.volume = Mathf.Lerp(1f, 0f, time);
            time += Time.deltaTime / fadeSpeed;

            if (audioSource.volume == 0)
            {
                Destroy(gameObject);
            }
        }

    }

       IEnumerator FadeInSound()
    {
        //yield return new WaitForSeconds(1f);
        /*txt.text = "Press [x] if you'd like to change some of the parameters.";
        rotate = true;
        ofcourse = true;*/
        float startVolume = 0.1f;

        while (audioSource.volume <1)
        {
            audioSource.volume += startVolume * Time.deltaTime / 3;

            yield return null;
        }
    }
   

}
