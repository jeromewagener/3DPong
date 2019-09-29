using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

// Class used to spawn the ball and monitor its position in case it goes out of bounds
// If the ball goes out of the playing field it will be re-spawned
public class BallMonitor : MonoBehaviour
{
    public float startSpeed = 250f;
    public float speedIncreaseTimerInSeconds = 1.5f;
    public float speedIncreasePercentageEachTimeout = 0.02f;
    
    public Text player1Label;
    public Text player2Label;

    private Rigidbody _ball;
    private int _player1Score = 0;
    private int _player2Score = 0;

    private void Start()
    {
        _ball = GetComponent<Rigidbody>();
        SpawnBall();
        InvokeRepeating(nameof(IncreaseSpeed), 2.0f, speedIncreaseTimerInSeconds);
    }

    private void IncreaseSpeed()
    {
        Debug.Log(_ball.velocity);
        var velocity = _ball.velocity;
        velocity = velocity + (velocity * speedIncreasePercentageEachTimeout);
        _ball.velocity = velocity;
        ;
    }

    private void Update()
    {
        if (Debug.isDebugBuild && Input.GetKeyDown("space"))
        {
            SpawnBall();
        }
        
        if (transform.position.x < -21)
        {
            _player2Score++;
            if (player2Label != null)
            {
                player2Label.text = "Player 2\nScore " + _player2Score;
            }

            SpawnBall();
        } 
        else if (transform.position.x > 22)
        {
            _player1Score++;
            if (player1Label != null)
            {
                player1Label.text = "Player 1\nScore " + _player1Score;
            }

            SpawnBall();
        }
    }

    public void SpawnBall()
    {
        _ball.position = Vector3.zero;
        _ball.velocity = Vector3.zero;

        float direction = 1;
        if (Random.value > 0.5f)
        {
            direction = -1;
        }

        Vector3 movement = new Vector3(direction * 1,0.0f,0.0f);
        _ball.AddForce(startSpeed * 100f * Time.deltaTime * movement);
    }
}
