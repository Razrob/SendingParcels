using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool controllWithTouch;

    [SerializeField] private VariableJoystick joystickRotate;
    [SerializeField] private VariableJoystick joystickMove;  

    public static bool controlIsActive = true;

    private CharacterController characterController;
     
    private Camera cam; 

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        characterController = GetComponent<CharacterController>();
        cam = GetComponentInChildren<Camera>();
        controlIsActive = true;
        PlayerStats.StatsDisplay();
    }


    private void Update()
    {
        if (!controlIsActive) return;

        if (!controllWithTouch)
        { 
            float xAxis = Input.GetAxis("Mouse X");
            float yAxis = Input.GetAxis("Mouse Y");

            transform.rotation = Quaternion.Euler(new Vector3(0, xAxis, 0) * 150 * Time.deltaTime * GeneralGameSettings.mouseSensitivity + transform.rotation.eulerAngles);
             
            cam.transform.rotation = Quaternion.Euler(new Vector3(-yAxis, 0, 0) * 150 * Time.deltaTime * GeneralGameSettings.mouseSensitivity + cam.transform.rotation.eulerAngles); 
             
            characterController.Move((transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + Physics.gravity) * Time.deltaTime * GeneralGameSettings.moveSpeed);
        }
        else
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, joystickRotate.Horizontal, 0) * 10 * Time.deltaTime * GeneralGameSettings.mouseSensitivity + transform.rotation.eulerAngles);
            cam.transform.rotation = Quaternion.Euler(new Vector3(-joystickRotate.Vertical, 0, 0) * 10 * Time.deltaTime * GeneralGameSettings.mouseSensitivity + cam.transform.rotation.eulerAngles);
            characterController.Move((transform.right * joystickMove.Horizontal + transform.forward * joystickMove.Vertical + Physics.gravity) * Time.deltaTime * GeneralGameSettings.moveSpeed);
        }

        if (cam.transform.localEulerAngles.x > 80 && cam.transform.localEulerAngles.x < 180) cam.transform.localRotation = Quaternion.Euler(80, 0, 0);
        if (cam.transform.localEulerAngles.x < 280 && cam.transform.localEulerAngles.x > 180) cam.transform.localRotation = Quaternion.Euler(280, 0, 0);

        if(cam.transform.localEulerAngles.x < 280 && cam.transform.localEulerAngles.x > 90) cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
        if (cam.transform.localEulerAngles.x < 0) cam.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }
}
