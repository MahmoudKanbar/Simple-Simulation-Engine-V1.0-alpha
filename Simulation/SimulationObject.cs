using System.Collections.Generic;

public class SimulationObject
{
    public readonly string name;
    public readonly Transform transform;
    public readonly SimulationManager simulationManager;

    public SimulationObject(string name, SimulationManager simulationManager)
    {
        this.name = name;
        this.simulationManager = simulationManager;

        componentsList = new LinkedList<Component>();
        transform = new Transform();

        simulationManager.simulationObjectsList.AddLast(this);
    }


    private readonly LinkedList<Component> componentsList;
    public T GetComponent<T>() where T : Component
    {
        if (componentsList == null) return null;

        foreach (var component in componentsList)
            if (component is T) return (T)component;

        return null;
    }
    public bool AddComponent<T>() where T : Component
    {
        if (componentsList == null) return false;

        foreach (var component in componentsList)
            if (component is T) return false;

        Component newComponent = null;

        if (typeof(T) == typeof(ModelRenderer)) newComponent = new ModelRenderer(transform, this);
        else if (typeof(T) == typeof(RigidBody)) newComponent = new RigidBody(transform, this);
        else if (typeof(T) == typeof(SphereCollider)) newComponent = new SphereCollider(transform, this);
        else if (typeof(T) == typeof(BoxCollider)) newComponent = new BoxCollider(transform, this);
        else if (typeof(T) == typeof(Camera)) newComponent = new Camera(transform, this);
        else if (typeof(T) == typeof(DirectionalLight)) newComponent = new DirectionalLight(transform, this);
        else if (typeof(T) == typeof(PointLight)) newComponent = new PointLight(transform, this);
        else if (typeof(T) == typeof(SpotLight)) newComponent = new SpotLight(transform, this);

        if (newComponent != null) componentsList.AddLast(newComponent);
        return newComponent != null;
    }

    public void AddComponent(Component newComponent)
    {
        if (newComponent == null) return;
        foreach (var component in componentsList)
            if (component.GetType() == newComponent.GetType()) return;

        componentsList.AddLast(newComponent);
    }

    public void RemoveComponent<T>() where T : Component
    {
        Component componentToDelete = null;

        foreach (var component in componentsList)
            if (component is T)
                componentToDelete = component;

        if (componentToDelete == null) return;
        if (componentToDelete is Camera) simulationManager.camerasList.Remove(componentToDelete as Camera);
        if (componentToDelete is Collider) simulationManager.collidersList.Remove(componentToDelete as Collider);
        if (componentToDelete is Light) simulationManager.lights.Remove(componentToDelete as Light);

        componentsList.Remove(componentToDelete);
    }
}