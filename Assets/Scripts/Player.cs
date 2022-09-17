using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private const int JumpForce = 5;
    private const int SidewaysForce = 2;
    private bool _jumpPressed;
    private float _horizontalInput;
    [SerializeField] private Transform groundCheckTransform;
    [SerializeField] private LayerMask playerMask;

    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
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
        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length != 0 && _jumpPressed)
        {
            _rigidbody.AddForce(Vector3.up * JumpForce, ForceMode.VelocityChange);
            _jumpPressed = false;
        }

        var velocity = _rigidbody.velocity;
        velocity = new Vector3(_horizontalInput * SidewaysForce, velocity.y, velocity.z);
        _rigidbody.velocity = velocity;
    }

    
}
