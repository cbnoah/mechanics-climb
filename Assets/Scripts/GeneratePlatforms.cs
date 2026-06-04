using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class GeneratePlatforms : MonoBehaviour
{
    [SerializeField] private GameObject platformPrefab;
    [SerializeField] private GameObject springPlaformPrefab;
    [SerializeField] private Camera _camera;
    [SerializeField] private int _maxPlatforms = 20;
    private int _checkRefreshValue = 5;
    private List<GameObject> _platforms = new List<GameObject>();

    private void Start()
    {
        generateFirstPlatforms();
        generatePlatforms();
    }

    private void FixedUpdate()
    {
        VerifyIsInCameraVison();
        if (_platforms.Count < _maxPlatforms - _checkRefreshValue)
        {
            Debug.Log("Platform count : " + _platforms.Count);
            generatePlatforms();
        }
    }

    private void VerifyIsInCameraVison()
    {
        Vector3 bottomEdge = _camera.ViewportToWorldPoint(new Vector3(0.5f, 0f, _camera.nearClipPlane));
        float destroyY = bottomEdge.y - 1f;
        if (_platforms[_checkRefreshValue].transform.position.y < destroyY)
        {
            for (int i = _platforms.Count - 1; i >= 0; i--)
            {
                if (_platforms[i].transform.position.y < destroyY)
                {
                    Destroy(_platforms[i].gameObject);
                    _platforms.RemoveAt(i);
                }
            }
        }
    }

    private void generateFirstPlatforms()
    {
        _platforms.Add(Instantiate(platformPrefab, new Vector3(0f, 0f, 0f), Quaternion.identity, transform));
    }

    private void AddSpringPlatform(float lastY)
    {
        _platforms.Add(Instantiate(springPlaformPrefab, new Vector3(Random.Range(-9f, 9f), lastY, 0),
            Quaternion.identity, transform));
    }

    private void generatePlatforms()
    {
        float lastY = _platforms.Last().transform.position.y;

        for (var i = _platforms.Count; i <= _maxPlatforms; i++)
        {
            lastY += 3.8f;
            _platforms.Add(Instantiate(
                platformPrefab,
                new Vector3(Random.Range(-9f, 9f), lastY, 0),
                Quaternion.identity,
                transform
            )); 
            if (Random.Range(0, 11) == 10)
            {
                AddSpringPlatform(lastY);
            }
        }
    }
}