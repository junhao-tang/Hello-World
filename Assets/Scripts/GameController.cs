using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Camera cam;
    public GameObject[] balls;
    public float timeLeft;
    public UnityEngine.UI.Text timerText;
    public GameObject gameOverText;
    public GameObject gameOverButton;
    public GameObject startButton;
    public GameObject splashScreen;
    public Controller hatController;

    private float maxWidth;
    private bool playing;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        playing = false;
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = balls[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        UpdateText();
    }

    private void FixedUpdate()
    {
        if(!playing)
            return;
        // if update = time for last frame
        // fixedupdate = amount of time per physic frame
        timeLeft -= Time.deltaTime;  // amount of time past
        print(Time.deltaTime);
        if (timeLeft < 0)
            return;
        UpdateText();
    }

    public void StartGame()
    {
        splashScreen.SetActive(false);
        startButton.SetActive(false);
        hatController.toggleControl(true);
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(2);
        playing = true;
        while (timeLeft > 0) {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0);
            Quaternion spawnRotation = Quaternion.identity;  // @TODO
            Instantiate(balls[Random.Range(0, balls.Length)], spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
        yield return new WaitForSeconds(2);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2);
        gameOverButton.SetActive(true);
    }

    void UpdateText() {
        timerText.text = "Time Left:\n " + Mathf.RoundToInt(timeLeft).ToString();
    }
}
