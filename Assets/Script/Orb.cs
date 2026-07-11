using UnityEngine;

public class Orb : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)  //Orb°ú Player°¡ ºÎµúÇûÀ» ¶§
    {
        if (other.transform.root.CompareTag("Player"))
        {
            other.transform.root.gameObject.BroadcastMessage("ApplyDamage");
            GameObject.FindWithTag("Life").GetComponent<Life>().LoseLife();
            Destroy(gameObject);
        }
        
    }
}
