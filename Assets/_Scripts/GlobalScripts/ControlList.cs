using UnityEngine;

[CreateAssetMenu()]
public class ControlList : ScriptableObject
{
    public string mainMenuButton;
    public KeyCode mainMenuInputPC;
    public KeyCode mainMenuInputMAC;

  //  public string dPadControls;
    public string dPadName;

    public KeyCode spaceTimeControl;
    public string spaceTimeName;

    public KeyCode closeReopenControl;
    public string closeReopenName;

    public KeyCode deleteBodyControl;
    public string deleteBodyName;

    public KeyCode addBodyControl;
    public string addBodyName;

    public KeyCode meetPetControl;
    public string meetPetName;

    public KeyCode submitControl;
    public string submitName;

    public string navigationName;
}
