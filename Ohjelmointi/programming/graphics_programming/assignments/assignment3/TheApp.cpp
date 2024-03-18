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
	m_uTexture = renderer->CreateTexture("white.png");
	if (!m_uVertexShader || !m_uFragmentShader || !m_uProgram || !m_uTexture)
	{
		return false;
	}

	// setup our view and projection matrices
	m_mView = glm::lookAt(
		glm::vec3(0.0f, 7.0f, 25.0f),
		glm::vec3(0.0f, 0.0f, 0.0f),
		glm::vec3(0.0f, 1.0f, 0.0f));
	m_mProjection = glm::perspective(0.7f, GetAspect(), 0.1f, 500.0f);

	// build the scenegraph
	m_pSceneRoot = std::make_unique<Node>();

	// TODO: build a tank
	// Base
	auto baseGeometry = std::make_shared<Geometry>();
	baseGeometry->GenCube(glm::vec3(9.0f, 1.0f, 7.0f));			//1. = leveys, 2. = korkeus, 3. = syvyys

	// turret
	auto turretGeometry = std::make_shared<Geometry>();
	turretGeometry->GenCube(glm::vec3(4.0f, 2.0f, 3.0f));		//1. = leveys, 2. = korkeus, 3. = syvyys

	// barrel
	auto barrelGeometry = std::make_shared<Geometry>();
	barrelGeometry->GenCube(glm::vec3(3.5f, 0.5f, 0.5f));		//1. = leveys, 2. = korkeus, 3. = syvyys

	// material
	auto material = std::make_shared<Material>();

	// nodes for parts
	auto baseNode = std::make_shared<GeometryNode>(baseGeometry, material);
	auto turretNode = std::make_shared<GeometryNode>(turretGeometry, material);
	auto barrelNode = std::make_shared<GeometryNode>(barrelGeometry, material);

	// set textures
	baseNode->SetTexture(0, m_uTexture);
	turretNode->SetTexture(0, m_uTexture);
	barrelNode->SetTexture(0, m_uTexture);
	
	// set positions
	baseNode->SetPos(0.0f, 0.0f, 0.0f);			//1. = sivuttais, 2. = korkeus, 3. = syvyys
	turretNode->SetPos(0.0f, 1.5f, 0.0f);		//1. = sivuttais, 2. = korkeus, 3. = syvyys
	barrelNode->SetPos(-2.5f, 0.0f, 0.0f);		//1. = sivuttais, 2. = korkeus, 3. = syvyys

	// nodes to sceneroot
	turretNode->AddNode(barrelNode);
	baseNode->AddNode(turretNode);
	m_pSceneRoot->AddNode(baseNode);

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
	const auto& nodes = m_pSceneRoot->GetNodes();
	auto baseNode = nodes[0];
	auto turretNode = baseNode->GetNodes()[0];
	auto barrelNode = turretNode->GetNodes()[0];

	glm::vec3 yaxis = glm::vec3(0.0f, 1.0f, 0.0f);
	glm::vec3 xaxis = glm::vec3(0.0f, 0.0f, 1.0f);

	baseNode->SetRotationAxis(yaxis);
	turretNode->SetRotationAxis(yaxis);
	

	baseNode->SetRotationSpeed(0.0f);
	turretNode->SetRotationSpeed(0.0f);
	barrelNode->SetRotationSpeed(0.0f);
	

	glm::vec3 forwardVector = baseNode->GetMatrix() * glm::vec4(-1.0f, 0.0f, 0.0f, 0.0f);
	forwardVector = glm::normalize(forwardVector);


	float rotationSpeed = 1.0f;
	float movementSpeed = 0.05f;

	if (IsKeyDown(KEY_UP) == true)
	{
		baseNode->SetPos(baseNode->GetPos() + forwardVector * movementSpeed);
	}
	
	if (IsKeyDown(KEY_DOWN) == true)
	{
		baseNode->SetPos(baseNode->GetPos() + forwardVector * -movementSpeed);
	}

	if (IsKeyDown(KEY_RIGHT) == true)
	{
		baseNode->SetRotationSpeed(-rotationSpeed);
	}

	if (IsKeyDown(KEY_LEFT) == true)
	{
		baseNode->SetRotationSpeed(rotationSpeed);
	}


	if (IsKeyDown('A'))
	{
		turretNode->SetRotationSpeed(rotationSpeed);
	}

	if (IsKeyDown('D'))
	{
		turretNode->SetRotationSpeed(-rotationSpeed);
	}

	float maxRotationAngle = glm::radians(20.0f);

	if (IsKeyDown('W'))
	{
		auto currentRotation = barrelNode->GetRotationAngle();
		auto rotate = currentRotation + 0.01f;

		if (rotate <= maxRotationAngle) {
				barrelNode->RotateAxisAngle(xaxis, rotate);
		}
	}
	if (IsKeyDown('S'))
	{
		auto currentRotation = barrelNode->GetRotationAngle();
		auto rotate = currentRotation - 0.01f;

		if (rotate >= -maxRotationAngle) {
				barrelNode->RotateAxisAngle(xaxis, rotate);
		}
	}


	// update scenegraph
	if (m_pSceneRoot)
	{
		m_pSceneRoot->Update(frametime);

	}
}


void TheApp::OnDraw(IRenderer& renderer)
{
	// clear color, depth and stencil buffers
	renderer.Clear(0.2f, 0.2f, 0.2f, 1.0f);

	// set view and projection into the renderer
	GetRenderer()->SetViewMatrix(m_mView);
	GetRenderer()->SetProjectionMatrix(m_mProjection);

	// setup the rendering of our quad
	glUseProgram(m_uProgram);

	// set the texture for the quad (slot 0)
	renderer.SetTexture(m_uProgram, m_uTexture, 0, "texture01");

	// setup the light position (to camera position)
	const glm::vec3 campos(-renderer.GetViewMatrix()[3]);
	OpenGLRenderer::SetUniformVec3(m_uProgram, "lightPosition", campos);

	// setup the camera position uniform
	OpenGLRenderer::SetUniformVec3(m_uProgram, "cameraPosition", campos);

	// draw the scenegraph
	if (m_pSceneRoot)
	{
		m_pSceneRoot->Render(renderer, m_uProgram);
	}
}


void TheApp::OnScreenSizeChanged(uint32_t widthPixels, uint32_t heightPixels)
{
	m_mProjection = glm::perspective(0.7f, GetAspect(), 0.1f, 500.0f);
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

