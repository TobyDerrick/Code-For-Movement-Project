using System.Collections;
using UnityEngine;
using TMPro;

/*
 This is the primary script responsible for the dialogue system, it is where most other scripts
are called and used.
 */
public class DialogueUI : MonoBehaviour
{
    [SerializeField] private TMP_Text textLabel;
    [SerializeField] private DialogueObject testDialogue;
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private PlayerMovement playerMovement;


    private ResponseHandler responseHandler;
    private TypeWriter TypeWriter;

    //initializes the script
    private void Start()
    {
        TypeWriter = GetComponent<TypeWriter>();
        responseHandler = GetComponent<ResponseHandler>();


        CloseDialogueBox();
    }

    public void ShowDialogue(DialogueObject dialogueObject)
    {
        dialogueBox.SetActive(true);
        StartCoroutine(StepThroughDialogue(dialogueObject));
        playerMovement.canMove = false;
    }


    //Calls the TypeWriter's "Run" method for each line of dialogue in the dialogue object
    private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
    {

        for (int i = 0; i < dialogueObject.Dialogue.Length; i++)
        {
            string dialogue = dialogueObject.Dialogue[i];
            yield return TypeWriter.Run(dialogue, textLabel);

            if (i == dialogueObject.Dialogue.Length - 1 && dialogueObject.HasResponses) break;
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space));
        }
        if (dialogueObject.HasResponses)
        {
            responseHandler.ShowResponses(dialogueObject.Responses);
        }

        else
        {
            CloseDialogueBox();
        }

    }

    private void CloseDialogueBox()
    {
        dialogueBox.SetActive(false);
        textLabel.text = string.Empty;
        playerMovement.canMove = true;
    }



}

