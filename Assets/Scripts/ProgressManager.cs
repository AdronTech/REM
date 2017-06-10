using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ProgressManager : MonoBehaviour {
    [System.Serializable]
    public struct Progress
    {
        public string name;
        [System.NonSerialized]
        public bool flag;
        public UnityEvent myEvent;
    }
    [SerializeField]
    private Progress[] events;
    private Dictionary<string, Progress> dict;

    private void Start()
    {
        dict = new Dictionary<string, Progress>();
        foreach (Progress p in events)
        {
            dict.Add(p.name, p);
        }

    }
    public void Trigger(string name)
    {
        Progress p;
        dict.TryGetValue(name, out p);
        p.myEvent.Invoke();
    }
}
