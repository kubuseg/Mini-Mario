using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private Transform playerTransform;

    private Rigidbody _rigidbody;
    private GameManager _gameManager;
    private GameObject _collectedCoinsTextGameObject;
    private ScoreScript _scoreScript;
    private GameObject _powerJumpsTextGameObject;
    private PowerJumpsScript _powerJumpsScript;
    
    private const int JumpForce = 5;
    private const int SidewaysForce = 2;
    private const int MaxColliders = 10;
    private readonly Collider[] _hitCollidersList = new Collider[MaxColliders];
    
    private bool _jumpPressed;
    private float _horizontalInput;
    private int _powerUps;
    
    // Start is called before the first frame update
    void Start()
    {
        _gameManager = FindObjectOfType<GameManager>();
        _rigidbody = GetComponent<Rigidbody>();

        _collectedCoinsTextGameObject = GameObject.Find("Canvas/CollectedCoinsText");
        _scoreScript = _collectedCoinsTextGameObject.GetComponent<ScoreScript>();
        
        _powerJumpsTextGameObject = GameObject.Find("Canvas/PowerJumpsText");
        _powerJumpsScript = _powerJumpsTextGameObject.GetComponent<PowerJumpsScript>();
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
        var velocity = _rigidbody.velocity;
        velocity = new Vector3(_horizontalInput * SidewaysForce, velocity.y, velocity.z);
        _rigidbody.velocity = velocity;
        
        if (playerTransform.position.y < 0)
        {
            GameManager.GameOver(SceneManager.GetActiveScene().buildIndex);
        }
        
        if (!_jumpPressed)
            return;
        int hitColliders = Physics.OverlapSphereNonAlloc(groundCheckTransform.position, 0.1f, _hitCollidersList);
        if (hitColliders != 1)
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
        else if (_powerUps > 0)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            _powerUps--;
            _powerJumpsScript.SetPowerJumpsText(_powerUps);
        }
        _jumpPressed = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        var hitObject = other.gameObject;
        string hitObjectTag = hitObject.tag;
        // layer 7 - Pick up items layer
        if (hitObject.layer.Equals(7))
        {
            Destroy(other.gameObject);
            switch (hitObjectTag)
            {
                case "Coin":
                    _scoreScript.IncrementCollectedCoins();
                    break;
                case "PowerUp":
                    _powerUps++;
                    _powerJumpsScript.SetPowerJumpsText(_powerUps);
                    break;
            }
        }
        else if (hitObjectTag.Equals("Portal"))
        {
            _gameManager.GoToNextLevel();
        }
        
    }
}
