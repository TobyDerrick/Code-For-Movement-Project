using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableGrid : MonoBehaviour
{

    [SerializeField] private Transform gridPos;
    [SerializeField] PlayerMovement playerMovement;
    private bool hasCollided;



    private void Start()
    {
        hasCollided = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (playerMovement.movedirection == "Right" && collision.tag == "Player")
        {
            gridPos.position += new Vector3(1, 0, 0);
        }
        if (playerMovement.movedirection == "Left" && collision.tag == "Player")
        {
            gridPos.position += new Vector3(-1, 0, 0);
        }
        if (playerMovement.movedirection == "Down" && collision.tag == "Player")
        {
            gridPos.position += new Vector3(0, -1, 0);
        }
        if (playerMovement.movedirection == "Up" && collision.tag == "Player")
        {
            gridPos.position += new Vector3(0, 1, 0);
        }

        else
            return;
    }

}


