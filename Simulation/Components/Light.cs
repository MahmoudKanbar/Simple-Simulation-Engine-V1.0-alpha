using OpenTK.Mathematics;
using System;

public abstract class Light : Component
{
    public Vector3 ambient;
    public Vector3 diffuse;
    public Vector3 specular;

    public Light(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        ambient = Vector3.One * 0.1f;
        diffuse = Vector3.One * 0.8f;
        specular = Vector3.One * 0.5f;

        simulationObject.simulationManager.lights.AddLast(this);
    }

    public virtual void SetInShader(Shader shader, string lightName)
    {
        shader.SetUniform($"{lightName}.ambient", ambient);
        shader.SetUniform($"{lightName}.diffuse", diffuse);
        shader.SetUniform($"{lightName}.specular", specular);
    }

}

public class DirectionalLight : Light
{
    public Vector3 Direction { get => transform.forward; }

    public DirectionalLight(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        simulationObject.simulationManager.directionalLightsCount++;
    }

    public override void SetInShader(Shader shader, string lightName)
    {
        shader.SetUniform($"{lightName}.direction", Direction);
        base.SetInShader(shader, lightName);
    }
}

public class PointLight : Light
{
    public float attenuation;

    public Vector3 Position => transform.position;

    public Vector3 MixedAtternuation { get; set; }
    public float Attenuation
    {
        get
        {
            return attenuation;
        }
        set
        {
            attenuation = value;
            MixedAtternuation = new Vector3(3 * attenuation, 6 * attenuation, attenuation);
        }
    }

    public PointLight(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        Attenuation = 0.0075f;
        simulationObject.simulationManager.pointLightsCount++;
    }

    public override void SetInShader(Shader shader, string lightName)
    {
        shader.SetUniform($"{lightName}.position", Position);
        shader.SetUniform($"{lightName}.constant", MixedAtternuation.X);
        shader.SetUniform($"{lightName}.linear", MixedAtternuation.Y);
        shader.SetUniform($"{lightName}.quadratic", MixedAtternuation.Z);

        base.SetInShader(shader, lightName);
    }
}

public class SpotLight : PointLight
{
    public Vector3 Direction => transform.forward;
    public float Inner { get; set; }

    public SpotLight(Transform transform, SimulationObject simulationObject) : base(transform, simulationObject)
    {
        simulationObject.simulationManager.spotLightsCount++;
        Inner = 5f;
    }

    public override void SetInShader(Shader shader, string lightName)
    {
        shader.SetUniform($"{lightName}.direction", Direction);
        shader.SetUniform($"{lightName}.inner", MathHelper.Cos(MathHelper.DegreesToRadians((double)Inner)));
        shader.SetUniform($"{lightName}.outter", MathHelper.Cos(MathHelper.DegreesToRadians(10)));

        base.SetInShader(shader, lightName);
    }
}


