using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawManager : MonoBehaviour {

    public GameObject[] spawLocations;
    private SpawTijoloDetector[] detectos;
    public GameObject tijolo;
    public GameObject tijoloFinal;
    private float lastSpaw;
    public float timeSpaw;

    public int lastGameScore;
    public bool gamePlayRunning;

    public void OnEnable()
    {
        GameManager.IniciarMenuPrincipal += destroiTijolos;
        GameManager.AoGameStart += gamePlayStart;
        GameManager.AoGameEnd += gamePlayEnd;
        GameManager.OpenVictoryScene += gerarMuroFinal;
    }

    public void OnDisable()
    {
        GameManager.IniciarMenuPrincipal -= destroiTijolos;
        GameManager.AoGameStart -= gamePlayStart;
        GameManager.AoGameEnd -= gamePlayEnd;
        GameManager.OpenVictoryScene -= gerarMuroFinal;
    }
 
    public void gamePlayStart()
    {
        gamePlayRunning = true;
        lastSpaw = Time.time;
        restartGame();
    }

    public void restartGame()
    {
        foreach (SpawTijoloDetector detector in detectos)
        {
            if (detector != null )
            {
                detector.espacoOcupado=false;
            }
        }
    }

    public void gerarMuroFinal()
    {
        StartCoroutine(gerarMuroFinalAnimation());
        
    }

    public void gamePlayEnd()
    {
        gamePlayRunning = false;
        lastGameScore = gerarPontuacao();
        destroiTijolos();
    }

    public int gerarPontuacao()
    {
        int count=0;
        foreach(SpawTijoloDetector detector in detectos)
        {
            if(detector!=null && detector.espacoOcupado)
            {
                count++;
            }
        }
        return (count * 100 / detectos.Length + 1);
    }

    public void destroiTijolos()
    {
        Tijolo[] tijolos = GameObject.FindObjectsOfType<Tijolo>();

        foreach (Tijolo tijolo in tijolos)
        {
            tijolo.tijoloDestruction();
        }
     }

	// Use this for initialization
	void Start () {
        timeSpaw = 0.3f;
        detectos = GameObject.FindObjectsOfType<SpawTijoloDetector>();
    }
	
	// Update is called once per frame
	void Update () {
		if(gamePlayRunning)
        {
            spawTijolo();
        }
	}

    public void spawTijolo()
    {
        if(lastSpaw + timeSpaw < Time.time)
        {
            Instantiate(tijolo, getRandomSpawLocation(), Quaternion.identity);
            lastSpaw = Time.time;
        }
    }


    public Vector3 getRandomSpawLocation()
    {
        return spawLocations[(int)Random.Range(0,spawLocations.Length)].transform.position;
    }

    IEnumerator gerarMuroFinalAnimation()
    {
        int cont1 = 0;
        for (int cont = 0; cont < 5; cont++)
        {
            for (cont1 = 0; cont1 < spawLocations.Length; cont1 += 2)
            {
                Instantiate(tijoloFinal, spawLocations[cont1].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
            for (cont1 = 10; cont1 >= 0; cont1 -= 2)
            {
                Instantiate(tijoloFinal, spawLocations[cont1].transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
