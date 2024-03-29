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
	m_uTexture(0)
{
	// seed the random number generator
	RandSeed();
}


bool TheApp::OnCreate()
{
	// OnCreate is called by the application when window and graphics initialization is complete
	auto renderer = GetOpenGLRenderer();
	m_uVertexShader = renderer->CreateVertexShaderFromFile("phongshader.vert");
	m_uFragmentShader = renderer->CreateFragmentShaderFromFile("phongshader.frag");
	m_uProgram = renderer->CreateProgram(m_uVertexShader, m_uFragmentShader);
	m_uTexture = renderer->CreateTexture("earth.jpg");
	if (!m_uVertexShader || !m_uFragmentShader || !m_uProgram || !m_uTexture)
	{
		return false;
	}

	// setup our view and projection matrices
	const glm::mat4 view = glm::lookAt(
		glm::vec3(0.0f, 0.0f, 32.0f),
		glm::vec3(0.0f, 0.0f, 0.0f),
		glm::vec3(0.0f, 1.0f, 0.0f));

	const glm::mat4 projection = glm::perspective(0.61f, GetAspect(), 1.0f, 500.0f);

	// set them into the renderer
	GetRenderer()->SetViewMatrix(view);
	GetRenderer()->SetProjectionMatrix(projection);

	// generate a sphere
	constexpr float radius = 2.0f;
	m_pGeometry = std::make_shared<Geometry>();
	m_pGeometry->GenSphere(glm::vec3(radius));

	// create the material
	m_pMaterial = std::make_shared<Material>();
	m_pMaterial->m_cAmbient = glm::vec4(0.1f, 0.1f, 0.1f, 1.0f);
	m_pMaterial->m_cDiffuse = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);
	m_pMaterial->m_cSpecular = glm::vec4(1.0f, 1.0f, 1.0f, 1.0f);
	m_pMaterial->m_cEmissive = glm::vec4(0.0f, 0.0f, 0.0f, 1.0f);
	m_pMaterial->m_fSpecularPower = 25.0f;

	// build scenegraph
	m_pSceneRoot = std::make_unique<Node>();

	for (size_t i = 0; i < 25; ++i)
	{
		auto object = std::make_shared<GeometryNode>(m_pGeometry, m_pMaterial);
		object->SetTexture(0, m_uTexture);

		object->SetPos(glm::vec3(glm::linearRand(-10.0f, 10.0f),
			glm::linearRand(-10.0f, 10.0f),
			glm::linearRand(-10.0f, 10.0f)));

		object->SetRotationAxis(glm::vec3(0.0f, 1.0f, 0.0f));
		object->SetRotationSpeed(glm::linearRand(-4.0f, 4.0f));

		m_pSceneRoot->AddNode(object);
	}
	m_pSceneRoot->SetRotationAxis(glm::vec3(0.0f, 1.0f, 0.0f));
	m_pSceneRoot->SetRotationSpeed(0.1f);

	return true;
}


void TheApp::OnDestroy()
{
	// app is about to close, clear all resources
	m_pSceneRoot = nullptr;

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
	if (m_pSceneRoot)
	{
		m_pSceneRoot->Update(frametime);
	}
}


void TheApp::OnDraw(IRenderer& renderer)
{
	// clear depth and stencil buffers
	renderer.Clear(0.2f, 0.2f, 0.2f, 1.0f);

	// render the sphere
	glUseProgram(m_uProgram);

	if (m_pSceneRoot)
	{
		m_pSceneRoot->Render(renderer, m_uProgram);
	}
}


void TheApp::OnScreenSizeChanged(uint32_t widthPixels, uint32_t heightPixels)
{
	const glm::mat4 projection = glm::perspective(0.61f, GetAspect(), 1.0f, 500.0f);
	GetRenderer()->SetProjectionMatrix(projection);
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

