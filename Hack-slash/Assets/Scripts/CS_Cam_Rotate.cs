using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS_Cam_Rotate : MonoBehaviour {
    [SerializeField]private float camSpeed;
    private GameObject player;
	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetAxis("Horizontal") != 0)
        {
            this.gameObject.transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * camSpeed);
        }
        this.gameObject.transform.position = player.transform.position;
    }
}
