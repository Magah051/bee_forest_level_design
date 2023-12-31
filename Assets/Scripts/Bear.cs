using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bear : MonoBehaviour
{
    public Animator animBear;
    private float velocidadeUrso = 2f;
    public GameObject uIBearNoPass;
    public GameObject uIBearPass;
    public float displayTime = 4f;

    private bool triggered = false;
    void OnCollisionEnter2D(Collision2D collision)
    {
        int honeyValue = collision.gameObject.GetComponent<Player>().honey;

        if (collision.gameObject.CompareTag("Player") && honeyValue >= 7)
        {
            animBear.SetBool("isAwake", true);
            Invoke("IniciarMovimento", 3f);
            GameObject uIBearInstance = Instantiate(uIBearPass, transform.position, Quaternion.identity);
            Destroy(uIBearInstance, displayTime);
            triggered = true;
        }
        else
        {
            animBear.SetBool("isAwake", true);
            StartCoroutine(DesativarAnimacaoAposTempo(4f));
            GameObject uIBearInstance = Instantiate(uIBearNoPass, transform.position, Quaternion.identity);
            Destroy(uIBearInstance, displayTime);
            triggered = true;
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
