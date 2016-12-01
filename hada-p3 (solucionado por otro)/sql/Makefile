
#
# Makefile para la segunda parte de la practica-3.
# Hada 2012-2013
#

PKGS=--pkg gee-1.0 --pkg gtk+-2.0 --pkg sqlite3 --pkg gmodule-2.0
OPTS=--disable-warnings -X -w

all : vbd crea-bd

vbd : $(wildcard *.vala)
	@echo Compilando...
	@valac $(OPTS) $(PKGS) $^ -o vbd

crea-bd :
	@echo Recreamos la base de datos de prueba...
	@sh ./create-db.sh

clean:
	@echo Borrando ficheros...
	@rm -f vbd hadadb *~
