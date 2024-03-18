/**
 * ============================================================================
 *  Name        : TheApp.cpp
 *  Part of     : Simple OpenGL graphics engine framework
 *  Description : LAB2
 *  Version     : 1.00
 *	Author		: Jani Immonen, <realdashdev@gmail.com>
 * ============================================================================
**/

#include "TheApp.h"


// constructor, init members
TheApp::TheApp() :
	m_uVertexShader(0),
	m_uFragmentShader(0),
	m_uProgram(0),
	m_Angle(0.0f),
	m_Rotate(0.0f)
{
	// seed the random number generator
	RandSeed();
}


bool TheApp::OnCreate()
{
	// OnCreate is called by the application when window and graphics initialization is complete
	auto renderer = GetOpenGLRenderer();
	m_uVertexShader = renderer->CreateVertexShaderFromFile("triangleshader.vert");
	m_uFragmentShader = renderer->CreateFragmentShaderFromFile("triangleshader.frag");
	m_uProgram = renderer->CreateProgram(m_uVertexShader, m_uFragmentShader);
	if (!m_uVertexShader || !m_uFragmentShader || !m_uProgram)
	{
		return false;
	}

	rotate = false;

	// TODO: make a gouraud shaded triangle
	float hw = 0.55f;

	m_Triangle[0] = VERTEX(hw, -hw, 0.0f, 1.0f, 0.0f, 0.0f);	//oikea ala
	m_Triangle[1] = VERTEX(-hw, -hw, 0.0f, 0.0f, 1.0f, 0.0f);	//vasen ala
	m_Triangle[2] = VERTEX(0.0f, hw, 0.0f, 0.0f, 0.0f, 1.0f);	//keskimmäinen

	return true;
}


void TheApp::OnDestroy()
{
	// app is about to close, clear all resources
	glDeleteProgram(m_uProgram);
	glDeleteShader(m_uFragmentShader);
	glDeleteShader(m_uVertexShader);

	m_uVertexShader = 0;
	m_uFragmentShader = 0;
	m_uProgram = 0;
}


void TheApp::OnUpdate(float frametime)
{
	if (rotate)
	{
		m_Angle += 50.0f * frametime;
		if (m_Angle >= 360.0f)
			m_Angle -= 360.0f;
	}

	m_Model = glm::rotate(glm::mat4(1.0f), glm::radians(m_Angle), glm::vec3(0.0f, 0.0f, 1.0f));
}


void TheApp::OnDraw(IRenderer& renderer)
{
	// clear color, depth and stencil buffers
	renderer.Clear(0.2f, 0.2f, 0.2f, 1.0f);
	// setup the rendering program
	glUseProgram(m_uProgram);

	GLint position = glGetAttribLocation(m_uProgram, "position");
	glEnableVertexAttribArray(position);
	glVertexAttribPointer(position, 3, GL_FLOAT, GL_FALSE, VERTEX::GetStride(), m_Triangle);

	GLint color = glGetAttribLocation(m_uProgram, "color");
	glEnableVertexAttribArray(color);
	glVertexAttribPointer(color, 3, GL_FLOAT, GL_FALSE, VERTEX::GetStride(), (float*)m_Triangle + 3);

	glm::mat4 mvp(m_Projection * m_View * m_Model);

	OpenGLRenderer::SetUniformMatrix4(m_uProgram, "mvpMatrix", mvp);

	glDrawArrays(GL_TRIANGLES, 0, 3);

}


void TheApp::OnScreenSizeChanged(uint32_t widthPixels, uint32_t heightPixels)
{
}


bool TheApp::OnKeyDown(uint32_t keyCode)
{
	if (keyCode == KEY_ESC)
	{
		Close();
		return true;
	}

	if (keyCode == KEY_SPACE)
	{
		rotate = !rotate;
	}

	return false;
}

