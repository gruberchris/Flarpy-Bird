using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
    public Rigidbody2D rigidbopdy2D;
    public float flapStrength;
    public GameStateScript gameStateScript;
    public bool isAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        gameStateScript = GameObject.FindGameObjectWithTag("GameState").GetComponent<GameStateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isAlive)
        {
            rigidbopdy2D.velocity = Vector2.up * flapStrength;
        }

        var pos = Camera.main.WorldToViewportPoint(transform.position);

        if (pos.x < 0 || pos.x > 1 || pos.y < 0 || pos.y > 1)
        {
            // If the bird position is left of the camera view, or the right, or above, or below it.
            BirdDeath();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BirdDeath();
    }

    private void BirdDeath()
    {
        gameStateScript.GameOver();
        isAlive = false;
    }
}
