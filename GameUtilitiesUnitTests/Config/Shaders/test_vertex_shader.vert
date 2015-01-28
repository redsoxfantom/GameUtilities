#version 430 core

layout(location = 0) in vec3 vertex;
layout(location = 1) in vec2 uvs;
uniform mat4 mvpMatrix;
out vec2 vs_uv;

void main()
{
	vs_uv = uvs;
	gl_Position = mvpMatrix * vec4(vertex,1.0);
}