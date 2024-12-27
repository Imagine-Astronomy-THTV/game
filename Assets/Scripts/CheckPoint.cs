using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private BoxCollider2D _boxCollider;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GameManager.instance.currentCheckPoint = transform.position;
            _animator.SetTrigger("appear");
            _boxCollider.enabled = false;
        }
    }
}
