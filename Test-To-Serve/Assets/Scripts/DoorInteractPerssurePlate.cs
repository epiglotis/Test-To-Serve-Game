using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteractPerssurePlate : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;
    private IDoor door;

    private void Awake()
    {
        door = doorGameObject.GetComponent<IDoor>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if(collision.GetComponent<magnet>() != null)
        {
            door.OpenDoor();
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.GetComponent<magnet>() != null)
        {
            door.CloseDoor();
        }
    }
}
