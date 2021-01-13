using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public List<GameObject> spawners;
    [SerializeField]
    private List<GameObject> ListObjets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void spawn()
    {
        int spawnerID = Random.Range(0, spawners.Count);
        int objectID = Random.Range(0, ListObjets.Count);
        Instantiate(ListObjets[objectID], spawners[spawnerID].transform.position, Quaternion.identity);
    }
}
