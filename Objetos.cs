using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objetos : MonoBehaviour
{
    public float speed = 2.5f;
  
    Vector2 ultimo;
    Vector3 posicaoInicial;
    public GameObject objeto;
    bool movendo = false;
    float cronometro = 0;
     public bool ir = false;
     public float espera = 3.4f;
    Animator animacao;
    public string tag;
    void Start()
    {
         posicaoInicial = transform.position;
        Debug.Log(transform.position);
        Debug.Log(posicaoInicial);
    }

    // Update is called once per frame
    void Update()
    {
        if (movendo && (Vector2)objeto.transform.position != ultimo)
        {
            Invoke("Andar", espera);
           // Invoke("Retornar", espera);
            //  Invoke("Retornar", espera);
         //   StartCoroutine(Percorrer(posicaoInicial));
           // if (ir == true)
            //{
           /*     float passos = speed * Time.deltaTime;
                objeto.transform.position = Vector2.MoveTowards(objeto.transform.position, ultimo, passos);*/
            }
            else movendo = false;
        //}
    }

    private void OnMouseDown()
    {
        ultimo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movendo = true;
       
    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == tag)
        {
            movendo = false;
        }
    }
   
    
     public void Andar()
    {
        float passos = speed * Time.deltaTime;
        objeto.transform.position = Vector2.MoveTowards(objeto.transform.position, ultimo, passos);
       
    }
    public void Retornar()
    {
        float passos = speed * Time.deltaTime;
    
            
        
        Vector2 novaPosicao = Vector2.MoveTowards(objeto.transform.position, posicaoInicial, passos);
   
       
    }
    IEnumerator Percorrer (Vector3  final) {
        float distancia = (objeto.transform.position - final).sqrMagnitude;
        float passos = speed * Time.deltaTime;
        while (distancia > float.Epsilon)
        {
            Vector3 novaPosicao = Vector3.MoveTowards(objeto.transform.position,final,passos);
           
            distancia = (objeto.transform.position - final).sqrMagnitude;
            yield return null;
        }
    }
}
