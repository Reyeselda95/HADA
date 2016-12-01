

SRCS      = mvc-sample.vala model-view.vala mvc-main.vala
PROGRAM   = mvc-sample
VALACOPTS = --save-temps -g -X -w

# Para compilar con gtk-2 usa: "--pkg gtk+-2.0" abajo en lugar de "--pkg gtk+-3.0"
# Si al compilar tienes un error con la version de 'gee', usalo asi: --pkg gee-1.0
PKGS      = --pkg gtk+-3.0 --pkg gee-0.8 --pkg gmodule-2.0

all : $(PROGRAM) doc

$(PROGRAM) : $(SRCS)
	valac $(VALACOPTS) $(PKGS) $(SRCS) -o $@

doc:
	@echo Generando documentacion...
	@valadoc --force -o doc --vapidir /usr/share/vala-0.22/vapi/ $(PKGS) $(SRCS)
clean:
	rm -rf doc *.o *~ $(PROGRAM) *.c

.PHONY: clean doc
