using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{   
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float force = 10;

    public int poids;

    private float VideCooldown = 1;
    private float NextVide = 0;

    [SerializeField]
    private GameController gameController;

    Rigidbody rb = null;

    [SerializeField]
    private Texture2D cursor;

    private void Start()
    {
        gameController = GetComponent<GameController>();
        Cursor.SetCursor(cursor, new Vector2(cursor.width/2, cursor.height/2), CursorMode.ForceSoftware);
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            //Debug.Log(hitData.point);

            GameObject objet = hitData.collider.gameObject;
            if (Input.GetButton("Fire1"))
            {
                if (objet.tag.Equals("Projectile")) {
                    Debug.Log("Tir sur un objet");

                    rb = objet.GetComponent<Rigidbody>();
                    Vector3 direction = target.position - objet.transform.position;
                    rb.velocity = Vector3.zero;
                    rb.AddForce(direction.normalized * force, ForceMode.Impulse);
                }
                else if (objet.tag.Equals("Vide") && Time.time > NextVide)
                {
                    Debug.Log("Tir Dans le Vide!");
                    NextVide = Time.time + VideCooldown;
                    gameController.addHealth(0 - poids);
                    gameController.ResetCombo();
                }
            }
        }
    }
}
