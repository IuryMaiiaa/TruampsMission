using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayManager : MonoBehaviour {

    public Touch touch;
    public Ray ray;

    public bool gamePlayRunning;

    public float timeLimit;
    public float timeBegin;
    public int porcentagemDesejada;

    public SpawManager spawManager;


    public void OnEnable()
    {
        GameManager.AoGameStart += gamePlayStart;
        GameManager.AoGameEnd += gamePlayEnd;
    }


    public void gamePlayStart()
    {
        timeBegin = Time.time;
        gamePlayRunning = true;
    }

    public void gamePlayEnd()
    {

        gamePlayRunning = false;

    }
    // Use this for initialization
    void Start () {
		
	}

    public void creckEndGameConditions()
    {
        if((timeLimit + timeBegin < Time.time) || (spawManager.gerarPontuacao() == 100))
        {
            GameManager.AoGameEnd();
            if (spawManager.gerarPontuacao() < porcentagemDesejada)
            {
                GameManager.derrota();
            } else
            {
                GameManager.vitoria();
            }
        }
    }

    // Update is called once per frame
    void Update () {

        if(gamePlayRunning)
        {
            creckEndGameConditions();
        }

        if(gamePlayRunning)
        {
            //mobilePhone
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
                    if (hit.collider.gameObject.tag == "tijolo" && hit.collider.isTrigger == false)
                    {

                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                hit.collider.GetComponent<Tijolo>().tijoloStop();
                                break;

                            case TouchPhase.Ended:
                                break;
                        }
                    }
                }

            }

            //PC
            if(Input.GetKeyDown(KeyCode.Mouse0))
            {
                Vector3 mousePos = Input.mousePosition;
                ray = Camera.main.ScreenPointToRay(new Vector2(mousePos.x,mousePos.y));
                Vector3 aux = ray.origin;
                aux.z = 0;
                ray.origin = aux;
                RaycastHit hit = new RaycastHit();

                if (Physics.Raycast(ray, out hit, 100))
                {
                    if (hit.collider.gameObject.tag == "tijolo" && hit.collider.isTrigger == false )
                    {
                        hit.collider.GetComponent<Tijolo>().tijoloStop();
                    }
                }
            }
        }
        
    }
}
