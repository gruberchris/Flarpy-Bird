using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{
    public GameStateScript gameStateScript;
    public BirdScript birdScript;

    // Start is called before the first frame update
    void Start()
    {
        gameStateScript = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateScript>();
        birdScript = GameObject.FindGameObjectWithTag("Bird").GetComponent<BirdScript>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        const int BIRD_LAYER = 3;
        const int SCORE_POINT = 1;

        if (collision.gameObject.layer == BIRD_LAYER && birdScript.isAlive)
        {
            gameStateScript.AddScore(SCORE_POINT);
        }
    }
}
