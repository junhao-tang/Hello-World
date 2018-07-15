using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public UnityEngine.UI.Text scoreText;
    public int ballValue;

    private int score;

	// Use this for initialization
	void Start () {
        score = 0;
        UpdateText();
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D () {
        score += ballValue;
        UpdateText();
	}

    void UpdateText() {
        scoreText.text = "Score:\n" + score.ToString();
    }
}
