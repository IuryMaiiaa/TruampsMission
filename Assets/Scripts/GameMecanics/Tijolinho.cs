using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tijolinho : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void destroi()
    {
        StartCoroutine(destruirTijolinho());
    }

    IEnumerator destruirTijolinho()
    {
        yield return new WaitForSeconds(1f);
        Destroy(this.gameObject);  
    }
}
