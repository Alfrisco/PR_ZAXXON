using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Columna : MonoBehaviour
{
    public GameObject Nave;
    private Cubo cubo;

    private Vector3 MyPos;
    public float mySpeed;
    // Start is called before the first frame update
    void Start()
    {
        Nave = GameObject.Find("Cubo");
        cubo = Nave.GetComponent<Cubo>();
        mySpeed = cubo.speed;
    }

    // Update is called once per frame
    void Update()
    {
         mySpeed = cubo.speed;

        transform.Translate(Vector3.back * Time.deltaTime * mySpeed);

        if (transform.position.z < -10)
        {
            Destroy(gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("objeto1 ha colisionado con objeto2");
        GameObject objeto1 = GameObject.FindGameObjectWithTag("Respawn");
        if (collision.gameObject.name == "Cubo")
        {
            Debug.Log("objeto1 ha colisionado con objeto3");

        }

    }
}
