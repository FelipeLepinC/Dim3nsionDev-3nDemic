using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FPCSwimmer
{
    [RequireComponent(typeof(Rigidbody))]
    public class Flotar : MonoBehaviour
    {
        public float underWaterDrag = 3f;
        public float underWaterAngularDrag = 1f;
        public float airDrag = 0f;
        public float airAngularDrag = 0.05f;
        public float floatingPower = 15f;
        public float waterHeight = 0f;

        public float playerWidth = 2f;
        private float currentWaterHeight = 0f;
        private float waterPlayerHeightDifference;

        Rigidbody m_rigidbody;

        bool underwater;

        void Start()
        {
            m_rigidbody = GetComponent<Rigidbody>();
            UpdatePlayerInWaterStatus();
        }

        void FixedUpdate()
        {
            // Si es que esta debajo del agua
            if (waterPlayerHeightDifference < 0)
            {
                // Debug.Log("Altura" + currentWaterHeight);
                // Debug.Log("diferencia : "+ waterPlayerHeightDifference);
                Vector3 fuerza = Vector3.up * floatingPower * Mathf.Abs(waterPlayerHeightDifference);
                // Debug.Log("Fuerza : " + fuerza.y);
                m_rigidbody.AddForceAtPosition(fuerza, transform.position, ForceMode.Force);
                underwater = true;
                SwitchState(true);
            }
            else
            {
                Vector3 fuerza = Vector3.down * 0;
                // Debug.Log("Fuerza : " + fuerza.y);
                m_rigidbody.AddForceAtPosition(fuerza, transform.position, ForceMode.Force);
                underwater = false;
                SwitchState(false);
            }
        }

        private void LateUpdate()
        {
            UpdatePlayerInWaterStatus();
            //Debug.Log(underwater);
        }


        private void UpdatePlayerInWaterStatus()
        {
            // Get updated water height
            currentWaterHeight = UnderWaterDetector.Master.GetCurrentWaterHeight(this.transform, playerWidth);

            // Calculate water - player height difference
            waterPlayerHeightDifference = transform.position.y - currentWaterHeight;

            // Check if we are over or under water
            underwater = waterPlayerHeightDifference < UnderWaterDetector.Master.maxHeightAboveWater;
        }

        void SwitchState(bool isUnderwater)
        {
            if (isUnderwater)
            {
                m_rigidbody.drag = underWaterDrag;
                m_rigidbody.angularDrag = underWaterAngularDrag;
            }
            else
            {
                m_rigidbody.drag = airDrag;
                m_rigidbody.angularDrag = airAngularDrag;
            }
        }
    }

}
