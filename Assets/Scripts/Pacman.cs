using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Movement))]
public class Pacman : MonoBehaviour
{
    private CircleCollider2D circleCollider;
    public Movement movement { get; private set; }
    public FloatingJoystick joystick;

    private void Awake()
    {
        movement = GetComponent<Movement>();

        circleCollider = GetComponent<CircleCollider2D>();


    }

    private void Start()
    {

        joystick = FindObjectOfType<FloatingJoystick>();
    }

    private void Update()
    {
        float x = joystick.Horizontal;
        float y = joystick.Vertical;

        
        

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow) || x>0)
        {
            movement.SetDirection(Vector2.up);

            Debug.Log("Up gidiyom");

        }
        else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow) || x < 0)
        {
            movement.SetDirection(Vector2.down);

            Debug.Log("Down gidiyom");

        }
        else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || y > 0)
        {
            movement.SetDirection(Vector2.left);

            Debug.Log("Left gidiyom");

        }
        else if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || y < 0)
        {
            movement.SetDirection(Vector2.right);

            Debug.Log("Right gidiyom");
        }

        float angle = Mathf.Atan2(movement.direction.y, movement.direction.x);
        transform.rotation = Quaternion.AngleAxis(angle * Mathf.Rad2Deg, Vector3.forward);
    }



}