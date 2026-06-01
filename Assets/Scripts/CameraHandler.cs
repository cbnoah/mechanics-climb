using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    
    private void Start()
    {
    }

    private void FixedUpdate()
    {
        if (transform.position.y < player.transform.position.y)
        {
            transform.Translate(Vector3.up * Time.deltaTime * player.transform.position.y);
        }
    }
}