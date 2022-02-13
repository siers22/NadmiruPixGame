using UnityEngine;

public class SwitchLight : MonoBehaviour
{
    [SerializeField] private PermanentButtonGameObject[] _buttonGameObjects;

    [SerializeField] private Light[] _light;

    private bool _isClicked;

    private void Update()
    {
        if (_isClicked == false && isAllClicked())
        {
            _isClicked = true;
            Debug.Log("Все нажаты");

            foreach (Light light in _light)
            {
                light.enabled = true;
            }
        }
    }

    private bool isAllClicked()
    {
        foreach (var buttonGameObject in _buttonGameObjects)
        {
            if (buttonGameObject.isActive == false)
            {
                return false;
            }
        }

        return true;
    }
}