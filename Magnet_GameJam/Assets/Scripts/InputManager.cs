using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{

    [SerializeField][Range(0, 10)] float craneMovementSpeed = 5;
    [SerializeField] [Range(0, 10)] float craneLiftSpeed = 5;
    [SerializeField] bool isFactoryOn;

    public static bool magnet { get; private set; }
    public static float mouseX { get; private set; }
    public static float mouseY { get; private set; }

    float horizontal;
    float vertical;
    float z;
    bool up;
    bool down;

    float cranePosX;
    float cranePosY;

    Animator animator;

    void Start()
    {
        if(GetComponent<Animator>() != null) animator = GetComponent<Animator>();
    }

    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        up = Input.GetKey(KeyCode.E);
        down = Input.GetKey(KeyCode.Q);
        magnet = Input.GetKey(KeyCode.Space);
        UpdateAnimatorVariables();
    }

    void UpdateAnimatorVariables()
    {
        animator.SetBool("On", isFactoryOn);
        if (isFactoryOn)
        {
            cranePosX += horizontal * Time.deltaTime * craneMovementSpeed;
            cranePosY += vertical * Time.deltaTime * craneMovementSpeed;
            if (up == true)
            {
                z += Time.deltaTime * craneLiftSpeed;
            }
            if (down == true)
            {
                z -= Time.deltaTime * craneLiftSpeed;
            }

            cranePosX = Mathf.Clamp(cranePosX, -1, 1);
            cranePosY = Mathf.Clamp(cranePosY, -1, 1);
            z = Mathf.Clamp(z, 0, 1);

            animator.SetFloat("x", cranePosX);
            animator.SetFloat("y", -cranePosY);
            animator.SetFloat("z", z);
        }
        
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
        animator.SetBool("Up", up);
        animator.SetBool("Down", down);
        animator.SetBool("Magnet", magnet);
    }

}
