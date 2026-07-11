using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gun : MonoBehaviour
{

    public GUISkin skin;
    public GameObject bulletPrefab;
    public float initialVelocity = 40.0f;
    private Camera mainCamera;

    private bool canShoot = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mainCamera = GetComponent<Camera>();    
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1") && canShoot) 
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);


            Vector3 screenPoint = Input.mousePosition;
            screenPoint.z = 10.0f;
            Vector3 worldPoint = mainCamera.ScreenToWorldPoint(screenPoint);
         
            Vector3 direction = (worldPoint - transform.position).normalized;   

            bullet.GetComponent<Rigidbody>().linearVelocity = initialVelocity * direction;

        }
    }

    public void ShootWitch()
    {
        canShoot = true;
    }

    private void OnGUI()
    {
        if(canShoot)
        {
            GUI.skin = skin;
            int sw = Screen.width;
            int sh = Screen.height;

            GUI.Label(new Rect(0, sh / 4, sw, sh / 4), "Shoot the Witch", "Shoot");
        }
    }

    public void HideMessage()
    {
        canShoot=false;
        GameObject cage = GameObject.Find("cage");
        if (cage != null)
        {
            cage.SetActive(false);
            StartCoroutine(GameClear(1.5f));
        }

    }

    IEnumerator GameClear(float timer)
    {
        yield return new WaitForSeconds(timer);
        SceneManager.LoadScene("GameClear");
    }
}

