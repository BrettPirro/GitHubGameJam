using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.SceneManage 
{
    public class PersistantOBJ : MonoBehaviour
    {
        [SerializeField] GameObject PersOBJ;
        static bool Spawned = false;

        private void Awake()
        {
            if (!Spawned)
            {
                GameObject SpawnedPerOBJ = Instantiate(PersOBJ, transform.position, transform.rotation) as GameObject;
                DontDestroyOnLoad(SpawnedPerOBJ);
                Spawned = true;
            }


        }



    }
}
