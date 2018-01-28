using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public Touch touch;
    public Ray ray;

    public AudioClip abertura;
    public AudioClip audioGameLoop;

    public AudioClip[] clicks;
    public AudioSource audioSourceClicks;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        for (int i = 0; i < Input.touches.Length; i=Input.touches.Length+1)
        {
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    audioSourceClicks.Stop();
                    audioSourceClicks.clip = clicks[Random.Range(0, clicks.Length - 1)];
                    audioSourceClicks.Play();
                    break;

                case TouchPhase.Ended:
                    break;
            }

        }

        //PC
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            audioSourceClicks.Stop();
            audioSourceClicks.clip = clicks[Random.Range(0, clicks.Length - 1)];
            audioSourceClicks.Play();
        }
    }
}
