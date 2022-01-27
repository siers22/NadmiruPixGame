using UnityEngine;
using UnityEngine.SceneManagement;

public class SlimeTrigger : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform point;

    private void OnTriggerEnter(Collider other)
    {
        CharacterControl CHCplayer = other.GetComponent<CharacterControl>();

        if (CHCplayer != null)
        {
            player.transform.position = point.transform.position;
        }
    }
}