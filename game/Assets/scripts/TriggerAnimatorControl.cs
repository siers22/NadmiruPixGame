using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimatorControl : MonoBehaviour
{
    public string nameTrigger;
    public string nameTrigger2;

    public string nameAnimButton;
    public string nameAnimButton2;

    public GameObject gameObjects;
    public GameObject bigButtonObject;

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Crate")
        {
            bigButtonObject.GetComponent<Animator>().SetTrigger(nameAnimButton);
            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger);
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Crate")
        {
            bigButtonObject.GetComponent<Animator>().SetTrigger(nameAnimButton2);
            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2);
        }
    }
}