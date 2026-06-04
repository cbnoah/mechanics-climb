using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float speed = 5f;

    private void Update()
    {
        if (transform.position.y < player.transform.position.y)
        {
            float targetY = player.transform.position.y;
            float newY = Mathf.Lerp(transform.position.y, targetY, speed * Time.deltaTime);
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }
    }
}