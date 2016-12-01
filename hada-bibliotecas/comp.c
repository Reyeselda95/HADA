// -*- mode: c++ -*-
/*
 *       comp-decomp.c
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

static int caracteres_iguales (char* s) {
  int l = 0;
  int cont = 1;

  if (s == NULL)
    return 0;

  l = strlen (s);
  if (l < 2)
    return l;
  else {
    int i = 1;
    while (s[0] == s[i++])
      cont++;
    return cont;
  }
}

/**
 * Devuelve en 'cs' la cadena comprimida de 's'.
 */
void comprime (char* s, char* cs) {
  int l = 0;
  int cont = 0;
  char num[5];
  int i;
  char* s2;

  if (s == NULL)
    return;

  l = strlen (s);
  if (l < 3)
    strcat (cs, s);
  else {
    int csl = 0;
    cont = caracteres_iguales (s);
    if (cont > 2) {
      sprintf (num, "%d", cont);

      strcat (cs, num);
      csl = strlen(cs);
      cs[csl++] = s[0];
      cs[csl] = '\0';
    } else {
      csl = strlen(cs);
      for (i = 0; i < cont; i++)
	cs[csl++] = s[0];
      cs[csl] = '\0';
    }

    s2 = &s[cont];
    comprime (s2, cs);
  }
}
