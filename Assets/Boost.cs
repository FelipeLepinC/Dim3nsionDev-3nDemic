using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class Boost : MonoBehaviour
{
    public float speed = 4;
    public float jumpingForce = 300f;
    private float jumpingSpeed;
    public bool saltando = false;
    bool cayendo = false;
    public float gravity = -10;
    private float fallingSpeed;
    public LayerMask groundLayer;
    public XRNode inputSource;
    public XRNode inputSource2;
    private Vector2 inputAxis;
    private CharacterController character;
    public bool primaryButtonState;
    private XROrigin rig;
    public Camera camera;
    private bool boost;
    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XROrigin>();
    }

    // Update is called once per frame
    void Update()
    {
        //InputDevices.GetDevicesWithCharacteristics();
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        InputDevice device2 = InputDevices.GetDeviceAtXRNode(inputSource2);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
        device2.TryGetFeatureValue(CommonUsages.primaryButton, out primaryButtonState);
    }

    private void FixedUpdate()
    {
        //Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        //Vector4 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        Debug.Log("ESTADO: " + primaryButtonState);
        if (primaryButtonState ){
            boost = camera.GetComponent<AppleCounter>().Boost2();
            Debug.Log("¿Puedes usar el boost?: " + boost);
            if (boost){
                this.GetComponent<ContinuousMovement>().Boost();
            }
        }
        else
        {

        }

    }
}
