using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tir : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float force = 10;

    Rigidbody rb = null;

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitData;

        if (Physics.Raycast(ray, out hitData, 1000))
        {
            Debug.Log(hitData.point);

            GameObject objet = hitData.collider.gameObject;
            if (Input.GetButton("Fire1") && objet.tag.Equals("Object"))
            {
                Debug.Log("Tir sur un objet");

                rb = objet.GetComponent<Rigidbody>();
                Vector3 direction = target.position-objet.transform.position;
                rb.velocity = Vector3.zero;
                rb.AddForce(direction*force, ForceMode.Impulse);
            }
        }
    }
}
