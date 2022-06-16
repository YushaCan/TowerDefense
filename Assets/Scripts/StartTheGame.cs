using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartTheGame : MonoBehaviour
{
    // For the animations
    private float buttonStayTime = 1f;
    // Controls wheter game is active or not
    public static bool isGameActive = false;
    // Controls the background music
    public GameObject musicManager;
    // Controls the start gun shot
    private AudioSource StartAudio;
    public AudioClip gunShot;
    // Controls the text.
    public GameObject unleashHellText;
    public GameObject warningText;
    // Controls the killing billboard.
    public GameObject killCounter;

    private void Start()
    {
        StartAudio = GetComponent<AudioSource>();
    }
    // If this function called. It starts the coroutine.
    public void StartGame()
    {
        StartCoroutine(timeForGameObjectDisable());
    }

    IEnumerator timeForGameObjectDisable()
    {
        StartAudio.PlayOneShot(gunShot, 1.0f); // Enables gun shot for once
        yield return new WaitForSeconds(buttonStayTime); // Waits for the animation to finish.
        musicManager.gameObject.SetActive(true); // Plays the background music.
        gameObject.SetActive(false);  //This line disables start button
        isGameActive = true;  //This variable is for control the enemy spawn
        unleashHellText.gameObject.SetActive(false);
        warningText.gameObject.SetActive(false);
        killCounter.gameObject.SetActive(true);
    }
}
