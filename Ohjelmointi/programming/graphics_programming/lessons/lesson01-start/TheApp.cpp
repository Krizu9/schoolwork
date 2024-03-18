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
TheApp::TheApp()
{
}


bool TheApp::OnCreate()
{
	// OnCreate is called by the application when window and graphics initialization is complete
	auto renderer = GetOpenGLRenderer();
	m_uVertexShader = renderer->CreateVertexShaderFromFile("simpleshader.vert");
	m_uFragmentShader = renderer->CreateFragmentShaderFromFile("simpleshader.frag");
	m_uProgram = renderer->CreateProgram(m_uVertexShader, m_uFragmentShader);
	m_uTexture = renderer->CreateTexture("texture.jpg");


	if (!m_uVertexShader || !m_uFragmentShader || !m_uProgram || !m_uTexture)
	{
		return false;
	}

	//task 1 : Make your image appear as mirror image
	//task 2 : Make yoir image appear upside down
	//task 3 : Map upper right quarter of the texture to the quad

	constexpr float hw = 0.55f;
	m_Quad[0] = VERTEX(-hw, hw, 0.0f, 0.0f ,0.0f); //last two variables for textures
	m_Quad[1] = VERTEX(hw, hw, 0.0f, 1.0f, 0.0f);
	m_Quad[2] = VERTEX(hw, -hw, 0.0f, 1.0f, 1.0f);

	m_Quad[3] = VERTEX(-hw, hw, 0.0f, 0.0f, 0.0f);
	m_Quad[4] = VERTEX(hw, -hw, 0.0f, 1.0f, 1.0f);
	m_Quad[5] = VERTEX(-hw, -hw, 0.0f, 0.0f, 1.0f);

	return true;
}


void TheApp::OnDestroy()
{
	// app is about to close, clear all resources
	glDeleteProgram(m_uProgram);
	glDeleteShader(m_uFragmentShader);
	glDeleteShader(m_uVertexShader);
	glDeleteTextures(1, &m_uTexture);
}


void TheApp::OnUpdate(float frametime)
{
	// the main loop
	Debug(std::to_string(1.0f / frametime));
	Debug("\n");
	
}


void TheApp::OnDraw(IRenderer& renderer)
{
	// clear color, depth and stencil buffers
	renderer.Clear(0.2f, 0.2f, 0.2f, 1.0f);

	glUseProgram(m_uProgram);

	GLint position = glGetAttribLocation(m_uProgram, "position");
	glEnableVertexAttribArray(position);

	glVertexAttribPointer(position,
		3,
		GL_FLOAT,
		GL_FALSE,
		VERTEX::GetStride(),
		m_Quad);

	//set the uv attribute
	GLint uv = glGetAttribLocation(m_uProgram, "uv");
	glEnableVertexAttribArray(uv);
	glVertexAttribPointer(uv,
		2,
		GL_FLOAT,
		GL_FALSE,
		VERTEX::GetStride(),
		(float*)m_Quad + 3);


	auto r = GetOpenGLRenderer();

	glm::mat4 model(1.0f);


	glm::mat4 view = glm::lookAt(glm::vec3(0.0f, 0.0f, 1.0f),
		glm::vec3(0.0f),
		glm::vec3(0.0f, 1.0f, 0.0f));
	glm::mat4 projection = glm::perspective(1.5f, GetAspect(), 0.1f, 500.0f);

	glm::mat4 mvp = projection * view * model;
	r->SetUniformMatrix4(m_uProgram, "mvpMatrix", mvp);

	//set texture active
	r->SetTexture(m_uProgram, m_uTexture, 0, "texture01");

	glDrawArrays(GL_TRIANGLES, 0, 6);
}


bool TheApp::OnKeyDown(uint32_t keyCode)
{
	if (keyCode == KEY_ESC)
	{
		Close();
		return true;
	}

	return false;
}

