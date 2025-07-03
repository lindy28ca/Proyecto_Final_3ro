using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Raycast")]
    [SerializeField] private float distance;
    [SerializeField] private LayerMask layer;

    [Header("Características")]
    [SerializeField] private float speed;
    [SerializeField] private float gravity = -9.81f;
    private Vector3 velocity;
    private Vector3 moveDirection;
    private Vector2 inputMove;

    [Header("Cámara")]
    [SerializeField] private Transform camaraPlayer;

    private CharacterController controller;

    private void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        moveDirection = camaraPlayer.forward * inputMove.y + camaraPlayer.right * inputMove.x;
        moveDirection.y = 0f;
        controller.Move(moveDirection * speed * Time.deltaTime);

        if (!ComprobarPiso())
        {
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
        }
        else
        {
            velocity.y = 0f;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Puñito"))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("Perdiste");
        }
    }

    private bool ComprobarPiso()
    {
        return Physics.Raycast(transform.position, Vector3.down, distance, layer);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, Vector3.down * distance);
    }

    private void GetInput(Vector2 input)
    {
        inputMove = input;
    }

    private void OnEnable()
    {
        InputReader.OnMovePlayer += GetInput;
    }

    private void OnDisable()
    {
        InputReader.OnMovePlayer -= GetInput;
    }
}
