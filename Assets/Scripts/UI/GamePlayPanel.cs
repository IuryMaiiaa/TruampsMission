using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePlayPanel : MonoBehaviour {

    public UnityEngine.UI.Text porcentagem;
    public UnityEngine.UI.Text timer;


    public SpawManager spawManager;
    public GamePlayManager gamePlayManager;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        porcentagem.text = spawManager.gerarPontuacao() + " / 100%";
        timer.text = (int)((gamePlayManager.timeLimit + gamePlayManager.timeBegin) - Time.time) + "s"; 
	}
}
