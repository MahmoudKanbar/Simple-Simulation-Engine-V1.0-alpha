#version 330 core

// inputs
in vec3 vsOutPoistion;
in vec3 vsOutColor;
in vec3 vsOutNormal;
in vec2 UV;

in mat3 TBN;

// outputs
out vec4 final_color;

// structs
struct Material 
{
    sampler2D diffuse;
    sampler2D specular;
    sampler2D height;

    float shininess;
};

struct PointLight 
{
    vec3 position;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;
};

struct DirectionalLight
{
    vec3 direction;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;
};

struct SpotLight
{
    vec3 position;
    vec3 direction;

    vec3 ambient;
    vec3 diffuse;
    vec3 specular;

    float constant;
    float linear;
    float quadratic;

    float inner;
    float outter;
};



// methods declarations
vec3 getLight(DirectionalLight directionalLight, vec3 normal);
vec3 getLight(PointLight pointLight, vec3 normal);
vec3 getLight(SpotLight spottLight, vec3 normal);

// light uniforms
const int MAX_LIGHT_COUNT = 10;

uniform int directionalLightsCount;
uniform DirectionalLight directionalLightsList[MAX_LIGHT_COUNT];

uniform int pointLightsCount;
uniform PointLight pointLightsList[MAX_LIGHT_COUNT];

uniform int spotLightsCount;
uniform SpotLight spotLightsList[MAX_LIGHT_COUNT];

// material to render && constrains on textures
uniform Material material;
uniform bool hasDiffuseMap;
uniform bool hasSpecularMap;
uniform bool hasHeightMap;

// camera position
uniform vec3 view_position;

void main()
{
    // calculate the normal
    vec3 finalNormal;
    if(hasHeightMap) 
    {
        finalNormal = texture(material.height, UV).xyz;
        finalNormal = finalNormal * 2 - 1.0f;
        finalNormal = normalize(TBN * finalNormal);
    }
    else finalNormal = vsOutNormal;

    vec3 lightsSum = vec3(0,0,0);
    for(int i = 0; i < directionalLightsCount && i < MAX_LIGHT_COUNT; i++) lightsSum += getLight(directionalLightsList[i], finalNormal);
    for(int i = 0; i < pointLightsCount && i < MAX_LIGHT_COUNT; i++) lightsSum += getLight(pointLightsList[i], finalNormal);
    for(int i = 0; i < spotLightsCount && i < MAX_LIGHT_COUNT; i++) lightsSum += getLight(spotLightsList[i], finalNormal);
    final_color = vec4(lightsSum, 1);
}



vec3 getLight(DirectionalLight directionalLight, vec3 normal)
{
    vec3 ambient = vec3(0.0f);
    vec3 diffuse = vec3(0.0f);
    vec3 specular = vec3(0.0f);
    
    vec3 inverseLightDirection = -normalize(directionalLight.direction);

    if(hasDiffuseMap)
    {
        // calculate the ambient
        ambient = directionalLight.ambient * texture(material.diffuse, UV).xyz;
        // calculate the diffuse
        float cosine = max(dot(normal, inverseLightDirection), 0);
        diffuse = directionalLight.diffuse * cosine * texture(material.diffuse, UV).xyz;
    }
    
    // calculate the specular
    if(hasSpecularMap)
    {
        vec3 viewDirection = normalize(view_position - vsOutPoistion);
        vec3 reflectDirection = reflect(inverseLightDirection, normal);
        float specular_factor = pow(max(dot(viewDirection, reflectDirection), 0), material.shininess);
        specular = directionalLight.specular * specular_factor * texture(material.specular, UV).xyz;
    }

    return ambient + diffuse + specular;
}

vec3 getLight(PointLight pointLight, vec3 normal)
{
    vec3 ambient = vec3(0.0f);
    vec3 diffuse = vec3(0.0f);
    vec3 specular = vec3(0.0f);
    
    vec3 inverseLightDirection = -normalize(vsOutPoistion - pointLight.position);

    if(hasDiffuseMap)
    {
        // calculate the ambient 
        ambient = pointLight.ambient * texture(material.diffuse, UV).xyz;
        // calculate the diffuse
        float cosine = max(dot(inverseLightDirection, normal), 0);
        diffuse = cosine * pointLight.diffuse * texture(material.diffuse, UV).xyz;
    }

    if(hasSpecularMap)
    {
        // calculate the specular
        vec3 viewDirection = normalize(view_position - vsOutPoistion);
        vec3 reflectDirection = reflect(inverseLightDirection, normal);
        float specular_factor = pow(max(dot(viewDirection, reflectDirection), 0), material.shininess);
        specular = specular_factor * pointLight.specular * texture(material.specular, UV).xyz;
    }

    // calculate the attenuation
    float light_distance = length(pointLight.position - vsOutPoistion);
    float attenuation = 1 / (pointLight.constant + pointLight.linear * light_distance + pointLight.quadratic * light_distance * light_distance);

    // calculate the final light
    return attenuation * (ambient + diffuse + specular);
}


vec3 getLight(SpotLight spottLight, vec3 normal)
{
    vec3 ambient = vec3(0.0f);
    vec3 diffuse = vec3(0.0f);
    vec3 specular = vec3(0.0f);
    
    vec3 inverseLightDirection = -normalize(vsOutPoistion - spottLight.position);

    if(hasDiffuseMap)
    {
        // calculate the ambient 
        ambient = spottLight.ambient * texture(material.diffuse, UV).xyz;
        // calculate the diffuse
        float cosine = max(dot(inverseLightDirection, normal), 0);
        diffuse = cosine * spottLight.diffuse * texture(material.diffuse, UV).xyz;
    }

    if(hasSpecularMap)
    {
        // calculate the specular
        vec3 viewDirection = normalize(view_position - vsOutPoistion);
        vec3 reflectDirection = reflect(inverseLightDirection, normal);
        float specular_factor = pow(max(dot(viewDirection, reflectDirection), 0), material.shininess);
        specular = specular_factor * spottLight.specular * texture(material.specular, UV).xyz;
    }

    // calculate the attenuation
    float light_distance = length(spottLight.position - vsOutPoistion);
    float attenuation = 1 / (spottLight.constant + spottLight.linear * light_distance + spottLight.quadratic * light_distance * light_distance);

    // calculations for spot light cone
    float theta_cosine = dot(inverseLightDirection, spottLight.direction);
    float intensity =  (theta_cosine - spottLight.outter) / (spottLight.inner -spottLight.outter);

    return intensity * attenuation * (ambient + diffuse + specular);
}