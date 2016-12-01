
all: comp-decomp-driver

comp-decomp-driver : libcomp-decomp.so
	valac comp-decomp.vapi comp-decomp-driver.vala -X libcomp-decomp.so -X -I. -o $@

libcomp-decomp.so : comp.vala
	valac --library=comp-decomp -H comp-decomp.h comp.vala -X -fPIC -X -shared -o libcomp-decomp.so

###################
# Otros objetivos #
#################################################################

clean:
	rm -f *.o *~ comp-decomp-driver *.vapi *.h *.so *.a

.PHONY: clean

