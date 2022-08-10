using System;
using System.Collections;
using Game.Scripts.Logic.Mode.Quest;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

namespace Game.Scripts.Logic.Mode.Video
{
    public class VideoShower : QuestAction
    {
        [SerializeField] private bool doOnStart;
        [SerializeField] private VideoPlayer player;


        private void Start()
        {
            DoActionEvent += Play;
            if (doOnStart)
            {
                DoAction();
            }
        }


        private void Play()
        {
           
            StartCoroutine(WaitForVideoEnd());

        }

        

        private IEnumerator WaitForVideoEnd()
        {
            player.Play();
        
            yield return new WaitForSeconds(2);
            while (player.isPlaying)
            {
                yield return null;
            }
            
            SceneManager.LoadScene(0);
        }
        
        
    }
}