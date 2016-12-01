// -*- mode: vala -*-
/*
 *       comp.vala
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

namespace CompDecomp {
	private int caracteres_iguales (string s) {
		int l = 0;
		int cont = 1;

		l = s.length;
		if (l < 2)
			return l;
		else {
			int i = 1;
			while (s[0] == s[i++])
				cont++;
			return cont;
		}
	}

	public void comprime (string s, ref string cs) {
		int l = 0, cont = 0;
		string num, s2;

		l = s.length;
		if (l < 3) cs += s;
		else {
			cont = caracteres_iguales (s);
			if (cont > 2) {
				num = cont.to_string();
				cs += num;
				cs += s[0].to_string();
			} else {
				cs += string.nfill (cont, s[0]);
			}

			s2 = s[cont:s.length];
			comprime (s2, ref cs);
		}
	}
}
