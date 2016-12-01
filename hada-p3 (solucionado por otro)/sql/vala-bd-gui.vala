// -*- mode: vala -*-
/*
 *       vala-bd-gui.vala
 *
 *       Copyright 2013  HADA <hada@dlsi.ua.es>
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

using Gtk;

int main (string[] args) {
    Gtk.init (ref args);

    try {
		Hada.ClienteEN c = new Hada.ClienteEN ("Alfredo", 
											   "Calle La Mancha", 
											   "Toledo");

        var builder = new Builder ();
        builder.add_from_file ("vala-bd-gtk2.ui");

		var bdv = new Hada.BD_vista1 (builder);

        Gtk.main ();
    } catch (Error e) {
        stderr.printf ("Could not load UI: %s\n", e.message);
        return 1;
    }

    return 0;
}
