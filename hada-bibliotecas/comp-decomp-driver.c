// -*- mode: c++ -*-
/*
 *       comp-decomp-driver.c
 *
 *       Copyright 2012 Antonio-Miguel Corbi Bellot <antonio.corbi@ua.es>
 *     
 *       This program is free software; you can redistribute it and/or modify
 *       it under the terms of the GNU  General Public License as published by
 *       the Free Software Foundation; either version 3 of the License, or
 *       (at your option) any later version.
 *     
 *       This program is distributed in the hope that it will be useful,
 *       but WITHOUT ANY WARRANTY; without even the implied warranty of
 *       MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 *       GNU General Public License for more details.
 *      
 *       You should have received a copy of the GNU General Public License
 *       along with this program; if not, write to the Free Software
 *       Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston,
 *       MA 02110-1301, USA.
 */

#include <stdio.h>
#include <stdlib.h>
#include <string.h>

#include "comp.h"
#include "decomp.h"


int main(int argc, char *argv[])
{
  char c[100];

  if (argc != 3) {
    printf("Uso: comp-decomp [-c|-d] cadena\n");
    return 1;
  } else if ( (strcmp(argv[1],"-c") != 0) &&
	      (strcmp(argv[1],"-d") != 0) ) {
    printf("Uso: comp-decomp [-c|-d] cadena\n");

    return 2;
  }

  /*printf("caracteres iguales en \"%s\" = %d \n", argv[2], caracteres_iguales (argv[2]));*/

  if (strcmp(argv[1],"-c") == 0) {
    c[0] = '\0';
    comprime (argv[2], c);
    printf ("Compresion de \"%s\"(%d) es \"%s\"(%d)\n", argv[2], strlen(argv[2]), c, strlen(c));
  }
  if (strcmp(argv[1],"-d") == 0) {
    c[0] = '\0';
    descomprime (argv[2], c);
    printf ("Descompresion de \"%s\"(%d) es \"%s\"(%d)\n", argv[2], strlen(argv[2]), c, strlen(c));
  }

  return 0;
}
