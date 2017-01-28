using UnityEngine;
using System.Collections;

public class Camerobo : MonoBehaviour
{

    public float speed_move = 0.1f;
    public float speed_look = 2f;
    public float speed_rate = 0.1f;

    public KeyCode key_jump = KeyCode.Space;
    public KeyCode key_crouch = KeyCode.LeftShift;
    public KeyCode key_menu = KeyCode.Escape;
    public KeyCode key_goforward = KeyCode.W;
    public KeyCode key_goleft = KeyCode.A;
    public KeyCode key_goback = KeyCode.S;
    public KeyCode key_goright = KeyCode.D;
    public KeyCode key_lookup = KeyCode.UpArrow;
    public KeyCode key_lookleft = KeyCode.LeftArrow;
    public KeyCode key_lookdown = KeyCode.DownArrow;
    public KeyCode key_lookright = KeyCode.RightArrow;

    float xx = 0.0f, yy = 0.0f, zz = 0.0f;

    void Start()
    {
    }

    void Update()
    {
        speed_move = Input.GetKey(KeyCode.Q) ? 0.01f : 0.05f;
        MoveAxis();
        JumpButton();
        CrouchButton();
        RotateCamera();
    }

    void MoveAxis()
    {
        //float input_x = 0, input_y = 0;
        if (Input.GetKey(key_goright)) xx += 1.0f / speed_rate;
        if (Input.GetKey(key_goleft)) xx -= 1.0f / speed_rate;
        xx = Mathf.Clamp(xx, -1.0f, 1.0f);
        if (!Input.GetKey(key_goright) && !Input.GetKey(key_goleft)) {
            xx -= xx >= 1f / speed_rate ? 1f / speed_rate : xx <= -1f / speed_rate ? -1f / speed_rate : 0f;
        }
        if (Input.GetKey(key_goforward)) yy += 1f / speed_rate;
        if (Input.GetKey(key_goback)) yy -= 1f / speed_rate;
        yy = Mathf.Clamp(yy, -1.0f, 1.0f);
        if (!Input.GetKey(key_goforward) && !Input.GetKey(key_goback))
        {
            yy -= yy >= 1f / speed_rate ? 1f / speed_rate : yy <= -1f / speed_rate ? -1f / speed_rate : 0f;
        }
        Vector3 vector_right = transform.rotation * new Vector3(1, 0, 0);
        Vector3 vector_forward = transform.rotation * new Vector3(0, 0, 1);
        vector_forward = new Vector3(vector_forward.x, 0, vector_forward.z).normalized;
        Vector3 vectormove = vector_right * xx * speed_move + vector_forward * yy * speed_move;
        transform.position += vectormove;
        if (Mathf.Sqrt(Mathf.Pow(transform.position.x, 2.0f) + Mathf.Pow(transform.position.z, 2.0f)) >= 80.0f)
        {
            transform.position -= vectormove;
        }
    }

    void JumpButton()
    {
        if (Input.GetKey(key_jump))
        {
            if (!Input.GetKey(key_crouch)) zz += 1.0f / speed_rate;
            zz = Mathf.Clamp(zz, -1.0f, 1.0f);
        }
        if (!Input.GetKey(key_jump) && !Input.GetKey(key_crouch))
        {
            zz -= zz >= 1f / speed_rate ? 1f / speed_rate : zz <= -1f / speed_rate ? -1f / speed_rate : 0f;
        }
        Vector3 v = new Vector3(0, 1, 0) * zz * speed_move;
        transform.position += v;
        if (transform.position.y >= 20f)
        {
            transform.position -= v;
        }
    }

    void CrouchButton()
    {
        if (Input.GetKey(key_crouch))
        {
            if (!Input.GetKey(key_jump)) zz -= 1.0f / speed_rate;
            zz = Mathf.Clamp(zz, -1.0f, 1.0f);
        }
        Vector3 v = new Vector3(0, 1, 0) * zz * speed_move;
        transform.position += v;
        if (transform.position.y <= -40f)
        {
            transform.position -= v;
        }
    }

    void RotateCamera()
    {
        float rotate_x = 0, rotate_y = 0;
        if (Input.GetKey(key_lookup)) rotate_x += 1;
        if (Input.GetKey(key_lookdown)) rotate_x -= 1;
        if (Input.GetKey(key_lookright)) rotate_y += 1;
        if (Input.GetKey(key_lookleft)) rotate_y -= 1;
        float y_rad = transform.eulerAngles.y * Mathf.Deg2Rad;
        transform.rotation = Quaternion.Euler(
            -speed_look * rotate_x * Mathf.Cos(y_rad),
            speed_look * rotate_y,
            speed_look * rotate_x * Mathf.Sin(y_rad)
        ) * transform.rotation;
        ClampAngleX();
    }

    void ClampAngleX()
    {
        float x_deg = transform.eulerAngles.x;
        Vector3 angles = transform.eulerAngles;
        if (x_deg <= 90 && x_deg >= 90 - speed_look)
        {
            transform.eulerAngles = new Vector3(90 - speed_look - 1, angles.y, angles.z);
        }
        else if (x_deg >= 270 && x_deg <= 270 + speed_look)
        {
            transform.eulerAngles = new Vector3(270 + speed_look + 1, angles.y, angles.z);
        }
    }
}