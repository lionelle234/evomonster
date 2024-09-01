using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HUDController : MonoBehaviour
{   
    private Player player;
    private GameObject health, evolution, food, score;
    private TextMeshProUGUI healthText, evolutionText, foodText, scoreText;
    private int scoreCount;

    private void Awake()
    {
        player = FindAnyObjectByType<Player>();
        health = GameObject.Find("Health (Temp)");
        evolution = GameObject.Find("Evolution (Temp)");
        food = GameObject.Find("Food (Temp)");
        score = GameObject.Find("Score");

    }
    // Start is called before the first frame update
    void Start()
    {
        healthText = health.GetComponent<TextMeshProUGUI>();
        evolutionText = evolution.GetComponent<TextMeshProUGUI>();
        foodText = food.GetComponent<TextMeshProUGUI>();
        scoreText = score.GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthText.text = player.currentHealth.ToString();
        evolutionText.text = player.currentEvo.ToString();
        foodText.text = player.foodAmount.ToString();   
    }

    public void ScoreUp(int point)
    {
        scoreCount += point;
        scoreText.text = scoreCount.ToString();
    }
}
