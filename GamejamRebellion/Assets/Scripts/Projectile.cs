using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public int poids;
    public Color couleurTrainer;
    private GameObject statue = null;
    private GameController gameController = null;

    // Start is called before the first frame update
    void Start() {
        statue = FindObjectOfType<Statue>().gameObject;
        gameController = FindObjectOfType<GameController>();
        couleurTrainer = gameObject.GetComponentInChildren<TrailRenderer>().endColor;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(couleurTrainer);
        if(Time.timeScale < 1.2)
        {
            couleurTrainer = Color.white;
        }else if (Time.timeScale < 3)
        {
            couleurTrainer = Color.yellow;
        }else if (Time.timeScale < 4)
        {
            couleurTrainer = Color.red;
        }else
        {
            couleurTrainer = Color.blue;
        }
        
    }

        private void OnCollisionEnter(Collision collision) {
        if (statue != null && gameController != null && statue.GetInstanceID() == collision.gameObject.GetInstanceID()) {
            Debug.Log("Le projectile "+gameObject.name+" est entrer en collision avec la statue!");
            gameController.touchee(poids);
            Destroy(gameObject);
        } 
    }
}
