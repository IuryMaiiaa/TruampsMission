using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuHUD : MonoBehaviour {

    public GameObject MainMenuPanel;
    public GameObject gamePlayPanel;
    public GameObject EndGamePanel;

    public void OnEnable()
    {
        GameManager.IniciarMenuPrincipal += abilitarMainMenuHUD;
        GameManager.IniciarMenuPrincipal += desabilitarEndGameHUD;
        GameManager.IniciarMenuPrincipal += desabilitarGamePlayHUD;

        GameManager.AoGameStart += desabilitarMainMenuHUD;
        GameManager.AoGameStart += abilitargamePlayPaneHUD;

        GameManager.AoGameEnd += desabilitarGamePlayHUD;
        GameManager.AoAtivateShare += abilitarEndGameHUD;
    }

    public void OnDisable()
    {
        GameManager.IniciarMenuPrincipal -= abilitarMainMenuHUD;
        GameManager.IniciarMenuPrincipal -= desabilitarEndGameHUD;
        GameManager.IniciarMenuPrincipal -= desabilitarGamePlayHUD;

        GameManager.AoGameStart -= desabilitarMainMenuHUD;
        GameManager.AoGameStart -= abilitargamePlayPaneHUD;

        GameManager.AoGameEnd -= desabilitarGamePlayHUD;
        GameManager.AoAtivateShare -= abilitarEndGameHUD;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void desabilitarEndGameHUD()
    {
        EndGamePanel.SetActive(false);
    }

    public void abilitarEndGameHUD()
    {
        EndGamePanel.SetActive(true);
    }

    public void desabilitarGamePlayHUD()
    {
        gamePlayPanel.SetActive(false);
    }

    public void abilitargamePlayPaneHUD()
    {
        gamePlayPanel.SetActive(true);
    }

    public void desabilitarMainMenuHUD()
    {
        MainMenuPanel.SetActive(false);
    }

    public void abilitarMainMenuHUD()
    {
        MainMenuPanel.SetActive(true);
    }
}
