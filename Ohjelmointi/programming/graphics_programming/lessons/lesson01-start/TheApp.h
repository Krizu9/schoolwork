/**
 * ============================================================================
 *  Name        : TheApp.h
 *  Part of     : Simple OpenGL graphics engine framework
 *  Description : the concrete application layer
 *  Version     : 1.00
 *	Author		: Jani Immonen, <realdashdev@gmail.com>
 * ============================================================================
**/

#pragma once

#include "../core/include/IApplication.h"
#include "../core/include/OpenGLRenderer.h"


struct VERTEX
{
	VERTEX() :
		x(0.0f), y(0.0f), z(0.0f),
		tu(0.0f), tv(0.0f)
	{
	}
	VERTEX(float _x, float _y, float _z) :
		x(_x), y(_y), z(_z),
		tu(0.0f), tv(0.0f)
	{
	}
	VERTEX(float _x, float _y, float _z, float _tu, float _tv) :
		x(_x), y(_y), z(_z),
		tu(_tu), tv(_tv)
	{
	}

	static constexpr int32_t GetStride() { return 20; }

	float x, y, z;
	float tu, tv;
};


class TheApp : public IApplication
{
public:
	TheApp();

	/**
	 * OnCreate
	 * app initializer, called by abstraction layer when engine initialization is complete
	 * @return true if successful, false otherwise.
	 */
	bool OnCreate() override;

	/**
	 * OnDestroy
	 * app destroyer, called by the abstraction layer when app is about to get destoyed
	 */
	void OnDestroy() override;

	/**
	 * OnUpdate
	 * app update loop
	 * @param fFrametime time since previous update, in seconds
	 */
	void OnUpdate(float frametime) override;

	/**
	 * OnDraw
	 * app drawing method
	 * @param renderer
	 */
	void OnDraw(IRenderer& renderer) override;

protected:
	/**
	 * OnKeyDown
	 * key down event
	 * @param keyCode key code
	 * @return true if event was handled by the receiver
	 */
	bool OnKeyDown(uint32_t keyCode) override;

private:
	/**
	 * GetOpenGLRenderer
	 * helper method to access the openGL renderer layer
	 * @return pointer to OpenGL renderer
	 */
	OpenGLRenderer* GetOpenGLRenderer() { return static_cast<OpenGLRenderer*>(GetRenderer()); }

private:
	// app data

	GLuint		m_uVertexShader;
	GLuint		m_uFragmentShader;
	GLuint		m_uProgram;

	GLuint		m_uTexture;

	VERTEX		m_Quad[6];
};

