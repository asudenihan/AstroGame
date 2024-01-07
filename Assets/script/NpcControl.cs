using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform'u
    public Transform Astronaut; // Astronaut karakterin Transform'u
    public float followDistance; // NPC'nin takip etme mesafesi
    NavMeshAgent navMeshAgent;
    private Animator animator;
    public Animator Animator { get => animator; set => animator = value; }
    //[SerializeField] private Animator _animator;

    public bool aim = false;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent <Animator>();
        SetRandomDestination(); // Baþlangýçta rastgele bir hedef belirle
    }

    public GameObject targ;
    public float turnRate;



    void Update()
    {
        //NPC takip offsetine geldikten sonra karaktere dogru donmesi icin kod daha sonra ates ederken aim olarak kullanılacak



               Vector3 targetDelta = target.transform.position - transform.position;
               float angleToTarget = Vector3.Angle(transform.forward, targetDelta);
               Vector3 turnAxis = Vector3.Cross(transform.forward, targetDelta);

               transform.RotateAround(transform.position, turnAxis, Time.deltaTime * turnRate * angleToTarget);


        // NPC hareket etmiyorsa ve Astronaut karakteri yakýnsa takip et, deðilse rastgele hareket et
        if (!navMeshAgent.pathPending && navMeshAgent.remainingDistance < 0.5f)
        {
            if (Vector3.Distance(transform.position, Astronaut.position) < followDistance)
            {
                SetFollowDestination();

            }
            else
            {
                SetRandomDestination();

            }
        }

        // NPC'nin hedefine ulaþtýðýný kontrol et
        if (navMeshAgent.remainingDistance > navMeshAgent.stoppingDistance)
        {
            aim = false;
            SetAnimation("Walk"); // Walk animasyonunu oynat

        }
        else
        {
            aim = true;
            SetAnimation("Idle"); // Idle animasyonunu oynat

        }

        // NPC'nin takip etmesi gereken karakteri belirle
        if (target != null)
        {
            navMeshAgent.SetDestination(target.position);
        }

    }

    void SetRandomDestination()
    {
        // Rastgele bir nokta belirle
        Vector3 randomDestination = Random.insideUnitSphere * 10f;
        randomDestination += transform.position;

        // Belirlenen noktaya hareket et
        navMeshAgent.SetDestination(randomDestination);
    }

    void SetFollowDestination()
    {
        // Astronaut karakterini takip etmek için hedef belirle
        navMeshAgent.SetDestination(Astronaut.position);
    }

    void SetAnimation(string MiniSkeletonAnim)
    {
        // Belirtilen animasyonu baþlat
        Animator.Play(MiniSkeletonAnim);
    }
}
