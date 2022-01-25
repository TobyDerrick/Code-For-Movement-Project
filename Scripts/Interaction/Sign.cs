using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sign : Interactable
{

    [SerializeField] private DialogueObject dialogueObject;
    [SerializeField] private DialogueUI dui;
    public Animator anim;





    public override void Interact()
    {
        anim.SetFloat("Speed", 0);
        anim.SetFloat("LastVertical", 1);
        dui.ShowDialogue(dialogueObject);
    }

}
