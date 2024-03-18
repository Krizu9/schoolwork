// TODO: vertex shader for gouraud shaded triangle
attribute vec3 position;
uniform mat4 mvpMatrix;
attribute vec3 color;
varying vec3 rendColor;

void main()
{
    gl_Position = mvpMatrix * vec4(position, 1);
    rendColor = color;
}
