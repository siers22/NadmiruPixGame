using UnityEngine;

public class LeverController : MonoBehaviour
{
    public string nameTrigger; // �������� �����
    public string nameTrigger2; // �������� �����

    public string nameLeverAnim; // �������� ��������� ������
    public string nameLeverAnim2; // �������� ����������� ������

    public GameObject leverObject;
    public GameObject gameObjects;

    public Transform player;
    public Transform lever;

    public bool isDisposable = false; // ����������� ����� ��� ���

    private bool isActivated = false;

    private float distantion;

    public float maxDistance = 4;

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, lever.position);

        if ((Input.GetKeyDown(KeyCode.E)) && (!isActivated) && (distantion < maxDistance))
        {
            isActivated = !isActivated;

            leverObject.GetComponent<Animator>().SetTrigger(nameLeverAnim);

            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger);

            if (isDisposable) return;
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && (isActivated) && (distantion < maxDistance))
        {
            isActivated = !isActivated;

            leverObject.GetComponent<Animator>().SetTrigger(nameLeverAnim2);

            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2);
        }

    }
}