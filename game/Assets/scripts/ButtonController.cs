using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string nameTrigger; // �������� �����
    public string nameTrigger2; // �������� �����

    public string nameAnimButton; // �������� ������� ������ 
    public string nameAnimButton2; // �������� ������� ������

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
            buttonObject.GetComponent<Animator>().SetTrigger(nameAnimButton); // �������� ������� ������ 

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

        buttonObject.GetComponent<Animator>().SetTrigger(nameAnimButton2); // �������� ������ ������

        gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2); // �������� �����
    }
}