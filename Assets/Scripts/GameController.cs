using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public Camera cam;
    public GameObject ball;
    public float timeLeft;
    public UnityEngine.UI.Text timerText;

    private float maxWidth;

    // Use this for initialization
    void Start()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float ballWidth = ball.GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - ballWidth;
        UpdateText();
        StartCoroutine(Spawn());
    }

    private void FixedUpdate()
    {
        // if update = time for last frame
        // fixedupdate = amount of time per physic frame
        timeLeft -= Time.deltaTime;  // amount of time past
        print(Time.deltaTime);
        if (timeLeft < 0)
            return;
        UpdateText();
    }

    IEnumerator Spawn() {
        yield return new WaitForSeconds(2);
        while (timeLeft > 0) {
            Vector3 spawnPosition = new Vector3(
                Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0);
            Quaternion spawnRotation = Quaternion.identity;  // @TODO
            Instantiate(ball, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(1, 2));
        }
    }

    void UpdateText() {
        timerText.text = "Time Left:\n " + Mathf.RoundToInt(timeLeft).ToString();
    }
}
