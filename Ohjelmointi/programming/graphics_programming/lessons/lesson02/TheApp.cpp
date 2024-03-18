/**
 * ============================================================================
 *  Name        : TheApp.cpp
 *  Part of     : Simple OpenGL graphics engine framework
 *  Description : the concrete application layer
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
	m_uTexture(0),
	flipped(false)
{
	// seed the random number generator
	RandSeed();
}


bool TheApp::OnCreate()
{
	// OnCreate is called by the application when window and graphics initialization is complete
	auto renderer = GetOpenGLRenderer();
	m_uVertexShader = renderer->CreateVertexShaderFromFile("simpleshader.vert");
	m_uFragmentShader = renderer->CreateFragmentShaderFromFile("simpleshader.frag");
	m_uProgram = renderer->CreateProgram(m_uVertexShader, m_uFragmentShader);
	m_uTexture = renderer->CreateTexture("dice.png");
	if (!m_uVertexShader || !m_uFragmentShader || !m_uProgram || !m_uTexture)
	{
		return false;
	}

	// declare the vertices for one quad
	constexpr float hw = 0.8f;
	
	m_Triangle[0] = VERTEX(-hw, -hw, 0.0f,		0.0f, 0.0f);	//vasen ala
	m_Triangle[1] = VERTEX(0.0, hw, 0.0f,		0.5f, 1.0f);	//keski
	m_Triangle[2] = VERTEX(hw, -hw, 0.0f,		1.0f, 0.0f);	//oikea ala

	m_mView = glm::lookAt(
		glm::vec3(0.0f, 0.0f, 5.0f),
		glm::vec3(0.0f, 0.0f, 0.0f),
		glm::vec3(0.0f, 1.0f, 0.0f));
	m_mProjection = glm::perspective(0.5f, GetAspect(), 0.1f, 500.0f);

	return true;
}

void TheApp::Quad()
{
	constexpr float hw = 0.8f;
	if (flipped) {
		m_Triangle[0] = VERTEX(-hw, -hw, 0.0f,		1.0f, 1.0f);	//vasen ala
		m_Triangle[1] = VERTEX(0.0, hw, 0.0f,		0.5f, 0.0f);	//keski
		m_Triangle[2] = VERTEX(hw, -hw, 0.0f,		0.0f, 1.0f);	//oikea ala
	}
	else {

		m_Triangle[0] = VERTEX(-hw, -hw, 0.0f,		0.0f, 0.0f);	//vasen ala
		m_Triangle[1] = VERTEX(0.0, hw, 0.0f,		0.5f, 1.0f);	//keski
		m_Triangle[2] = VERTEX(hw, -hw, 0.0f,		1.0f, 0.0f);	//oikea ala
	}
}



void TheApp::OnDestroy()
{
	// app is about to close, clear all resources

	glDeleteTextures(1, &m_uTexture);
	glDeleteProgram(m_uProgram);
	glDeleteShader(m_uFragmentShader);
	glDeleteShader(m_uVertexShader);

	m_uTexture = 0;
	m_uVertexShader = 0;
	m_uFragmentShader = 0;
	m_uProgram = 0;
}


void TheApp::OnUpdate(float frametime)
{

}


void TheApp::OnDraw(IRenderer& renderer)
{
	// clear color, depth and stencil buffers
	renderer.Clear(0.2f, 0.2f, 0.2f, 1.0f);

	// setup the rendering of our quad
	glUseProgram(m_uProgram);

	// find the locations of position and uv attributes in shader program
	GLint position = glGetAttribLocation(m_uProgram, "position");
	GLint uv = glGetAttribLocation(m_uProgram, "uv");

	// enable the position and uv attributes
	glEnableVertexAttribArray(position);
	glEnableVertexAttribArray(uv);

	// set the data source for position and uv attributes
	glVertexAttribPointer(position, 3, GL_FLOAT, GL_FALSE, VERTEX::GetStride(), m_Triangle);
	glVertexAttribPointer(uv, 2, GL_FLOAT, GL_FALSE, VERTEX::GetStride(), (float*)m_Triangle + 3);

	// set the texture for the quad (slot 0)
	renderer.SetTexture(m_uProgram, m_uTexture, 0, "texture01");

	// set model-view-projection matrix to shader uniform
	glm::mat4 modelViewProjectionMatrix(m_mProjection * m_mView * m_mModel);
	GLint mvp = glGetUniformLocation(m_uProgram, "mvpMatrix");
	glUniformMatrix4fv(mvp, 1, GL_FALSE, &modelViewProjectionMatrix[0][0]);

	// set the alpha blending for the texture
	glEnable(GL_BLEND);

	// draw the quad
	glDrawArrays(GL_TRIANGLES, 0, 3);
}


void TheApp::OnScreenSizeChanged(uint32_t widthPixels, uint32_t heightPixels)
{

}


bool TheApp::OnMouseBegin(int32_t buttonIndex, const glm::vec2& point)
{
	//Debug("OnMouseBegin " + std::to_string(iButtonIndex) + ": " + std::to_string((int)vPoint.x) + "x" + std::to_string((int)vPoint.y) + "\r\n");
	return true;
}


bool TheApp::OnMouseDrag(int32_t buttonIndex, const glm::vec2& point)
{
	//Debug("OnMouseDrag " + std::to_string(iButtonIndex) + ": " + std::to_string((int)vPoint.x) + "x" + std::to_string((int)vPoint.y) + "\r\n");
	return true;
}


bool TheApp::OnMouseEnd(int32_t buttonIndex, const glm::vec2& point)
{
	//Debug("OnMouseEnd " + std::to_string(iButtonIndex) + ": " + std::to_string((int)vPoint.x) + "x" + std::to_string((int)vPoint.y) + "\r\n");
	return true;
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
		flipped = !flipped;
		Quad();
	}

	return false;
}

