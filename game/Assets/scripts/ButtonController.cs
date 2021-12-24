using System.Collections;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public string nameTrigger; // Открытие двери
    public string nameTrigger2; // Закрытие двери

    public string nameAnimButton; // Анимация нажатия кнопки 
    public string nameAnimButton2; // Анимация отжатия кнопки

    public Transform player; // Игрок
    public Transform button; // Кнопка

    public GameObject gameObjects; // Объект дверь
    public GameObject buttonObject; // Объект кнопка

    public bool isPermanent = true;
    public float delay;
    private float distantion;
    public float maxDistance = 4f;

    void OnMouseOver()
    {
        distantion = Vector3.Distance(player.position, button.position);

        if ((Input.GetKeyDown(KeyCode.E)) && (distantion < maxDistance))
        {
            buttonObject.GetComponent<Animator>().SetTrigger(nameAnimButton); // Анимация нажатия кнопки 

            gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger); // Открытие двери

            if (!isPermanent)
            {
                StartCoroutine(WaitAndDo());
            }
        }
    }

    IEnumerator WaitAndDo()
    {
        yield return new WaitForSeconds(delay);

        buttonObject.GetComponent<Animator>().SetTrigger(nameAnimButton2); // Анимация отжима кнопки

        gameObjects.GetComponent<Animator>().SetTrigger(nameTrigger2); // Закрытие двери
    }
}