using UnityEngine;

public class PermanentButtonGameObject : MonoBehaviour
{
    private bool _isActive;
    public bool isActive => _isActive;

    private Animator animator;

    [SerializeField] private string buttonPressAnimName;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Interact()
    {
        _isActive = true;

        if (_isActive)
        {
            animator.Play(buttonPressAnimName);
            Debug.Log($"Нажато {gameObject.name}");
        }
    }
}