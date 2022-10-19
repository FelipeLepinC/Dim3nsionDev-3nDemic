using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour
{   
    public float speed = 2;
    public float gravity = -10;
    private float fallingSpeed;
    public LayerMask groundLayer;
    public XRNode inputSource;
    public XRNode inputSource2;
    private Vector2 inputAxis;
    private CharacterController character;
    private bool primaryButtonState;
    private XROrigin rig;
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

    private void FixedUpdate() {
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector4 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        //character.Move(direction * Time.fixedDeltaTime * speed);
        Debug.Log(primaryButtonState);
        if (primaryButtonState){
            character.Move(direction * Time.fixedDeltaTime * speed * 2);
        }
        else{
            character.Move(direction * Time.fixedDeltaTime * speed);
        }

        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded) fallingSpeed = 0;
        else fallingSpeed += gravity * Time.fixedDeltaTime;
        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }
}
