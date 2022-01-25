using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 This script is responsible for printing the text in the "typewriter" sort of style.
 */
public class TypeWriter : MonoBehaviour
{

    [SerializeField] private float writingSpeed = 50f;

    //Runs the Coroutine "TypeText" with given data "textToType" and "textLabel"
    public Coroutine Run(string textToType, TMP_Text textLabel)
    {
        return StartCoroutine(TypeText(textToType, textLabel));
    }

    //Types the text from the textToType
    private IEnumerator TypeText(string textToType, TMP_Text textLabel)
    {
        float t = 0;
        int charIndex = 0;

        // t increases over time and charIndex is the floored version of t, When charIndex reaches the total length of the text the process will be terminated.

        while (charIndex < textToType.Length)
        {
            t += Time.deltaTime * writingSpeed;
            charIndex = Mathf.FloorToInt(t);
            charIndex = Mathf.Clamp(charIndex, 0, textToType.Length);

            textLabel.text = textToType.Substring(0, charIndex);

            yield return null;
        }

        textLabel.text = textToType;
    }
}

