using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private Transform playerTransform;
    
    private Rigidbody _rigidbody;
    private const int JumpForce = 5;
    private const int SidewaysForce = 2;
    private bool _jumpPressed;
    private float _horizontalInput;
    private const int MaxColliders = 10;
    private readonly Collider[] _hitColliders = new Collider[MaxColliders];
    
    private GameObject _collectedCoinsText;
    private ScoreScript _scoreScript;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collectedCoinsText = GameObject.Find("CollectedCoinsText");
        _scoreScript = _collectedCoinsText.GetComponent<ScoreScript>();
        _gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _jumpPressed = true;
        _horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (_jumpPressed && Physics.
                OverlapSphereNonAlloc(groundCheckTransform.position, 0.1f, _hitColliders) != 1)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            _jumpPressed = false;
        }

        var velocity = _rigidbody.velocity;
        velocity = new Vector3(_horizontalInput * SidewaysForce, velocity.y, velocity.z);
        _rigidbody.velocity = velocity;
        
        if (playerTransform.position.y < 0)
        {
            GameManager.GameOver(SceneManager.GetActiveScene().buildIndex);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // layer 7 - Pick up items layer
        if (other.gameObject.layer.Equals(7))
        {
            Destroy((other.gameObject));
            _scoreScript.IncrementCollectedCoins();
        }
        
    }
}
