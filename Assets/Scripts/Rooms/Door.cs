using UnityEngine;

public class Door : MonoBehaviour
{

    [SerializeField] protected Transform previousRoom; // phong truoc
    [SerializeField] protected Transform nextRoom;
    [SerializeField] protected CameraController cam;
    private void Awake()
    {
        cam = Camera.main.GetComponent<CameraController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            // vi tri nguoi choi nho hon cua 
            if (collision.transform.position.x < transform.position.x)
            {
                cam.MoveToNewRoom(nextRoom);
                nextRoom.GetComponent<Room>().ActivateRoom(true);
                previousRoom.GetComponent<Room>().ActivateRoom(false);
            }
            else
            {
                cam.MoveToNewRoom(previousRoom);

                previousRoom.GetComponent<Room>().ActivateRoom(true);
                nextRoom.GetComponent<Room>().ActivateRoom(false);


            }


        }
    }
}
