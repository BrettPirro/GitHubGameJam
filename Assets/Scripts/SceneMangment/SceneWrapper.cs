using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GitHub.SceneManage 
{
    public class SceneWrapper : MonoBehaviour
    {
        public void loadNextLvl(float time) 
        {
            FindObjectOfType<Scene_Manager>().LoadTheeNextLevel(time);
        }

        public void loadGameOver(float time)
        {
            FindObjectOfType<Scene_Manager>().LoadTheeGameOver(time);
        }

        public void loadMenu(float time)
        {
            FindObjectOfType<Scene_Manager>().LoadTheeMainMenu(time);
        }

    }
}
