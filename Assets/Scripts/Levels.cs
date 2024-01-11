using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Levels : MonoBehaviour
{
    public int level = 0;
    public Text[] levelDisplays;
    public Animator levelAnimator;

    public int[] levels;
    public int scoreToNextLevel = 0;
    // Start is called before the first frame update
    void Start()
    {
        NextLevel();
    }

    // Update is called once per frame
    void Update()
    {
        if (Score.instance.score >= scoreToNextLevel){
            NextLevel();
        }
    }

    void NextLevel(){
        scoreToNextLevel = levels[level];
        level += 1;

        Parallax.speed = 2.0f + (level * 0.1f);
        
        for (int i = 0; i < levelDisplays.Length; i++)
        {
            levelDisplays[i].text = "Level " + level.ToString();
        }

        levelAnimator.SetTrigger("Play");
    }
}
