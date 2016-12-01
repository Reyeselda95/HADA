
// -*- mode: vala -*-
/*
 *       mv-sample.vala
 *
 *       Copyright 2012 hada dlsi.ua.es
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

////////////////
// La Vista 1 //
////////////////

/**
 * Persona_vista1: Vista que permite modificar el modelo.
 */
public class Persona_vista1 : GLib.Object, View {
	/**
	 * Constructor a partir de un Gtk.Builder para cargar el interfaz.
	 */
	public Persona_vista1 (Builder b) {
		m_window         = b.get_object ("ventana1")        as Window;
		m_entry_nombre   = b.get_object ("entry_nombre")    as Entry;
		m_sb_edad        = b.get_object ("spinbutton_edad") as SpinButton;
		m_button_cambiar = b.get_object ("button_cambiar")  as Button;

		b.connect_signals (this);
		m_window.destroy.connect (Gtk.main_quit);
		m_window.show_all ();
	}

	/**
	 * Método callback invocado cuando el usuario pulsa el botón 'cambiar'.
	 */
	[CCode (instance_pos = -1)]
	public void on_button_cambiar_clicked (Button source) {
		stdout.printf ("Cambiar el modelo y las vistas\n");
		update_model ();
	}

	/**
	 * Setter para el modelo de esta vista.
	 */
	public void set_model (Model m) { 
		m_modelo = m as Persona_modelo; 
		// Actualizamos la vista desde su modelo
		update ();
	}
	/**
	 * Actualizamos la vista desde el modelo.
	 */
	public void update () {
		string new_name = m_modelo.get_name ();
		int    new_age  = m_modelo.get_age ();

		m_sb_edad.value = new_age;
		m_entry_nombre.text = new_name;
	}
    /**
	 * Actualizamos el modelo desde la vista
	 */
	public void update_model () {
		m_modelo.set_name (m_entry_nombre.text);
		m_modelo.set_age ( (int)m_sb_edad.value );

		m_modelo.notify_views ();
	}

	//-- Datos ---------------------------------
	Window          m_window;
	Entry           m_entry_nombre;
	SpinButton      m_sb_edad;
	Button          m_button_cambiar;
	Persona_modelo  m_modelo;
}

////////////////
// La Vista 2 //
////////////////

/**
 * Persona_vista2: Vista que permite solo consultar el modelo.
 */
public class Persona_vista2 : GLib.Object, View {
	public Persona_vista2 (Builder b) {
		m_window         = b.get_object ("ventana2")        as Window;
		m_label_nombre   = b.get_object ("label_nombre")    as Label;
		m_label_edad     = b.get_object ("label_edad")      as Label;

		m_window.destroy.connect (Gtk.main_quit);
		m_window.show_all ();
	}

	public void set_model (Model m) { 
		m_modelo = m as Persona_modelo; 
		// Actualizamos la vista desde su modelo
		update ();
	}
	public void update () {
		// Actualizamos la vista desde el modelo.
		string new_name = m_modelo.get_name ();
		int    new_age  = m_modelo.get_age ();

		m_label_edad.label   = new_age.to_string();
		m_label_nombre.label = new_name;
	}

	public void update_model () {
		// Actualizamos el modelo desde la vista
	}

	//-- Datos ---------------------------------
	Window          m_window;
	Label           m_label_nombre;
	Label           m_label_edad;
	Persona_modelo  m_modelo;
}

///////////////
// El Modelo //
///////////////
/**
 * Persona_modelo: El modelo de una Persona.
 */
public class Persona_modelo : Model {
	public Persona_modelo (string n, int e) {
		m_name = n;
		m_age  = e;
	}

	public void set_name (string n) { m_name=n; }
	public string get_name () { return m_name; }
	public void set_age (int e) { m_age=e; }
	public int get_age () { return m_age; }

	//-- Data -------------------------------------
	private string m_name;
	private int m_age;
 }
