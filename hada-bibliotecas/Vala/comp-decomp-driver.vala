// -*- mode: vala -*-
/*
 *       comp-decomp-driver.vala
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

using CompDecomp;

int main(string[] args) {

	if (args.length != 3) {
		stdout.printf ("Uso: comp-decomp [-c|-d] cadena\n");
		return 1;
	} else if ( (args[1] != "-c") &&
				(args[1] != "-d") ) {
		stdout.printf("Uso: comp-decomp [-c|-d] cadena\n");

		return 2;
	}

	if (args[1] == "-c") {
		string c="";
		comprime (args[2], ref c);
		stdout.printf ("Compresion de \"%s\"(%d) es \"%s\"(%d)\n", args[2], args[2].length, c, c.length);
	}
	
	return 0;
}
