namespace Hada{
	
	using Gtk ;
	using Mvc;
	using Gee;
	
	class Stack_vista : GLib.Object , Mvc.View {
	
	Window ventana;
	Entry intro;
	Label ultimo;
	Label pila0 ;
	Label pila1 ;
	Label pila2 ;
	Label pila3 ;
	Label pila4 ;
	Label pila5 ;
	Label pila6 ;
	Label pila7 ;
	Label pila8 ;
	Label pila9 ;
	Stack c_pila;
	Button boton_push;
	Button boton_pop;
	int indice;
	
	
	public Stack_vista(Builder b){
		ventana = b.get_object("ventana1") as Window;
		intro = b.get_object("entry_push") as Entry ;
		ultimo = b.get_object("label_pop") as Label ;
		pila0 = b.get_object("label0") as Label ;
		pila1 = b.get_object("label1") as Label ;
		pila2 = b.get_object("label2") as Label ;
		pila3 = b.get_object("label3") as Label ;
		pila4 = b.get_object("label4") as Label ;
		pila5 = b.get_object("label5") as Label ;
		pila6 = b.get_object("label6") as Label ;
		pila7 = b.get_object("label7") as Label ;
		pila8 = b.get_object("label8") as Label ;
		pila9 = b.get_object("label9") as Label ;
		boton_push = b.get_object("button_push") as Button ;
		boton_pop = b.get_object("button_pop") as Button ;
		c_pila = new Stack("MyPila");
		indice = 0;
		
		b.connect_signals (this);
		ventana.destroy.connect (Gtk.main_quit);
		ventana.show_all ();
		
		
	}
	
	public void set_model (Model m){
		c_pila = m as Stack ;
		//actualizamos la vista desde su modelo
		update();
	}
	
	/**
	* Actualiza la vista desde el modelo
	*/
	public void update (){
		
		if(c_pila == null) return ;
		
		//int indi = c_pila.getindice()+1;
		
		int i = c_pila.getindice()+1;
		for(i=0;i<indice;i++)
		{
			
			switch (i) {
				
				case 0: pila0.set_label(c_pila.valor(i).to_string());
				break;
				case 1: pila1.set_label(c_pila.valor(i).to_string());
				break;
				case 2: pila2.set_label(c_pila.valor(i).to_string());
				break;
				case 3: pila3.set_label(c_pila.valor(i).to_string());
				break;
				case 4: pila4.set_label(c_pila.valor(i).to_string());
				break;
				case 5: pila5.set_label(c_pila.valor(i).to_string());
				break;
				case 6: pila6.set_label(c_pila.valor(i).to_string());
				break;
				case 7: pila7.set_label(c_pila.valor(i).to_string());
				break;
				case 8: pila8.set_label(c_pila.valor(i).to_string());
				break;
				case 9: pila9.set_label(c_pila.valor(i).to_string());
				break;
				default: stdout.printf("Error");
				break;
			}
			
		}
		
		
		for(int j=9;j>=indice;j--)
		{
			
			switch (j) {
				
				case 0: pila0.set_label("-");
				break;
				case 1: pila1.set_label("-");
				break;
				case 2: pila2.set_label("-");
				break;
				case 3: pila3.set_label("-");
				break;
				case 4: pila4.set_label("-");
				break;
				case 5: pila5.set_label("-");
				break;
				case 6: pila6.set_label("-");
				break;
				case 7: pila7.set_label("-");
				break;
				case 8: pila8.set_label("-");
				break;
				case 9: pila9.set_label("-");
				break;
				default: stdout.printf("Error");
				break;
			}
			
		}
		
		
}
	
	public void update_model (){
		
		if(c_pila == null) return ;
				
				if(pila0.get_label() != "-")
				c_pila.push(int.parse(pila0.get_label()));
				
				if(pila1.get_label() != "-")
				c_pila.push(int.parse(pila1.get_label()));
				
				if(pila2.get_label() != "-")
				c_pila.push(int.parse(pila2.get_label()));
						
				if(pila3.get_label() != "-")
				c_pila.push(int.parse(pila3.get_label()));
		
				if(pila4.get_label() != "-")
				c_pila.push(int.parse(pila4.get_label()));
				
				if(pila5.get_label() != "-")
				c_pila.push(int.parse(pila5.get_label()));
				
				if(pila6.get_label() != "-")
				c_pila.push(int.parse(pila6.get_label()));
				
				if(pila7.get_label() != "-")
				c_pila.push(int.parse(pila7.get_label()));
				
				if(pila8.get_label() != "-")
				c_pila.push(int.parse(pila8.get_label()));
				
				if(pila9.get_label() != "-")
				c_pila.push(int.parse(pila9.get_label()));
	}
	
	[CCode (instance_pos = -1)]
	public void push_clicked (Button boton) {
		
		c_pila.push(int.parse(intro.text));
		indice++;
		update();
	}
	
	[CCode (instance_pos = -1)]
	public void pop_clicked (Button boton){
		
		if(indice !=0)
		ultimo.set_label(c_pila.valor(indice-1).to_string());
		
		c_pila.pop();
		indice--;
		update();
	}
	
	
	
}//fin de la clase
	
}//fin del namespace
