using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtTeleport : MonoBehaviour {
    private RaycastHit lastHit;
	// Use this for initialization
	void Start () {
		
	}
    public GameObject LookedAt(){
        Vector3 origin = transform.position;
        Vector3 direction = Camera.main.transform.forward;
        float range = 1000;
        if (Physics.Raycast(origin, direction, out lastHit, range))
        {
            return lastHit.collider.gameObject;
        }
        else return null;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0)){
            if (lastHit.collider.name == "plane"){
                if (lastHit.distance <= 10){
                    transform.position = (lastHit.point + lastHit.normal * 2);
                }
            }
        }
	}
}
