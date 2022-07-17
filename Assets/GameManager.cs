using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool gameEnded { get; private set; }
    public static uint score { get; private set; }

    private static TextMeshProUGUI scoreCounter;

    private void Start() {
        gameEnded = false;
        scoreCounter = GameObject.FindGameObjectWithTag("scorecounter").GetComponent<TextMeshProUGUI>();
        score = 0;

        UpdateText();
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public static void EndGame() {
        print("Game over!");
        gameEnded = true;   
    }

    public static IEnumerator RestartScene() {
        yield return new WaitForSeconds(2.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void IncrementScore() {
        if (gameEnded) return;

        score++;
        UpdateText();
    }

    public static void UpdateText() {
        scoreCounter.text = Convert.ToString(score);
    }
}