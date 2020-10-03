using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Actone : MonoBehaviour {

    void Start()
    {

        StartCoroutine(LoadAct());
    }

    private IEnumerator LoadAct()
    {

        yield return new WaitForSeconds(5f);

        SceneManager.LoadScene("ActIScene1");
      
    }
}