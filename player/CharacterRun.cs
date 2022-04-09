using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRun : CharacterComponent
{
   
    [SerializeField] private float runSpeed = 5f;
    //Timer controls
    private float startTime = 0f;
    private float timer = 0f;
    [SerializeField] private float holdTime = 4.0f;
    private bool held = false;
    [SerializeField] private string[] key = new string[] {"w","a","s","d"};


    protected override void HandleInput()
    {
        
        for (int i = 0; i < 4; i++){
            if (Input.GetKeyDown(key[i]))
            {
                startTime = Time.time;
                timer = startTime;
              
              
            }
         

            if (Input.GetKey(key[i]) && held == false)
            {
                timer += Time.deltaTime;
                if(timer > (startTime + holdTime))
                {
                    held = true;
                    Run();
                }
            }

            
            if (Input.GetKeyUp(key[i]))
            {
                if (stopMoving(i))
                {
                    held = false;
                    stopRun();
                }
                
            }
        }
    }
    private void Run()
    {
        characterMovement.MoveSpeed = runSpeed;
    }
    private void stopRun()
    {
        characterMovement.ResetSpeed();
    }
    private bool stopMoving(int index)
    {
       
        for(int j = 0; j < 4; j++)
        {
           if(index != j && Input.GetKey(key[j]))
           {
                return false;
           }
          
        }
        return true;
    }
}
