using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawnerScript : MonoBehaviour
{
    public GameObject[] Clouds;

    public GameObject Endpoint;

    public float SpawnCloudTimerMinSeconds = 10;

    public float SpawnCloudTimerMaxSeconds = 45;

    public float CloudElevationOffset = 10;

    public float MinCloudScale = 0.75f;

    public float MaxCloudScale = 1.25f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeCloudsTimer(SpawnCloudTimerMinSeconds, SpawnCloudTimerMaxSeconds));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCloud()
    {
        // Much inspiration for this cloud generator came from watching: https://youtu.be/DvAmw-YXrG0

        var cloudElevation = Random.Range(transform.position.y - CloudElevationOffset, transform.position.y + CloudElevationOffset);

        var startPosition = new Vector3(transform.position.x, cloudElevation, transform.position.z);

        // the idea with using an array of clouds is to be able to display clouds with different looks
        var cloudIndex = Random.Range(0, Clouds.Length);

        var cloud = Instantiate(Clouds[cloudIndex]);

        // TODO: randomize cloud opacity?

        var cloudScale = Random.Range(MinCloudScale, MaxCloudScale);

        cloud.GetComponent<CloudScript>().StartFloating(startPosition, Endpoint.transform.position, cloudScale, cloudScale);
    }

    IEnumerator MakeCloudsTimer(float minSeconds, float maxSeconds)
    {
        while (true)
        {
            SpawnCloud();

            yield return new WaitForSeconds(Random.Range(minSeconds, maxSeconds));
        }
    }
}
