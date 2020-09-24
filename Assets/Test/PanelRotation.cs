using UnityEngine;
public class PanelRotation : MonoBehaviour
{
    //这个脚本在"转盘"物体上.
    private Quaternion originalAngle;

    public bool isTurning;

    void Start()
    {
        print("Press A or D to rotate panel.");
        originalAngle = transform.localRotation;
    }
    void Update()
    {
        RotationControl(KeyCode.A, -6f);
        RotationControl(KeyCode.D, 6f);
   
        if (!isTurning)
        {
            RotationReset();
        }
    }
    private void RotationReset() //这个是角度重置. 当前角度转回到最开始的角度
    {
        transform.localRotation =
        Quaternion.RotateTowards(transform.localRotation, originalAngle, 100 * Time.deltaTime);
    }

    private void RotationControl(KeyCode key, float speed) //这个是A、D键控制旋转
    {
        if (Input.GetKey(key))
        {
            isTurning = true;
            transform.eulerAngles += new Vector3(0, 0, speed);
        }
        else if (Input.GetKeyUp(key))
        {
            isTurning = false;
        }
    }
}
