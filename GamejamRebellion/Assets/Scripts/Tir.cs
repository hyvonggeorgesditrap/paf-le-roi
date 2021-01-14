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
    public int hauteurCible;
    private float HitCooldown = (float)0.5;
    private float NextHit = 0;

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
            if (Input.GetButton("Fire1") && Time.time > NextHit)
            {
                if (objet.tag.Equals("Projectile")) {
                    Debug.Log("Tir sur un objet");
                    gameController.Frappe();
                    rb = objet.GetComponent<Rigidbody>();
                    Vector3 targetPosition = new Vector3(target.position.x, target.position.y + hauteurCible, target.position.z);
                    Vector3 direction = targetPosition - objet.transform.position;

                    rb.velocity = Vector3.zero;
                    rb.AddForce(direction.normalized * force, ForceMode.Impulse);
                }
                else if (objet.tag.Equals("Vide"))
                {
                    Debug.Log("Tir Dans le Vide!");
                    gameController.addHealth(0 - poids);
                    gameController.ResetCombo();
                }
                NextHit = Time.time + HitCooldown;
            }
        }
    }
}
