namespace Hada{
	
class Stack : Mvc.Model {
	
	private string nombre ;
	public const int max = 10 ; //numero de elementos de la pila
	public const int kERROR = -100;
	private int[] pila = {} ;
	private int indice = -1;
	
	public Stack (string nombre) {
		this.nombre = nombre ;
		this.stack_underflow.connect(on_underflow);
		this.stack_overflow.connect(on_overflow);
	}
	
	public void push (int num) {
		
		if(pila.length < 10) {
		//stdout.printf(pila.length.to_string());
		pila+= num;
		indice++;
		}
		else
		stack_overflow(this.nombre,indice);
		
	}
	
	public int pop () {
		
		int dev;
		
		if(pila.length > 0) {
			indice--;
			dev = pila[pila.length] ;
			//stdout.printf("\nAntes de redimensionar : ");
			//stdout.printf(pila.length.to_string());
			pila.resize(pila.length-1);
			//stdout.printf("\nDespues de redimensionar : ");
			//stdout.printf(pila.length.to_string());
		}
		else {
			stack_underflow(this.nombre,indice);
			dev = kERROR ;
		}
		
		return dev ;
	}
	
	public int getindice(){
	
	return indice;
}

public int valor(int num){
	
	return this.pila[num] ;
}
	
	public signal void stack_underflow (string nombre,int indice);
	public signal void stack_overflow (string nombre,int indice);
}

public void on_overflow(string nombre, int index) {
		stdout.printf("Stack overflow " + nombre + " index = ");
		stdout.printf("%d",index);
		stdout.printf(" \n");
}

public void on_underflow (string nombre, int index) {
		stdout.printf("Stack underflow " + nombre + " index = ");
		stdout.printf("%d",index);
		stdout.printf(" \n");
}


}//fin namespace
