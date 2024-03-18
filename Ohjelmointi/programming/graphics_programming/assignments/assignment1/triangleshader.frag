// TODO: fragment shader for gouraud shaded triangle
varying vec3 rendColor;

void main(void)
{
    gl_FragColor = vec4(rendColor, 1);
} 
