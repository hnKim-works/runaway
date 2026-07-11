using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatus : MonoBehaviour
{
    public GUISkin skin;
    private int snack = 0;

    private Color originalColor;
    private SkinnedMeshRenderer playerSkin;

    private bool countSnack;

    

    void CatchPepero(int amount)
    {   
        snack += amount;

        string currentScene = SceneManager.GetActiveScene().name;

        if (currentScene == "Stage1" && snack >= 10)
        {
            if (GameObject.Find("DoorEffect") != null && GameObject.Find("Door") != null)
            {
                GameObject.Find("DoorEffect").SendMessage("OpenTheDoor");
                GameObject.Find("Door").SendMessage("GoalIn");
                if(countSnack)
                    {
                        StartCoroutine(Wait(1.2f));
                    }
            }

            GameObject witch = GameObject.Find("Witch1");
            GameObject sangeun1 = GameObject.Find("Sangeun1");
            if (witch != null)
            {
                witch.SendMessage("StopAttack");
                witch.SetActive(false);   
                sangeun1.SetActive(false);  
            }
        }

        if (currentScene == "Stage2" && snack >= 15)
        {
            if (GameObject.Find("DamageEffecter") != null)
            {
                GameObject.Find("DamageEffecter").SendMessage("HideStick");
            }

            GameObject witch = GameObject.Find("Witch2");
            if (witch != null)
            {
                witch.SendMessage("StopAttack");
                witch.GetComponentInChildren<CapsuleCollider>().enabled = true; 
                GameObject.FindWithTag("MainCamera").SendMessage("ShootWitch");
            }

        }
    }


    private void OnGUI()
    {
        if (countSnack)
        { 
        GUI.skin = skin;
        Rect rect = new Rect(Screen.width / 2, 0, Screen.width, Screen.height);
        GUI.Label(rect, "SNACKS: " + snack.ToString(), "Snacks");
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerSkin = GetComponentInChildren<SkinnedMeshRenderer>();
        originalColor = playerSkin.material.color;
        countSnack= true;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ApplyDamage()
    {
        StartCoroutine(ChangeColor(0.3f));
    }

    IEnumerator ChangeColor(float time)
    {
        playerSkin.material.color = Color.red * Mathf.Abs(Mathf.Sin(40.0f * Time.time));
        yield return new WaitForSeconds(time);
        playerSkin.material.color = originalColor;  
    }

    IEnumerator Wait(float time)
    {
        yield return new WaitForSeconds(time);
        countSnack = false;
    }
    
}
