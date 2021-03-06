using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Arcadia.UI
{
    public class UI_System : MonoBehaviour
    {
        private Component[] screens = new Component[0];
        [Header("system Events")]
        public UnityEvent onSwitchedScreen = new UnityEvent();

        private UI_Screen previousScreen;
        public UI_Screen PreviousScreen{get{return previousScreen;}}
        private UI_Screen currentScreen; // Private variable
        public UI_Screen CurrentScreen{get{return currentScreen;}} // Property (for get/retrieve CRUD GET)

        // Start is called before the first frame update
        void Start()
        {
            screens = GetComponentsInChildren<UI_Screen>(true);
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void SwitchScreen(UI_Screen aScreen) {
            if(aScreen)
            {
                if(currentScreen) // If we have a current scene existing
                {
                    //currentScreen.close(); //// STUB
                    previousScreen = CurrentScreen;
                }

                currentScreen = aScreen;
                currentScreen.gameObject.SetActive(true);
                //currentScreen.StartScreen();

                if (onSwitchedScreen != null) {
                    onSwitchedScreen.Invoke();
                }
            }
        }

        /*public void GoToPreviousScreen() {
            if (previousScreen)
            {
                yield return null;
                //SwitchScreens(previousScreen);
            }
        }*/

        public void LoadScene(int sceneIndex)
        {
            StartCoroutine(WaitToLoadScene(sceneIndex));
        }
        IEnumerator WaitToLoadScene(int sceneIndex)
        {
            yield return null;
        }
    }
}