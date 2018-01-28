using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tijolo : MonoBehaviour {

    public bool tijoloStopFlag;
    public Vector3 lastPosition;

    public GameObject tijolinho;

	// Use this for initialization
	void Start () {
        tijoloStopFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(tijoloStopFlag == true)
        {
            this.transform.position = lastPosition;
        }
	}

    public void tijoloDestruction()
    {
        GameObject aux;
        for(int cont = 0; cont < 5; cont ++)
        {
            aux = Instantiate(tijolinho, this.transform.position, Quaternion.identity);
            aux.GetComponent<Rigidbody>().AddRelativeForce(Random.onUnitSphere * 200f);
            aux.GetComponent<Tijolinho>().destroi();
        }
        
        Destroy(this.gameObject);
    }

    public void tijoloStop()
    {
        tijoloStopFlag = true;
        lastPosition = this.transform.position;
        this.GetComponent<Collider>().isTrigger = true;
    }
}
