using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField]
    public int poids;
    public TrailRenderer trail;
    private GameObject statue = null;
    private GameController gameController = null;

    Vector3 torque;

    // Start is called before the first frame update
    void Start() {
        statue = FindObjectOfType<Statue>().gameObject;
        gameController = FindObjectOfType<GameController>();
        trail = gameObject.GetComponentInChildren<TrailRenderer>();
        Spin();
    }

    void Spin() {
        Rigidbody rb = gameObject.GetComponent<Rigidbody>();
        torque.x = Random.Range(-200, 200);
        torque.y = Random.Range(-200, 200);
        torque.z = Random.Range(-200, 200);
        rb.AddTorque(torque);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale < 1.2f)
        {
            trail.startColor = Color.white;
        }
        else if (Time.timeScale < 1.4f)
        {
            trail.startColor = Color.yellow;
        }
        else if (Time.timeScale < 1.6f)
        {
            trail.startColor = Color.red;
        }
        else
        {
            trail.startColor = Color.magenta;
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
