using UnityEngine;

public class CloudMove : MonoBehaviour
{
    public float speed = 2.0f;
    public float distance = 15.0f;

    private Vector3 startPos; //https://unitybeginner.tistory.com/157 참고 블로그
    private float pingpong; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform.position;   
    }

    // Update is called once per frame
    void Update()
    {
        pingpong = Mathf.PingPong(Time.time * speed, distance);
        transform.position = startPos+ new Vector3(pingpong, 0.0f,0.0f);
    }

   

}
