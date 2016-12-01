
all: comp-decomp comp-decomp-estatico comp-decomp-dinamico vala

######################
# Version monolitica #
#################################################################
comp-decomp: comp-decomp.o
	$(CC) $(LDFLAGS) comp-decomp.o -o $@

comp-decomp.o: comp-decomp.c
	$(CC) -c $(CFLAGS) comp-decomp.c 


#######################
# Biblioteca estatica #
#################################################################
comp-decomp-estatico: comp-decomp-driver.o libcomp-decomp.a
	$(CC) -static comp-decomp-driver.o -L . -lcomp-decomp -o comp-decomp-estatico

comp-decomp-driver.o: comp-decomp-driver.c
	$(CC) -c $(CFLAGS) comp-decomp-driver.c

libcomp-decomp.a: comp.o decomp.o
	$(AR) crs libcomp-decomp.a comp.o decomp.o

comp.o: comp.c 
	$(CC) -c $(CFLAGS) comp.c 

decomp.o: decomp.c 
	$(CC) -c $(CFLAGS) decomp.c 

##################################
# Bibliotecea de enlace dinamico #
#################################################################
comp-decomp-dinamico: comp-decomp-driverdin.o libcomp-decomp.so
	$(CC) comp-decomp-driverdin.o -L . -lcomp-decomp -o comp-decomp-dinamico

comp-decomp-driverdin.o: comp-decomp-driverdin.c
	$(CC) -fpic -c $(CFLAGS) comp-decomp-driverdin.c

libcomp-decomp.so: comp-pic.o decomp-pic.o
	$(CC) -shared -o libcomp-decomp.so comp-pic.o decomp-pic.o

comp-pic.o: comp.c 
	$(CC) -c -o comp-pic.o -fpic $(CFLAGS) comp.c 

decomp-pic.o: decomp.c 
	$(CC) -c -o decomp-pic.o -fpic $(CFLAGS) decomp.c 

###################
# Otros objetivos #
#################################################################
vala:
	cd Vala; make

dist: clean
	cd ..; \
	tar cfz hada-bibliotecas.tgz hada-bibliotecas; \
	mv hada-bibliotecas.tgz hada-bibliotecas

clean:
	rm -f *.o *~ comp-decomp comp-decomp-driver comp-decomp-estatico comp-decomp-dinamico *.so *.a
	cd Vala; make clean

.PHONY: clean dist vala

