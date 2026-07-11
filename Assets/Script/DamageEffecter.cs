using UnityEngine;

public class DamageEffecter : MonoBehaviour
{
    public float speed = 3.7f;
    public float distance = 30.0f;

    private Vector3 startPos; //https://unitybeginner.tistory.com/157 참고 블로그
    private float pingpong; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        pingpong = Mathf.PingPong(Time.time * speed, distance * 2) - distance/2;
        transform.position = startPos + new Vector3(pingpong, 0.0f, 0.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.CompareTag("Player"))
        {
            other.transform.root.gameObject.BroadcastMessage("ApplyDamage");
            FindFirstObjectByType<Life>().LoseLife();
            
        }
    }

    public void HideStick() 
    {
        gameObject.SetActive(false);
    }

}
