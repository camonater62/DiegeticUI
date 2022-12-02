using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;
public class ScoreManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TextMeshPro scoreText;
    public int score = 0;

    public void IncrementScore(){
        score += 1;
        scoreText.text = score.ToString();
    }
}
