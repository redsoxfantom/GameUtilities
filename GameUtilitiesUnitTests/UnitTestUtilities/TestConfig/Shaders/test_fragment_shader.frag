#version 330 core

uniform sampler2D tex;
in vec2 vs_uv;
out vec4 color;

#define PI 3.14159

void main()
{
	float t = vs_uv.t;
	float s = vs_uv.s;

	vec4 color1 = vec4(texture(tex,vec2(s,t)));


	color = color1;
}
