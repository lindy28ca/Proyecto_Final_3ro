using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;

    [Header("Características")]

    [SerializeField]private float speed;
    private Rigidbody rb;
    private Vector3 OnMoveDirection;
    private Vector2 OnMove;

    [Header("Cámara")]
    [SerializeField] private Transform camaraPlayer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        OnMoveDirection = camaraPlayer.forward * OnMove.y + camaraPlayer.right * OnMove.x;
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector3(OnMoveDirection.x * speed, rb.linearVelocity.y, OnMoveDirection.z * speed);   
    }
    private bool Comprobarpiso()
    {
        return Physics.Raycast(transform.position, Vector2.down,distance,layer);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector2.down * distance);
    }
    private void GetImput(Vector2 Input)
    {
        OnMove = Input;
    }
    private void OnEnable()
    {
        InputReader.OnMovePlayer += GetImput;
    }
    private void OnDisable()
    {
        InputReader.OnMovePlayer -= GetImput;
    }
}
