using UnityEngine;

public class InteractRayCast : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private float _maxDistanceRay;

    private void Start()
    {
        _camera = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);
        Ray ray = _camera.ScreenPointToRay(point);
        RaycastHit hit;

        if ((Physics.Raycast(ray, out hit, _maxDistanceRay)) && (Input.GetKeyDown(KeyCode.E)))
        {
            GameObject hitObject = hit.transform.gameObject;
            PermanentButtonGameObject permanentButton = hitObject.GetComponent<PermanentButtonGameObject>();

            if (permanentButton != null)
            {
                permanentButton.Interact();
            }
        }
    }
}