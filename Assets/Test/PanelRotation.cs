using UnityEngine;
public class PanelRotation : MonoBehaviour
{
    //这个脚本在"转盘"物体上.
    private Quaternion originalAngle;

    public int laps = 10;
    public GameObject right, left, still;
    public Transform checkerPosition;
    public enum angle
    {
        right,
        left,
        still
    };
    public angle direction;

    private void Start()
    {
        originalAngle = transform.localRotation;
    }
    private void Update()
    {
        InputManagement();
        WheelRotation();
    }
    private void AngleReset() //这个是当角度转回到最开始的角度以后能可不是0°，所以又加了一个RotateTowards
    {
        transform.localRotation =
        Quaternion.RotateTowards(transform.localRotation, originalAngle, 1000 * Time.deltaTime);
    }

    private void RotationReset() //当手离开以后的自动回转
    {
        if (laps > 0) transform.Rotate(new Vector3(0, 0, -1000 * Time.deltaTime), Space.Self);
        if (laps < 0) transform.Rotate(new Vector3(0, 0, 1000 * Time.deltaTime), Space.Self);
    }

    private void WheelRotation()
    {
        if (direction == angle.right)
        {
            if (laps < 3) transform.localEulerAngles += new Vector3(0, 0, 1000 * Time.deltaTime);
            right.transform.position = checkerPosition.position;
            still.transform.position = Vector3.zero;
            left.transform.position = Vector3.zero;
        }
        else if (direction == angle.left)
        {
            if (laps > -3) transform.localEulerAngles -= new Vector3(0, 0, 1000 * Time.deltaTime);
            left.transform.position = checkerPosition.position;
            still.transform.position = Vector3.zero;
            right.transform.position = Vector3.zero;
        }
        else if (direction == angle.still)
        {
            still.transform.position = checkerPosition.position;
            right.transform.position = Vector3.zero;
            left.transform.position = Vector3.zero;
            RotationReset();
            if (laps == 0) AngleReset();
        }
    }

    private void InputManagement()
    {
        if (Input.GetKey(KeyCode.D))
        {
            direction = angle.right;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            direction = angle.still;
        }

        if (Input.GetKey(KeyCode.A))
        {
            direction = angle.left;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            direction = angle.still;
        }
    }
    private void RotateRight()
    {
        if (Input.GetKey(KeyCode.D))
        {
            if (laps < 3) transform.localEulerAngles += new Vector3(0, 0, 1000 * Time.deltaTime);
            right.transform.position = checkerPosition.position;
            still.transform.position = Vector3.zero;
            left.transform.position = Vector3.zero;
            direction = angle.right;
        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            still.transform.position = checkerPosition.position;
            right.transform.position = Vector3.zero;
            left.transform.position = Vector3.zero;
            direction = angle.still;
        }
    }

    private void RotateLeft()
    {
        if (Input.GetKey(KeyCode.A))
        {
            if (laps > -3) transform.localEulerAngles -= new Vector3(0, 0, 1000 * Time.deltaTime);
            left.transform.position = checkerPosition.position;
            still.transform.position = Vector3.zero;
            right.transform.position = Vector3.zero;
            direction = angle.left;
        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            still.transform.position = checkerPosition.position;
            right.transform.position = Vector3.zero;
            left.transform.position = Vector3.zero;
            direction = angle.still;
        }
    }
}
