using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InariPlaysLibrary.EN
{
    public class AdministradorEN
    {
            private int id;

            private string nombre;

            private string apellidos;

            private string password;

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

            public AdministradorEN() { }

            public AdministradorEN(int id, string nom, string ape, string pas)
            {
                this.init(id, nom, ape, pas);
            }

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

            public override int GetHashCode()
            {
                int hash = 13;

                hash += this.Id.GetHashCode();
                return hash;
            }
    }
}
