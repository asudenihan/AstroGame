using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bosscontrol : MonoBehaviour
{

    public Transform Astronaut;
    public Transform target;
    public bool aim = false;
    public GameObject targ;
    public float turnRate;
    public float followdistance;
    
    public Animator Animator { get => animator; set => animator = value; }
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {


        if (Vector3.Distance(transform.position, Astronaut.position) < followdistance)
        {
            aim = true;

        }
        else
        {
            aim = false;

        }



        if (aim == true)
        {
            Vector3 targetDelta = target.transform.position - transform.position;
            float angleToTarget = Vector3.Angle(transform.forward, targetDelta);
            Vector3 turnAxis = Vector3.Cross(transform.forward, targetDelta);

            transform.RotateAround(transform.position, turnAxis, Time.deltaTime * turnRate * angleToTarget);

            SetAnimation("Combat_Stance");
        }

        else
        {
            SetAnimation("idle");
        }


    }

    void SetAnimation(string Animator_LPSkeleton)
    {
        Animator.Play(Animator_LPSkeleton);
    }

}
