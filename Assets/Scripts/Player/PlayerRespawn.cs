using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    [SerializeField] private AudioClip checkpointSound;
    private Transform currentCheckpoint;
    private PlayerHealth playerHealth;
    private UImanager uiManager;

    private void Awake()
    {
        playerHealth = GetComponent<PlayerHealth>();
        uiManager = FindFirstObjectByType<UImanager>();
    }

    public void CheckRespawn()
    {
        if (currentCheckpoint == null)
        {
            // N?u ch?a c� checkpoint, x? l� quay l?i v? tr� m?c ??nh ban ??u
            Debug.LogWarning("No checkpoint set! Respawning at default position.");
            transform.position = Vector3.zero; // Ho?c v? tr� m?c ??nh
            playerHealth.Respawn();
            return;
        }

        // Quay l?i checkpoint ?� l?u
        transform.position = currentCheckpoint.position;
        playerHealth.Respawn();

        // Di chuy?n camera ??n room t??ng ?ng n?u c?n
        CameraController cam = Camera.main.GetComponent<CameraController>();
        if (cam != null)
        {
            cam.MoveToNewRoom(currentCheckpoint.parent);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Checkpoint"))
        {
            currentCheckpoint = collision.transform;
            SoundManager.instance.PlaySound(checkpointSound);

            // K�ch ho?t animation checkpoint v� tr�nh k�ch ho?t l?i
            Animator checkpointAnim = collision.GetComponent<Animator>();
            if (checkpointAnim != null)
            {
                checkpointAnim.SetTrigger("appear");
            }

            Collider2D checkpointCollider = collision.GetComponent<Collider2D>();
            if (checkpointCollider != null)
            {
                checkpointCollider.enabled = false;
            }
        }
    }
}

//using UnityEngine;

//public class PlayerRespawn : MonoBehaviour
//{
//    [SerializeField] private AudioClip checkpointSound;
//    private Transform currentCheckpoint;
//    private PlayerHealth playerHealth;

//    private UImanager uiManager;

//    private void Awake()
//    {
//        playerHealth = GetComponent<PlayerHealth>();
//        uiManager = FindFirstObjectByType<UImanager>();
//    }
//    public void CheckRespawn()
//    {
//        if (currentCheckpoint != null)
//        {
//            uiManager.GameOver();
//            return;
//        }
//        transform.position = currentCheckpoint.position;
//        playerHealth.Respawn();
//        Camera.main.GetComponent<CameraController>().MoveToNewRoom(currentCheckpoint.parent);
//    }
//    private void OnTriggerEnter2D(Collider2D collision)
//    {
//        if(collision.transform.tag == "Checkpoint")
//        {
//            currentCheckpoint = collision.transform;
//            SoundManager.instance.PlaySound(checkpointSound);
//            collision.GetComponent<Collider2D>().enabled = false;
//            collision.GetComponent<Animator>().SetTrigger("appear");
//        }
//    }
//}
