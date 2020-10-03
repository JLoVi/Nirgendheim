using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text instructions;

    // Use this for initialization
    void Start()
    {
        string s = string.Format("Press <color=#00ff00ff>{0}</color> to enter the Main Menu at any point during gameplay", GamepadController.instance.controlList.mainMenuButton);
        instructions.text = s;

        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {

        yield return new WaitForSeconds(10f);

        SceneManager.LoadScene("Act I");

    }
}
