using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapTrigger : MonoBehaviour
{
    [SerializeField] private GameObject trapWall;
    [SerializeField] private GameObject CheckEnemy;
    // Start is called before the first frame update
    void Start()
    {
       // setAct(false);
    }

    // Update is called once per frame
    void Update()
    {
        checkEnemy();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){
            Debug.Log("Player collides with trap wall trigger");
            setAct(true);
        }
    }
    public void setAct(bool set)
    {
        Debug.Log("Wall active");
        trapWall.SetActive(set);
    }
    public void checkEnemy()
    {
        if (CheckEnemy.transform.childCount == 0)
        {
            setAct(false);
            Destroy(this.gameObject);
        }
    }
}
