uniform sampler2D texture01;

varying vec2 outUv;
varying vec3 eyespaceNormal;

void main(void)
{
    vec3 normal = normalize(eyespaceNormal);
    float diffuseFactor = dot(normal, vec3(1.0, 0.0, 0.0));
    vec4 diffuseColor = texture2D(texture01, outUv) * diffuseFactor;

    gl_FragColor = diffuseColor;
}

