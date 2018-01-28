using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SprayTimeManager : MonoBehaviour {

    public Touch touch;
    public Ray ray;

    private float sprayTime;
    public bool sprayFlag;

    public GameObject spray;

    public float TimeOpenSpray;

    public void OnEnable()
    {
        GameManager.IniciarMenuPrincipal += destroySpray;
        GameManager.OpenVictoryScene += ativarSprayTime;
    }

    public void OnDisable()
    {
        GameManager.IniciarMenuPrincipal -= destroySpray;
        GameManager.OpenVictoryScene -= ativarSprayTime;
    }

    public void destroySpray()
    {
        GameObject[] sprays = GameObject.FindGameObjectsWithTag("spray");
        foreach (GameObject spray in sprays)
        {
            Destroy(spray);
        }
    }

    public void ativarSprayTime()
    {
        sprayFlag = true;
        sprayTime = Time.time;
    }

    // Use this for initialization
    void Start () {
        sprayFlag = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(sprayFlag == true)
        {
            pintarSpray();
            if ((sprayTime + TimeOpenSpray < Time.time) && sprayFlag == true)
            {
                sprayFlag = false;
                GameManager.aoAtivateShare();
            }
        }
	}

    public void pintarSpray()
    {
        for (int i = 0; i < Input.touches.Length; i++)
        {
            touch = Input.touches[i];
            ray = Camera.main.ScreenPointToRay(Input.touches[i].position);
            Vector3 aux = ray.origin;
            aux.z = 0;
            ray.origin = aux;
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 100))
            {
                if ((hit.collider.GetComponent<Tijolo>() != null) && hit.collider.isTrigger == false)
                {

                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            Instantiate(spray, ray.origin, Quaternion.identity);
                            break;
                        case TouchPhase.Moved:
                            break;

                        case TouchPhase.Ended:
                            break;
                    }
                }
            }

        }

        //PC
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = Input.mousePosition;
            ray = Camera.main.ScreenPointToRay(new Vector2(mousePos.x, mousePos.y));
            Vector3 aux = ray.origin;
            aux.z = 0;
            ray.origin = aux;
            RaycastHit hit = new RaycastHit();

            if (Physics.Raycast(ray, out hit, 100))
            {
                if ((hit.collider.GetComponent<Tijolo>() !=null) && hit.collider.isTrigger == false)
                {
                    Instantiate(spray, ray.origin, Quaternion.identity);
                }
            }
        }
    }

}
