using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;
using System;
using System.IO;
using System.Text;

public class Shader
{
    public readonly int ID;
    public Shader(string vertexPath, string fragmentPath)
    {
        string vertexShaderSource;
        {
            StreamReader reader = new(vertexPath, Encoding.UTF8);
            vertexShaderSource = reader.ReadToEnd();
            reader.Close();
        }

        string fragmentShaderSource;
        {
            StreamReader reader = new(fragmentPath, Encoding.UTF8);
            fragmentShaderSource = reader.ReadToEnd();
            reader.Close();
        }

        int vertexShaderID, fragmentShaderID;
        // compiling and checking vertex shader
        vertexShaderID = GL.CreateShader(ShaderType.VertexShader);
        GL.ShaderSource(vertexShaderID, vertexShaderSource);
        GL.CompileShader(vertexShaderID);
        string vertexLog = GL.GetShaderInfoLog(vertexShaderID);
        if (vertexLog != string.Empty) Console.WriteLine("vertex shader at " + vertexPath + "\n" + vertexLog);

        // compiling and checking fragment shader
        fragmentShaderID = GL.CreateShader(ShaderType.FragmentShader);
        GL.ShaderSource(fragmentShaderID, fragmentShaderSource);
        GL.CompileShader(fragmentShaderID);
        string fragmentLog = GL.GetShaderInfoLog(fragmentShaderID);
        if (fragmentLog != string.Empty) Console.WriteLine("fragment shader at " + fragmentPath + "\n" + fragmentLog);

        // creating and linking shader program
        ID = GL.CreateProgram();

        GL.AttachShader(ID, vertexShaderID);
        GL.AttachShader(ID, fragmentShaderID);

        GL.LinkProgram(ID);
        string shaderLog = GL.GetProgramInfoLog(ID);
        if (shaderLog != string.Empty) Console.WriteLine("Error in Linking shader " + ID + "\n" + shaderLog);


        // datatching and deleting vertex and fragment shaders, cuze they are already in the shader program
        GL.DetachShader(ID, vertexShaderID);
        GL.DeleteShader(vertexShaderID);

        GL.DetachShader(ID, fragmentShaderID);
        GL.DeleteShader(fragmentShaderID);
    }

    ~Shader()
    {
        // deleting shader program
        GL.DeleteProgram(ID);
    }

    public void SetUniform(string name, bool value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        if (value) GL.Uniform1(uniformLocation, 1);
        else GL.Uniform1(uniformLocation, 0);
    }

    public void SetUniform(string name, float value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform1(uniformLocation, value);
    }

    public void SetUniform(string name, double value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform1(uniformLocation, value);
    }

    public void SetUniform(string name, float x, float y)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform2(uniformLocation, x, y);
    }

    public void SetUniform(string name, float x, float y, float z)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform3(uniformLocation, x, y, z);
    }

    public void SetUniform(string name, float x, float y, float z, float w)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform4(uniformLocation, x, y, z, w);
    }

    public void SetUniform(string name, int value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform1(uniformLocation, value);
    }

    public void SetUniform(string name, int x, int y)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform2(uniformLocation, x, y);
    }

    public void SetUniform(string name, int x, int y, int z)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform3(uniformLocation, x, y, z);
    }

    public void SetUniform(string name, int x, int y, int z, int w)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform4(uniformLocation, x, y, z, w);
    }

    public void SetUniform(string name, Vector2 value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform2(uniformLocation, value.X, value.Y);
    }

    public void SetUniform(string name, Vector3 value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform3(uniformLocation, value.X, value.Y, value.Z);
    }

    public void SetUniform(string name, Vector4 value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.Uniform4(uniformLocation, value.X, value.Y, value.Z, value.W);
    }

    public void SetUniform(string name, Matrix4 value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.UniformMatrix4(uniformLocation, false, ref value);
    }

    public void SetUniform(string name, Matrix3 value)
    {
        GL.UseProgram(ID);
        int uniformLocation = GL.GetUniformLocation(ID, name);
        GL.UniformMatrix3(uniformLocation, false, ref value);
    }
}