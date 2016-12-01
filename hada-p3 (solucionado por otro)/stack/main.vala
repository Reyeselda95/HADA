using Gtk;
using Hada;
int main (string[] args){
	
	Gtk.init(ref args);
	try{
		
		
		var constructor = new Builder(); // creamos constructor de tipo builder
		constructor.add_from_file("hada-p3.ui"); // le añadimos la interfaz creada con glade
		var pili = new Stack("pili");
		var vista = new Stack_vista(constructor);
		//var hola = new Stack_vista(constructor);
		//pili.add_view(vista);
		//pili.add_view(hola);
		Gtk.main (); //espera de eventos
		
	}
	catch(Error e){
		stderr.printf( " Could not load UI : %s \n " , e.message) ;
		return 1;
	}
	
	return 0 ;
}
