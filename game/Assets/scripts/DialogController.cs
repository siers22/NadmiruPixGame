using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogController : MonoBehaviour
{
    public AudioSource dialogAudio;
    public float delayBeforePlay;
    private AudioClip clip;

    private void Start()
    {
        clip = dialogAudio.clip;
    }

    public void PlayDialogue()
    {
        StartCoroutine(WaitAndPlayDialog());
    }

    private IEnumerator WaitAndPlayDialog()
    {
        yield return new WaitForSeconds(delayBeforePlay);

        dialogAudio.PlayOneShot(clip);
    }
}