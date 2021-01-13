using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public int vitesseSpawn = 5;
    public List<GameObject> spawners;
    [SerializeField]
    private List<GameObject> ListObjets;
    [SerializeField]
    private Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("allo");
        InvokeRepeating("Spawn", 2, vitesseSpawn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Spawn()
    {
        int spawnerID = Random.Range(0, spawners.Count);
        Debug.Log(spawnerID);
        int objectID = Random.Range(0, ListObjets.Count);
        Debug.Log(objectID);
        GameObject objet = Instantiate(ListObjets[objectID], spawners[spawnerID].transform.position, Quaternion.identity);
        int velocite = Random.Range(2, 5);
        Vector3 camPos = new Vector3(cam.transform.position.x, cam.transform.position.y, 0f);
        Vector3 impulse = velocite * (camPos - objet.transform.position);
        objet.GetComponent<Rigidbody>().AddForce(impulse, ForceMode.Impulse);


    }
}
