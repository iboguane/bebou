using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arena : MonoBehaviour
{
    public Transform HautGauche;
    public Transform HautDroit;
    public Transform BasGauche;
    public Transform BasDroit;
    public GameObject ennemi;
    public GameObject Bullet;
    public GameObject Lala;
    private GameObject ennemyRef;
    private int ran;
    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(ennemi, SpawnMechant(HautGauche,HautDroit), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        ran = Random.Range(0, 4);
        if (ran == 0){
            ennemyRef = Instantiate(ennemi, SpawnMechant(HautGauche, HautDroit), Quaternion.identity);
        }
        if (ran == 1)
        {
            ennemyRef = Instantiate(ennemi, SpawnMechant(HautGauche, BasGauche), Quaternion.identity);
        }
        if (ran == 2)
        {
            ennemyRef = Instantiate(ennemi, SpawnMechant(BasDroit, BasGauche), Quaternion.identity);
        }
        if (ran == 3)
        {
            ennemyRef = Instantiate(ennemi, SpawnMechant(BasDroit, HautDroit), Quaternion.identity);
        }
        Instantiate(Lala, ennemyRef.transform.position, Quaternion.identity);
    }

//renvoie le Vector3 d'un point entre les deux transform donné
    Vector3 SpawnMechant(Transform point1,Transform point2){
        return(new Vector3(point1.position.x +Random.Range(0f,1f)*(point2.position.x -point1.position.x),point1.position.y+Random.Range(0f,1f)*(point2.position.y-point1.position.y)));
    }
}
