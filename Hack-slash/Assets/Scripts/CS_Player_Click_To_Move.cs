using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(BoxCollider))]
public class CS_Player_Click_To_Move : MonoBehaviour {
    private NavMeshAgent nav;
    private Vector3 destination;
    private GameObject Target;
    private Camera cam;
	// Use this for initialization
	void Start () {
        nav = GetComponent<NavMeshAgent>();
        cam = Camera.main;
        destination = this.gameObject.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit rayHit;
        if (Input.GetMouseButtonDown(0))
        {
            if (Physics.Raycast(ray, out rayHit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.yellow);
                if (rayHit.collider.tag == "Ground")
                {
                    destination = rayHit.point;
                    Target = null;
                }
                if (rayHit.collider.tag == "NME")
                {
                    destination = rayHit.point;
                    Target = rayHit.collider.gameObject;
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (Physics.Raycast(ray, out rayHit))
            {
                Debug.DrawRay(ray.origin, ray.direction * 10, Color.red);
                if (rayHit.collider.tag == "NME" && Vector3.Distance(this.gameObject.transform.position, rayHit.point) < 3)
                {
                    Attack();
                }
            }
        }

        nav.destination = destination;
        if(Target != null && Vector3.Distance(this.gameObject.transform.position, Target.transform.position) < 3)
        {
            nav.destination = this.gameObject.transform.position;
        }
    }

    void Attack()
    {
        Debug.Log("Attacking Enemy");
    }
}
