using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinalScore : MonoBehaviour
{   
    private ScoreKeeper scoreKeeper;
    private TextMeshProUGUI text;
    private void Awake()
    {
        scoreKeeper = FindAnyObjectByType<ScoreKeeper>();
        text = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
        text.text = scoreKeeper.finalScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
