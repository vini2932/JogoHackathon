using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radio : MonoBehaviour
{
    public AudioClip[] tocar = new AudioClip[3];
    public AudioSource lit;
    public string tag;
    public int count = 0;
    public string tag2;
    Objetos instance;
    public float speed = 2.5f;
    public GameObject objeto;
    Vector2 ultimo;
    bool movendo = false;
    public float espera = 2.4f;
    public SpriteRenderer mudarcor;
    Personagem per;
    public bool pode = false;
   public Vector2 posicaoInicial;
    public GameObject casa;

    // Start is called before the first frame update
    private void Awake()
    {
        lit = GetComponent<AudioSource>();
        mudarcor = GetComponent<SpriteRenderer>();
        posicaoInicial = casa.transform.position;
        //posicaoInicial = objeto.transform.position;
        objeto.GetComponent<Renderer>().material.color = Color.black;
    }
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (movendo && (Vector2)objeto.transform.position != ultimo)
        {
            Invoke("Andar", espera);
        }
        else
        {
            movendo = false;
        }
        if (pode == true)
        {
            Invoke("Retornar", espera);
        }
    }
    /*  private void OnTriggerEnter2D(Collider2D outro)
      {
          if (outro.tag == tag)
          {
              count++;
              Debug.Log(count);
              if (count == 1)
              {
                  lit.PlayOneShot(tocar[0]);
              }else if (count == 2)
              {
                  lit.PlayOneShot(tocar[1]);
              }else if (count == 3)
              {
                  lit.PlayOneShot(tocar[2]);
              }
          }
          if (outro.tag == tag2)
          {

          }
      }*/
    private void OnMouseDown()
    {
        ultimo = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        movendo = true;
        count++;
        Debug.Log(count);
        if (count == 1)
        {
            lit.PlayOneShot(tocar[0]);
        }
        else if (count == 2)
        {
            lit.PlayOneShot(tocar[1]);
        }
        else if (count == 3)
        {
            lit.PlayOneShot(tocar[2]);
        }
    }
    public void Andar()
    {
        float passos = speed * Time.deltaTime;
        objeto.transform.position = Vector2.MoveTowards(objeto.transform.position, ultimo, passos);

    }
    private void OnTriggerEnter2D(Collider2D outro)
    {
        if (outro.tag == tag)
        {
            movendo = false;
            lit.Stop();
        }
        if (count == 3)
        {
           // lit.Stop();
            objeto.GetComponent<Renderer>().material.color = Color.white;
            pode = true;
          //  float passos = speed * Time.deltaTime;
            //objeto.transform.position = Vector2.MoveTowards(objeto.transform.position, posicaoInicial, passos);
        }
    }
    void Retornar() {
        float passos = speed * Time.deltaTime;
        objeto.transform.position = Vector2.MoveTowards(objeto.transform.position, posicaoInicial, passos);
    }
}