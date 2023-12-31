using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NpcControl : MonoBehaviour
{
    public Transform target; // Takip edilecek karakterin Transform'u
    public Transform Astronaut; // Astronaut karakterin Transform'u
    public float followDistance = 5f; // NPC'nin takip etme mesafesi
    NavMeshAgent navMeshAgent;
    private Animator animator;
    public Animator Animator { get => animator; set => animator = value; }
    //[SerializeField] private Animator _animator;


    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        Animator = GetComponent <Animator>();
        SetRandomDestination(); // Baþlangýçta rastgele bir hedef belirle
    }

    void Update()
    {
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
            SetAnimation("Walk"); // Walk animasyonunu oynat
         
        }
        else
        {
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
