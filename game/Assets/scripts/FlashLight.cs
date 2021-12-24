using UnityEngine;

public class FlashLight : MonoBehaviour
{
    public Light flashlight;

    public AudioSource flSound;

    void Start()
    {
        flashlight = GetComponent<Light>();
    }

    void Update()
    {
        FlashlightController();
    }

    void FlashlightController()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            flashlight.enabled = !flashlight.enabled;

            flSound.Play();
        }
    }
}