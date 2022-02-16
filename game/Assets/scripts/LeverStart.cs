using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverStart : MonoBehaviour
{
    public GameObject lightObj;
    public GameObject leverObject;

    private float distantion;
    public float maxDistance;

    public Transform player;
    public Transform lever;

    public AudioSource engineOn;

    public string leverAnimation;

    public static bool isStartButtonActive = false;

    void Start()
    {
        lightObj.GetComponent<Light>().enabled = false;
    }

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, lever.position);

        if ((Input.GetKeyDown(KeyCode.E)) & (distantion < maxDistance) & (LoadedStart.isStartLeverActive))
        {
            leverObject.GetComponent<Animator>().SetTrigger(leverAnimation);

            lightObj.GetComponent<Light>().enabled = true;
            engineOn.Play();

            isStartButtonActive = true;
        }
    }
}