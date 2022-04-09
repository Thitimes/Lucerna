using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    [SerializeField] private GameObject keyMissingText;
    [SerializeField]  private int SceneIndex;

    private Collider2D col;
    private SpriteRenderer sr;

    private float displayTextTimer=0;

    [HideInInspector] public enum DoorType {sendsPlayerToNextLevel, isStupidNormalDoor };
    public bool isLocked = true;
    public DoorType thisDoor;

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (keyMissingText.activeInHierarchy)
        {
            displayTextTimer += Time.deltaTime;

            if (displayTextTimer >= 1f)
            {
                keyMissingText.SetActive(false) ;
            }
        }


        if (col.isTrigger)
        {
            sr.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!isLocked)
            {
                if (thisDoor == DoorType.isStupidNormalDoor)
                {
                    GetComponent<Collider2D>().isTrigger = true;
                }
                else
                {
                    SceneManager.LoadScene(sceneBuildIndex: SceneIndex);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("KeyHeld", 0) == 1)
                {
                    if (thisDoor == DoorType.isStupidNormalDoor)
                    {
                        GetComponent<Collider2D>().isTrigger = true;
                    }
                    else
                    {
                        SceneManager.LoadScene(sceneBuildIndex: SceneIndex);
                    }

                    PlayerPrefs.SetInt("KeyHeld", 0);
                }
                else
                {
                    displayTextTimer = 0;
                    keyMissingText.SetActive(true);
                }
            }
        }
    }
    /*
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerPrefs.GetInt("KeyHeld", 0) == 1)
            {

                SceneManager.LoadScene(sceneBuildIndex: SceneIndex);
            }
            else
            {
                displayTextTimer = 0;
                keyMissingText.SetActive(true);
            }
        }
    }
    */
}
