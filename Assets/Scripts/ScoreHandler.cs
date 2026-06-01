using TMPro;
using UnityEngine;

public class ScoreHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private Camera _camera;

    private void Update()
    {
        var score = (int)_camera.transform.position.y;
        scoreText.text = "Score : " + score;
    }
}
