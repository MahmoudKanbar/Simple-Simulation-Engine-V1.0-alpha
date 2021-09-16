#version 330 core

layout (location = 0) in vec3 in_position;
layout (location = 1) in vec3 in_color;
layout (location = 2) in vec3 in_normal;
layout (location = 3) in vec3 in_tangent;
layout (location = 4) in vec3 in_bitangent;
layout (location = 5) in vec2 in_UV;


out vec3 vsOutPoistion;
out vec3 vsOutColor;
out vec3 vsOutNormal;
out vec2 UV;

uniform mat4 model;
uniform mat4 view;
uniform mat4 projection;

uniform mat3 normalMatrix;
out mat3 TBN;

uniform bool hasHeightMap;

void main()
{
    // the position in world space (for specular lightening)
    vsOutPoistion = vec3(model * vec4(in_position, 1.0f));
    // fragment color in case of every vertix has it's own color
    vsOutColor = in_color;

    // normals calculations
    if(hasHeightMap)
    {
        vec3 T = normalize(vec3(model * vec4(in_tangent, 1)));
        vec3 B = normalize(vec3(model * vec4(in_bitangent, 1)));
        vec3 N = normalize(vec3(model * vec4(in_normal, 1)));
        TBN = mat3(T, B, N);
    }
    else
    {
        vsOutNormal = normalMatrix * in_normal;
        normalize(vsOutNormal);
    }

    // textures coordinates
    UV = in_UV;

    // the gl position
    gl_Position = projection * view * model * vec4(in_position, 1.0);
}