using UnityEngine;
using Leap;

public class PlayerController : MonoBehaviour
{
    public HandController LeapHandController;
    public Utilities.HandModelType HandModelType;

    private HandModel _handModel;

    public void Start()
    {
        if (!LeapHandController)
            throw new System.Exception("Leap Hand Controller has not been assigned!");

        _handModel = Utilities.GetHandModel(LeapHandController, HandModelType);
    }

    public void Update()
    {
        if (!IsHandPresent())
            return;

        UpdateSlowMotion();
        UpdatePosition();
        UpdatePositionSecond();
    }

    private void UpdateSlowMotion()
    {

    }

    private void UpdatePositionSecond()
    {
        var indexPosition = _handModel.fingers[1].GetBoneCenter(3);

        transform.position = new Vector3(indexPosition.x, indexPosition.y);
    }

    private void UpdatePosition()
    {
        var hand = _handModel.GetLeapHand();
        var indexFinger = hand.Fingers.FingerType(Finger.FingerType.TYPE_INDEX)[0];
        var indexTipPosition = indexFinger.TipPosition;
        indexTipPosition *= 2;
        indexTipPosition.z /= 1;

        var unityIndexTipPosition = UnityVectorExtension.ToUnityScaled(indexTipPosition);
        unityIndexTipPosition *= LeapHandController.transform.localScale.x;

        if (LeapHandController.transform.localScale.x != LeapHandController.transform.localScale.y)
        {
            Debug.LogWarning("Leap Hand Controller not scaled uniformly");
        }

        //unityIndexTipPosition = new Vector3(
        //    unityIndexTipPosition.x * LeapHandController.handMovementScale.x,
        //    unityIndexTipPosition.y * LeapHandController.handMovementScale.y,
        //    unityIndexTipPosition.z * LeapHandController.handMovementScale.z);

        unityIndexTipPosition += _handModel.transform.position;

        //Debug.Log("Unity " + unityIndexTipPosition);
        //Debug.Log("API " + indexTipPosition);

        transform.position = new Vector3(unityIndexTipPosition.x, unityIndexTipPosition.y, transform.position.z);
    }

    private bool IsHandPresent()
    {
        if (!_handModel)
            _handModel = Utilities.GetHandModel(LeapHandController, HandModelType);

        if (_handModel == null)
            return false;

        return true;
    }
}
