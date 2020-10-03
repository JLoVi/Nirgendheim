using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamepadController : MonoBehaviour
{
    private int Xbox_One_Controller = 0;
    private int PS4_Controller = 0;

    public GamePadData gamePadData;
    public ControlList controlList;

    public static GamepadController instance;


    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        GetJoySticks();
        AssignJoyStickData();
        AssignControls();

    }

    public void GetJoySticks()
    {
        string[] names = Input.GetJoystickNames();
        for (int x = 0; x < names.Length; x++)
        {
            print(names[x].Length);

            if (names[x].Length == 19)
            {
                print("PS4 CONTROLLER IS CONNECTED");
                PS4_Controller = 1;
                Xbox_One_Controller = 0;
            }
            if (names[x].Length == 33 || names[x].Length == 29)
            {
                print("XBOX ONE CONTROLLER IS CONNECTED");
                PS4_Controller = 0;
                Xbox_One_Controller = 1;

            }
        }
    }

    public void AssignJoyStickData()
    {
        if (Xbox_One_Controller == 1)
        {
            gamePadData.gamePad = GamePadEnum.XboxController;
        }
        else if (PS4_Controller == 1)
        {
            gamePadData.gamePad = GamePadEnum.PS4Controller;
        }
        else
        {
            gamePadData.gamePad = GamePadEnum.Computer;
        }
    }

    public void AssignControls()
    {
        switch (gamePadData.gamePad)
        {
            case GamePadEnum.XboxController:
                controlList.mainMenuButton = "LB";
                controlList.mainMenuInputPC = KeyCode.Joystick1Button4;
                controlList.mainMenuInputMAC = KeyCode.Joystick1Button13;

                controlList.dPadName = "THE LEFT JOYSTICK";

                controlList.spaceTimeName = "A";

                controlList.closeReopenName = "X";

                if (Application.platform == RuntimePlatform.WindowsPlayer || Application.platform == RuntimePlatform.WindowsEditor)
                {
                    controlList.spaceTimeControl = KeyCode.Joystick1Button0;
                    controlList.closeReopenControl = KeyCode.Joystick1Button2;

                }

                if (Application.platform == RuntimePlatform.OSXPlayer || Application.platform == RuntimePlatform.OSXEditor)
                {
                    controlList.spaceTimeControl = KeyCode.Joystick1Button16;
                    controlList.closeReopenControl = KeyCode.Joystick1Button18;

                }

               
                break;

            case GamePadEnum.PS4Controller:
                controlList.mainMenuButton = "OPTION";
                controlList.mainMenuInputPC = KeyCode.Joystick1Button9;

                controlList.dPadName = "THE LEFT JOYSTICK";

                controlList.spaceTimeName = "O";
                controlList.spaceTimeControl = KeyCode.Joystick1Button2;

                controlList.closeReopenControl = KeyCode.Joystick1Button1;
                controlList.closeReopenName = "X";

                break;
            case GamePadEnum.Computer:
                controlList.mainMenuButton = "M";
                controlList.mainMenuInputPC = KeyCode.M;

                controlList.dPadName = "THE ARROW KEYS";

                controlList.spaceTimeName = "T";
                controlList.spaceTimeControl = KeyCode.T;

                controlList.closeReopenName = "X";
                controlList.closeReopenControl = KeyCode.X;


                break;
            default:
                controlList.mainMenuButton = "M";
                controlList.mainMenuInputPC = KeyCode.M;

                controlList.dPadName = "THE ARROW KEYS";

                controlList.spaceTimeName = "T";
                controlList.spaceTimeControl = KeyCode.T;

                controlList.closeReopenName = "X";
                controlList.closeReopenControl = KeyCode.X;



                break;
        }
    }
}
