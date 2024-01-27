using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

    public class AnimationUnityEventTrigger : MonoBehaviour
    {
        public UnityEvent<int> Punch;
        public Button.ButtonClickedEvent Event;
        public Button.ButtonClickedEvent Trigger1Event;
        public Button.ButtonClickedEvent OnWalking;
        public Button.ButtonClickedEvent OnRunning;
        public Button.ButtonClickedEvent OnAnimationEnd;
        public Button.ButtonClickedEvent[] EventsIndex;

        public void OnEventsIndex(int onEventsIndex)
        {
            EventsIndex[onEventsIndex].Invoke();
        }
        public void OnPunch(int count)
        {
            Punch?.Invoke(count);
        }
        public void OnEvent()
        {
            Event?.Invoke();
        }
        public void Trigger1()
        {
            Trigger1Event?.Invoke();
        }
        public void Walking()
        {
            Trigger1Event?.Invoke();
        }
        public void Running()
        {
            OnRunning?.Invoke();
        }
        public void OnAnimationEnded()
        {
            OnAnimationEnd?.Invoke();
        }
    }
