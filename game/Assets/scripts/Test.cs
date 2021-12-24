using System.Collections;
using UnityEngine;

public class Test : MonoBehaviour
{
    public string nameTrigger; // �������� �����
    public string nameTrigger2; // �������� �����

    public Transform player; // �����
    public Transform button; // ������

    public GameObject gameObjects; // ������ �����
    public GameObject buttonObject; // ������ ������

    public bool isPermanent = true;
    public float delay;
    private float distantion;
    public float maxDistance = 4f;

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, button.position);

        if ((Input.GetKeyDown(KeyCode.E)) && (distantion < maxDistance))
        {
            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger); // �������� �����

            if (!isPermanent)
            {
                StartCoroutine(WaitAndDo());
            }
        }
    }

    IEnumerator WaitAndDo()
    {
        yield return new WaitForSeconds(delay);

        gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2); // �������� �����
    }
}