using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This Script is responsible for creating scriptable objects that will be
used as data for the rest of the dialogue system.
*/

[CreateAssetMenu(menuName = "Dialogue/DialogueObject")]
public class DialogueObject : ScriptableObject
{
    [SerializeField] [TextArea] private string[] dialogue;
    [SerializeField] private Response[] responses;

    // allows scripts to read from this field, but not write to it. 
    public string[] Dialogue => dialogue;
    //Checks if the dialogue has responses, and if the length of the array of responses is greater than 0 so that you dont accidentally create empty response boxes
    public bool HasResponses => Responses != null && Responses.Length > 0;

    public Response[] Responses => responses;
}
