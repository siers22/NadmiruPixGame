using UnityEngine;

public class LoadLevelStart : MonoBehaviour
{
    public string nameAnimOpen;
    public string nameAnimClose;

    public GameObject doorObject;

    void Start()
    {
        doorObject.GetComponent<Animator>().SetTrigger(nameAnimOpen);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorObject.GetComponent<Animator>().SetTrigger(nameAnimClose);
        }
    }
}