using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The class of MusicMessage, which are sent by the MusicManager
public class MusicMessage
{
    // Allow new MusicMessages to be created with an Obj, Msg, and Dup
    public MusicMessage(GameObject obj, string msg, bool dup)
    {
        Obj = obj;
        Msg = msg;
        Dup = dup;
    }

    // What object should the message be sent to?
    public GameObject Obj { get; }
    // What message should be sent to the object?
    public string Msg { get; }
    // Can this message be duplicated?
    public bool Dup { get; }

    // Send the message
    public void Send()
    {
        Obj.SendMessage(Msg);
    }
}

// The class of the MusicManager itself
public class MusicManager : MonoBehaviour
{
    // How long until the next beat
    private float _tillBeat = 0f;
    // How long should there be between beats
    [SerializeField] private float _betweenBeat = 0.5f;
    // All the messages to send on the beat
    public List<MusicMessage> _onBeat = new List<MusicMessage>();

    void Update()
    {
        // Countdown till the beat happens
        _tillBeat -= Time.deltaTime;

        // Once the beat happens
        if (_tillBeat <= 0f)
        {
            // Debug Log the beat
            Debug.Log("Beat");

            // Send all the messages in the queue
            foreach (MusicMessage _musicMessage in _onBeat)
            {
                _musicMessage.Send();
                Debug.Log("LoopMessage");
            }

            // Empty the list
            _onBeat.Clear();

            // Reset the beat
            _tillBeat = _betweenBeat + _tillBeat;
        }
    }

    // Add a message to the queue, to happen when the beat happens
    public void AddToQueue(MusicMessage _toAdd)
    {
        Debug.Log("Adding To Queue");
        // Whether there is no duplicate found
        var noDup = true;

        // If the message doesn't allow duplicates then check for duplicates
        if (!_toAdd.Dup)
        {
            foreach (MusicMessage _musicMessage in _onBeat)
            {
                if (_toAdd == _musicMessage)
                {
                    noDup = false;
                    break;
                }
            }
        }
        
        // If no duplicate has been found then add it to queue.
        if (noDup)
        {
            _onBeat.Add(_toAdd);
        }
    }

    // Send the message of within frame tolerance
    public bool NearBeat(int _frames, MusicMessage _msg)
    {
        // Figure out the tolerance in seconds based on the tolerance in frames and the length of a frame in seconds
        var _timeTolerance = _frames * Time.deltaTime;

        if (_tillBeat <= _timeTolerance || _tillBeat >= _betweenBeat - _timeTolerance)
        {
            _msg.Send();
            return true;
        }
        else
        {
            return false;
        }
    }

    // Either add the message to the queue or play it right away if its near enough to the beat
    public void QueueOrNearBeat(int _frames, MusicMessage _msg)
    {
        if (!NearBeat(_frames, _msg))
        {
            AddToQueue(_msg);
        }
    }
}