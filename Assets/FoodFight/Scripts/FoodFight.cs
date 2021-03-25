using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodFight : MonoBehaviour
{
    public int score;
    public Target targetPrefab;
    public BoxCollider spawnArea;
    public float countdown;
    public float gameDuration;
    public TMP_Text scoreText;
    public TMP_Text countdownText;
    public  int oddsOfHardTarget;
    public Texture2D targetTextureEasy;
    public Texture2D targetTextureHard;

    private int scoreForCurrentTarget;

    private void Start()
    {
        // Spawn the first target
        SpawnTarget();

        // Start the countdown
        countdown = gameDuration;
    }

    public void OnTargetHit()
    {
        // Increase score
        score += scoreForCurrentTarget;

        // Spawn a new target
        SpawnTarget();
    }

    public void SpawnTarget()
    {
        Texture targetTexture;
        // Quaternion.identity = no rotation - Vector3.Zero = center (0,0,0)

        // Calculate new random position for target
        Vector3 randomPosition = new Vector3(
            Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x),
            Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y),
            Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z));

        // Spawn the new target
        Target newTarget = Instantiate(targetPrefab, randomPosition, Quaternion.Euler(-90,0,0));
        
        // Determine if the target is a hard one
        if (Random.Range(0, oddsOfHardTarget) == 0) 
        {
            newTarget.speed *= 2;
            targetTexture = targetTextureHard;
            scoreForCurrentTarget = 3;
        }
        else
        {
            targetTexture = targetTextureEasy;
            scoreForCurrentTarget = 1;
        }
        newTarget.GetComponent<MeshRenderer>().material.mainTexture = targetTexture;

        // Let the target know about the current game script
        newTarget.game = this;
    }

    public void Update()
    {
        // Decrease the game countdown 
        countdown -= Time.deltaTime;

        // If the countdown has run out
        if(countdown <= 0)
        {
            GameOver();
        }

        // Update UI
        UpdateUI();
    }

    private void UpdateUI()
    {
        // Update score text
        scoreText.text = $"Score: {score}";

        // Update countdown text
        countdownText.text = $"Time Left: {countdown:F1} sec";
    }

    private void GameOver()
    {
        // Freeze time
        Time.timeScale = 0f;
    }
}
