using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cubo : MonoBehaviour
{
    public float speed = 2.5f;
    public GameObject Columna;
    private Columna columna;
    [SerializeField] Text speedText;
    [SerializeField] Text timeText;
    Renderer rend;

    private string currentTime;
    public GameObject Nave;
    private Cubo cubo;
    public float mySpeed;
    bool alive;
    // Start is called before the first frame update
    void Start()
    {
        Nave = GameObject.Find("Cubo");
        cubo = Nave.GetComponent<Cubo>();
        mySpeed = cubo.speed;
        alive = true;
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();

        if (speed < 50f && alive == true)
        {
            speed = speed + 0.1f;
        }
        speedText.text = "Velocidad: " + speed + " Kmts/h";
        currentTime = Time.time.ToString("f2");
        currentTime = "Time is: " + currentTime + " sec.";

        timeText.text = currentTime;
    }

    void MoverNave()
    {
        float PosX = transform.position.x;
        float PosY = transform.position.y;
        print(transform.position.x);
        float desplY = Input.GetAxis("Vertical");

        float desplX = Input.GetAxis("Horizontal");

        //Restringir movimiento horizontal
        if (PosX > 0 && PosX < 30)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        }
        else if (PosX < 0 && desplX > 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        }
        else if (PosX > 30 && desplX < 0)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * desplX);
        }

        //Restringir movimiento vertical
        if (PosY > 0 && PosY < 9)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }
        else if (PosY < 0 && desplY > 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }
        else if (PosY > 9 && desplY < 0)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed * desplY);
        }



    }

    void OnCollisionEnter(Collision collision)
    {
        GameObject objeto1 = GameObject.Find("Cubo");
        if (collision.gameObject.tag == "Respawn")
        {
            Debug.Log("objeto1 ha colisionado con objeto3");
            speed = 0f;
            rend.enabled = false;
            alive = false;
        }

    }
}
