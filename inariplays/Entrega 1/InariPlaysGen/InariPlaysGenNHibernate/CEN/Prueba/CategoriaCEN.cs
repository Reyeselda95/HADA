

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using InariPlaysGenNHibernate.EN.Prueba;
using InariPlaysGenNHibernate.CAD.Prueba;

namespace InariPlaysGenNHibernate.CEN.Prueba
{
public partial class CategoriaCEN
{
private ICategoriaCAD _ICategoriaCAD;

public CategoriaCEN()
{
        this._ICategoriaCAD = new CategoriaCAD ();
}

public CategoriaCEN(ICategoriaCAD _ICategoriaCAD)
{
        this._ICategoriaCAD = _ICategoriaCAD;
}

public ICategoriaCAD get_ICategoriaCAD ()
{
        return this._ICategoriaCAD;
}

public int Crear (int p_categoriaID, string p_nombre, string p_descripcion)
{
        CategoriaEN categoriaEN = null;
        int oid;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.CategoriaID = p_categoriaID;

        categoriaEN.Nombre = p_nombre;

        categoriaEN.Descripcion = p_descripcion;

        //Call to CategoriaCAD

        oid = _ICategoriaCAD.Crear (categoriaEN);
        return oid;
}

public void Borrar (int categoriaID)
{
        _ICategoriaCAD.Borrar (categoriaID);
}

public void Modificar (int p_Categoria_OID, string p_nombre, string p_descripcion)
{
        CategoriaEN categoriaEN = null;

        //Initialized CategoriaEN
        categoriaEN = new CategoriaEN ();
        categoriaEN.CategoriaID = p_Categoria_OID;
        categoriaEN.Nombre = p_nombre;
        categoriaEN.Descripcion = p_descripcion;
        //Call to CategoriaCAD

        _ICategoriaCAD.Modificar (categoriaEN);
}
}
}
