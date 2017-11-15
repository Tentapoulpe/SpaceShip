using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{

	}

	void OnCollisionEnter(Collider col)
	{

		if(col.gameObject.name == "Player")
        {
            Destroy(col.gameObject);
        }
	}
}
