public static class Utilities
{
    public enum HandModelType
    {
        Graphic,
        Physics
    }

    public static HandModel GetHandModel(HandController controller, HandModelType type)
    {
        HandModel[] allHands;

        switch (type)
        {
            case HandModelType.Graphic:
                allHands = controller.GetAllGraphicsHands();
                break;

            case HandModelType.Physics:
                allHands = controller.GetAllPhysicsHands();
                break;

            default:
                allHands = controller.GetAllGraphicsHands();
                break;
        }

        if (allHands.Length == 0)
        {
            return null;
        }

        return allHands[0];
    }
}
