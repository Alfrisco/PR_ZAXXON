using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearColumnas : MonoBehaviour
{
    [SerializeField] GameObject MyColumn;
    [SerializeField] Transform RefPos;
    [SerializeField] float distObstacle;
    Vector3 newPos;
    // Start is called before the first frame update
    void Start()
    {
         distObstacle = 8f;
        CrearColumnasIniciales();

        StartCoroutine("ColumnCorrutine");

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CrearColumnasIniciales()
    {
        
        for (int n = 1; n <= 17; n++)
        {
            float randomX = Random.Range(0f, -30f);
            newPos = new Vector3(randomX, 0, n * distObstacle);
            Vector3 finalPos = RefPos.position - newPos;
            Instantiate(MyColumn, finalPos, Quaternion.identity);
        }
    }

    void CrearColumna()
    {
        
        float posRandom = Random.Range(0f, 30f);
        Vector3 DestPos = new Vector3(posRandom, 0, 0);
        Vector3 NewPos = RefPos.position + DestPos;
        Instantiate(MyColumn, NewPos, Quaternion.identity);
    }

    IEnumerator ColumnCorrutine()
    {

        for (int n=0; ; n++ )
        {
            CrearColumna();
            yield return new WaitForSeconds(1f);
        }
    }
}
