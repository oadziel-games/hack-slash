using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class CS_AI_Basic : MonoBehaviour {
    private GameObject player;
    private NavMeshAgent nav;
    [SerializeField] private float agroDistance;
    [SerializeField] private float stopDistance;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        nav = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Vector3.Distance(player.transform.position, this.gameObject.transform.position) < agroDistance && Vector3.Distance(player.transform.position, this.gameObject.transform.position) > stopDistance)
        {
            nav.destination = player.transform.position;
        }
        else
        {
            nav.destination = this.gameObject.transform.position;
        }
	}
}
