using UnityEngine;
using System.Collections;
using Leap;

public class PinchRecognizer : MonoBehaviour
{

    private HandModel _handModel;
    private HandController _controller;

    public void Start()
    {
        _controller = GetComponent<HandController>();
        if (_controller == null)
        {
            throw new System.Exception("Cannot find Controller!");
        }

        GetHand();
    }

    public void Update()
    {
        if (_handModel == null)
        {
            if (!GetHand()) { return; }
        }
        var indexPosition = _handModel.fingers[1].GetBoneCenter(3);
        var thumbPosition = _handModel.fingers[0].GetBoneCenter(3);

        if (_handModel.GetLeapHand() != null)
            Debug.Log(_handModel.GetLeapHand().Fingers.FingerType(Finger.FingerType.TYPE_THUMB)[0].TipPosition);
    }

    private bool GetHand()
    {
        var allHands = _controller.GetAllGraphicsHands();
        if (allHands.Length == 0)
        {
            return false;
        }

        _handModel = allHands[0];
        return true;
    }

}
