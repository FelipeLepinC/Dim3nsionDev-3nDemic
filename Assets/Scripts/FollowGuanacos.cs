using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class FollowGuanacos : MonoBehaviourPunCallbacks
{
    public float speed = 5.0f;

    bool direccionEscapeLista = false;
    Vector3 direccionEscape;
    float deltaTime = 0.0f;
    const float segundosAlejandose = 1.5f;
    public bool derrotado = false;
    Transform destination;
    GameObject player;
    GameObject alerta;
    GuanacosManager puntos;

    public LayerMask guanacosMask;
    PhotonView view;

    void Start()
    {
        // alerta = GameObject.FindWithTag("punto");
        // player = GameObject.FindWithTag("Player");
        // destination = player.transform;
        view = GetComponent<PhotonView>();
        StartCoroutine("FindTargetsWithDelay", .0f);
    }


	IEnumerator FindTargetsWithDelay(float delay)
	{
		while (true)
		{
			yield return new WaitForSeconds(delay);
			FindVisibleTargets();
			//Debug.Log(visibleTargets.Count);
		}
	}


    public void FindVisibleTargets()
	{
        float disMin = 10000000.0f;
        int move_target = 0;
        Transform target;
        Vector3 dirToTarget;

		Collider[] targetsInViewRadius = Physics.OverlapSphere(transform.position, 100.0f, guanacosMask);

		for (int i = 0; i < targetsInViewRadius.Length; i++)
		{
			target = targetsInViewRadius[i].transform;
			dirToTarget = (target.position - transform.position).normalized;

            float dstToTarget = Vector3.Distance(transform.position, target.position);

            if(dstToTarget < disMin){
                disMin = dstToTarget;
                move_target = i;
            }
		}
        target = targetsInViewRadius[move_target].transform;
        dirToTarget = (target.position - transform.position).normalized;

        if (!derrotado)
        {
            // alerta.SetActive(true);
            float space = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target.position, space);

            // Vector3 targetDirection = target.position - transform.position;
            Vector3 newposition = Vector3.RotateTowards(transform.forward, dirToTarget, space, 0);
            transform.rotation = Quaternion.LookRotation(newposition);
        }
        else
        {
            // alerta.SetActive(false);
            deltaTime = deltaTime + Time.deltaTime;
            if (deltaTime > segundosAlejandose) 
            {
                if (view.IsMine) {
                    //puntos = GameObject.FindWithTag("GameManager").GetComponent<GuanacosManager>();
                    //puntos.SumarPuntos(1);
                    PhotonNetwork.Destroy(gameObject);
                    }
            }
            else
            {
                float space = speed * Time.deltaTime;
                if (!direccionEscapeLista)
                {
                    direccionEscape = new Vector3(transform.forward.x * -1, 0, transform.forward.z * -1);
                    transform.rotation = Quaternion.LookRotation(direccionEscape);
                    direccionEscapeLista = true;
                }
                else
                {
                    // alejandose
                    transform.position = Vector3.MoveTowards(transform.position, transform.position + direccionEscape, space);
                }
            }
        }
	}

    // public void moveTo(){
    //     float space = speed * Time.deltaTime;
    //     transform.position = Vector3.MoveTowards(transform.position, destination.position, space);

    //     Vector3 targetDirection = destination.position - transform.position;
    //     Vector3 newposition = Vector3.RotateTowards(transform.forward, targetDirection, space, 0);
    //     transform.rotation = Quaternion.LookRotation(newposition);
    // }

    // void Update()
    // {
    //     if (!derrotado)
    //     {
    //         alerta.SetActive(true);
    //         float space = speed * Time.deltaTime;
    //         transform.position = Vector3.MoveTowards(transform.position, destination.position, space);

    //         Vector3 targetDirection = destination.position - transform.position;
    //         Vector3 newposition = Vector3.RotateTowards(transform.forward, targetDirection, space, 0);
    //         transform.rotation = Quaternion.LookRotation(newposition);
    //     }
    //     else
    //     {
    //         alerta.SetActive(false);
    //         deltaTime = deltaTime + Time.deltaTime;
    //         if (deltaTime > segundosAlejandose) Destroy(gameObject);
    //         else
    //         {
    //             float space = speed * Time.deltaTime;
    //             if (!direccionEscapeLista)
    //             {
    //                 direccionEscape = new Vector3(transform.forward.x * -1, 0, transform.forward.z * -1);
    //                 transform.rotation = Quaternion.LookRotation(direccionEscape);
    //                 direccionEscapeLista = true;
    //             }
    //             else
    //             {
    //                 // alejandose
    //                 transform.position = Vector3.MoveTowards(transform.position, transform.position + direccionEscape, space);
    //             }
    //         }
    //     }
    // }
}
