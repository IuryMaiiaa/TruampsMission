using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour {


    public static Action OpenVictoryScene;
    public static Action OpenDefeatScene;
    public static Action HideMainMenuHUD;
    public static Action AoGameStart;
    public static Action AoGameEnd;
    public static Action IniciarMenuPrincipal;
    public static Action AoAtivateShare;

    public float timeToEndGamePanel;

    // Use this for initialization
    void Start () {
        iniciarMenuPrincipal();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void derrota()
    {
        if(AoGameEnd != null)
        {
            AoAtivateShare();
        }
        
    }

    public static void vitoria()
    {
        if(OpenVictoryScene != null)
        {
            OpenVictoryScene();
        }
    }

    public static void aoAtivateShare()
    {
        if (AoAtivateShare != null)
        {
            AoAtivateShare();
        }
    }

    public void iniciarMenuPrincipal()
    {
        if(IniciarMenuPrincipal != null)
        {
            IniciarMenuPrincipal();
        }
    }

    public void StartGame()
    {
        if(HideMainMenuHUD != null)
        {
            HideMainMenuHUD();
        }
        
        if(AoGameStart != null)
        {
            AoGameStart();
        }
    }

    public void CloseGame()
    {
        Application.Quit();
    }


    IEnumerator spraiTime()
    {
        yield return new WaitForSeconds(timeToEndGamePanel);
    }
}
