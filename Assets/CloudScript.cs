using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudScript : MonoBehaviour
{
    private float speed;

    private Vector3 endPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * (Time.deltaTime * speed));

        if (transform.position.x > endPosition.x)
        {
            Destroy(gameObject);
        }
    }

    public void StartFloating(Vector3 startPosition, Vector3 endPosition, float speed, float scale)
    {
        transform.position = startPosition;
        transform.localScale = new Vector2(scale, scale);
        this.speed = speed;
        this.endPosition = endPosition;
    }
}
