using System;
using UnityEngine;

namespace Sem5.EventBus
{
    public class EventBus
    {
        public event StartRaceHandler OnStartRace;
        public event FinishRaceHandler OnFinishRace;
        public event TrackTimeUpdateHandler OnTrackTimeUpdate;


        public static EventBus Instance { get; private set; }

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.SubsystemRegistration)]
        private static void SetInstance()
        {
            Instance = new EventBus();
            MonoBehaviour.print("Created Eventbus");
        }

        public void InvokeOnStartRace()
        {
            OnStartRace?.Invoke();
        }

        public void InvokeOnFinishRace()
        {
            OnFinishRace?.Invoke();
        }

        public void InvokeOnTrackTimeUpdate(float trackTime)
        {
            OnTrackTimeUpdate?.Invoke(trackTime);
        }
    }
}