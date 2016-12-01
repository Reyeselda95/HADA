using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InariPlaysLibrary.CAD;


namespace InariPlaysLibrary.EN
{
    public class AdministradorEN{
    
        // Propiedades de cada adminstrador
            private int id;

            private string nombre;

            private string apellidos;

            private string password;

        //getters y setters
            public virtual int Id
            {
                get { return id; }
                set { id = value; }
            }

            public virtual string Nombre
            {
                get { return nombre; }
                set { nombre = value; }
            }

            public virtual string Apellidos
            {
                get { return apellidos; }
                set { apellidos = value; }
            }

            public virtual string Password
            {
                get { return password; }
                set { password = value; }
            }

        //inicializadores
            public AdministradorEN() { }

            public AdministradorEN(int id, string nom, string ape, string pas)
            {
                this.init(id, nom, ape, pas);
            }
        //constructor de copia
            public AdministradorEN(AdministradorEN admin)
            {
                this.init(admin.Id, admin.Nombre, admin.Apellidos, admin.Password);
            }

            private void init(int id, string nombre, string apellidos, string password)
            {
                this.Id = id;


                this.Nombre = nombre;

                this.Apellidos = apellidos;

                this.Password = password;
            }

        //funcion equals oara la comparacin de objetos del mismo tipo
            public override bool Equals(object obj)
            {
                if (obj == null)
                    return false;
                AdministradorEN t = obj as AdministradorEN;
                if (t == null)
                    return false;
                if (Id.Equals(t.Id))
                    return true;
                else
                    return false;
            }

        //obtener hash code 
            public override int GetHashCode()
            {
                int hash = 13;

                hash += this.Id.GetHashCode();
                return hash;
            }

        //funcion que lista todos los admin
            public AdministradorEN[] dameTodosAdmin() {
                return AdministradorCAD.dameTodosAdmin();
            }

        //comprueba si un usuario es administrador
            public bool esAdmin() {
                return AdministradorCAD.esAdmin(this.nombre, this.Password);
            }
        //inserta y actualiza conun nuevo admin
            public bool insertarActualizarAdmin() {
                AdministradorCAD admin = new AdministradorCAD(this);
                return admin.insertarActualizarAdmin();
            }
        //borra un administrador
            public bool borrarAdmin()
            {
                AdministradorCAD admin = new AdministradorCAD(this);
                return admin.borrarAdmin();
            }
    }
}
