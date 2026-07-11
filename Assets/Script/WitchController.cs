using System.Collections;
using UnityEngine;

public class WitchController : MonoBehaviour
{
    Animator animator;
    public Transform ThrowBall;
    public GameObject orbPrefab;
    public float orbSpeed = 8.0f;

    private bool attack; //제너릭맨 참고
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        StartCoroutine(AnimationSession());
        attack = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator AnimationSession() //애니메이션 바꾸기
    {
        while (true)
        {
            if (attack)
            {
                yield return new WaitForSeconds(Random.Range(3.0f, 5.0f));
                animator.SetTrigger("Throw");
            }
            else
            {
                yield return null; 
            }
        }
    }

    void FireOrb()
    {
        if (!attack) return; 

        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector3 direction = (player.transform.position - ThrowBall.position).normalized;
            GameObject orb = Instantiate(orbPrefab, ThrowBall.position, Quaternion.identity);
            Rigidbody rb = orb.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = direction * orbSpeed;
            }
            Destroy(orb, 7.0f);
        }
    }
    public void StopAttack()
    {
        attack = false;
    }

}
