using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePosition : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Vector3 GridOffset;
    [SerializeField] private Transform player;
    private void Update()
    {

        Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPos.z = 0f;
        transform.position = new Vector3(Mathf.RoundToInt(mouseWorldPos.x) + GridOffset.x, Mathf.RoundToInt(mouseWorldPos.y) + GridOffset.y, mouseWorldPos.z + GridOffset.z);

        Debug.DrawLine(transform.position, player.position, Color.red);

        RaycastHit2D closestbox = Physics2D.Linecast(transform.position, player.position);
        if (closestbox.collider.tag == "PleaseDontJudge")
        {
            transform.position = closestbox.transform.position;
        }

    }
}
