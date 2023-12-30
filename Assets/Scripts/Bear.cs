using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Animator animBear;
    private float velocidadeUrso = 2f;
    void OnCollisionEnter2D(Collision2D collision)
    {
        int honeyValue = collision.gameObject.GetComponent<Player>().honey;

        if (collision.gameObject.CompareTag("Player") && honeyValue >= 7)
        {
            animBear.SetBool("isAwake", true);
            Invoke("IniciarMovimento", 3f);
            Debug.Log("Pode passar");
        }
        else
        {
            animBear.SetBool("isAwake", true);
            StartCoroutine(DesativarAnimacaoAposTempo(6f));
            Debug.Log("Tenho fome");
        }
    }
    private void IniciarMovimento()
    {
        animBear.SetBool("canRun", true);
    }

    void Update()
    {
        if (animBear.GetBool("canRun"))
        {
            transform.position += Vector3.right * velocidadeUrso * Time.deltaTime;
        }
    }
    private IEnumerator DesativarAnimacaoAposTempo(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        animBear.SetBool("isAwake", false);
    }
}
