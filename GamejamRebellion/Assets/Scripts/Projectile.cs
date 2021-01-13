using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public int poids;

    private GameObject statue = null;
    private GameController gameController = null;

    // Start is called before the first frame update
    void Start() {
        statue = FindObjectOfType<Statue>().gameObject;
        gameController = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (statue != null && gameController != null && statue.GetInstanceID() == collision.gameObject.GetInstanceID()) {
            Debug.Log("Le projectile "+gameObject.name+" est entrer en collision avec la statue!");
            gameController.AddScore(poids);
            Destroy(gameObject);
        } 
    }
}
