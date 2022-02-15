using UnityEngine;

public class LeverStart : MonoBehaviour
{
    public GameObject lightObj;
    public GameObject leverObject;
    public DialogController dialogController;

    private float distantion;
    public float maxDistance;

    public Transform player;
    public Transform lever;

    public AudioSource engineOn;

    public string leverAnimation;

    public static bool isStartButtonActive = false;

    private bool _isClicked; // Чтобы скрипт выполнялся один раз, неважное поле короче.

    void Start()
    {
        lightObj.GetComponent<Light>().enabled = false;
    }

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, lever.position);

        if ((Input.GetKeyDown(KeyCode.E)) & (distantion < maxDistance) & (LoadedStart.isStartLeverActive) & (_isClicked == false))
        {
            _isClicked = true;

            leverObject.GetComponent<Animator>().SetTrigger(leverAnimation);

            lightObj.GetComponent<Light>().enabled = true;

            engineOn.Play();

            dialogController.PlayDialogue();

            isStartButtonActive = true;
        }
    }
}