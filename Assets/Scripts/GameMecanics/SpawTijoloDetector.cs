using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawTijoloDetector : MonoBehaviour {

    public bool espacoOcupado;

	// Use this for initialization
	void Start () {
        espacoOcupado = false;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnTriggerStay(Collider coll)
    {
        if (coll.gameObject.tag == "tijolo" && coll.isTrigger == true)
        {
            espacoOcupado = true;
        }
    }
}
