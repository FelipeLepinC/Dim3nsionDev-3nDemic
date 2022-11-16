using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Unity.XR.CoreUtils;

public class ContinuousMovement : MonoBehaviour
{
    public float speed = 4;
    public float jumpingForce = 600f;
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
        Quaternion headYaw = Quaternion.Euler(0, rig.Camera.transform.eulerAngles.y, 0);
        Vector4 direction = headYaw * new Vector3(inputAxis.x, 0, inputAxis.y);
        if (primaryButtonState && !saltando) saltando = true;
        else
        {
            Vector3 finalDirection = direction * Time.fixedDeltaTime * speed * 2;
            character.Move(finalDirection);
        }

        //gravity
        bool isGrounded = CheckIfGrounded();
        if (isGrounded)
        {
            fallingSpeed = 0;
        }
        else
        {
            fallingSpeed += gravity * Time.fixedDeltaTime;
            // Hacer un salto que se sienta bonito
            if (saltando)
            {
                jumpingSpeed = (jumpingForce * Time.fixedDeltaTime) + fallingSpeed;
                if (jumpingSpeed < 0) cayendo = true;
                character.Move(Vector3.up * jumpingSpeed * Time.fixedDeltaTime);
            }
        }

        if (!cayendo) character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);
    }

    bool CheckIfGrounded()
    {
        Vector3 rayStart = transform.TransformPoint(character.center);
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);
        return hasHit;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Agua")
        {
            saltando = false;
            cayendo = false;
            fallingSpeed = 0;
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Agua")
        {
            saltando = false;
            cayendo = false;
            fallingSpeed = 0;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Terrain" || collision.gameObject.tag == "Agua")
        {
            saltando = true;
        }
    }
}
