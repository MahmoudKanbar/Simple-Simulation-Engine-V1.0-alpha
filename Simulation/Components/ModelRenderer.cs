using OpenTK.Mathematics;
public class ModelRenderer : Component
{
    public SimulationModel simulationModel;
    public ModelRenderer(Transform transform, SimulationObject simulationObject) :
        base(transform, simulationObject)
    { }

    public void Draw(Shader shader)
    {
        shader.SetUniform("model", transform.modelSRT);

        Matrix3 normalMatrix = new Matrix3(transform.modelSRT);
        normalMatrix = Matrix3.Transpose(Matrix3.Invert(normalMatrix));
        shader.SetUniform("normalMatrix", normalMatrix);

        if (simulationModel != null) simulationModel.Draw(shader);
    }
}
