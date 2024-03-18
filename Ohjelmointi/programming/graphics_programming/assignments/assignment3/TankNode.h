#pragma once
#include "../core/include/Node.h"
class TankNode :
    public Node
{
public:
    static void Setup(IRenderer& renderer,
        GLuint program,
        GLuint texture,
        float* vertexData,
        int32_t vertexStride);

    void Render(IRenderer& renderer, GLuint program) override;
};

