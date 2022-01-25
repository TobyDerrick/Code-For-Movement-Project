using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    [SerializeField] Rigidbody2D rb;
    public Vector2 movement;
    private Vector2 boxSize = new Vector2(0.1f, 1f);
    public bool canMove;
    public Animator anim; 
    public string movedirection;


    private void Start()
    {

    }

    private void Update()
    {
        if (!canMove)
        {
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x > 0){
            movedirection = "Right";
        }

        if (movement.x < 0)
        {
            movedirection = "Left";
        }

        if (movement.y > 0){
            movedirection = "Up";
        }

        if (movement.y < 0){
            movedirection = "Down";
        }




        if (movement.x != 0 || movement.y != 0)
        {
            anim.SetFloat("LastHorizontal", movement.x);
            anim.SetFloat("LastVertical", movement.y);
        }


        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Speed", movement.sqrMagnitude);


            if (Input.GetKeyDown(KeyCode.E))
        {
            checkInteraction();
        }



    }

    private void FixedUpdate()
    {

        rb.MovePosition(rb.position + movement.normalized * movespeed * Time.fixedDeltaTime);
    }

    private void checkInteraction()
    {
        RaycastHit2D[] hits = Physics2D.BoxCastAll(transform.position, boxSize, 0, Vector2.zero);

        foreach (RaycastHit2D rc in hits)
        {
            if (rc.transform.GetComponent<Interactable>())
            {
                Debug.Log("bug probably here");
                rc.transform.GetComponent<Interactable>().Interact();
                return;
            }
        }
    }
}
