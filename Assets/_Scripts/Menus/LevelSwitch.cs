using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class LevelSwitch : MonoBehaviour
{

    public int levelWeAreAt;

    public Text buttonActI;
    public Text buttonActII;
    public Text buttonActIII;
    // Use this for initialization
   
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        ActToSwitchTo();

      
    }
    void ActToSwitchTo()
    {
        switch (levelWeAreAt)
        {
            case 1:
                buttonActI.text = "RESTART ACT I";
                buttonActII.text = "ACT II";
                buttonActIII.text = "ACT III";
                break;
            case 2:
                buttonActI.text = "ACT I";
                buttonActII.text = "RESTART ACT II";
                buttonActIII.text = "ACT III";
                break;
            case 3:
                buttonActI.text = "ACT I";
                buttonActII.text = "ACT II";
                buttonActIII.text = "RESTART ACT III";
                break;
            default:
                buttonActI.text = "ACT I";
                buttonActII.text = "ACT II";
                buttonActIII.text = "ACT III";
                break;

        }
    }

    public void LoadActI()
    {
        SceneManager.LoadScene("act I");
    }
    public void LoadActII()
    {
        SceneManager.LoadScene("act II");
    }
    public void LoadActIII()
    {
        SceneManager.LoadScene("ACT III");
    }

   

}