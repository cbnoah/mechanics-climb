using System.Collections.Generic;
using UnityEngine;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject camera;
    private List<GameObject> platforms;

    private void Start()
    {
        for (var i = 0; i < 10; i++)
        {
            platforms.Add(Instantiate(platformPrefab, new Vector3(0, i * 2.0f, 0), Quaternion.identity));
        }
    }

    private void verifyIsInCameraVison()
    {
        foreach (GameObject platform in platforms)
        {
            if (platform.transform.position.y < camera.transform.position.y)
            {
                
            }
        }
    }
}