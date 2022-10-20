using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public Transform HautGauche;
    public Transform HautDroit;
    public Transform BasGauche;
    public Transform BasDroit;
    public GameObject[] Ennemis;
    private GameObject ennemyRef;
    private int ran;
    private int ranEnnemy;
    private int IntervalSpawn =1;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(ennemi, SpawnMechant(HautGauche,HautDroit), Quaternion.identity);
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
    }

//renvoie le Vector3 d'un point entre les deux transform donné
    Vector3 SpawnMechant(Transform point1,Transform point2){
        return(new Vector3(point1.position.x +Random.Range(0f,1f)*(point2.position.x -point1.position.x),point1.position.y+Random.Range(0f,1f)*(point2.position.y-point1.position.y)));
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            ran = Random.Range(0, 4);
            //ranEnnemy = Random.Range(0, Ennemis.Length);
            ranEnnemy = Random.Range(0, 3);
            if (ran == 0)
            {
                ennemyRef = Instantiate(Ennemis[ranEnnemy], SpawnMechant(HautGauche, HautDroit), Quaternion.identity);
            }
            if (ran == 1)
            {
                ennemyRef = Instantiate(Ennemis[ranEnnemy], SpawnMechant(HautGauche, BasGauche), Quaternion.identity);
            }
            if (ran == 2)
            {
                ennemyRef = Instantiate(Ennemis[ranEnnemy], SpawnMechant(BasDroit, BasGauche), Quaternion.identity);
            }
            if (ran == 3)
            {
                ennemyRef = Instantiate(Ennemis[ranEnnemy], SpawnMechant(BasDroit, HautDroit), Quaternion.identity);
            }
            yield return new WaitForSeconds(IntervalSpawn);
        }
    }
}
