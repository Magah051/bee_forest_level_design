using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypeTextAnimation : MonoBehaviour
{

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    string fullText = "Hello! I'm hungry! To pass you need to bring me seven honeycombs.";
 
    void Start()
    {
        StartCoroutine(TypeText());
    }


    IEnumerator TypeText()
    {

        textObject.text = fullText;
        textObject.maxVisibleCharacters = 0;
        for (int i = 0; i <= textObject.text.Length; i++)
        {
            textObject.maxVisibleCharacters = i;
            yield return new WaitForSeconds(typeDelay);
        }
    }

}