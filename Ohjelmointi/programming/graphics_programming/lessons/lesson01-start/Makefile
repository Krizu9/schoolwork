CC=g++
CFLAGS=-c -D_LINUX -std=c++17
LDFLAGS=
SOURCES=../core/src/IApplication_linux.cpp ../core/src/OpenGLRenderer.cpp ../core/src/Material.cpp ../core/src/Timer.cpp main.cpp TheApp.cpp
OBJECTS=$(SOURCES:.cpp=.o)
EXECUTABLE=lesson01
INCLUDE=
LIBS =  -L /usr/X11R6/lib/ -lGL -lGLU -lX11 -lXi -lm
all: $(SOURCES) $(EXECUTABLE)

$(EXECUTABLE): $(OBJECTS)
	$(CC) $(LDFLAGS) $(OBJECTS) -o $@ $(LIBS)

.cpp.o:
	$(CC) $(CFLAGS) $< -o $(INCLUDE) $@

clean:
	rm -f *.o
	rm -f $(EXECUTABLE)
