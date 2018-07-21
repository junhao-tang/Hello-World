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
	void OnTriggerEnter2D (Collider2D obj)
    {  // take note that there is a method with no args
        score += ballValue;
        UpdateText();
	}

    // differences between OnCollisionEnter and OnTriggerEnter is that
    // OnCollisionEnter will be triggered when any collision happened 
    // whereas OnTriggerEnter 2D will only trigger when collision
    // happens on collider that has "is trigger" attr
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bomb") {
            score -= ballValue * 2;
            UpdateText();
        }
    }

    void UpdateText() {
        scoreText.text = "Score:\n" + score.ToString();
    }
}
