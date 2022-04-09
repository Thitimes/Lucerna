using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BossDoor : MonoBehaviour

{

    [SerializeField] private int SceneIndex;
    [SerializeField] private Character character;
    private bool bdead;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bdead = character.bossDead;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.CompareTag("Player") && bdead == true)
        {
            SceneManager.LoadScene(sceneBuildIndex: SceneIndex);   
        }
    }
}

