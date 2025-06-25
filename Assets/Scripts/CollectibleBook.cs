using UnityEngine;
using TMPro;

public class CollectibleBook : MonoBehaviour
{
    private static int score = 0;
    private static TextMeshProUGUI scoreText;

    void Start()
    {
        if (scoreText == null)
        {
            GameObject textObj = GameObject.Find("ScoreText");
            if (textObj != null)
                scoreText = textObj.GetComponent<TextMeshProUGUI>();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            score++;
            if (scoreText != null)
                scoreText.text = "Score: " + score;

            Destroy(gameObject);
        }
    }
}

