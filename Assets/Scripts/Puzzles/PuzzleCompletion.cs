using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GitHub.SceneManage;
using System;

namespace GitHub.Puzzles 
{
    public class PuzzleCompletion : MonoBehaviour
    {
        [SerializeField] GameObject PuzzleCompleted;
        
     

        void Start()
        {
            if (FindObjectOfType<LockIntoPlace>()) { FindObjectOfType<LockIntoPlace>().PuzzleFinished += PuzzleBoxCompletion; }
            if (FindObjectOfType<Doors>()) { FindObjectOfType<Doors>().DoorOpening += OpeningDoors; }

        }
      

        public void OnPuzzleFinish(float Time)
        {
            
     
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("DeleteOnFinish"))
            {
                Destroy(obj);
            }

            
            FindObjectOfType<Scene_Manager>().LoadTheeNextLevel(Time);
        }

        public void OpeningDoors() 
        {
            FindObjectOfType<Doors>().DoorOpening -= OpeningDoors;
            OnPuzzleFinish(1f);

        }


        public void PuzzleBoxCompletion() 
        {
            FindObjectOfType<LockIntoPlace>().PuzzleFinished -= PuzzleBoxCompletion;
            OnPuzzleFinish(5.5f);
            Instantiate(PuzzleCompleted, transform.position, transform.rotation);
        }

    }
}
