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
            // N?u ch?a có checkpoint, x? lý quay l?i v? trí m?c ??nh ban ??u
            Debug.LogWarning("No checkpoint set! Respawning at default position.");
            transform.position = Vector3.zero; // Ho?c v? trí m?c ??nh
            playerHealth.Respawn();
            return;
        }

        // Quay l?i checkpoint ?ã l?u
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

            // Kích ho?t animation checkpoint và tránh kích ho?t l?i
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
