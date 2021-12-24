using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LocationEnd : MonoBehaviour
{
    public string nameTriggerClose; // Закрытие двери

    public GameObject doorObject; // Объект двери

    public string sceneName;

    public GameObject menuLoading;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorObject.GetComponent<Animator>().SetTrigger(nameTriggerClose);

            StartCoroutine(WaitAndDo());
        }
        else if (other.CompareTag("Hands"))
        { }
        else
        {
            Destroy(other);
        }
    }

    IEnumerator WaitAndDo()
    {
        menuLoading.SetActive(true);

        yield return new WaitForSeconds(1.5f);
        menuLoading.SetActive(false);

        SceneManager.LoadScene(sceneName);
    }
}