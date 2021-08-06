using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerInteraction : MonoBehaviour
{


    [SerializeField] private float powerThrowParcel;

    private Image screenDot;
    private Rigidbody activeParcel;
    private ParcelController activeParcelController;
    private Camera cam;

    //private bool controlWithTouch;

    private void Start()
    { 
        cam = GetComponentInChildren<Camera>();
        //controlWithTouch = GetComponent<PlayerController>().controllWithTouch;
        screenDot = GameObject.Find("ScreenDot").GetComponent<Image>(); 
    }
    private void Update()
    {
        if (Input.GetKey(KeyCode.Space)) ThrowActiveParcel();

        RaycastHit hit;
        if (Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject(-1))
        {
            //Ray ray = controlWithTouch ? cam.ScreenPointToRay(Input.mousePosition) : cam.ScreenPointToRay(new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2));
            Ray ray = cam.ScreenPointToRay(new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2));

            if (Physics.Raycast(ray, out hit, 5))
            { 
                if (hit.transform.tag == "Parcel")
                {
                    if (activeParcel == null)
                    {
                        activeParcel = hit.transform.GetComponent<Rigidbody>();
                        activeParcelController = hit.transform.GetComponent<ParcelController>();
                        activeParcel.isKinematic = true;
                    }
                    else SkipParcel();
                }
                else
                {
                    IInteraction interaction = hit.transform.GetComponent<IInteraction>();
                    if (interaction != null) interaction.Interact();
                }

            }

        } 
        Physics.Raycast(cam.ScreenPointToRay(new Vector2(cam.pixelWidth / 2, cam.pixelHeight / 2)), out hit, 5);

        if(hit.transform != null && hit.transform.gameObject.layer == 6) screenDot.color = Color.grey; 
        else screenDot.color = Color.white;


        if (activeParcel != null) SetParcelPosition();
    }

    private void SetParcelPosition()
    {
        activeParcel.transform.rotation = Quaternion.Euler(Vector3.right * 90 + transform.rotation.eulerAngles);
        activeParcel.transform.position = transform.position + activeParcelController.positionOnPlayer.x * transform.right + activeParcelController.positionOnPlayer.y * transform.up + activeParcelController.positionOnPlayer.z * transform.forward;
    }

    private void SkipParcel()
    {
        if (activeParcel != null)
        {
            activeParcel.isKinematic = false;
            activeParcel = null;
        }
    }

    public void ThrowActiveParcel()
    {
        if (activeParcel != null)
        {
            activeParcel.isKinematic = false;
            activeParcel.AddForce(transform.forward * powerThrowParcel + transform.up * powerThrowParcel * 1.5f, ForceMode.Impulse);
            activeParcel = null;
        }
    }
}
