public abstract class Component
{
    public readonly Transform transform;
    public readonly SimulationObject simulationObject;

    public Component(Transform transform, SimulationObject simulationObject)
    {
        this.transform = transform;
        this.simulationObject = simulationObject;
    }
}