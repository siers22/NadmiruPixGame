using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DevConsole : MonoBehaviour
{
    public GameObject devConsole;
    public InputField inputFieldUI;
    public GameObject[] objects;
    public GameObject player;

    void Start()
    {
        devConsole.SetActive(false);

        inputFieldUI.onEndEdit.AddListener(delegate { CommandsHandler(inputFieldUI); });
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.BackQuote)) & (EscMenu.GameIsPaused == false))
        {
            ConsoleShow();
        }
    }

    public void CommandsHandler(InputField input)
    {
        string[] arguments = inputFieldUI.text.Split(' ');

        switch (arguments[0])
        {
            case "loadlevel":
                SceneManager.LoadScene(arguments[1]);
                break;
            case "createbox":
                CreateBox(int.Parse(arguments[1]));
                break;
            case "setjump":
                CharacterControl.jumpSpeed = float.Parse(arguments[1]);
                break;
            case "setspeed":
                CharacterControl.speed = float.Parse(arguments[1]);
                break;
            case "setgravity":
                CharacterControl.gravity = float.Parse(arguments[1]);
                break;
            case "quit":
                Application.Quit();
                break;
            case "setdefault":
                CharacterControl.jumpSpeed = 8f;
                CharacterControl.speed = 5f;
                CharacterControl.gravity = 20f;
                break;
        }
    }

    public void ConsoleShow()
    {
        devConsole.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void ConsoleClose()
    {
        inputFieldUI.text = "";
        devConsole.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void CreateBox(int numOfBoxes)
    {
        for (int i = 0; i < numOfBoxes; i++)
        {
            Instantiate(objects[0]);
        }
    }
}