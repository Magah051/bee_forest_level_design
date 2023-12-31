using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TypeTextAnimation : MonoBehaviour
{

    public float typeDelay = 0.05f;
    public TextMeshProUGUI textObject;
    string fullText = "Olá! Tenho fome! Para passar você precisa me trazer sete favos de mel.";
 
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